var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// ПОРТ: Render автоматически назначает порт через переменную окружения PORT
// Если её нет, используем порт 10000 для локальной отладки
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
builder.WebHost.UseUrls($"http://*:{port}");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// app.UseHttpsRedirection(); // Временно отключаем перенаправление на HTTPS для Render
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();