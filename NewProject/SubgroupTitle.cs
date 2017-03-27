using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    class SubgroupTitle
    {
        protected
        Item definitionItem = new Item("item", "SubgroupTitle");
        Value definitionValue = new Value();

        public string createAsXML()
        {
            string subGrpTtlXML = definitionItem.createAsXML() + "\n" +
            definitionValue.createAsXML() + "\n";
            return subGrpTtlXML;
        }
    }
}
