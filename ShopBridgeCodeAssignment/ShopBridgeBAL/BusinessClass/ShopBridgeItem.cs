using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ShopBridgeBAL.Interface;
using System.Linq;
using ShopBridgeDAL.Model;
using System.Threading.Tasks;

namespace ShopBridgeBAL.BusinessClass
{
   public class ShopBridgeInvItem : IShopBridgeInvItem
    {
        InventoryItemDBContext invDbContext = new InventoryItemDBContext();
        ReturnObject objReturn = new ReturnObject();
       public ShopBridgeInvItem()
        {
           
        }

        public async Task<ReturnObject> AddItem(ShopBridgeDAL.Model.ShopBridgeItem shopBridgeItem)
        {
            
            objReturn.isSucess = false;
            try
            {
                invDbContext.ShopBridgeItems.Add(shopBridgeItem);
                var result = await invDbContext.SaveChangesAsync();
                if (result > 0)
                {
                    objReturn.isSucess = true;
                }
            }
            catch (Exception ex)
            {
                objReturn.failureMsg = ex.Message;
                objReturn.isSucess = false;
            }

            return  objReturn;
        }

        public async Task<ReturnObject> DeleteItem(int itemID)
        {
           
            objReturn.isSucess = false;
            try
            {
                var ShopBridgeItem = invDbContext.ShopBridgeItems.FirstOrDefault(x => x.ItemId == itemID);
                invDbContext.ShopBridgeItems.Remove(ShopBridgeItem);
                var result = await invDbContext.SaveChangesAsync();
                if (result > 0)
                {
                    objReturn.isSucess = true;
                }
            }
            catch (Exception ex)
            {
                objReturn.failureMsg = ex.Message;
                objReturn.isSucess = false;
            }
            return objReturn;

        }

        public async Task<IEnumerable<ShopBridgeDAL.Model.ShopBridgeItem> >GetItemList()
        {
            return  await invDbContext.ShopBridgeItems.ToListAsync();
        }

        public async Task<ReturnObject> ModifyItem(ShopBridgeDAL.Model.ShopBridgeItem shopBridgeItem)
        {
            
            objReturn.isSucess = false;
            try
            {
                invDbContext.ShopBridgeItems.Update(shopBridgeItem);
                var result =  await invDbContext.SaveChangesAsync();
                if (result > 0)
                {
                    objReturn.isSucess = true;
                }
            }
            catch (Exception ex)
            {
                objReturn.failureMsg = ex.Message;
                objReturn.isSucess = false;
            }
            return objReturn;


        }
        
    }
}
