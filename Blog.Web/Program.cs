using Blog.DataAccess.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Blog.DataAccess.Contexts;
using Blog.DataAccess.Repositories;




var builder = WebApplication.CreateBuilder(args);





builder.Services.AddScoped<PostRepository>();
// Add services to the container.
builder.Services.AddScoped<MongoDbContext>();
builder.Services.AddControllersWithViews();
// MongoDbSettings -> appsettings.json'dan ayarlarý okur
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings")
);
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
