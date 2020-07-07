using System;
using System.Xml;
using System.Xml.Schema;

namespace XmlValidator
{
    public class XmlValidator
    {
        public XmlValidator(string xsdPath, string xmlPath)
        {
            Validate(xsdPath, xmlPath);
        }

        private void Validate(string xsdPath, string xmlPath)
        {
            XmlReaderSettings settings = new XmlReaderSettings();

            settings.Schemas.Add(null, xsdPath);
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
            

            XmlReader reader = XmlReader.Create(xmlPath, settings);
            while (reader.Read()) ;
        }

        private static void ValidationCallBack(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.WriteLine($"Warning: Matching schema not found. {args.Message}");
            else
                Console.WriteLine($"Validation error: {args.Exception.LineNumber}, {args.Message}");
        }
    }
    
   
}
