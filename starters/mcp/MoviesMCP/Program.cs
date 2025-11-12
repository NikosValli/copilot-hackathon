var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole(consoleLogOptions => consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace);
builder.Services
    .AddMcpServer()
    .WithHttpTransport(o => o.Stateless = true)
    .WithToolsFromAssembly();
builder.Services.AddHttpClient();
var app = builder.Build();
app.MapMcp("/mcp");
app.Run();