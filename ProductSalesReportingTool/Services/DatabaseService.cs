using ProductSalesReportingTool.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSalesReportingTool.Services
{
    public class DatabaseService
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public List<SaleDto> GetSales(DateTime startDate, DateTime endDate)
        {
            var sales = new List<SaleDto>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    //query to fetch sales data based on date range
                    string query = "SELECT PRODUCTCODE, PRODUCTNAME, QUANTITY, UNITPRICE, SALEDATE " +
                                    "FROM PRODUCTSALES " +
                                    "WHERE SALEDATE BETWEEN @StartDate AND @EndDate";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    //input parameters 
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        sales.Add(new SaleDto
                        {
                            ProductCode = reader["PRODUCTCODE"].ToString(),
                            ProductName = reader["PRODUCTNAME"].ToString(),
                            Quantity = Convert.ToInt32(reader["QUANTITY"]),
                            UnitPrice = Convert.ToDecimal(reader["UNITPRICE"]),
                            SaleDate = Convert.ToDateTime(reader["SALEDATE"]),
                        });
                    }

                }

            }catch(Exception ex)
            {
                System.IO.File.AppendAllText("logs/errors.txt", ex.Message + Environment.NewLine);

            }
            return sales;

        }
    }
}
