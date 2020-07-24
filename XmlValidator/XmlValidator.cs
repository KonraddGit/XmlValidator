using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace XmlValidation
{
    public class XmlValidator
    {
        Results results = new Results(2);
        public XmlValidator(string filePath)
        {
            //GetAllFiles getAllFiles = new GetAllFiles();
            AddingLinks addingLinks = new AddingLinks();

            addingLinks.GetFilesRecursive(filePath);

            // var url = getAllFiles.ShowAndDownload(xsdPath, xmlPath);
            // getAllFiles.GetUrlsString(url.ToString());

            //getAllFiles.GetFiles(filePath);
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
                results.StatusOfValidation(1);
            }
            catch (Exception e)
            {
                // Get stack trace for the exception with source file information
                var st = new StackTrace(e, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                //
                Console.WriteLine(e.Message.ToString());
                results.StatusOfValidation(0);
                Errors error = new Errors(line, e.Message.ToString());
                results.Add(error);
            }
        }
        public struct Errors
        {
            public int lineNumber;
            public string errorSubstance;

            public Errors(int lineNumber, string errorSubstance)
            {
                this.lineNumber = lineNumber;
                this.errorSubstance = errorSubstance;
            }
        }
        /*
        //deklarowanie struktury:
        Results name = new Results(1);  //1-walidacja przebieła pomyślnie
                                        //0-walidacja nie powiodła się
                                        //2-brak dostępu do plików zdalnych
        name.ValidationStatus(0);
        Errors name2 = new Errors(14, "errorSubstance"); //nr lini błędu, treść błędu
        name.Add(name2);
        Errors name3 = new Errors(28, "errorSubstance"); 
        name.Add(name3);
        */
        public struct Results
        {
            public enum ValidationStatus
            {
                Failure = 0,
                Success = 1,
                Inconclusive = 2
            }
            public ValidationStatus validationStatus;

            private List<Errors> ErrorList;

            public Results(int statusOfValidation)
            {
                switch (statusOfValidation)
                {
                    case 1:
                        validationStatus = ValidationStatus.Success;
                        break;
                    case 0:
                        validationStatus = ValidationStatus.Failure;
                        break;
                    case 2:
                        validationStatus = ValidationStatus.Inconclusive;
                        break;
                    default:
                        validationStatus = ValidationStatus.Inconclusive;
                        break;
                }
                ErrorList = new List<Errors>();
            }
            public void StatusOfValidation(int statusOfValidation)
            {
                switch (statusOfValidation)
                {
                    case 1:
                        validationStatus = ValidationStatus.Success;
                        break;
                    case 0:
                        validationStatus = ValidationStatus.Failure;
                        break;
                    case 2:
                        validationStatus = ValidationStatus.Inconclusive;
                        break;
                    default:
                        validationStatus = ValidationStatus.Inconclusive;
                        break;
                }
            }

            public void Add(Errors error)
            {
                ErrorList.Add(error);
            }

        }
    }

}

