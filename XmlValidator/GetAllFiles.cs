using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using HtmlAgilityPack;

namespace XmlValidation
{
    public class GetAllFiles
    {
        public List<string> FinalList = new List<string>();
        public HashSet<string> fileList = new HashSet<string>();
        public Dictionary<string, string> urlDictionary = new Dictionary<string, string>();
        public string filePath = "C:/Users/Konrad/Desktop/Work/Repozytorium Lokalne/xmlvalidator/XmlValidator/ConsoleApp1/bin/Debug/";

        public Dictionary<string, string> notWorkingLink = new Dictionary<string, string>();
        public List<string> AddLinksToDictionaryFromHtmlAndDownload(string url)
        {
            var UrlList = new List<string>();
            string newLink = "";
            string formatedLink = "";

            HtmlWeb htmlWeb = new HtmlWeb();

            HtmlDocument document = new HtmlDocument();

            if (url != "http://www.w3.org/2001/XMLSchema")
            {
                document = htmlWeb.Load(url);

                foreach (HtmlNode link in document.DocumentNode.SelectNodes("//a[@href]"))
                {
                    string hrefValue = link.GetAttributeValue("href", string.Empty);

                    if (RemoteFileExists(hrefValue) == true)
                    {
                        UrlList.Add(hrefValue);
                    }

                    if (hrefValue.Substring(1) != "." || hrefValue.Substring(0) == "h")
                    {
                        formatedLink = hrefValue.Substring(2);

                        newLink = $"{url}" + $"{formatedLink}";

                        if (RemoteFileExists(newLink) == true)
                        {
                            UrlList.Add(newLink.ToString());
                        }
                    }
                }
            }

            return UrlList;
        }

        public void DownloadFilesFromHtml()
        {
            try
            {
                using (var client = new WebClient())
                {
                    foreach (var link in urlDictionary)
                    {
                        client.DownloadFile(link.Key, link.Value);
                    }
                }
            }
            catch (Exception)
            {
                throw;
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
        private bool RemoteFileExists(string url)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    string HtmlSource = webClient.DownloadString(url);

                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<string> LinksFromFile(string filePath)
        {
            var tempList = new List<string>();
            var result = new List<string>();
            var linkParser = new Regex(@"((\w+:\/\/)[-a-zA-Z0-9:@;?&=\/%\+\.\*!'\(\),\$_\{\}\^~\[\]`#|]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var localFiles = Directory.GetFiles(filePath, "*.xsd", SearchOption.TopDirectoryOnly).ToList();

            foreach (var file in localFiles)
            {
                fileList.Add(file);
            }

            foreach (var file in fileList)
            {
                var page = File.ReadAllText(file);

                foreach (Match link in linkParser.Matches(page))
                {
                    tempList.Add(link.ToString());
                }
            }

            foreach (string link in tempList)
            {
                if (link.Contains(".xsd") || link.Contains(".xml"))
                {
                    DownloadFile(link);
                }
                else if (!link.Contains(".xsd") || !link.Contains(".xsl"))
                {
                    foreach (var item in AddLinksToDictionaryFromHtmlAndDownload(link))
                    {
                        result.Add(item);
                    }

                    foreach (var item in result)
                    {
                        DownloadFile(item);
                    }
                }
            }

            foreach (var item in result)
            {
                tempList.Add(item);
            }

            return tempList;
        }

        public void SearchFolderRecursive(string filePath)
        {
            try
            {
                foreach (string link in LinksFromFile(filePath))
                {
                    if (!FinalList.Contains(link))
                    {
                        Console.WriteLine(link);
                        FinalList.Add(link);
                        SearchFolderRecursive(link);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            foreach (var item in urlDictionary)
            {
                Console.WriteLine(item);
            }
        }
    }
}
