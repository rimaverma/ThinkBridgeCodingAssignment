using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopBridgeApp;
using ShopBridgeApp.Controllers;
using ShopBridgeBAL.Interface;
using ShopBridgeDAL.Model;


namespace ShopBridgeTest
{
    [TestClass]
    public class InventoryControllerTest
    {
        private static WebApplicationFactory<Startup> _factory;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [TestMethod]
        public async Task ShouldReturnSuccessResponse_forPost()
        {
            var client = _factory.CreateClient();
            var obj = new ShopBridgeItem()
            {
                ItemName = "Surf Excel",
                ItemDescription = "2 kg packet",
                ItemPrice = 200
            };
            var payload = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringcontent = new StringContent(payload,Encoding.UTF8,"application/json");
            var response = await client.PostAsync("Inventory/AddItem", stringcontent);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());

           
        }
        [TestMethod]
        public async Task ShouldReturnSuccessResponse_forPut()
        {
            var client = _factory.CreateClient();
            var obj = new ShopBridgeItem()
            {
                ItemId = 2,
                ItemName = "Surf Excel Matic TopLoad",
                ItemDescription = "2 kg packet",
                ItemPrice = 300
            };
            var payload = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var stringcontent = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("Inventory/UpdateItem/"+obj.ItemId, stringcontent);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());


        }


        [TestMethod]
        public async Task ShouldReturnSuccessResponse_forDelete()
        {
            var client = _factory.CreateClient();  
            
            var response = await client.DeleteAsync("Inventory/DeleteItem/1");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());

        }

        [TestMethod]
        public async Task ShouldReturnSuccessResponse_forGet()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("Inventory/GetItems");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());

            var json = await response.Content.ReadAsStringAsync();
            Assert.AreEqual("[{\"itemId\":2,\"itemName\":\"Surf Excel Matic TopLoad\",\"itemDescription\":\"2 kg packet\",\"itemPrice\":300},{\"itemId\":3,\"itemName\":\"Surf Excel\",\"itemDescription\":\"2 kg packet\",\"itemPrice\":200}]", json);

        }


        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }
    }
}
