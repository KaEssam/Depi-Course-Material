using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Auth.OAuth2.Requests;

namespace YourProject.Services
{
    public class GoogleMeetService
    {
        private CalendarService? _calendarService;
        private readonly IConfiguration _configuration;

        public GoogleMeetService(IConfiguration configuration)
        {
            _configuration = configuration;
            InitializeCalendarService();
        }

        private void InitializeCalendarService()
        {
            try
            {
                // For server-side applications, it's better to use a service account
                // But for this demo, we'll use a simpler approach with a fixed redirect URI

                // Path to credentials file
                var credentialsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "credentials.json");

                // If credentials file doesn't exist, create it from appsettings
                if (!File.Exists(credentialsPath))
                {
                    CreateCredentialsFile(credentialsPath);
                }

                using (var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
                {
                    var secrets = GoogleClientSecrets.FromStream(stream).Secrets;

                    // Get the redirect URI from configuration
                    var redirectUri = _configuration["web:redirect_uris:0"] ?? "http://localhost:5027/authorize/"; // Get first redirect URI with fallback

                    // Create the authorization code flow with fixed redirect URI
                    var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                    {
                        ClientSecrets = secrets,
                        Scopes = new[] { CalendarService.Scope.Calendar },
                        DataStore = new FileDataStore(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "token.json"), true)
                    });

                    // Create a custom code receiver with the configured port
                    var codeReceiver = new FixedPortCodeReceiver(redirectUri);
                    var authorizationCodeInstalledApp = new AuthorizationCodeInstalledApp(flow, codeReceiver);

                    // Authorize
                    var credential = authorizationCodeInstalledApp.AuthorizeAsync("user", CancellationToken.None).Result;

                    _calendarService = new CalendarService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "GoogleMeet API Integration"
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to initialize Google Calendar service: {ex.Message}", ex);
            }
        }

        private void CreateCredentialsFile(string credentialsPath)
        {
            var clientId = _configuration["web:client_id"];
            var clientSecret = _configuration["web:client_secret"];
            var projectId = _configuration["web:project_id"];
            var authUri = _configuration["web:auth_uri"];
            var tokenUri = _configuration["web:token_uri"];
            var authProviderX509CertUrl = _configuration["web:auth_provider_x509_cert_url"];
            var redirectUris = _configuration.GetSection("web:redirect_uris").Get<string[]>();

            var credentials = new
            {
                installed = new
                {
                    client_id = clientId,
                    project_id = projectId,
                    auth_uri = authUri,
                    token_uri = tokenUri,
                    auth_provider_x509_cert_url = authProviderX509CertUrl,
                    client_secret = clientSecret,
                    redirect_uris = redirectUris
                }
            };

            var json = System.Text.Json.JsonSerializer.Serialize(credentials, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(credentialsPath, json);
        }

        public async Task<string> CreateGoogleMeet()
        {
            try
            {
                if (_calendarService == null)
                {
                    InitializeCalendarService();
                }

                var ev = new Event()
                {
                    Summary = "API Generated Meet",
                    Description = "Google Meet created from .NET Core API",
                    Start = new EventDateTime()
                    {
                        DateTimeRaw = DateTime.UtcNow.AddMinutes(5).ToString("yyyy-MM-dd'T'HH:mm:ss.fffK"),
                        TimeZone = "UTC"
                    },
                    End = new EventDateTime()
                    {
                        DateTimeRaw = DateTime.UtcNow.AddMinutes(35).ToString("yyyy-MM-dd'T'HH:mm:ss.fffK"),
                        TimeZone = "UTC"
                    },
                    ConferenceData = new ConferenceData()
                    {
                        CreateRequest = new CreateConferenceRequest()
                        {
                            RequestId = Guid.NewGuid().ToString(),
                            ConferenceSolutionKey = new ConferenceSolutionKey()
                            {
                                Type = "hangoutsMeet"
                            }
                        }
                    }
                };

                var request = _calendarService!.Events.Insert(ev, "primary");
                request.ConferenceDataVersion = 1;

                var createdEvent = await request.ExecuteAsync();

                return createdEvent.HangoutLink ?? string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create Google Meet: {ex.Message}", ex);
            }
        }
    }

    // Custom code receiver that uses a fixed port
    public class FixedPortCodeReceiver : ICodeReceiver
    {
        private readonly string _redirectUri;
        private HttpListener? _listener;

        public FixedPortCodeReceiver(string redirectUri)
        {
            _redirectUri = redirectUri;
        }

        public string RedirectUri
        {
            get { return _redirectUri; }
        }

        public async Task<AuthorizationCodeResponseUrl> ReceiveCodeAsync(AuthorizationCodeRequestUrl authorizationCodeRequestUrl, CancellationToken taskCancellationToken)
        {
            // Extract the port from the redirect URI
            var uri = new Uri(_redirectUri);
            var port = uri.Port;
            var host = uri.Host;

            // Start the HTTP listener
            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://{host}:{port}/");
            _listener.Start();

            // Open the browser for authorization
            Process.Start(new ProcessStartInfo
            {
                FileName = authorizationCodeRequestUrl.Build().ToString(),
                UseShellExecute = true
            });

            // Wait for the callback
            var context = await _listener.GetContextAsync();
            var request = context.Request;
            var response = context.Response;

            // Extract the authorization code from the request
            var code = request.QueryString["code"];
            var error = request.QueryString["error"];
            var state = request.QueryString["state"];

            // Send a response to the browser
            var responseString = "<html><head><title>Authentication Complete</title></head><body>You can close this window now.</body></html>";
            var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            response.OutputStream.Close();

            // Stop the listener
            _listener.Stop();

            // Return the authorization code response
            if (!string.IsNullOrEmpty(error))
            {
                throw new Exception($"Authorization failed: {error}");
            }

            return new AuthorizationCodeResponseUrl
            {
                Code = code,
                State = state
            };
        }
    }
}
