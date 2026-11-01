> Responde **sobre tu proyecto**, no en general (entre 5 y 10 líneas cada una):

1. **Cliente y servidor.** Indica qué se ejecuta en el **cliente** y qué en el **servidor** cuando abres `/status`. Cuando NovaHarvest permita reservar producto, la regla *"no se pueden reservar más kilos de los disponibles"*, ¿dónde debe comprobarse obligatoriamente? ¿Por qué?

En el cliente no se ejecuta nada cuando el usuario entra en status hace una peticion al servidor y le devuelve el html css y el codigo de la hora en cuanto a la otra parte siempre debe comprobarse en el servidor por que el usuario podria modificar lo que envia desde el navegador y saltarse la regla.

2. **Estático o dinámico.** ¿Cuál de tus tres páginas podría ser un HTML estático y cuál no? Justifícalo. Pon dos ejemplos de páginas que NovaHarvest necesitará y que **no** podrían ser estáticas.

Las de incio y abaut podrian ser paginas estaticas por que su contenido no cambia pero el estado cada peticion es dinamica por que cambia la hora poniendo de ejemplo lo anterior otra pagina que tendria que ser dinamica es para consultar el stock de los productos  es decir las dos estaticas podrian ser inicio y abaut y las dinamicas serian las de estado y stock de productos cada peticion actualizaria la hora  y el stock

3. **Ejecución en el servidor.** Explica paso a paso cómo una petición a `http://localhost:8080/status` acaba ejecutando tu código C#. ¿Qué cambiaría si NovaHarvest funcionara con **CGI**? ¿Y con un **módulo embebido** en el servidor web?
 
el navegador hace la peticion nginx recibe la peticion y la manda al backend  el .net ejecuta el c# el servidor  genera el html con todo actualizado a la ulktima peticion y con el cgi se inicia un proceso externo y con el modulo embebido el servidor web ejecuta el c# directamente sin necesidad de un proceso externo

4. **Reverse proxy.** Haz `curl -I` (o mira la pestaña Red del navegador) a `/status` con Docker y con `dotnet run`. ¿Qué cabecera `Server` aparece en cada caso y por qué? Para el backend (`docker compose stop backend`) y pide `/status` y `/css/site.css`: ¿qué código HTTP recibes y por qué? ¿Por qué `backend` no publica ningún puerto?

con dotnet run me aparece kestrel y con docker me aparece nginx y si paro le backend da error por que la web no puede levantarse si antes no esta levantado el backend recibo un 502 por que ngnix manda las peticiones al backend, y backend no publica ningun puerto por que lo comparte con web el puerto 8080 

5. **nginx.** ¿Por qué nginx no sirve `site.css` ni `logo.png` por su cuenta? Cita dos funciones que nginx podría aportar si NovaHarvest se publicara en Internet.

nginx no sirve esas peticiones por que se las pide al backend 
las dos funcionalidades pordiran se4r gestionar https y repartir peticiones 

6. **Tecnologías.** Si la cooperativa pidiera hacer el backend con otra de las tecnologías *server-side* vistas en clase, ¿qué ficheros de tu repositorio cambiarían y cuáles se quedarían igual?


segun yo lo unico que tendria que cambiar es el codigo y el dockerfile el css y el logo si los reutilizan tambien podrian quedarse basicamente nginx se queda por que solo pide al backend la peticion mientras el puerto sea el mismo 

7. **Marcado y código.** Copia de tu `Program.cs` el código de una de las páginas y señala **dos** problemas concretos de generar HTML a base de cadenas. ¿Qué parte se repite en las tres páginas?


app.MapGet("/", () => Results.Content(RenderPage("Inicio", """
    <p>Cada semana, los productores de la cooperativa del Valle del Jerte tienen fruta y verdura que no llegan a venderse.</p>
    <p>NovaHarvest quiere conectar a esos productores con quienes pueden aprovecharla: residencias, comedores sociales, restaurantes y particulares.</p>
    <p>Así se facilita el aprovechamiento de excedentes y se evita que alimentos en buen estado acaben desperdiciados.</p>
    """), "text/html"));

el primer problema es la sintaxis si pones algo mal o no compila no te va a dar error por que esta escrito en cadena de texto como si no fuera codigo por asi decirlo  el segundo problema diria yo seria la dificultad de separarlo del c# 

8. **Docker.** ¿Cuántas imágenes y cuántos contenedores tienes con el entorno levantado? Explica la diferencia usando tu proyecto. ¿Por qué la imagen final del backend no incluye el SDK? ¿Qué pasaría sin el `.dockerignore`?

tengo 2 imagenes y 2 contenedores  la imagen es la plantilla y el contenedor es la misma imagen en ejecucion el sdk solo se usa para compilar si quitas el dockerignore se copiarian tambien las carpetas de bin o obj basicamente es para que se ignoren las carpetas que no nos interesa

9. **Herramientas.** Haz una tabla con las herramientas que has usado en el proyecto y el problema que resuelve cada una en él.

|Herramienta        |  Problema que resuelve|
|-------------------|----------------------|
|Visual Studio Code | Edición y depuración del código|
|dotnet             | Compilación y ejecución de la aplicación|
|Docker             | Contenerización y despliegue de la aplicación|
|nginx              | Gestión de tráfico y balanceo de carga|

10. **Observación.** Compara la hora de `/status` con `dotnet run` y con Docker. ¿Coinciden? Explica por qué.
no coinciden por que dotnet run usa la hora del ordenador y docker usa la UTC 