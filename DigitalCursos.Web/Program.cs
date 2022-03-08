using DigitalCursos.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DigitalCursos.Web.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DigitalCursosWebContextConnection");builder.Services.AddDbContext<DigitalCursosWebContext>(options =>
    options.UseSqlServer(connectionString));builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DigitalCursosWebContext>();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAuthentication("Identity.Application")
    .AddCookie();

builder.Services.AddHttpClient<IAlunoService, AlunoService>
    (
    client =>
        {
            client.BaseAddress = new Uri("https://localhost:7270");
            client.DefaultRequestHeaders.Add("Accept", "application/+json");
        }
    );
builder.Services.AddHttpClient<ICursoService, CursoService>
    (
    client =>
    {
        client.BaseAddress = new Uri("https://localhost:7270");
        client.DefaultRequestHeaders.Add("Accept", "application/+json");
    }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
