# prueba-labcave-unity
Proyecto Unity de la Prueba LabCave FullStackDeveloper de Joaqu&iacute;n Casas.

###### Estructura proyecto:
- **Assets/animations**: contiene las animaciones.
- **Assets/resources**: contiene los prefabs.
- **Assets/scenes**: contiene las escenas.
- **Assets/scripts**: contiene los scripts C#.
    + **network/NetworkManager**: configuraci&oacute;n para conectarse al *server express*.
    + **network/NetworkManagerSocket**: configuraci&oacute;n para conectarse al *server socket.io*.
    + **time/Time**: obtiene la hora actual a trav&eacute;s del **server express** (*NetworkManager.serverExpress == true*) o del **server socket.io** (*NetworkManager.serverExpress == false*).
- **Assets/utils**: contiene utilidades comunes.

###### Funcionamiento:
1. Al iniciarse:
    - Si NetworkManager.serverExpress est&aacute; marcado: se conecta al servidor de la url indicada (localhost:8030), correspondiente al del server NodeJS express.
    - Si NetworkManager.serverExpress NO est&aacute; marcado: se conecta al servidor de la url indicada (127.0.0.1:8031), correspondiente al del server socket.
- *❌Si falla, se muestra un popup indicando el error durante unos segundos, y se cierra.*


2. Al clickar en el bot&oacute;n time_btn:
    - Si **NetworkManager.serverExpress** est&aacute; marcado: se realiza una petici&oacute;n GET a la API "/time" del server *NodeJS express*.
    - Si **NetworkManager.serverExpress NO** est&aacute; marcado: se ejecuta el evento socket "getTime" del *server socket.io*,
    que devuelve la fecha en el evento callback "getTimeCallback".
- *❌Si falla, se muestra un popup indicando el error durante unos segundos, y se cierra.*
- *✅Si no falla, devuelve la fecha actual, en formato HH:MM:ss (Horas:Minutos:Segundos).*

###### Conectarse al servidor:
- Para utilizar el servicio del servidor **Node express**, arrancar *prueba-labcave-server* en *8030*.
- Para utilizar el servicio del servidor **Node socket.io**, arrancar *prueba-labcave-server-socket* en *8031*.

###### Android App apk (ARM64):
**Builds/pruebalabcave.apk**
