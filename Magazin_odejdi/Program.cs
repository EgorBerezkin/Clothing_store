using Magazin_odejdi.Hubs;
using Magazin_odejdi.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor(); // авторизация

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Magazin_odejdi")));

builder.Services.AddSignalR();

// Добавляем Cookie Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // куда перекидывать неавторизованных
        options.AccessDeniedPath = "/Account/AccessDenied"; // можно отдельно /AccessDenied
        options.Cookie.Name = "StudentLibraryCookie";
        options.ExpireTimeSpan = TimeSpan.FromHours(1); // Срок действия
    });

builder.Services.AddAuthorization(); // авторизация

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();// порядок важен
app.UseAuthorization(); // внимание эта после UseAuthentication

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.MapHub<ClothesHub>("/clothesHub");
app.MapHub<ChatHub>("/chatHub");
app.MapHub<BuyersHub>("/buyersHub");
app.MapHub<UsersHub>("/usersHub");

app.Run();

