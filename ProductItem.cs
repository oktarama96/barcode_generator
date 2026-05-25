using System;

namespace NetBarcodeDotNet
{
    public class ProductItem
    {
        public string Barcode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0.00m;
        public int CopyCount { get; set; } = 1;

        public ProductItem() { }

        public ProductItem(string barcode, string name, decimal price, int copyCount)
        {
            Barcode = barcode;
            Name = name;
            Price = price;
            CopyCount = copyCount;
        }
    }
}
