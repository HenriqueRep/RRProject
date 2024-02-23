using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RRProject.Web;
using RRProject.Web.Interfaces;
using RRProject.Web.Services;
using System.IdentityModel.Tokens.Jwt;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var host = builder.Build();
_ = new JwtHeader();
_ = new JwtPayload();

builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("Permissão", policy => policy.RequireClaim("sucesso", "true"));
});

var baseUrl = "https://localhost:7102";

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });
builder.Services.AddScoped<ICandidataService, CandidataService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<IAvaliacaoUsuarioService, AvaliacaoUsuarioService>();




await builder.Build().RunAsync();
