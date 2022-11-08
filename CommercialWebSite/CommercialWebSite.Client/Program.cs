using CommercialWebSite.Client.RefitClient;
using Microsoft.AspNetCore.Authentication.Cookies;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.LoginPath = "/Auth/AccessDenied";
        opt.AccessDeniedPath = "/Auth/AccessDenied";
    });

// Add services to the container.
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.MaxValue;
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Dependency Injection
string baseUrl = "https://localhost:7281";
builder.Services.AddRefitClient<IAuthenticateClient>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
builder.Services.AddRefitClient<ICategoryClient>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
builder.Services.AddRefitClient<IOrderClient>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
builder.Services.AddRefitClient<IProductClient>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
builder.Services.AddRefitClient<IReviewClient>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));

builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

builder.Services.AddMvcCore()
    .AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseDeveloperExceptionPage();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
