using RockPaperScissordle.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission",
        policy =>
        {
            policy.AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("http://localhost:3000")
                .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("ClientPermission");
app.UseRouting();
app.MapHub<ChatHub>("/hubs/chat");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); //TODO do we want to delete this?

if (app.Environment.IsDevelopment())
{
    app.UseSpa(spa => { spa.UseProxyToSpaDevelopmentServer("http://localhost:3000"); });
}
else
{
    app.MapFallbackToFile("index.html");
}

app.Run();