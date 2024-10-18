# MiniMarketIntec
# Proyecto de Aplicación de Almacenamiento de Productos

Esta es una aplicación de escritorio desarrollada en C#, diseñada para gestionar el almacenamiento y la visualización de productos y sus datos relacionados. La aplicación cuenta con una interfaz gráfica intuitiva que permite acceder a diferentes interfaces donde se puede interactuar con diversas entidades relacionadas con los productos, tales como marcas, países, almacenes, municipios, proveedores, y unidades de medida.
La aplicación está conectada a una base de datos SQL que permite a los usuarios agregar, modificar y actualizar los datos de cada una de estas entidades. Los productos registrados y gestionados a través de estas interfaces se visualizan finalmente en una capa principal llamada Productos.

# características:

Interfaz gráfica de usuario con navegación fácil mediante botones que llevan a distintas secciones.
Gestión de:

-Marcas: Visualización y modificación de las marcas disponibles.
-Países: Gestión de países asociados a los productos.
-Almacenes: Control de los almacenes donde se almacenan los productos.
-Municipios: Gestión de los municipios relacionados con los proveedores.
-Proveedores: Gestión de proveedores y sus detalles.
-Unidades de medida: Configuración de las unidades de medida utilizadas para los productos.

Conexión a una base de datos SQL para almacenar, actualizar y recuperar datos en tiempo real.
Visualización consolidada de los productos registrados en una sección principal.

# Requisitos del Sistema
.NET Framework 4.7.2 o superior
SQL Server 2019 o superior
Visual Studio 2019 (o versión superior recomendada para el desarrollo)

# Instalación
1. Clona el repositorio
-git clone https://github.com/Rasmeh27/MiniMarket.git
2. Abre el proyecto en Visual Studio.
3. Configura la conexión a la base de datos SQL en el archivo de configuración app.config.
4. Ejecuta las migraciones de base de datos (si aplica).
5. Compila y ejecuta la aplicación.

# Uso
Navega a través de las distintas interfaces haciendo clic en los botones del menú principal.
En cada interfaz, podrás agregar, modificar o eliminar datos relacionados con marcas, países, almacenes, municipios, proveedores y unidades de medida.
Todos los cambios realizados en las entidades se reflejan directamente en la base de datos SQL.
La sección Productos muestra todos los productos registrados, consolidando la información de las otras secciones.

