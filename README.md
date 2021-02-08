# arandasofttest
Prueba de desarrollo Back-End suministrada por arandasoft

SOLUCIÓN PROPUESTA: Servicio REST Web API sin Interfaz de Usuario

STACK TECNOLÓGICO
* Framework: .Net 5
* Lenguaje de Programación: C# 9
* Enfoque de Acceso a Datos: ORM --> Entity Framework 5
* Tipo de Aplicación: Asp.Net Core REST Web API
* Herramienta de Loggeo: SeriLog
* Sistema Gestor de Bases de Datos: SQL Server 
* Herramienta de Unit Testing: XUnit y In-Memory DataBase
* Herramienta de visualización: Swagger

REQUERIMIENTOS DE INSTALACIÓN

* Instalar (si no se tiene) el framework .Net 5.
* Ajustar cadena de Conexión a ambiente local de pruebas en el proyecto ArandaSoft.Idenity.API appsetting.json, segmento "ConnectionStrings"
* Ejecutar comando (desde dir ArandaSoft.Identity.DataBase) de creación de BD --> dotnet ef database update -s ..\ArandaSoft.Identity.API\ArandaSoft.Identity.API.csproj

      NOTA: La aplicación está configurada para cargar el usuario: Administrator, Password: 123 una vez creada la aplicación. Para obtener token debe ejecutarse login válido y      suminstrar token obtenido a la IU de Swagger para posteriormente ejecutar los End-Points propios del requerimiento. 
