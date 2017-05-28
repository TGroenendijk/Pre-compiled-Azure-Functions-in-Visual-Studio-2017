using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.Azure.WebJobs;
using OrderStorage.Models;

namespace OrderStorage.Repositories
{
    public class OrderRepository
    {
        #region GetOrderById
        public ClientOrder Find(string id, CloudTable table)
        {
            ClientOrder resOrd = null;
            
            TableOperation operation = TableOperation.Retrieve<TableOrder>("Orders", id);
            TableResult result = table.Execute(operation);

            if (result.Result != null)
            {
                TableOrder obj = (TableOrder)result.Result;

                Customer cus = new Customer();
                cus.Name = obj.Name;
                cus.Address = obj.Address;
                cus.City = obj.City;

                Item itm = new Item();
                itm.ProductType = obj.ProductType;
                itm.Article = obj.Article;
                itm.Amount = obj.Amount;

                ClientOrder ord = new ClientOrder();
                ord.Id = obj.RowKey;
                ord.customer = cus;
                ord.item = itm;     

                resOrd = ord;
            }

            return resOrd;
        }
        #endregion


        #region AddOrder
        public void Add(ref ICollector<TableOrder> table, ClientOrder order)
        { 

            table.Add(new TableOrder()
            {
                PartitionKey = "Orders",
                RowKey = order.Id,
                Name = order.customer.Name,
                Address = order.customer.Address,
                City = order.customer.City,
                ProductType = order.item.ProductType,
                Article = order.item.Article,
                Amount = order.item.Amount               
            });
        }
        #endregion


        #region UpdateOrderById
        public bool Update(ref CloudTable table, ClientOrder order)
        {
            bool updated = false;

            TableOperation operation = TableOperation.Retrieve<TableOrder>("Orders", order.Id);
            TableResult result = table.Execute(operation);

            if (result.Result != null)
            {
                TableOrder obj = (TableOrder)result.Result;
                obj.Name = order.customer.Name;
                obj.Address = order.customer.Address;
                obj.City = order.customer.City;
                obj.ProductType = order.item.ProductType;
                obj.Article = order.item.Article;
                obj.Amount = order.item.Amount;

                operation = TableOperation.Replace(obj);
                table.Execute(operation);

                updated = true;
            }

            return updated;
        }
        #endregion

        #region RemoveOrderById
        public bool Remove(ref CloudTable table, string id)
        {
            bool deleted = false;

            TableOperation operation = TableOperation.Retrieve<TableOrder>("Orders", id);
            TableResult result = table.Execute(operation);

            if (result.Result != null)
            {
                TableOrder obj = (TableOrder)result.Result;

                TableOperation deleteOperation = TableOperation.Delete(obj);

                // Execute the operation.
                table.Execute(deleteOperation);

                deleted = true;
            }
            
            return deleted;
        }
        #endregion
    }
}
