using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    class SubGroup
    {
        protected
        SubgroupTitle subgrpTtl = new SubgroupTitle();
        SubAttributeDefinition subAttDef = new SubAttributeDefinition();
        List<Property> SubAtts = new List<Property>();
        Value subGrpVal = new Value();
        int SubAttCounter = 0;

        public string createAsXML()
        {
            StringBuilder subGroupBuilder = new StringBuilder();

            subAttDef.valueValue = printsubGroupAttributeXML();


            subGroupBuilder.Append(subgrpTtl.createAsXML() + "\n" +
                                subAttDef.createAsXML());
                                //have to put the attributes in the attdef value
                                

            return subGroupBuilder.ToString();

        }

        public string printsubGroupAttributeXML()
        {

            int subAttributeCount = 0;
            //properties
            StringBuilder subAttributes = new StringBuilder();
            foreach (Property element in SubAtts)
            {
                subAttributes.Append(SubAtts.ElementAt(subAttributeCount).createAsXML());
                subAttributeCount++;
            }
            return subAttributeCount.ToString();

        }
        public void AddSubAttribute(Property sa)
        {
            SubAtts.Add(sa);
            SubAttCounter++;
        }
    }
}
