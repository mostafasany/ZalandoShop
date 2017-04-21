using System;

namespace ZalandoShop.Models.Response
{
    public class PriceResponse
    {
        public string currency { get; set; }
        public float value { get; set; }
        public string formatted { get; set; }
    }
}
