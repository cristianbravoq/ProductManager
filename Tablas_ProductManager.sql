-- Crear la base de datos
CREATE DATABASE ProductManagerDB;

USE ProductManagerDB;

-- Crear tabla Usuarios
CREATE TABLE Usuarios (
    UsuarioID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(50) NOT NULL,
    Contrase�a NVARCHAR(128) NOT NULL,
    Rol NVARCHAR(20) NOT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    UltimoAcceso DATETIME
);

-- Crear tabla Categorias
CREATE TABLE Categorias (
    CategoriaID INT PRIMARY KEY IDENTITY,
    NombreCategoria NVARCHAR(50) NOT NULL
);

-- Crear tabla Productos
CREATE TABLE Productos (
    ProductoID INT PRIMARY KEY IDENTITY,
    NombreProducto NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    CategoriaID INT FOREIGN KEY REFERENCES Categorias(CategoriaID),
    Precio DECIMAL(10, 2) NOT NULL,
    CantidadDisponible INT NOT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    UltimaActualizacion DATETIME
);

INSERT INTO Categorias (NombreCategoria)
VALUES ('Electr�nicos');

INSERT INTO Categorias (NombreCategoria)
VALUES ('Computadoras');

INSERT INTO Categorias (NombreCategoria)
VALUES ('Videojuegos');

INSERT INTO Categorias (NombreCategoria)
VALUES ('Electrodom�sticos');

INSERT INTO Categorias (NombreCategoria)
VALUES ('Accesorios');

INSERT INTO Productos (NombreProducto, Descripcion, CategoriaID, Precio, CantidadDisponible, FechaCreacion)
VALUES ('Samsung Galaxy S21', 'Pantalla AMOLED 6.2", 128GB de almacenamiento', 1, 2800000.00, 15, GETDATE());

INSERT INTO Productos (NombreProducto, Descripcion, CategoriaID, Precio, CantidadDisponible, FechaCreacion)
VALUES ('MacBook Pro', 'Procesador Intel Core i7, 16GB RAM, 512GB SSD', 2, 8000000.00, 5, GETDATE());

INSERT INTO Productos (NombreProducto, Descripcion, CategoriaID, Precio, CantidadDisponible, FechaCreacion)
VALUES ('PlayStation 5', 'Consola de videojuegos de �ltima generaci�n', 3, 4500000.00, 8, GETDATE());

INSERT INTO Productos (NombreProducto, Descripcion, CategoriaID, Precio, CantidadDisponible, FechaCreacion)
VALUES ('Smart TV 55"', 'Pantalla 4K con aplicaciones integradas', 4, 2500000.00, 10, GETDATE());

INSERT INTO Productos (NombreProducto, Descripcion, CategoriaID, Precio, CantidadDisponible, FechaCreacion)
VALUES ('AirPods Pro', 'Auriculares inal�mbricos con cancelaci�n de ruido', 5, 1200000.00, 20, GETDATE());

INSERT INTO Usuarios (Nombre, Contrase�a, Rol, FechaCreacion, UltimoAcceso)
VALUES
    ('juanperez', 'contrase�a123', 'Administrador', GETDATE(), NULL),
    ('mariagonzalez', 'clave456', 'Comprador', GETDATE(), NULL),
    ('carlosrodriguez', 'secreto789', 'UsuarioNormal', GETDATE(), NULL),
    ('lauramartinez', 'p4ssw0rd', 'Comprador', GETDATE(), NULL);
