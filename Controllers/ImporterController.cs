using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CoronaBot.Models;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using CoronaBot.Models.Tools;

namespace CoronaBot.Controllers
{
    public class ImporterController : Controller
    {
        readonly NHibernate.ISession _session;

        public ImporterController()
        {
            _session = NHibernateSession.OpenSession();
        }


        //public async Task<IActionResult> Importer()
        public IActionResult Index()
        {
            HtmlSanitizer sanitizer = new HtmlSanitizer();

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load("https://www.worldometers.info/coronavirus/");


            // foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//table[@id='main_table_countries_today']//tbody//tr"))
            //  {

            //  }
            //HtmlNodeCollection 

            /*DateTime DateCreated;
            string RegionName;
            string SourceName;
            int CasesTotal;
            int CasesNew;
            int DeathsTotal;
            int DeathsNew;
            int RecoveredTotal;
            int Active;
            int ActiveCritical;
            int RatioCasesTo1M;
            */
            int i;

        var nodes = htmlDoc.GetElementbyId("main_table_countries_today").SelectNodes("//tbody//tr");
            foreach (HtmlNode node in nodes)
            {
                LogImportData logData = new LogImportData();
                logData.DateCreated = DateTime.Now;
                i = 0;
                
                
                //var subNodes = node.SelectNodes("//td");

                foreach (HtmlNode subNode in node.ChildNodes)
                {
                    if (subNode.Name == "td")
                    {

                        if (i == 0)
                        {
                            if (subNode.HasChildNodes)
                            {
                                var a = subNode.FirstChild;
                                if (a.Name == "a")
                                    logData.RegionName = subNode.InnerText.Trim();
                                else
                                    logData.RegionName = subNode.InnerText.Trim();
                            }
                            else
                            {
                                logData.RegionName = subNode.InnerText.Trim();
                            }
                        }
                        if (i == 1)
                        {
                            logData.CasesTotal = sanitizer.SanitizeInt(subNode.InnerText); 
                        }
                        if (i == 2)
                        {
                            logData.CasesNew = sanitizer.SanitizeInt(subNode.InnerText);
                        }
                        if (i == 3)
                        {
                            logData.DeathsTotal = sanitizer.SanitizeInt(subNode.InnerText);
                        }
                        if (i == 4)
                        {
                            logData.DeathsNew = sanitizer.SanitizeInt(subNode.InnerText);
                        }
                        if (i == 5)
                        {
                            logData.RecoveredTotal = sanitizer.SanitizeInt(subNode.InnerText);
                        }
                        if (i == 6)
                        {
                            logData.Active = sanitizer.SanitizeInt(subNode.InnerText);
                        }
                        if (i == 7)
                        {
                            logData.ActiveCritical = sanitizer.SanitizeInt(subNode.InnerText);
                        }
                        if (i == 8)
                        {
                            logData.RatioCasesTo1M = sanitizer.SanitizeInt(subNode.InnerText);
                        }


                        i++;
                    }
                }


                if (logData.RegionName == "Total:")
                    break;

                _session.Save(logData);

            }

            /*
            var nodes = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='main_table_countries_today']").SelectNodes("//tbody//tr");
            foreach (HtmlNode node in nodes)
            {
                var subNodes = node.SelectNodes("//td");



            }*/

            //var myTripsDiv = htmlDoc.DocumentNode.SelectSingleNode("//table[@id='main_table_countries_today']");
            //var myTripsDiv = htmlDoc.DocumentNode.SelectSingleNode("//table[@id='main_table_countries_today']");
            //var myTripsNode = HtmlNode.CreateNode(myTripsDiv.InnerHtml);
            //var liOfTravels = myTripsNode.SelectNodes("//tbody//tr");


            //var tbody = node.Element("tbody");
            //var rows = tbody.SelectNodes("//tr");

            //HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("item[@id='main_table_countries_today'//tbody//tr");

            /*
            // get answer in non-blocking way
            using (var response = await client.GetAsync("https://www.worldometers.info/coronavirus/"))
            {
                using (var content = response.Content)
                {
                    // read answer in non-blocking way
                    var result = await content.ReadAsStringAsync();
                    var document = new HtmlDocument();
                    document.LoadHtml(result);

                    var nodes = document.GetElementbyId("main_table_countries_today");
                    //Some work with page....
                }
            }*/



            //_session.Save(logData);


            return Ok();
        }
    }
}