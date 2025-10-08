using Middelware.ExtensionMethods;
using Middelware.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<TimeResponseMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<TimeResponseMiddleware>();

app.TimeResonse();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.Use(async (context, next) =>
//{
//    Console.WriteLine($"req: {context.Request.Method}");
//    await next();
//    Console.WriteLine($"res status: {context.Response.StatusCode}");
//});

//app.UseMiddleware<LogMiddleware>();

app.useLog();


app.Use(async (context, next) =>
{
    Console.WriteLine("Hello from custom middleware 2");
    await next();
    Console.WriteLine("middleware 2 done");
});



app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello world!");
});

//app.MapGet("/", () => Console.WriteLine("hello"));


app.Run();

//app.Use(async (context, next) =>
//{
//    Console.WriteLine("Hello from custom middleware 3");
//    await next();
//    Console.WriteLine("middleware 3 done");
//});