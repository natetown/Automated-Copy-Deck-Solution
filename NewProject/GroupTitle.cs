using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    class GroupTitle
    {
        public Item definitionItem = new Item("item", "GroupTitle");
        public string valueValue { get; set; } = "";
        protected
        Value definitionValue = new Value();

        public string createAsXML()
        {
            string grpTtlXML = "<item name=" + "\"" + "TYPE" + "\"" + ">" +
                               "<value>" + valueValue + "</value>" +
                               "</item>";


            return grpTtlXML;
        }
    }


}
