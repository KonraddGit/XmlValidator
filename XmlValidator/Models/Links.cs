using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlValidation.Models
{

    public class Links
    {
        public List<string> urlListWithoutDuplicates = new List<string>();
        public string Url { get; set; }
    }
}
