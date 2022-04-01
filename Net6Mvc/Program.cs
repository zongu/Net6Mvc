var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.Run();
