using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Models
{
    public class ProductsModel
    {
        public int Id { get; set; }
        public int catId { get; set; }
        public string name { get; set; }

        public string description { get; set; }
        public string image { get; set; }

        public int price { get; set; }
    }
}
