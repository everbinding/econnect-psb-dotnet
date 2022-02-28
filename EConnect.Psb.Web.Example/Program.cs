using EConnect.Psb.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AddPageRoute("/ExampleSendInvoice", "");
});

builder.Services.AddPsbService(_ =>
{
    _.PsbUrl = "https://accp-psb.econnect.eu";
    _.IdentityUrl = "https://accp-identity.econnect.eu";
    _.ClientId = "2210f77eed3a4ab2";
    _.ClientSecret = "ddded83702534a6c9cadde3d1bf3e94a";
    _.SubscriptionKey = "Sandbox.Accp.W2NmWFRINXokdA";
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
