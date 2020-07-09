using System;
using System.Net;
using System.Xml;
using System.Xml.Schema;

namespace XmlValidation
{
    public class XmlValidator
    {
        
        public XmlValidator(string xmlPath, string xsdPath)
        {
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add(null, xsdPath);

            Validate(schemaSet, xmlPath);
        }
        
        private void Validate(XmlSchemaSet schemaSet, string xmlPath)
        {

            XmlSchema compiledSchema = null;

            foreach (XmlSchema schema in schemaSet.Schemas())
            {
                compiledSchema = schema;
            }

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(compiledSchema);
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            settings.ValidationType = ValidationType.Schema;

            using (var reader = XmlReader.Create(xmlPath, settings))
            {
                while (reader.Read()) ;
            };

        }

        private void ValidationCallBack(object sender, ValidationEventArgs args)
        {
            switch (args.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine($"Error w lini {args.Exception.LineNumber}, {args.Message}");
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine($"Warning w lini {args.Exception.LineNumber}, {args.Message}");
                    break;
            }
        }

        static private bool LinkAvailabity(string xsdLocation) //True: all links work, False:at least one link doesn't work
        {
            int a, b;
            string link, fragment;
            string[] lines = System.IO.File.ReadAllLines(xsdLocation);
            foreach (string line in lines)
            {
                if (line.Contains(".xsd") && line.Contains("http://"))
                {
                    a = line.IndexOf("http://");
                    b = line.IndexOf(".xsd");
                    fragment = line.Substring(a, b - a + 4);
                    if (CountStringOccurrences(fragment, "http://") > 1)
                    {
                        fragment = fragment.Substring(5);
                        a = fragment.IndexOf("http://");
                        b = fragment.IndexOf(".xsd");
                    }
                    link = fragment.Substring(a, b - a + 4);

                    if (!RemoteFileExists(link))
                    {
                        Console.WriteLine("problem with a link:   ");
                        Console.WriteLine(link);
                        return false;
                    }
                }
            }
            return true;
        }
        static private bool RemoteFileExists(string url) // True : If the file exits, False if file not exists
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
        }
        public static int CountStringOccurrences(string text, string pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }
    }


}


