using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AdviceTestAPI.DTOs;

namespace AdviceTestAPI.Controllers
{
    [ApiController]
    [Route("AdviceTestAPI")]
    public class AdviceTestAPIController : ControllerBase
    {
        [HttpGet]
        [Route("GetTopTenSoledProdouctsList")]
        public List<ProductSoldInCityDTO> GetTopTenSoledProdoucts()
        {
            List<ProductSoldInCityDTO> top10List = SqlClientClass.GetTop10ProductsSoldInCities();
            //string s = "";
            //foreach(ProductSoldInCityDTO product in top10List)
            //{
            //    s += $"{product.QuantitySoldInTheCity} products of '{product.CategoryName} - {product.ProductName}' were sold in {product.City}\n";
            //}
            //return s;
            return top10List;
        }
        //[HttpGet]
        //[Route("GetTopTenEarlyOrders")]
        //public List<OrderDTO> GetTopTenEarlyOrders()
        //{

        //}
    }
}
