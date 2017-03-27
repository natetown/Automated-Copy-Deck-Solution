using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    class SubAttributeDefinition
    {
        protected
        Item definitionItem = new Item("item", "SubgroupDefinition");
        Value definitionValue = new Value();
        public string createAsXML()
        {
            string subGrpDefXML = definitionItem.createAsXML() + "\n";

            return subGrpDefXML;
        }
        public string valueValue { get; set; } = "";
    }


}
