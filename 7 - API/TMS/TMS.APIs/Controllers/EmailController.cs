using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Microsoft.Extensions.Configuration;

namespace TMS.APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            try
            {
                var smtpSettings = _configuration.GetSection("SmtpSettings");

                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(
                    smtpSettings["SenderName"],
                    smtpSettings["SenderEmail"]
                ));
                email.To.Add(MailboxAddress.Parse(request.ToEmail));
                email.Subject = request.Subject;

                var builder = new BodyBuilder
                {
                    HtmlBody = request.Message
                };
                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(
                    smtpSettings["Server"],
                    int.Parse(smtpSettings["Port"]!),
                    SecureSocketOptions.StartTls
                );
                await smtp.AuthenticateAsync(
                    smtpSettings["Username"],
                    smtpSettings["Password"]
                );
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return Ok(new { Message = "Email sent successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Failed to send email", Error = ex.Message });
            }
        }

        [HttpPost("send-with-attachment")]
        public async Task<IActionResult> SendEmailWithAttachment([FromForm] EmailWithAttachmentRequest request)
        {
            try
            {
                var smtpSettings = _configuration.GetSection("SmtpSettings");

                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(
                    smtpSettings["SenderName"],
                    smtpSettings["SenderEmail"]
                ));
                email.To.Add(MailboxAddress.Parse(request.ToEmail));
                email.Subject = request.Subject;

                var builder = new BodyBuilder
                {
                    HtmlBody = request.Message
                };

                if (request.Attachment != null && request.Attachment.Length > 0)
                {
                    using var memoryStream = new MemoryStream();
                    await request.Attachment.CopyToAsync(memoryStream);
                    builder.Attachments.Add(request.Attachment.FileName, memoryStream.ToArray());
                }

                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(
                    smtpSettings["Server"],
                    int.Parse(smtpSettings["Port"]!),
                    SecureSocketOptions.StartTls
                );
                await smtp.AuthenticateAsync(
                    smtpSettings["Username"],
                    smtpSettings["Password"]
                );
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return Ok(new { Message = "Email with attachment sent successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Failed to send email", Error = ex.Message });
            }
        }

        [HttpPost("test")]
        public async Task<IActionResult> TestEmail()
        {
            try
            {
                var smtpSettings = _configuration.GetSection("SmtpSettings");

                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(
                    smtpSettings["SenderName"],
                    smtpSettings["SenderEmail"]
                ));
                email.To.Add(MailboxAddress.Parse("kaessam@hotmail.com"));
                email.Subject = "Test Email from TMS";

                var builder = new BodyBuilder
                {
                    HtmlBody = "<h1>Test Email</h1><p>This is a test email from TMS.</p>"
                };
                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(
                    smtpSettings["Server"],
                    int.Parse(smtpSettings["Port"]!),
                    SecureSocketOptions.StartTls
                );
                await smtp.AuthenticateAsync(
                    smtpSettings["Username"],
                    smtpSettings["Password"]
                );
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return Ok(new { Message = "Test email sent successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Failed to send test email", Error = ex.Message });
            }
        }
    }

    public class EmailRequest
    {
        public string ToEmail { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }

    public class EmailWithAttachmentRequest
    {
        public string ToEmail { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public IFormFile? Attachment { get; set; }
    }
}