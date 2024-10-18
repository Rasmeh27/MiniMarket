# MiniMarketIntec
# Product Storage Management Application

This is a desktop application developed in C#, designed to manage the storage and visualization of products and their related data. The application features an intuitive graphical interface that allows users to navigate through various sections, interacting with multiple product-related entities, such as brands, countries, warehouses, municipalities, suppliers, and units of measurement.
The application is connected to an SQL database, enabling users to add, modify, and update data for each of these entities. Registered products are managed through the interfaces and are ultimately displayed in a primary section called "Products".

# Features
Graphical User Interface (GUI): Easy navigation using buttons that direct to different sections.

# Management of:

-Brands: View and modify available brands.
-Countries: Manage countries associated with products.
-Warehouses: Control the warehouses where products are stored.
-Municipalities: Manage municipalities linked to suppliers.
-Suppliers: Manage suppliers and their details.
-Units of Measurement: Configure the measurement units used for products.
-SQL Database Integration: Store, update, and retrieve data in real-time.
-Consolidated Product View: Displays all registered products in a central section.

# System Requirements
.NET Framework 4.7.2 or higher
SQL Server 2019 or higher
Visual Studio 2019 (or later version recommended for development)

# Installation

1. Clone the repository:
bash
Copy code
git clone https://github.com/Rasmeh27/MiniMarket.git
2. Open the project in Visual Studio.
3. Configure the SQL database connection in the app.config file.
4. Run database migrations (if applicable).
5. Build and run the application.
   
# Usage

Navigate through the various sections by clicking on the buttons in the main menu.
In each section, you can add, modify, or delete data related to brands, countries, warehouses, municipalities, suppliers, and units of measurement.
All changes made to the entities are reflected directly in the SQL database.
The "Products" section consolidates and displays all registered products, summarizing information from other sections.
