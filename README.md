# prueba-labcave-unity
Proyecto Unity de la Prueba LabCave FullStackDeveloper de Joaqu&iacute;n Casas.

###### Estructura proyecto:
- Assets/animations -> contiene las animaciones.
- Assets/resources  -> contiene los prefabs.
- Assets/scenes     -> contiene las escenas.
- Assets/scripts    -> contiene los scripts C#.
- Assets/utils      -> contiene utilidades comunes.

###### Funcionamiento:
Al iniciarse, NetworkManager se conecta al servidor de la url indicada (localhost:8030), correspondiente al del server NodeJS.

*❌Si falla, se muestra un popup indicando el error durante unos segundos, y se cierra.


Al clickar en el bot&oacute;n time_btn, se realiza una petici&oacute;n GET a la API "/time" del server NodeJS.

*❌Si falla, se muestra un popup indicando el error durante unos segundos, y se cierra.

*✅Si no falla, devuelve la fecha actual, en formato HH:MM:ss (Horas:Minutos:Segundos).

