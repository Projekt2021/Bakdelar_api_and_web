using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bakdelar.Classes
{
    class APIConnectionInfo
    {

        /*
         *"API_ConnectionSettings": {
         *"IP": "https://localhost",
         *"Port": "5001",
         *"Controllers": {
         *   "Products": "api/Products",
         *   "ProductImages": "api/ProductImages"
         *  }
         *}
         */



        private static readonly JToken APIConnectionNode = JObject.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + "\\appSettings.json")).SelectToken("API_ConnectionSettings");




        private static string IP
        {
            get
            {
                return APIConnectionNode.SelectToken("IP")
                                        .Value<string>();
            }
        }



        private static string Port 
        { 
            get 
            { 
                return APIConnectionNode.SelectToken("Port")
                                        .Value<string>();
            }
        }
        private static string ProductsController 
        { 
            get 
            { 
                return APIConnectionNode.SelectToken("Controllers")
                                        .SelectToken("Products")
                                        .Value<string>();
            } 
        }
        private static string ProductImagesController 
        { 
            get 
            {
                return APIConnectionNode.SelectToken("Controllers")
                                        .SelectToken("ProductImages")
                                        .Value<string>();
            } 
        }

        public static string CategoriesController
        {
            get
            {
                return APIConnectionNode.SelectToken("Controllers")
                                        .SelectToken("Categories")
                                        .Value<string>();
            }
        }

        public static string ProductsURL
        {
            get
            {
                return $"{IP}:{Port}/{ProductsController}";
            }
        }

        public static string ProductImagesURL
        {
            get
            {
                return $"{IP}:{Port}/{ProductImagesController}";
            }
        }
        public static string CategoriesURL
        {
            get
            {
                return $"{IP}:{Port}/{CategoriesController}";
            }
        }
    }
}
