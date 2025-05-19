using Microsoft.AspNetCore.Identity.UI.Services;
using DemoMVC.Data;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Models;
using Microsoft.AspNetCore.Identity;
using DemoMVC.Models.Process;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.CodeAnalysis.Options;
using Microsoft.AspNetCore.Authorization;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOptions();
var mailSettings = builder.Configuration.GetSection("MailSettings");
builder.Services.Configure<MailSettings>(mailSettings);
builder.Services.AddTransient<IEmailSender, SendMailService>();
builder.Services.AddRazorPages();
// Add services to the container.
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization(options =>
        {
            foreach (var permission in Enum.GetValues(typeof(SystemPermissions)).Cast<SystemPermissions>())
            {
                options.AddPolicy(permission.ToString(), policy =>
                    policy.RequireClaim("Permission", permission.ToString()));
            }
            // options.AddPolicy("ViewEmployee", policy => policy.RequireClaim("Employee", "Index"));
            // options.AddPolicy("CreateEmployee", policy => policy.RequireClaim("Employee", "Create"));
            // options.AddPolicy("Role", policy => policy.RequireClaim("Role", "AdminOnly"));
            // options.AddPolicy("Permission", policy => policy.RequireClaim("Role", "EmployeeOnly"));
            // options.AddPolicy("PolicyAdmin", policy => policy.RequireRole("Admin"));
            // options.AddPolicy("PolicyEmployee", policy => policy.RequireRole("Employee"));
            // options.AddPolicy("PolicyByPhoneNumber", policy => policy.Requirements.Add(new PolicyByPhoneNumberRequirement()));
        });
// builder.Services.AddSingleton<IAuthorizationHandler, PolicyByPhoneNumberHandler>();
builder.Services.Configure<IdentityOptions>(options =>
{
    // Default lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    // config password
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;
    // config Login
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    //config user
    options.User.RequireUniqueEmail = true;
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    // chi gui cooke qua HTTPS
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    // giam thieu rui ro CSRF
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.SlidingExpiration = true;
});
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));
builder.Services.AddTransient<EmployeeSeeder>(); 
builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = $"/Identity/Account/Login";
            options.LogoutPath = $"/Identity/Account/Logout";
            options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
        });
var app = builder.Build();

using (var scope = app.Services.CreateAsyncScope())
{
    var services = scope.ServiceProvider;
    var seeder = services.GetRequiredService<EmployeeSeeder>();
    seeder.SeedEmployees(1000);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages();

app.Run();