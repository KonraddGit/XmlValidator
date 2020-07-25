using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace XmlValidation
{
    public class AddingLinks
    {
        public List<string> result = new List<string>();
        public Dictionary<string, string> urlDictionary = new Dictionary<string, string>();

        public List<string> notWorkingLinks = new List<string>();

        public HashSet<string> UrlList = new HashSet<string>();

        public string filePath = "C:/Users/Konrad/Desktop/Work/Repozytorium Lokalne/PlikiXml/";

        public List<string> AddLinksToDictionaryFromLocalXsd(string xsdPath)
        {
            var pageXsd = File.ReadAllText(xsdPath);
            var linkParser = new Regex(@"((\w+:\/\/)[-a-zA-Z0-9:@;?&=\/%\+\.\*!'\(\),\$_\{\}\^~\[\]`#|]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            foreach (Match link in linkParser.Matches(pageXsd))
            {
                if (RemoteFileExists(link.ToString()) == true)
                {
                    UrlList.Add(link.ToString());
                }
            }

            return UrlList.ToList();
        }

        public List<string> AddLinksToDictionaryFromLocalXml(string xmlPath)
        {
            var pageXml = File.ReadAllText(xmlPath);
            var linkParser = new Regex(@"((\w+:\/\/)[-a-zA-Z0-9:@;?&=\/%\+\.\*!'\(\),\$_\{\}\^~\[\]`#|]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            foreach (Match link in linkParser.Matches(pageXml))
            {
                if (RemoteFileExists(link.ToString()) == true)
                {
                    UrlList.Add(link.ToString());
                }
            }

            return UrlList.ToList();
        }

        public List<string> AddLinksToDictionaryFromHtmlAndDownload(string url)
        {
            string newLink = "";
            string formatedLink = "";

            HtmlWeb htmlWeb = new HtmlWeb();

            HtmlDocument document = new HtmlDocument();

            if (url != "http://www.w3.org/2001/XMLSchema" && url != "System.Collections.Generic.List`1[System.String]")
            {
                document = htmlWeb.Load(url);

                foreach (HtmlNode link in document.DocumentNode.SelectNodes("//a[@href]"))
                {
                    string hrefValue = link.GetAttributeValue("href", string.Empty);

                    if (hrefValue.Substring(2) != "")
                    {
                        formatedLink = hrefValue.Substring(2);

                        newLink = $"{url}" + $"{formatedLink}";

                        if (RemoteFileExists(newLink) == true)
                        {
                            if (!urlDictionary.ContainsKey(newLink))
                            {
                                urlDictionary.Add(newLink, formatedLink);

                                UrlList.Add(newLink.ToString());
                            }
                        }
                        else
                        {
                            notWorkingLinks.Add(newLink);
                        }
                    }
                }
            }
            DownloadFilesFromHtml();

            return UrlList.ToList();
        }

        private bool RemoteFileExists(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                string HtmlSource = webClient.DownloadString(url);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void DownloadFilesFromHtml()
        {
            using (var client = new WebClient())
            {
                foreach (var link in urlDictionary)
                {
                    client.DownloadFile(link.Key, link.Value);
                }
            }
        }

        public void DownloadFile(string url)
        {
            var formated = Path.GetFileName(url);


            if (!urlDictionary.ContainsKey(url))
            {
                urlDictionary.Add(url, formated);
            }

            DownloadFilesFromHtml();
        }

        public void SearchDirectoryForFiles()
        {
            result = Directory.GetFiles(filePath, "*.xsd", SearchOption.TopDirectoryOnly).ToList();

            foreach (var item in result)
            {
                UrlList.Add(item.ToString());
            }
        }

        public void GetLinksFromLink(string link)
        {
            if (link.Contains(filePath))
            {
                UrlList.Add(AddLinksToDictionaryFromLocalXsd(link).ToString());
            }
            else if (!link.Contains(filePath) && link.Contains(".xsd"))
            {
                DownloadFile(link);
            }
            else if (!link.Contains(".xsl"))
            {
                UrlList.Add(AddLinksToDictionaryFromHtmlAndDownload(link).ToString());
            }
        }

        public List<string> GetFilesRecursive(string link)
        {
            SearchDirectoryForFiles();

            result = UrlList.ToList();

            foreach (var item in result)
            {
                GetLinksFromLink(item);
                Console.WriteLine(item);
            }

            GetFilesRecursive(link);


            return UrlList.ToList();
        }
    }
}

