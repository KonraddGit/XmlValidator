using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using XmlValidation.Models;
using System.Linq;

namespace XmlValidation
{
    public class LinksCheck
    {
        private List<string> urlList = new List<string>();
        private List<string> urlListWithoutDuplicates = new List<string>();
        public void CheckUrlAndReturnIfFalse(Links link)
        {
            Console.WriteLine("Fałszywe linki");

            foreach (var item in urlListWithoutDuplicates)
            {
                if (RemoteFileExists(item) == false)
                {
                    Console.WriteLine(item);
                }
                else
                {
                    Console.Write(" - brak");
                }
            }
        }

        public void ListOfUrls()
        {
            Console.WriteLine("lista wszystkich url");

            foreach (var item in urlListWithoutDuplicates)
            {
                Console.WriteLine(item);
            }
        }

        public void AddLinksToListAndDeleteDuplicates(string xsdPath, string xmlPath)
        {
            string pageXsd = File.ReadAllText(xsdPath);
            string pageXml = File.ReadAllText(xmlPath);

            var linkParser = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", RegexOptions.Compiled | RegexOptions.IgnoreCase);


            foreach (Match link in linkParser.Matches(pageXsd))
            {
                urlList.Add(link.ToString());
            }


            foreach (Match link in linkParser.Matches(pageXml))
            {
                urlList.Add(link.ToString());
            }

            urlListWithoutDuplicates = urlList.Distinct().ToList();
        }

        private bool RemoteFileExists(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();

                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
        }

    }
}
