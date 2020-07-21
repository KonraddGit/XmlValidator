using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlValidator
{
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
