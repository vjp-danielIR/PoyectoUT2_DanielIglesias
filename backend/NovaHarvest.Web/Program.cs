var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build();

app.UseRequestLocalization("es-ES");
app.MapStaticAssets();
app.MapRazorPages();




app.MapGet("/status", () => Results.Content(RenderPage("Estado del servidor", $"""
    <p>Fecha y hora del servidor: <strong>{DateTime.Now:dd/MM/yyyy HH:mm:ss}</strong></p>
    <p>Página generada por ASP.NET Core (Kestrel)</p>
    """), "text/html"));

app.Run();

static string RenderPage(string title, string content) => $"""
    <!DOCTYPE html>
    <html lang="es">
    <head>
        <meta charset="UTF-8">
        <title>NovaHarvest - {title}</title>
        <link rel="stylesheet" href="/css/site.css">
    </head>
    <body>
        <header>
            <img src="/img/logo.png" alt="Logotipo de NovaHarvest">
            <br>
            <span class="brand">NovaHarvest</span>
            <br>
            <nav>
                <a href="/">Inicio</a>
                <a href="/about">Acerca de</a>
                <a href="/status">Estado</a>
            </nav>
        </header>
        <main>
            <h1>{title}</h1>
            {content}
        </main>
        <footer>NovaHarvest · IES Valle del Jerte · {DateTime.Now.Year}</footer>
    </body>
    </html>
    """;
