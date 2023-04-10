using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WebApplication5.Entity;
using WebApplication5.Middleware;
using WebApplication5.Repositories;
using WebApplication5.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddDbContext<MyDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"));
});
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<ITourRepository,TourRepository>();
builder.Services.AddScoped<ILocationRepository,LocationRepository>();
builder.Services.AddSingleton<AdminMiddleware>();
builder.Services.AddScoped<IAccountRepository,AccountRepository>();    
builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/login";
});

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<MyDbContext>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
.AddEntityFrameworkStores<MyDbContext>().AddDefaultTokenProviders();
//builder.Services.AddDefaultIdentity<ApplicationUser>().AddEntityFrameworkStores<MyDbContext>().AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);   
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.User.RequireUniqueEmail = true;

    //options.SignIn.RequireConfirmedEmail = true;
    options.SignIn.RequireConfirmedPhoneNumber = false;
});
builder.Services.AddOptions();
//var mailsetting = builder.Configuration.GetSection("MailSetting");
//builder.Services.Configure < MailSettings>(mailsetting);
//builder.Services.AddSingleton<IEmailSender, SendMailService>();
var app = builder.Build();


app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
    Path.Combine(builder.Environment.ContentRootPath)),
    RequestPath = "/Uploaded"
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// Configure the HTTP request pipeline.


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseMiddleware<AdminMiddleware>();
app.UseAuthorization();

app.MapRazorPages();
app.UseRouting();

app.Run();

