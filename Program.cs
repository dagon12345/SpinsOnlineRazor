using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Data;
using Microsoft.AspNetCore.Identity;
using SpinsOnlineRazor.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using SpinsOnlineRazor.Services;
using QRCoder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SpinsContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SpinsContext")));

builder.Services.AddDefaultIdentity<SpinsUser>(options => options.SignIn.RequireConfirmedAccount = true)
      .AddEntityFrameworkStores<SpinsContext>();

builder.Services.AddRazorPages(options =>
    options.Conventions.AuthorizePage("/AdminsOnly", "Admin"));
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddSingleton(new QRCodeService(new QRCodeGenerator()));

builder.Services.AddAuthorization(options =>
    options.AddPolicy("Admin", policy =>
        policy.RequireAuthenticatedUser()
            .RequireClaim("IsAdmin", bool.TrueString)));


    /*The AddDatabaseDeveloperPageExceptionFilter provides helpful error 
    information in the development environment for EF migrations errors.*/
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2UFhhQlJBfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hTX5Xd0NjWX9acHZRQ2hb");

// ILogger builder using SeriLog
// builder.Host.UseSerilog((context, services, configuration) => configuration
//                 .ReadFrom.Configuration(context.Configuration));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

/*The EnsureCreated method takes no action if a database for the context exists. 
If no database exists, it creates the database and schema.
 EnsureCreated enables the following workflow for handling data model changes:

Delete the database. Any existing data is lost.
Change the data model. For example, add an EmailAddress field.
Run the app.
EnsureCreated creates a database with the new schema.*/
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<SpinsContext>();
    //context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
