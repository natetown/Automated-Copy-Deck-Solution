using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    abstract public class DCR
    {
        //Constructor
            public
            DCR(string CId, string BId, string AId)
        {
            Business_ID = BId;
            Content_ID = CId;
            App_ID = AId;
            Locale_ID = "en_us";
        }

        //Creates The DCRs that get exported
        abstract public string CreateDCRXML();
   

        //creates the DCRs that are shown in the GUI
           public string CreateFriendlyDCR()
         {
                string FriendlyDCR;

                FriendlyDCR =
                           Content_ID + "_" +
                           App_ID + " " +
                           Business_ID + " " +
                           Locale_ID + " " +
                           Content_Type;
                return FriendlyDCR;
          }

        //A bunch of getter and setter methods
            public void setBusinessId(string x)
          {

                    Business_ID = x;
          }
            public string getBusinessId()
          {
                    return Business_ID;
          }
            public void setContentType(string x)
         {
                Content_Type = x;
          }
            public string getContentType()
          {
                return Content_Type;
          }

        //Properties that can be overridden in the derived classes.
        public string Locale_ID { get; set; }
        public string Content_Type { get; set; }

        //DCR Paramters 

        public virtual string Content_ID { get; set; }
        public virtual string Business_ID { get; set; }
        public virtual string App_ID { get; set; }

    }
};

    

