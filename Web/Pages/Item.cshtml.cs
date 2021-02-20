using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace Bakdelar.Pages
{
    public class ItemModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public bool Error { get; set; } = false;

        public Classes.Product Product { get; set; }
        public void OnGet()
        {

            if (string.IsNullOrWhiteSpace(Id))
            {
                Error = true;
            }
            else
            {
                try
                {
                    using var httpClient = new HttpClient();

                    //link to the product in the API
                    string productApiLink = "https://localhost:44347/api/Products/" + Id;



                    //gets the data for the product from api
                    Product = httpClient.GetFromJsonAsync<Classes.Product>(Classes.APIConnectionInfo.ProductsURL + $"/{Id}").Result;

                    //sets the title to the product name
                    ViewData["Title"] = Product.ProductName;
                }
                catch(AggregateException)
                {
                    Error = true;
                }
            }
            
        }
    }
}
