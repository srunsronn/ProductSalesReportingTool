-- Clean Version after I generate the script in the SQL Server
-- Create Database
CREATE DATABASE [SalesReportDB];
GO

USE [SalesReportDB];
GO

-- Create PRODUCTSALES Table
CREATE TABLE [dbo].[PRODUCTSALES] (
    [SALEID] INT PRIMARY KEY,
    [PRODUCTCODE] NVARCHAR(20),
    [PRODUCTNAME] NVARCHAR(100),
    [QUANTITY] INT,
    [UNITPRICE] DECIMAL(18, 2),
    [SALEDATE] DATE
);
GO

-- Seed Sample Data
INSERT INTO [dbo].[PRODUCTSALES] ([SALEID], [PRODUCTCODE], [PRODUCTNAME], [QUANTITY], [UNITPRICE], [SALEDATE])
VALUES 
(1, N'P001', N'Pen', 10, 1.50, '2025-06-20'),
(2, N'P001', N'Pen', 5, 1.50, '2025-06-25'),
(3, N'P002', N'Notebook', 3, 3.20, '2025-06-21'),
(4, N'P003', N'Eraser', 15, 0.80, '2025-06-22'),
(5, N'KH001', N'សៀវភៅ', 5, 12.99, '2025-07-04'),  -- Book (Khmer)
(6, N'KH002', N'ប៊ិច', 10, 1.50, '2025-07-03'),      -- Pen (Khmer)
(7, N'KH003', N'ក្រដាស', 20, 5.99, '2025-07-02');    -- Paper (Khmer)
GO

-- Create Stored Procedure for Report
CREATE PROCEDURE [dbo].[sp_GetProductSales]
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        PRODUCTCODE,
        PRODUCTNAME,
        QUANTITY,
        UNITPRICE,
        SALEDATE
    FROM [dbo].[PRODUCTSALES]
    WHERE SALEDATE BETWEEN @StartDate AND @EndDate
    ORDER BY PRODUCTCODE, SALEDATE;
END
GO
