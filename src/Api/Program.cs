using Api;

var builder = WebApplication.CreateBuilder(args);
var app = InitializerExtension.Initialize(builder);
app.Run();