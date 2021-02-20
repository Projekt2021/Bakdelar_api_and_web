using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net.Http;

namespace Bakdelar.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public bool Error { get; set; } = false;
        public List<Classes.Product> Products { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public async Task OnGetAsync()
        {
            //länken till ProductController i APIt

            Products = await GetProductsAsync();

            //är det inga produkter i listan är det något fel
            if (!Products.Any())
            {
                Error = true;
            }
        }


        public async Task<List<Classes.Product>> GetProductsAsync()
        {
            using var httpClient = new HttpClient();

            //hämtar listan med produkter ifrån apit
            return await httpClient.GetFromJsonAsync<List<Classes.Product>>(Classes.APIConnectionInfo.ProductsURL)
                                   .ContinueWith<List<Classes.Product>>(task =>
            {
                if(task.IsFaulted)
                {
                    Console.WriteLine(task.Exception.Message);
                    return new();
                }
                else
                {
                    return task.Result;
                }
            });

        }
    }
}
