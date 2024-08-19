using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// MVC hizmetini ekle
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Uygulama için rota yapılandırması
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Default route ayarı
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calculate}/{action=GetCapacity}/{id?}");

app.Run();
