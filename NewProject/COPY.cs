using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    class COPY : DCR
    {
        public COPY(string CId, string BId, string AId) : base(CId, BId, AId)
        {
            Content_Type = "Copy";
        }

        public override string CreateDCRXML()
        {   

            string QualifiedCopyDCR;

            //creating items in c#
            
            record recordContainer = new record(Content_ID);
            Item copyItem = new Item("item", Content_Type); // goes in the value of recordContainer Value.value
            Item contentIdItem = new Item("item", "CONTENT_ID"); contentIdItem.valueValue = Content_ID;//goes in the value of copyItem Value.value
            Item businessIdItem = new Item("item", "BUSINESS_ID"); businessIdItem.valueValue = Business_ID;
            Item localeIdItem = new Item("item", "LOCALE_ID"); localeIdItem.valueValue = Locale_ID;
            Item appIdItem = new Item("item", "APP_ID"); appIdItem.valueValue = App_ID;
            Item nameItem = new Item("item", "NAME"); nameItem.valueValue = Content_ID;
            Item txtItem = new Item("item", "TEXT");
            Item activeItem = new Item("item", "ACTIVE"); activeItem.valueValue = "T"; //default Value.value to "T"
            Item setNotificationItem = new Item("item", "SET_NOTIFICATION"); setNotificationItem.valueValue = "N"; // default Value.value to "N"
            Item prpdef = new Item("item", "PROPERTY");//prpDef
            //loop through copyProperties and return the xml as a string to prpDef.Value 
            Item groupType = new Item("item", "GROUP_TYPE"); groupType.valueValue = "Container";//default Value.value to "Container"
            Item subGroupType = new Item("item", "SUBGROUP_TYPE"); subGroupType.valueValue = "Container"; //default Value.value to "Container"


            //storing items in variables as XML
            string contentNode = contentIdItem.createAsXML();
            string businessIDNode = businessIdItem.createAsXML();
            string localeIDNode = localeIdItem.createAsXML();
            string appIDNode = appIdItem.createAsXML();
            string nameItemNode = nameItem.createAsXML();
            string txtItemNode = txtItem.createAsXML();
            string activeItemNode = activeItem.createAsXML();
            string setNotificationNode = setNotificationItem.createAsXML();

            //creating the XML and assigning it as values
            //properties
            prpdef.valueValue = printCopyPropertyXML();
            string prpdefNode = prpdef.createAsXML();

            //groups
            groupDef.valueValue = groupDef.printGroupsXML();
            string grpdefNode = groupDef.createAsXML(); 

            copyItem.valueValue = contentNode + " \n" +
                                  businessIDNode + " \n" +
                                  localeIDNode + " \n" +
                                  appIDNode + " \n" +
                                  nameItemNode + " \n" +
                                  txtItemNode + " \n" +
                                  activeItemNode + " \n" +
                                  setNotificationNode + " \n" +
                                  prpdefNode + " \n" +
                                  grpdefNode;
            
            string copyNode = copyItem.createAsXML();

            recordContainer.valueValue = copyNode;

            //putting together the final DCR
            QualifiedCopyDCR = "<?xml version= \"1.0\" encoding=\"UTF-8\"?>" + "\n"+ 
                               "<!DOCTYPE record SYSTEM \"dcr4.5.dtd\">" + " \n" +
                               recordContainer.createAsXML();
            return QualifiedCopyDCR;
        }

        public string printFriendlyCopyPropertyXML()
        {
            string friendlyProperty = "\t" + copyProperties.ElementAt(propertyCounter - 1).NAME.valueValue + //Title
                                      Environment.NewLine + "\t\t" + copyProperties.ElementAt(propertyCounter - 1).VALUE.valueValue + Environment.NewLine;  //value
            //the current property's name.valueValue VALUE.valueValue
            return friendlyProperty; 
        }

        public string printCopyPropertyXML() {

            int propertyCount = 0;
            //properties
            StringBuilder properties = new StringBuilder();
            foreach (Property element in copyProperties)
            {
                properties.Append(copyProperties.ElementAt(propertyCount).createAsXML());
                propertyCount++;
            }
            return properties.ToString();

        }

        public void AddProperty(Property p)
        {
            copyProperties.Add(p);
            propertyCounter++;
        }
        public List<Property> copyProperties = new List<Property>();
        public int propertyCounter { get; set; } = 0;
        public GroupDefinition groupDef = new GroupDefinition();
        protected
        Item prpDef = new Item("item", "PROPERTY");


        string teamSiteLocale;

    }
}
