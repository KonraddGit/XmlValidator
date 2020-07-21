﻿using System;
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
        public Dictionary<string, string> urlList = new Dictionary<string, string>();

        public List<string> notWorkingLinks = new List<string>();


        public void AddLinksToDictionaryFromLocalXsd(string xsdPath)
        {
            var pageXsd = File.ReadAllText(xsdPath);
            var linkParser = new Regex(@"((\w+:\/\/)[-a-zA-Z0-9:@;?&=\/%\+\.\*!'\(\),\$_\{\}\^~\[\]`#|]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            foreach (Match link in linkParser.Matches(pageXsd))
            {
                var formated = link.ToString();

                if (RemoteFileExists(formated) == true)
                {
                    urlList.Add(link.ToString(), formated);
                }
            }
        }

        public void AddLinksToDictionaryFromLocalXml(string xmlPath)
        {
            var pageXml = File.ReadAllText(xmlPath);
            var linkParser = new Regex(@"((\w+:\/\/)[-a-zA-Z0-9:@;?&=\/%\+\.\*!'\(\),\$_\{\}\^~\[\]`#|]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            foreach (Match link in linkParser.Matches(pageXml))
            {
                var formated = link.ToString();

                if (RemoteFileExists(formated) == true)
                {
                    urlList.Add(link.ToString(), formated);
                }
            }
        }

        public void AddLinksToDictionaryFromHtmlAndDownload(string url)
        {
            string newLink = "";
            string formatedLink = "";

            HtmlWeb htmlWeb = new HtmlWeb();

            HtmlDocument document = new HtmlDocument();
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
                        urlList.Add(newLink, formatedLink);
                    }
                    else
                    {
                        notWorkingLinks.Add(newLink);
                    }
                }
            }
            DownloadFilesFromHtml();
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

        public void DownloadFilesFromHtml()
        {
            using (var client = new WebClient())
            {
                foreach (var link in urlList)
                {
                    client.DownloadFile(link.Key,link.Value);
                }
            }
        }
    }
}
