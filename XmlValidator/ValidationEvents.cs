using System;
using System.Xml.Schema;

namespace XmlValidation
{
    public class ValidationEvents
    {
        public void ValidationCallBack(object sender, ValidationEventArgs args)
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

    }
}
