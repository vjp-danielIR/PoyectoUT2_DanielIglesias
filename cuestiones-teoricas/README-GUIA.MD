## Arranque

### Con Docker

1. Abre una terminal en la carpeta raíz del proyecto, donde se encuentra `compose.yaml`.

2. Construye las imágenes e inicia los servicios:

Lo habres en el terminal de poweshell y pones el comando:
   docker compose up -d --build

   Si quieres detenerlo o eliminarlo pon:
   docker compose down

   si se hace sin docker entonces deberas entrar en la carpeta del proyecto y poner:
   dotnet run 
   advertencia: solo funciona si tienes .NET o SDK instalado en el dispositivo (son interpretes que ejecutaran el codigo)

