using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShopBridgeDAL;
using ShopBridgeDAL.Model;

namespace ShopBridgeBAL.Interface
{
    public interface IShopBridgeInvItem
    {
       Task <ReturnObject> AddItem(ShopBridgeItem shopBridgeItem);
        Task<ReturnObject> ModifyItem(ShopBridgeItem shopBridgeItem);

        Task<ReturnObject> DeleteItem(int itemID);

       Task < IEnumerable<ShopBridgeItem> >GetItemList();
    }
}
