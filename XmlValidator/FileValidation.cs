using System;
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
    }


}
