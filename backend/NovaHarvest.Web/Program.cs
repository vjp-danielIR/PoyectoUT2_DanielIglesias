var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapStaticAssets();

app.MapGet("/", () => Results.Content(RenderPage("Inicio", """
    <p>Cada semana, los productores de la cooperativa del Valle del Jerte tienen fruta y verdura que no llegan a venderse.</p>
    <p>NovaHarvest quiere conectar a esos productores con quienes pueden aprovecharla: residencias, comedores sociales, restaurantes y particulares.</p>
    <p>Así se facilita el aprovechamiento de excedentes y se evita que alimentos en buen estado acaben desperdiciados.</p>
    """), "text/html"));

app.MapGet("/about", () => Results.Content(RenderPage("Acerca de", """
    <ul>
        <li><strong>Proyecto:</strong> NovaHarvest, aprovechamiento de excedentes agrícolas del Valle del Jerte</li>
        <li><strong>Centro:</strong> IES Valle del Jerte</li>
        <li><strong>Autor:</strong> Daniel Iglesias Ramos</li>
        <li><strong>Versión:</strong> 0.1.0</li>
    </ul>
    """), "text/html"));

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
            <img src="/img/logo.jpg" alt="Logotipo de NovaHarvest">
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
