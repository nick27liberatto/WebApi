using Api;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

InitializerExtension.Initialize(builder, app);

app.Run();