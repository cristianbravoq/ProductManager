# Nombre de la Aplicación
Breve descripción o introducción de la aplicación.

## Requisitos Previos
Antes de comenzar, asegúrate de tener instalado lo siguiente:

Visual Studio (preferiblemente la última versión)
SQL Server
Git

# Configuración
1- Clona este repositorio en tu máquina local: git clone https://github.com/TuUsuario/TuRepositorio.git
2- Abre el archivo de solución ProductManager.sln en Visual Studio.
3- Configura la cadena de conexión a la base de datos en web.config:
    <connectionStrings>
      <add name="ProductManagerContext" connectionString="Server=NAME-SERVER;Database=ProductManagerDB;Integrated Security=True" providerName="System.Data.SqlClient" />
    </connectionStrings>
4- Compila la solución en Visual Studio.

# Ejecución
Inicia la aplicación presionando el botón de "Start" o utilizando F5 en Visual Studio.

# Uso
A continuación, se detallan los diferentes endpoints disponibles en la API y cómo usarlos:

## Obtener Todos los Productos
Método: GET
Ruta: /Product

Este endpoint te permite obtener todos los productos disponibles en la base de datos.

Ejemplo de solicitud:
  GET /Product

## Obtener Detalles de un Producto
Método: GET
Ruta: /Product/{id}

Este endpoint te permite obtener los detalles de un producto específico según su ID.

Ejemplo de solicitud:
  GET /Product/{id}

## Crear un Producto Nuevo
Método: POST
Ruta: /Product

Este endpoint te permite crear un nuevo producto en la base de datos.

Ejemplo de solicitud:
  POST /Product
  Content-Type: application/json
  
  {
    "NombreProducto": "Nuevo Producto",
    "Descripcion": "Descripción del nuevo producto",
    "CategoriaID": 2,
    "Precio": 99.99,
    "CantidadDisponible": 50
  }

## Actualizar un Producto Existente
Método: PUT
Ruta: /Product/{id}

Este endpoint te permite actualizar los detalles de un producto existente según su ID.

Ejemplo de solicitud:
  PUT /Product/1
  Content-Type: application/json
  
  {
    "NombreProducto": "Producto Actualizado",
    "Descripcion": "Descripción actualizada",
    "CategoriaID": 3,
    "Precio": 149.99,
    "CantidadDisponible": 75
  }

## Buscar Productos
Método: GET
Ruta: /Product/BuscarProductos?NombreProducto=Producto&PrecioMinimo=50&PrecioMaximo=200

Este endpoint te permite buscar productos con filtros opcionales, como nombre y rango de precio.

Ejemplo de solicitud:
  GET /Product/BuscarProductos?NombreProducto=Producto&PrecioMinimo=50&PrecioMaximo=200

## Eliminar un Producto
Método: DELETE
Ruta: /Product/{id}

Este endpoint te permite eliminar un producto existente según su ID.

Ejemplo de solicitud:
  DELETE /Product/1
