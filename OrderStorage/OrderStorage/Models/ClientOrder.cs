using Newtonsoft.Json;
using System;

namespace OrderStorage.Models
{
    public class ClientOrder
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public Customer customer { get; set; }
        public Item item { get; set; }            
    }

}