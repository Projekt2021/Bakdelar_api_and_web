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

            using var httpClient = new HttpClient();

            //hämtar listan med produkter ifrån apit
            Products = await httpClient.GetFromJsonAsync<List<Classes.Product>>(Classes.APIConnectionInfo.ProductsURL);


            //är det inga produkter i listan är det något fel
            if (!Products.Any())
            {
                Error = true;
            }
        }
    }
}
