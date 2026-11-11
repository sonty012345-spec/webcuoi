var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Bật tính năng sử dụng file tĩnh (HTML, CSS, JS, hình ảnh) trong thư mục wwwroot
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Tự động chuyển hướng trang chủ (/) vào file index.html của bạn
app.MapGet("/", async context =>
{
    context.Response.Redirect("/index.html");
    await Task.CompletedTask;
});

app.MapRazorPages();

app.Run();