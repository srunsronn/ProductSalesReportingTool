# 🛒 Product Sales Reporting Tool

A Windows Forms application for generating detailed product sales reports with features like PDF export, Unicode/Khmer font support, and grouping by product code.

---

## ✨ Features

- 📅 Selectable date range for reports  
- 🔍 Filter sales by product name or code  
- 📊 Group by product with subtotal display  
- 📄 Export reports to PDF  
- 🌐 Supports Khmer Unicode fonts for multilingual reports

---

## 🧰 Prerequisites

- Visual Studio 2019 or 2022  
- .NET Framework 4.8  
- SQL Server or LocalDB  
- DevExpress Reporting Components  
- [Khmer OS Unicode Font](http://khmer.hawaii.edu/Fonts.html) *(optional)*

---

## 🗃️ Database Setup

1. Create a database named `ProductSalesDB`
2. Run the SQL script below to create and populate the `PRODUCTSALES` table:

```sql
CREATE TABLE PRODUCTSALES (
  ID INT IDENTITY(1,1) PRIMARY KEY,
  PRODUCTCODE NVARCHAR(20) NOT NULL,
  PRODUCTNAME NVARCHAR(100) NOT NULL,
  QUANTITY INT NOT NULL,
  UNITPRICE DECIMAL(10,2) NOT NULL,
  SALEDATE DATE NOT NULL
);

INSERT INTO PRODUCTSALES (PRODUCTCODE, PRODUCTNAME, QUANTITY, UNITPRICE, SALEDATE)
VALUES
  ('P001', 'Pen', 10, 1.50, '2025-06-20'),
  ('P001', 'Pen', 5, 1.50, '2025-06-25'),
  ('P002', 'Notebook', 3, 3.20, '2025-06-21'),
  ('P003', 'Eraser', 15, 0.80, '2025-06-22'),
  ('KH001', N'សៀវភៅ', 5, 12.99, '2025-07-04'),
  ('KH002', N'ប៊ិច', 10, 1.50, '2025-07-03'),
  ('KH003', N'ក្រដាស', 20, 5.99, '2025-07-02');
```

## 🗃️ Database Setup
The connection string is located in App.config:
<connectionStrings>
  <add name="DefaultConnection"
       connectionString="Data Source=YOUR_SERVER;Initial Catalog=ProductSalesDB;
       Integrated Security=True;MultipleActiveResultSets=True;"
       providerName="System.Data.SqlClient"/>
</connectionStrings>
💡 Replace YOUR_SERVER with your SQL Server instance name (e.g., .\SQLEXPRESS or (localdb)\MSSQLLocalDB)

## 🌐 Khmer Font Support
Download and install Khmer OS fonts:
👉 http://khmer.hawaii.edu/Fonts.html

The application will automatically select an available Unicode-compatible font.

## 🧪 How to Use
Open the solution in Visual Studio

Build and run the application

Select the desired start and end dates

Optionally enter a product code or name in the filter box

Click "Generate Report" to preview

Click "Export to PDF" to save the report

## 🛠️ Technologies Used
Windows Forms (.NET Framework 4.8)

DevExpress XtraReports

ADO.NET

SQL Server

Unicode font rendering support

## 📸 Example Output
👉 Location: /ProductSalesReportingTool/screenshoot/

## 👉 Script For Create and Seed Data generate from Sql Server
👉 Location: /ProductSalesReportingTool/ProductSalesScript.sql
