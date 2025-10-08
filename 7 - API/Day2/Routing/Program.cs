using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/",()=> "welcome to api");
app.MapGet("/hello/hi",()=> "hi");


//// /user/karim
//app.MapGet("/user/{name:alpha}", (string name) => $"user name: {name}"); //route paramters
//app.MapGet("/user/{age:int}", (int age) => $"user name: {age}"); //route paramters

//// /user?name=baraa&age=23
//app.MapGet("/user", (int age, string? name) => $"user name: {name ?? "GUEST"}, age: {age}");// query string 

// //body binding
//app.MapPost("/product", (product p) =>
//{
//    return $"product Name: {p.name}, price: {p.price}";
//});



//app.MapPost("/product", ([FromForm]product p) =>
//{
//    return $"product Name: {p.name}, price: {p.price}";
//});

//app.MapPost("/productImg", ([FromForm] IFormFile file) =>
//{
//    return Results.Ok(new {fileName = file.FileName});
//});


app.Run();

record product ( string name, decimal price);
