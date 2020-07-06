using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.IO;

namespace XmlValidator
{
    public class XmlValidator
    {
        public XmlValidator(string xsdPath, string xmlPath, string xmlns)
        {
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add(xmlns, xsdPath);
            Validate(xmlPath, schemaSet);
        }

        private static void Validate(string filename, XmlSchemaSet schemaSet)
        {
            XmlSchema compiledSchema = null;

            foreach (XmlSchema schema in schemaSet.Schemas())
            {
                compiledSchema = schema;
            }

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(compiledSchema);
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
            settings.ValidationType = ValidationType.Schema;

            XmlReader vreader = XmlReader.Create(filename, settings);

            while (vreader.Read()) { }

            vreader.Close();
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
