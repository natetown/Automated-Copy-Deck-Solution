using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    class Property
    {
        public Item NAME = new Item("item", "NAME");
        public Item VALUE = new Item("item", "VALUE");
        public string createAsXML() {
            string propertyXML = NAME.createAsXML() + "\n" +
                                 VALUE.createAsXML() + "\n";
            return propertyXML;
        }
    }
}
