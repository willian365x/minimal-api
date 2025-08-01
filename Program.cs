using MinimalApi.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (LoginDTO login) =>
{
    if (login.Email == "admin@test.com" && login.Senha == "123456")
    {
        return Results.Ok("Login efetuado com sucesso na API");
    }
    else
    {
        return Results.Unauthorized();
    }
});

app.Run();
