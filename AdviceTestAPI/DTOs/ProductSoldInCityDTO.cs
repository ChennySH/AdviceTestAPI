using System;
using System.Collections.Generic;
namespace AdviceTestAPI.DTOs
{
    public class ProductSoldInCityDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string City { get; set; }
        public int QuantitySoldInTheCity { get; set; }
        public static void AddToList(List<ProductSoldInCityDTO> list, ProductSoldInCityDTO productSoldInCity)
        {
            bool IsInList = false;
            foreach (ProductSoldInCityDTO p in list)
            {
                if (!IsInList)
                {
                    if (p.ProductID == productSoldInCity.ProductID && p.City == productSoldInCity.City)
                    {
                        p.QuantitySoldInTheCity += productSoldInCity.QuantitySoldInTheCity;
                        IsInList = true;
                    }
                }
            }
            if (!IsInList)
            {
                list.Add(productSoldInCity);
            }
        }
        public static List<ProductSoldInCityDTO> GetSortedList(List<ProductSoldInCityDTO> list)
        {
            // copies list
            List<ProductSoldInCityDTO> copy = new List<ProductSoldInCityDTO>();
            foreach(ProductSoldInCityDTO p in list)
            {
                copy.Add(p);
            }
            // creates empty list
            List<ProductSoldInCityDTO> sortedList = new List<ProductSoldInCityDTO>();
            //each run the code signals the productInCity with the highest sold quantity,
            //puts it in the sortedList and removes it from the copy
            while(copy.Count > 0)
            {
                int maxIndex = 0;
                for (int i = 1; i < copy.Count; i++)
                {
                    if (copy[i].QuantitySoldInTheCity > copy[maxIndex].QuantitySoldInTheCity)
                    {
                        maxIndex = i;
                    }
                }
                ProductSoldInCityDTO maxProduct = copy[maxIndex];
                sortedList.Add(maxProduct);
                copy.RemoveAt(maxIndex);
            }
            return sortedList;
        }
        public static List<ProductSoldInCityDTO> GetTop10ProductsList(List<ProductSoldInCityDTO> list)
        {
            // get the list sorted
            List<ProductSoldInCityDTO> sortedList = GetSortedList(list);
            // leaves only top sold cities
            LeaveOnlyTopSoldCitiesPerProduct(sortedList);
            List<ProductSoldInCityDTO> top10List = new List<ProductSoldInCityDTO>();
            for (int i = 0; i < 10; i++)
            {
                if (i < sortedList.Count)
                {
                    top10List.Add(sortedList[i]);
                }
            }
            return top10List;
        }
        // gets a sorted list and leaves the items with the highest soled city for each product
        public static void LeaveOnlyTopSoldCitiesPerProduct(List<ProductSoldInCityDTO> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                // gets the product id
                int productID = list[i].ProductID;
                // removes the product in city which represent the same product in a diffrent city
                // because we get a sorted list, every product in city which is placed after the first one 
                // which presents the product is with a lower sold quantity
                if (i < list.Count - 1)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[j].ProductID == productID)
                        {
                            list.RemoveAt(j);
                        }
                    }
                }
            }
        }
    }
}
