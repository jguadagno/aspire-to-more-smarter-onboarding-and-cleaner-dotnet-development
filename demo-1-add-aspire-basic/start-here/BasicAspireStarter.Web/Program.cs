var builder = WebApplication.CreateBuilder(args);

var apiBaseAddress = builder.Configuration["ApiBaseAddress"]
	?? throw new InvalidOperationException("ApiBaseAddress is not configured.");

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

app.Run();
