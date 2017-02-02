using System;
using System.Collections.Generic;
using System.Web.Mvc;
using HtmlAgilityPack;

namespace Sample_ASP.NetMVC5_HtmlAgilityPackBasic.Controllers
{
    public class WebCrawlerController : Controller
    {
        // GET: WebCrawler
        public ActionResult Index()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("http://testing-ground.scraping.pro/blocks");

            HtmlNode node = doc.DocumentNode.SelectSingleNode("//div[@id='case1']");  
            node.ParentNode.RemoveChild(node);

            node = doc.DocumentNode.SelectSingleNode("//div[@id='case2']");
            node.SetAttributeValue("id", "case1");

            node = doc.DocumentNode.SelectSingleNode("//h2//text()") ;  
            (node as HtmlTextNode).Text = "Case 1 (With Deleted Items)";

            //Getting the elements inside the document
            var stringList = new List<String>();
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@id='case1']");
                foreach (HtmlNode tempNode in nodes[0].ChildNodes)
                {
                    var a = tempNode.SelectSingleNode("div//text()") as HtmlTextNode;
                    if (a != null)
                    {
                        stringList.Add(a.Text);
                    }
                }

            ViewBag.Html = doc.DocumentNode.OuterHtml;
            return View();
        }
    }
}