using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    class Item
    {

        public Item(string type, string name)
        {
         itemType = type;
         nameValue = name;
         if (name == prpDef) nameValue = "PROPERTY";
         if (name == prpName) nameValue = "NAME";
         if (name == prpVal) nameValue = "VALUE";
         if (name == grpDef) nameValue = "CONFIG_DETAILS";
         if (name == grpTtl) nameValue = "TYPE";
         if (name == grpAttDef) nameValue = "NAMEVALUES";
         if (name == grpAttNme) nameValue = "NAME";
         if (name == grpAttVal) nameValue = "VALUE";
         if (name == sGrpDef) nameValue = "config_details";
         if (name == sGrpTtl) nameValue = "TYPE";
         if (name == sAttDef) nameValue = "SUB_NAMEVALUES";
         if (name == sAttNme) nameValue = "NAME";
         if (name == sAttVal) nameValue = "VALUE";
        }

        public void setnameAttribute(string x)
        {
            nameAttribute = x;
        }
        public string getAttribute()
        {
            return nameAttribute;
        }
        public string createAsXML()
        {

            return "<" + itemType + " " + nameAttribute + "\"" + nameValue + "\"" + recordType + ">" + "\n" + "\t" +
                     "<" + valueAttribute + ">" +  valueValue + "</" + valueAttribute + ">" + "\n" +
                    "</" + itemType + ">";
                    ;
        }

        protected
            string nameAttribute = "name=";
            string valueAttribute = "value";
            string recordType;
            public string getrecordType() { return recordType; }
            public void setrecordType(string x) { recordType = x; }
            string nameValue;
            string itemType;
            public string valueValue { get; set; } = "";
            Value itemValue;

        /* Variables for friendly names */
        string prpDef = "PropertiesDefinition"; public string getprpDef(){return prpDef;}
        string prpName = "PropertyName"; public string getprpName() { return prpName; }
        string prpVal = "PropertyValue"; public string getprpVal() { return prpVal; }
        string grpDef = "GroupDefinition"; public string getgrp() { return grpDef; }
        string grpTtl = "GroupTitle"; public string getgrpTtl() { return grpTtl; }
        string grpAttDef = "GroupAttributesDefinition"; public string getgrpAttDef() { return grpAttDef; }
        string grpAttNme = "GroupAttributeName"; public string getgrpAttNme() { return grpAttNme; }
        string grpAttVal = "GroupAttributeValue"; public string getgrpAttVal() { return grpAttVal; }
        string sGrpDef = "SubgroupDefinition"; public string getsGrpDef() { return sGrpDef; }
        string sGrpTtl = "SubgroupTitle"; public string getsGrpTtl() { return sGrpTtl; }
        string sAttDef = "SubAttributeDefinition"; public string getsAttDef() { return sAttDef; }
        string sAttNme = "SubAttributeName"; public string getsAttNme() { return sAttNme; }
        string sAttVal = "SubAttributeValue"; public string getsAttVal() { return sAttVal; }

    }

}
