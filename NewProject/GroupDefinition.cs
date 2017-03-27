using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    class GroupDefinition
    {
        public GroupDefinition()
        {
            groupCounter = 0;
        }
        Item definitionItem = new Item("item", "GroupDefinition");
        Value definitionValue = new Value();


        public string createAsXML()
        {
            string grpDefXML;
            grpDefXML = "<item name=\"CONFIG_DETAILS\">" + "\n" + "" + printGroupsXML() +
                                "</item>";
                                    
            return grpDefXML;
        }
        public string printGroupsXML()
        {

            int GroupCount = 0;
            //properties
            StringBuilder groups = new StringBuilder();
            foreach (Group element in copyGroups)
            {
                groups.Append(copyGroups.ElementAt(GroupCount).createAsXML());
                GroupCount++;
            }
            return groups.ToString();

        }
        public void AddGroup(Group g)
        {
            copyGroups.Add(g);
            groupCounter++;
        }

        public string valueValue { get; set; } = "";
        public List<Group> copyGroups = new List<Group>();
        public int groupCounter { get; set; }
    }

}
