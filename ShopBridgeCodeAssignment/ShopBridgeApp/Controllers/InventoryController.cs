using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopBridgeBAL.Interface;
using ShopBridgeDAL.Model;

namespace ShopBridgeApp.Controllers
{
    [ApiController]
    [Route("Inventory")]
    public class InventoryController: ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private IShopBridgeInvItem _shopBridge;

        public InventoryController(ILogger<InventoryController> logger, IShopBridgeInvItem shopBridge)
        {
            _logger = logger;
            _shopBridge = shopBridge;
        }

        [HttpGet]
        [Route("GetItems")]
        public async Task< IEnumerable<ShopBridgeItem>> Get()
        {

            return  await _shopBridge.GetItemList();
        }

        [HttpPost]
        [Route("AddItem")]
        public async Task<bool> PostItem(ShopBridgeItem item)
        {
           var result = await _shopBridge.AddItem(item);
            if(!result.isSucess)
            {
                _logger.LogError(result.failureMsg);
            }
            return result.isSucess;
        }

        [HttpPut]
        [Route("UpdateItem/{itemid}")]
        public async Task<bool> UpdateItem(int itemid,ShopBridgeItem item)
        {
            item.ItemId = itemid;
            var result = await _shopBridge.ModifyItem(item);
            if (!result.isSucess)
            {
                _logger.LogError(result.failureMsg);
            }
            return result.isSucess;
        }

        [HttpDelete]
        [Route("DeleteItem/{itemid}")]
        public async Task<bool> DeleteItem(int itemid)
        {
            var result = await _shopBridge.DeleteItem(itemid);
            if (!result.isSucess)
            {
                _logger.LogError(result.failureMsg);
            }
            return result.isSucess;
        }

    }
}
