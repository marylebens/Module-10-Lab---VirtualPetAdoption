using Microsoft.EntityFrameworkCore;
using VirtualPetAdoption.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PetAdoptionContext> (options => options.UseSqlite(builder.Configuration.GetConnectionString("PetAdoptionContext")));

var app = builder.Build();
using (var scope = app.Services.CreateScope()){
    // This gives you access to all the services you registered earlier, like DBContext
    var services = scope.ServiceProvider; 

    // This gets an instance of your database context = the thing that talks to your database
    var context = services.GetRequiredService<PetAdoptionContext>();

    // This checks if you database exists and if it does not, it creates it. 
    context.Database.Migrate();
}

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
