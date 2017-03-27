using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    class Group
    {
        public GroupTitle grpTtl = new GroupTitle();
        public List<Property> GrpAtts = new List<Property>();
        protected
            GroupAttributeDefinition grpAttDef = new GroupAttributeDefinition();
            SubgroupDefinition subGrpDef = new SubgroupDefinition();
            List<SubGroup> grpSubGrps = new List<SubGroup>();
            Value subGrpVal = new Value();
            public string valueValue { get; set; } = "";
            int GrpAttCounter = 0;
            int subGroupCounter = 0;

        public string createAsXML()
        {
            StringBuilder groupBuilder = new StringBuilder();

            grpAttDef.valueValue = printGroupAttributeXML();
            subGrpDef.valueValue = printSubGroupsXML();

            groupBuilder.Append(grpTtl.createAsXML());                                

            return groupBuilder.ToString();

        }

        public string printGroupAttributeXML()
        {

            int attributeCount = 0;
            //properties
            StringBuilder attributes = new StringBuilder();
            foreach (Property element in GrpAtts)
            {
                attributes.Append(GrpAtts.ElementAt(attributeCount).createAsXML());
                attributeCount++;
            }
            return attributes.ToString();

        }
        public string printSubGroupsXML()
        {

            int subGroupCount = 0;
            //properties
            StringBuilder subGrps = new StringBuilder();
            foreach (SubGroup element in grpSubGrps)
            {
                subGrps.Append(grpSubGrps.ElementAt(subGroupCount).createAsXML());
                subGroupCount++;
            }
            return subGrps.ToString();

        }
        public string printFriendlyGroupTitleXML()
        {
            string friendlyGroupTitle = "\t" + grpTtl.valueValue +
                Environment.NewLine;  //value; //Title
            //the current property's name.valueValue VALUE.valueValue
            return friendlyGroupTitle;
        }
        public void AddGroupattribute(Property p)
        {
            GrpAtts.Add(p);
            GrpAttCounter++;
        }
        public void AddSubGroup(SubGroup sg)
        {
            grpSubGrps.Add(sg);
            subGroupCounter++;
        }

    }


}
