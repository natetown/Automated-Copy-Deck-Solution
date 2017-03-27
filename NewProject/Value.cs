using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    class Value
    {
        public void setvalueAttribute(string x)
        {
            valueAttribute = x;
           
        }
        public string getvalueAttribute()
        {
            return valueAttribute;
        }
        public void setvalue(string x)
        {
            value = x;

        }
        public string getvalue()
        {
            return value;
        }
        public string createAsXML()
        {

            return "<" + valueAttribute + ">" + value + "</" + valueAttribute + ">" + "\t";
        }

        protected
        string valueAttribute = "value";
        List<Item> itemsInValues = new List<Item>();
        string value = "";
    }
}
