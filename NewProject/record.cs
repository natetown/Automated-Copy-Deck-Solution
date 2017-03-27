using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    class record
    {
        public record(string Cid)
        {

            Content_ID = Cid;
        }
        public string createAsXML() {
            return "<record name=\"" + Content_ID + "\" type=\"content\">" + "\n" + valueValue + "</record>";
        }
        string Content_ID;
        public string valueValue { get; set; }
    }
}
