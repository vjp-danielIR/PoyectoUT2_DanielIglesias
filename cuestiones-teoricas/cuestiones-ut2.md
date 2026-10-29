> Responde **sobre tu proyecto**, no en general (entre 5 y 10 líneas cada una):

1. **Cliente y servidor.** Indica qué se ejecuta en el **cliente** y qué en el **servidor** cuando abres `/status`. Cuando NovaHarvest permita reservar producto, la regla *"no se pueden reservar más kilos de los disponibles"*, ¿dónde debe comprobarse obligatoriamente? ¿Por qué?


2. **Estático o dinámico.** ¿Cuál de tus tres páginas podría ser un HTML estático y cuál no? Justifícalo. Pon dos ejemplos de páginas que NovaHarvest necesitará y que **no** podrían ser estáticas.


3. **Ejecución en el servidor.** Explica paso a paso cómo una petición a `http://localhost:8080/status` acaba ejecutando tu código C#. ¿Qué cambiaría si NovaHarvest funcionara con **CGI**? ¿Y con un **módulo embebido** en el servidor web?



4. **Reverse proxy.** Haz `curl -I` (o mira la pestaña Red del navegador) a `/status` con Docker y con `dotnet run`. ¿Qué cabecera `Server` aparece en cada caso y por qué? Para el backend (`docker compose stop backend`) y pide `/status` y `/css/site.css`: ¿qué código HTTP recibes y por qué? ¿Por qué `backend` no publica ningún puerto?


5. **nginx.** ¿Por qué nginx no sirve `site.css` ni `logo.png` por su cuenta? Cita dos funciones que nginx
 podría aportar si NovaHarvest se publicara en Internet.


6. **Tecnologías.** Si la cooperativa pidiera hacer el backend con otra de las tecnologías *server-side* vistas en clase, ¿qué ficheros de tu repositorio cambiarían y cuáles se quedarían igual?




7. **Marcado y código.** Copia de tu `Program.cs` el código de una de las páginas y señala **dos** problemas concretos de generar HTML a base de cadenas. ¿Qué parte se repite en las tres páginas?


8. **Docker.** ¿Cuántas imágenes y cuántos contenedores tienes con el entorno levantado? Explica la diferencia usando tu proyecto. ¿Por qué la imagen final del backend no incluye el SDK? ¿Qué pasaría sin el `.dockerignore`?


9. **Herramientas.** Haz una tabla con las herramientas que has usado en el proyecto y el problema que resuelve cada una en él.




10. **Observación.** Compara la hora de `/status` con `dotnet run` y con Docker. ¿Coinciden? Explica por qué.
