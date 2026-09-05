using BasicAspireStarter.Web;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

var apiBaseAddress = builder.Configuration["ApiBaseAddress"] ?? "https+http://api";

builder.Services.AddRazorPages();
builder.Services.AddHttpClient("Api", client =>
{
    client.BaseAddress = new Uri(apiBaseAddress);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.MapDefaultEndpoints();

app.Run();
