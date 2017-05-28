using Newtonsoft.Json;
using System;

namespace OrderStorage.Models
{
    public class Item
    {     
        public string ProductType { get; set; }
        public string Article { get; set; }
        public int Amount { get; set; }        
    }

}