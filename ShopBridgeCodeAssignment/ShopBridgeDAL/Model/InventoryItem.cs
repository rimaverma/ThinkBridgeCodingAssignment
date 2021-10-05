using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopBridgeDAL.Model
{
    public class ShopBridgeItem
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public double ItemPrice { get; set; }
    }
}
