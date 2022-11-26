using AmlScreeningService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IAmlListCaptureService, AmlListCaptureService>();
builder.Services.AddSingleton<IAmlListCache, AmlListCache>();
builder.Services.AddSingleton<IAmlListChecker, AmlListChecker>();

var app = builder.Build();

app.MapControllers();
app.Run();