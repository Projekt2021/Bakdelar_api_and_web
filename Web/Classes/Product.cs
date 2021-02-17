using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bakdelar.Classes
{
    public class Product
    {
        /*
         * "id": 15,
    "productName": "Mortel",
    "productDescription": "En mortel i trä",
    "productImageID": 16,
    "productImage": {
      "productImageID": 16,
      "imageUrl": "\\images\\products\\mortel.jpg",
      "productID": null
    },
    "categoryID": 0,
    "salePrice": 39
         */
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductImageID { get; set; }
        public ProductImage ProductImage { get; set; }
        public int CategoryID { get; set; }
        public double SalePrice { get; set; }

    }
}
