using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpinsOnlineRazor.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SpinsContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SpinsContext")));



    /*The AddDatabaseDeveloperPageExceptionFilter provides helpful error 
    information in the development environment for EF migrations errors.*/
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

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
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
