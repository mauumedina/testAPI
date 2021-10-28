# testAPI
Para usar esta API es necesario descargar y compilar el código fuente.
Contar con Net 5 instalado y postgreSQL instalados y configurados.

Para poder correr esta web API en un entorno productivo, es necesario realizar un deploy del codigo fuente y ejecutar la dll o el exe, segun el SO que se utilice para el deploy.
La base de datos deberá ser creada y así mismo las tablas ejecutando un migrate para que se creen los modelos mediante Entity Framework.

El appsettings de la aplicación debera de tener la ip, puertos y datos de conexión necesarios, para realizar conexión a PostgreSQL.


Ejemplo Mostrado en el video.
https://drive.google.com/file/d/1CTrXPKI6VW5YBuhnIBplD6QUmHWm1Uxj/view?usp=sharing

Se deberá de crear una maquina virtual con Centos y seguir los pasos siguientes:
  1.- Setear una IP estatica a la maquina virtual.
  2.- Instalar PostgresSQL y Net Core
  3.- Crear un nuevo usuario de postgres.
  4.- Modificar el appsettings de la aplicacion NET con los accessos a la base de datos.
  5.- Compilar y Publicar nuestra aplicacion para SO Linux.
  6.- Correr dotnet ef mediante la dll de nuestro aplicativo en la maquina centos para que se creen todos los modelos de la base de datos.
  7.- Ejecutamos nuestra aplicación en centos medinate el comando dotnet
  8.- Automatizamos su ejecucion para que el servicio inicie cada vez junto a la maquina virtual.
      para ello vamos a:  /etc/systemd/system y creamos un file sudo vi webTest.service
      y creamos lo siguiente dentro del archivo:

      [Service]
      WorkingDirectory= "la ruta de nuestra aplicación"
      ExecStart=/usr/bin/dotnet"la ruta de nuestra aplicación junto con la dll"
      Restart=always
      # RestartService after 10secs if dotnet service crashes
      RestartSec=10
      KillSignal=SIGINT
      SyslogIdentifier=ejemploApp
      user=NOMBRE_USUARIO
      Environment=ASPNETCORE_ENVIRONMENT=Production
      Environment=DOTNET_PRINT_TELEMETRY_MESSAGE=fasle

      [Install]
      WantedBy=multi-user.target
  9.- Ejecutamos nuestro servicio mediante el comando sudo systemctl enable webTest.service
  10.- Adicional configuraremos NGINX para servir nuestra aplicación, para ello iremos a la ruta /etc/nginx/conf.d y crearemos un archivo mediante el siguiente comando: 
       sudo vi webTest.conf con lo siguiente:
       
       server {
       server_name IP_ADDRESS;
       location / {
           proxy_pass         http://localhost:5000;
           }
       }
   11.- Ejecutamos sudo systemctl restart nginx.service
   
 Listo podremos acceder a nuestra aplicación desde la misma red con la dirección IP.
