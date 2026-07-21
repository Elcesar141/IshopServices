var builder = WebApplication.CreateBuilder(args);

// 1. Servicios
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Forzamos a Carter a buscar los módulos dentro de este mismo proyecto (Catalog.API)
var catalogAssembly = typeof(Program).Assembly;
builder.Services.AddCarter(configurator: config =>
{
    var moduleTypes = catalogAssembly.GetTypes()
        .Where(t => typeof(ICarterModule).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
        .ToArray();
    config.WithModules(moduleTypes);
});

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

// 🟢 NUEVO: Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// 🟢 NUEVO: Activar CORS
app.UseCors();

// 2. Ruta de prueba directa (para descartar problemas de servidor)
app.MapGet("/test", () => "¡La API de Catálogo está viva y respondiendo!");

// 3. Rutas de Carter
app.MapCarter();

app.Run();