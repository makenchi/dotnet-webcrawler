﻿using DotnetCrawlerAPI.DTO;
using DotnetCrawlerAPI.Entities;
using DotnetCrawlerAPI.Services.Interfaces;
using HtmlAgilityPack;
using System.Net;

namespace DotnetCrawlerAPI.Services
{
    public class WebCrawlerService : IWebCrawlerService
    {
        public Task<List<ProductDTO>> SearchProducts(string searchOrigin, string query)
        {
            var products = getProducts(searchOrigin, query);

            throw new NotImplementedException();
        }

        private List<Comment> getComments(string productUrl)
        {
            return new List<Comment>();
        }

        private List<Product> getProducts(string searchOrigin, string query)
        {
            HtmlDocument page = crawle(string.Format("{0}{1}",searchOrigin,query));

            //https://www.kabum.com.br/busca/ps4

            var container = page.DocumentNode.SelectSingleNode("//main");
            var nodes = container.SelectNodes("//div[contains(@class,'productCard')]");

            foreach (var node in nodes)
            {

            }

            return new List<Product>();
        }

        private HtmlDocument crawle(string searchOrigin)
        {
            HtmlDocument doc = new HtmlDocument();
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("User-Agent: Other");
                string origin = client.DownloadString(searchOrigin);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(origin);

                doc = htmlDoc;
            }

            return doc;
        }
    }
}
