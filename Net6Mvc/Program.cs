using Autofac;
using Autofac.Extensions.DependencyInjection;
using Net6Mvc.Applibs;
using Net6Mvc.Domain.Model;
using NLog.Extensions.Logging;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // 設定 PascalCase 格式，而不是預設的 camelCase 格式
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

// nlog
builder.Host.UseNLog();

// autofac
{
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

    builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterType<TimeStampHelper>()
            .As<ITimeStampHelper>()
            .SingleInstance();
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// MapControllerRoute 用來建立單一路由。 單一路由的名稱 default 為 route。
// 大部分具有控制器和 views 的應用程式都會使用類似于路由的 default 路由範本。
// ** REST Api 應該使用 屬性路由。**
// 路由是使用 UseRouting 和 UseEndpoints 中介軟體進行設定。
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// nlog認appsetting設定
NLog.LogManager.Configuration = new NLogLoggingConfiguration(ConfigHelper.Config.GetSection("NLog"));

app.Run();
