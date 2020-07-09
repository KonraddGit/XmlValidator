﻿using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using XmlValidation.Models;
using System.Linq;
using System.Diagnostics;

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
        
    }
}