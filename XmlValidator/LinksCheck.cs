using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace XmlValidation
{
    public class LinksCheck
    {
        private List<string> urlList = new List<string>();
        private List<string> urlListWithoutDuplicates = new List<string>();
        public void CheckUrlAndReturnIfFalse()
        {
            Console.WriteLine("\n Not Working Links");

            foreach (var item in urlListWithoutDuplicates)
            {
                if (RemoteFileExists(item) == false)
                {
                    Console.WriteLine($"Link not responding -> {item}");
                }
                else if (RemoteFileExists(item) == true)
                {
                    Console.WriteLine($"Link works -> {item}");
                }
            }
        }
        public bool RemoteFileExists(string URL)
        {
            try
            {
                WebClient wc = new WebClient();
                string HTMLSource = wc.DownloadString(URL);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void ListOfUrls()
        {
            Console.WriteLine(" All Url Links");

            foreach (var item in urlListWithoutDuplicates)
            {
                Console.WriteLine(item);
            }
        }

        public void AddLinksToListAndDeleteDuplicates(string xsdPath, string xmlPath)
        {
            string pageXsd = File.ReadAllText(xsdPath);
            string pageXml = File.ReadAllText(xmlPath);

            var linkParser = new Regex(@"((\w+:\/\/)[-a-zA-Z0-9:@;?&=\/%\+\.\*!'\(\),\$_\{\}\^~\[\]`#|]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);


            foreach (Match link in linkParser.Matches(pageXsd))
            {
                urlList.Add(link.ToString());
            }


            foreach (Match link in linkParser.Matches(pageXml))
            {
                urlList.Add(link.ToString());
            }

            urlListWithoutDuplicates = urlList.Distinct().ToList();
            urlListWithoutDuplicates.Remove("http://www.w3.org/2001/XMLSchema");
        }


        //todo
        private List<string> GetLinkFromFile(string url)
        {
            var newList = new List<string>();

            var webpage = GetHttpPage(url);
            var selectLink = File.ReadAllText(webpage);

            var linkParser = new Regex(@"((\w+:\/\/)[-a-zA-Z0-9:@;?&=\/%\+\.\*!'\(\),\$_\{\}\^~\[\]`#|]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            foreach (Match link in linkParser.Matches(selectLink))
            {
                newList.Add(link.ToString());
            }
            return newList;
        }

        private string GetHttpPage(string url)
        {
            WebClient wc = new WebClient();
            var webpage = wc.DownloadString(url);
            return webpage;
        }

        public List<string> GetUrlsString(string url)
        {
            var result = new List<string>();
            var links = GetLinkFromFile(url);

            if (links.Count() > 0)
            {
                foreach (var item in links)
                {
                    result.AddRange(GetUrlsString(item));
                }
            }

            result.AddRange(GetUrlsString(url));
            Console.WriteLine(result);
            return result;
        }
        //todo end

    }
}
