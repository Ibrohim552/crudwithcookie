using BlazorCrud;
using BlazorCrud.Components;
using BlazorCrud.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(x =>
{
    x.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
    x.LogTo(Console.WriteLine);
});
builder.Services.AddAuthentication("Cookie")
    .AddCookie("Cookie", options =>
    {
        options.Cookie.Name = "MyAuthCookie";
        options.LoginPath = "/login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });
builder.Services.AddScoped<IDeveloperService,DeveloperService > ();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();