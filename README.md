# Documentación Técnica

## Descripción del Proyecto

El proyecto consiste en el desarrollo de un Sistema de Gestión de Usuarios que permite registrar, editar, y eliminar usuarios. La aplicación sigue los principios de la arquitectura MVC, utilizando .NET, ASP.NET MVC, ASP.NET Web API para el manejo de servicios, SQL Server como base de datos y Entity Framework como ORM.

## Decisiones de Diseño

1. **Arquitectura MVC Separada**:
   - Se separó la API y la interfaz de usuario en proyectos distintos para seguir una arquitectura limpia y modular.
   - **API**: Gestiona todas las operaciones CRUD mediante endpoints RESTful.
   - **MVC**: Provee la interfaz de usuario, comunicándose con la API para realizar operaciones.

2. **Configuración del ORM (Entity Framework)**:
   - Se utilizó Entity Framework para interactuar con SQL Server.
   - La configuración de Entity Framework se realizó en el archivo `DbContext`, donde se definieron las entidades y sus relaciones.
   - Se aplicaron migraciones para gestionar los cambios en la base de datos de manera controlada y segura.

## Configuración del ORM

La configuración del ORM se realizó en la clase `ApplicationDbContext`, que hereda de `DbContext`. Aquí se definieron las entidades y sus relaciones.

## api 
cambiar la cadena de conexion ConnectionStrings-> Con que se encuentra en el archivo appsettings.json


## MVC Interface

Cambiar en el controlador  UsersController la Uri(Endpoint) que se este utilizando en su momento.



