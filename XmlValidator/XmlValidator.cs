using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace XmlValidation
{
    public class XmlValidator
    {
        public XmlValidator(string xmlPath, string xsdPath)
        {
            GetAllFiles getAllFiles = new GetAllFiles();

            getAllFiles.ShowAndDownload(xsdPath,xmlPath);
        }


        private void Validator(string xsdPath, string xmlPath)
        {

            try
            {

                ValidationEvents validationEvents = new ValidationEvents();
                XmlReaderSettings Xsettings = new XmlReaderSettings();
                Xsettings.Schemas.Add(null, xsdPath);

                Xsettings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
                Xsettings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
                Xsettings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                Xsettings.ValidationEventHandler += new ValidationEventHandler(validationEvents.ValidationCallBack);

                Xsettings.ValidationType = ValidationType.Schema;

                XmlDocument document = new XmlDocument();
                document.Load(xmlPath);

                XmlReader reader = XmlReader.Create(new StringReader(document.InnerXml), Xsettings);


                while (reader.Read()) ;

                Console.WriteLine("\n Successful Validation");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());

            }
        }
    }

}

