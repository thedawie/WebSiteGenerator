using generator.web.Components;
using generator.web.Services;
using Microsoft.SemanticKernel;





var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IGeneratorService,GeneratorService>();
builder.Services.AddTransient<IHelperService,HelperService>();
builder.Services.AddSingleton<Kernel>(sp =>
{
    var model = "llama3.2";
    var endPoint = "http://127.0.0.1:11434";

    var builder = Kernel.CreateBuilder();
    builder.AddOllamaTextGeneration(modelId: model, endpoint: new Uri(endPoint));

    var kernel = builder.Build();
    return kernel;
});


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


var app = builder.Build();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
