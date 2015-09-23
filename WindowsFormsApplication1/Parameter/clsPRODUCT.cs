using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.Parameter
{
    class clsPRODUCT
    {
        public string Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Pricebuy { get; set; }
        public string Pricesale { get; set; }
        public string Type_ID { get; set; }
        public string Good_Min { get; set; }
        public string Total { get; set; } 
    }
    class clsSale 
    {
        public string Product_ID { get; set; }
        public string Total { get; set; }
        public string Sale_ID { get; set; }
        public string Pricesale { get; set; } 
    }

    class clsORDER
    {
        public string Order_ID { get; set; }
        public string DateSent { get; set; } 
        public string DateReceive { get; set; }
        public string Mem_ID { get; set; }
        public string Dealer_ID { get; set; }
        public string note { get; set; }
        public string Status { get; set; }
        public string Dealer_Name { get; set; }
        public string Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Price { get; set; }
        public string Total { get; set; }
        public string ID { get; set; }
    }
    class clsSTOCK
    {
        public string Stock_ID { get; set; }
        public string Product_ID { get; set; }
        public string Total { get; set; } 
    }
    class clsCancel 
    {
        public string Exp_ID { get; set; }
        public string Product_ID { get; set; }
        public string Exp_Total { get; set; }
        public string Exp_Note { get; set; }
        public string Pricesale { get; set; }
    }
    
    
}

