using Newtonsoft.Json;
using System;

namespace OrderStorage.Models
{
    public class Customer
    {
        public string Name { get; set; }        
        public string Address { get; set; }
        public string City { get; set; }        
    }

}