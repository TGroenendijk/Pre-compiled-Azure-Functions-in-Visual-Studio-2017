using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Table;


namespace OrderStorage.Models
{
    public class TableOrder : TableEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }    
        public string ProductType { get; set; }
        public string Article { get; set; }
        public int Amount { get; set; }         
    }
}
