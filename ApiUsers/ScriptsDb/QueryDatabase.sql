-- Crear la base de datos
CREATE DATABASE SystemUsers;
GO

-- Usar la base de datos creada
USE SystemUsers;
GO

-- Crear la tabla Usuarios
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Fullname NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
	created datetime NOT NULL,
	LastUpdate datetime NULL,
);
GO


