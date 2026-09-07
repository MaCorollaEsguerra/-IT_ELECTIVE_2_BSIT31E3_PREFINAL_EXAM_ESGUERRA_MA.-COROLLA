using ExamMvc.Data;

var builder = WebApplication.CreateBuilder(args);

// MVC services. No database is used anywhere in this project -
// all exam content lives in-memory inside Data/QuestionRepository.cs
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<QuestionRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
