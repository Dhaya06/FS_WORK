using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class CartList
    {
        public string productID { set; get; }
        public string name { set; get; }
        public string quantity { set; get; }
        public decimal amount { set; get; }
        public decimal discountRate { set; get; }
        public decimal discount { set; get; }
        public decimal vatRate { set; get; }
        public decimal varAMount{ set;  get;}
        public decimal totalAmount { set; get; }
        public decimal price { get; set; }
        public string type { set; get; } 
        public int tileID{set;get;}
        public bool weightedproduct { set; get; }
        public string measuringUnit { set; get; }
       // public string quanText { set; get; } //this is to store data of quanitty and the exact cost

        public List<CartSaleProductList> StockOrderList { get; set; }

    }
}
