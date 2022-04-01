using Autofac;
using Autofac.Extensions.DependencyInjection;
using Net6Mvc.Applibs;
using Net6Mvc.Domain.Model;
using NLog.Extensions.Logging;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

// MapControllerRoute �Á�����һ·�ɡ� ��һ·�ɵ����Q default �� route��
// �󲿷־��п������� views �đ��ó�ʽ����ʹ�������·�ɵ� default ·�ɹ�����
// ** REST Api ��ԓʹ�� ����·�ɡ�**
// ·����ʹ�� UseRouting �� UseEndpoints �н�ܛ�w�M���O����
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// nlog�Jappsetting�O��
NLog.LogManager.Configuration = new NLogLoggingConfiguration(ConfigHelper.Config.GetSection("NLog"));

app.Run();
