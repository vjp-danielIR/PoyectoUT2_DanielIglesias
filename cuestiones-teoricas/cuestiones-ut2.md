> Responde **sobre tu proyecto**, no en general (entre 5 y 10 líneas cada una):

1. **Cliente y servidor.** Indica qué se ejecuta en el **cliente** y qué en el **servidor** cuando abres `/status`. Cuando NovaHarvest permita reservar producto, la regla *"no se pueden reservar más kilos de los disponibles"*, ¿dónde debe comprobarse obligatoriamente? ¿Por qué?

En el cliente solo se ejecuta el navegador que muestra el html y el css que recibe. todo el c# se ejecuta en el servidor que genera el html con la hora y lo devuelve. la regla de no reservar mas kilos de los disponibles debe comprobarse siempre en el servidor el usuario puede modificar lo que envia desde el navegador y saltarse la regla el servidor es el unico que tiene el stock real y el usuario no puede tocarlo.

2. **Estático o dinámico.** ¿Cuál de tus tres páginas podría ser un HTML estático y cuál no? Justifícalo. Pon dos ejemplos de páginas que NovaHarvest necesitará y que **no** podrían ser estáticas.

El inicio y about podrian ser html estatico por que su contenido es siempre el mismo. status no puede serlo por que cada peticion genera la hora actual. dos paginas de novaharvest que no podrian ser estaticas son la consulta de stock de productos y la de reservas. las dos dependen de datos que cambian y de lo que haga cada usuario.

3. **Ejecución en el servidor.** Explica paso a paso cómo una petición a `http://localhost:8080/status` acaba ejecutando tu código C#. ¿Qué cambiaría si NovaHarvest funcionara con **CGI**? ¿Y con un **módulo embebido** en el servidor web?
 
El navegador pide la página /status a nginx. nginx pasa la petición al backend. El backend ejecuta el código C# y crea la página con la hora actual. Después, la respuesta vuelve al navegador. Con CGI se iniciaría otro programa para responder. Con un módulo integrado, el código se ejecutaría dentro del servidor web.

4. **Reverse proxy.** Haz `curl -I` (o mira la pestaña Red del navegador) a `/status` con Docker y con `dotnet run`. ¿Qué cabecera `Server` aparece en cada caso y por qué? Para el backend (`docker compose stop backend`) y pide `/status` y `/css/site.css`: ¿qué código HTTP recibes y por qué? ¿Por qué `backend` no publica ningún puerto?

Con dotnet run, aparece Kestrel porque la petición llega directamente a la aplicación. Con Docker, aparece nginx porque recibe primero la petición. Si paro el backend, /status y /css/site.css devuelven un error 502 porque nginx no puede conectarse. El backend no publica un puerto en el ordenador: se comunica con nginx dentro de Docker. Solo nginx está disponible desde fuera, en el puerto 8080.

5. **nginx.** ¿Por qué nginx no sirve `site.css` ni `logo.png` por su cuenta? Cita dos funciones que nginx podría aportar si NovaHarvest se publicara en Internet.

nginx no sirve site.css ni logo.png porque esos archivos están en el backend. nginx recibe las peticiones y se las pasa al backend. Si la aplicación estuviera en Internet, nginx también podría proteger la conexión y repartir las peticiones entre varios servidores.

6. **Tecnologías.** Si la cooperativa pidiera hacer el backend con otra de las tecnologías *server-side* vistas en clase, ¿qué ficheros de tu repositorio cambiarían y cuáles se quedarían igual?

Habría que cambiar el código del backend y su Dockerfile para usar la nueva tecnología. Si cambia el puerto, también habría que actualizar la configuración de Docker y nginx. El resto de nginx podría quedarse igual. El CSS y el logotipo se podrían seguir usando.

7. **Marcado y código.** Copia de tu `Program.cs` el código de una de las páginas y señala **dos** problemas concretos de generar HTML a base de cadenas. ¿Qué parte se repite en las tres páginas?


app.MapGet("/", () => Results.Content(RenderPage("Inicio", """
    <p>Cada semana, los productores de la cooperativa del Valle del Jerte tienen fruta y verdura que no llegan a venderse.</p>
    <p>NovaHarvest quiere conectar a esos productores con quienes pueden aprovecharla: residencias, comedores sociales, restaurantes y particulares.</p>
    <p>Así se facilita el aprovechamiento de excedentes y se evita que alimentos en buen estado acaben desperdiciados.</p>
    """), "text/html"));

Un problema de escribir HTML como texto es que es fácil equivocarse en las etiquetas. Otro es que cuesta más leer y cambiar el código al estar mezclado con C#. En las tres páginas se repiten la cabecera, el menú, el enlace a los estilos y el pie de página.

8. **Docker.** ¿Cuántas imágenes y cuántos contenedores tienes con el entorno levantado? Explica la diferencia usando tu proyecto. ¿Por qué la imagen final del backend no incluye el SDK? ¿Qué pasaría sin el `.dockerignore`?

Al iniciar el proyecto hay dos imágenes y dos contenedores: uno para web y otro para backend. La imagen es la plantilla y el contenedor es esa plantilla funcionando. El SDK se usa para compilar; para ejecutar la aplicación basta ASP.NET Core. Sin dockerignore, también se copiarían las carpetas bin y obj, que contienen archivos generados que no necesitamos.

9. **Herramientas.** Haz una tabla con las herramientas que has usado en el proyecto y el problema que resuelve cada una en él.

| Herramienta | Uso en este proyecto |
|---|---|
| Visual Studio Code | Editar el código y los archivos de configuración. |
| .NET 10 SDK | Compilar y ejecutar la aplicación con dotnet build y dotnet run. |
| Docker y Docker Compose | Construir las imágenes y levantar los servicios web y backend. |
| nginx | Recibir las peticiones y reenviarlas al backend como proxy inverso. |
| Git | Registrar los cambios del proyecto. |
| PowerShell | Ejecutar comandos en Windows. |

10. **Observación.** Compara la hora de `/status` con `dotnet run` y con Docker. ¿Coinciden? Explica por qué.

    las horas no coinciden. Con dotnet run se usa la hora del ordenador. En Docker se usa la hora configurada dentro del contenedor, que normalmente es UTC. Por eso puede haber una diferencia.