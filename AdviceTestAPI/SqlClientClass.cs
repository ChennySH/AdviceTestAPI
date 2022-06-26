using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AdviceTestAPI.DTOs;

namespace AdviceTestAPI
{
    public class SqlClientClass
    {
        public static List<ProductSoldInCityDTO> GetTop10ProductsSoldInCities()
        {
            List<ProductSoldInCityDTO> productsInCitiesList = new List<ProductSoldInCityDTO>();
            string connectionString =
                "Data Source=localhost\\sqlexpress;Initial Catalog=BikeStores;"
                + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT [orders].[order_id]" +
                ",[order_items].[product_id]" +
                ",[products].[product_name]" +
                ",[categories].[category_id]" +
                ",[categories].[category_name]" +
                ",[order_items].[quantity]" +
                ",[stores].[city] " +
                "FROM [BikeStores].[sales].[orders] " +
                "INNER JOIN [BikeStores].[sales].[order_items] " +
                "ON [BikeStores].[sales].[orders].order_id = [BikeStores].[sales].[order_items].[order_id] " +
                "INNER JOIN [BikeStores].[sales].stores " +
                "ON [BikeStores].[sales].[orders].[store_id]=[BikeStores].[sales].[stores].[store_id] " +
                "INNER JOIN [BikeStores].[production].[products] " +
                "ON [BikeStores].[sales].[order_items].[product_id]=[BikeStores].[production].[products].[product_id] " +
                "INNER JOIN [BikeStores].[production].[categories] " +
                "ON [BikeStores].[production].[products].[category_id] = [BikeStores].[production].[categories].[category_id]" +
                "ORDER BY [orders].[order_id]";



            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductSoldInCityDTO.AddToList(productsInCitiesList, new ProductSoldInCityDTO
                        {
                            ProductID = reader.GetInt32(1),
                            ProductName = reader.GetString(2),
                            CategoryID = reader.GetInt32(3),
                            CategoryName = reader.GetString(4), 
                            City = reader.GetString(6),
                            QuantitySoldInTheCity = reader.GetInt32(5)
                        });
                    }
                    reader.Close();
                    List<ProductSoldInCityDTO> top10List = ProductSoldInCityDTO.GetTop10ProductsList(productsInCitiesList);
                    return top10List;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return null;
        }
    }
}
