using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace NewProject
{
    public partial class Form1 : Form
    {
        List<COPY> activeCOPY = new List<COPY>();
        int copyCounter = 0;
        int copyFriendlyCounter = 1;


        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // if mime type = text
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string formattedFileName = ofd.SafeFileName.ToString().ToLower();
                int extSubStrStart = formattedFileName.Length - 4;
                int extSubStrLength = 4;
                string extension = formattedFileName.Substring(extSubStrStart, extSubStrLength);
                if (extension == ".txt") {
                    textBox1.Text = extension;
                    StreamReader sr = new StreamReader(File.OpenRead(ofd.FileName));
                    BottomBox.Text = sr.ReadToEnd();
                    }
                if (extension == "docx") {
                    Microsoft.Office.Interop.Word.ApplicationClass wordObject = new Microsoft.Office.Interop.Word.ApplicationClass();
                    object file = ofd.FileName; //this is the path
                    object nullobject = System.Reflection.Missing.Value;
                    Microsoft.Office.Interop.Word.Document docs = wordObject.Documents.Open
                        (ref file, ref nullobject, ref nullobject, ref nullobject,
                        ref nullobject, ref nullobject, ref nullobject, ref nullobject,
                        ref nullobject, ref nullobject, ref nullobject, ref nullobject,
                        ref nullobject, ref nullobject, ref nullobject, ref nullobject
                                        );
                    docs.ActiveWindow.Selection.WholeStory();
                    docs.ActiveWindow.Selection.Copy();
                    IDataObject data = Clipboard.GetDataObject();
                    BottomBox.Text = data.GetData(DataFormats.Text).ToString();
                    docs.Close(ref nullobject, ref nullobject, ref nullobject);
                }
            }

            // if mime type = word


            }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (CopyCheckBox.Checked && CIdTextBox.Text != "")
            {
                activeCOPY.Add(new COPY(CIdTextBox.Text, BIdTextBox.Text, AIdTextBox.Text));
                activeCOPY.ElementAt(copyCounter).setContentType("COPY");
                TopTextBox.Text += copyFriendlyCounter + ". " + activeCOPY.ElementAt(copyCounter).CreateFriendlyDCR() +  Environment.NewLine;
                CIdTextBox.Text = "";
                copyCounter++;
                copyFriendlyCounter++;
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Toggle_Click(object sender, EventArgs e)
        {
            //creates a property object
            //stores your selection in the VALUE valueValue;
            //messagebox appears asking for NAME 
            //store entry in NAME
            //call add property on this
            Property p = new Property();
            p.VALUE.valueValue = BottomBox.SelectedText;
            p.NAME.valueValue = propertyTextBox.Text;
            activeCOPY.ElementAt(copyCounter - 1).AddProperty(p);
            TopTextBox.AppendText(activeCOPY.ElementAt(copyCounter - 1).printFriendlyCopyPropertyXML());
            //print the newlycreated property under
                
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //remember to ask for a project name
            //remember to ask if they want to generate mobile or spanish content IDs.
        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            
            int copyloopCounter = 0;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\COPY\\data\\USGCB\\ENGLISH\\TESTforDEMO\\";
            Directory.CreateDirectory(path);
            //LOOP Through to create all cop contents

            foreach (COPY element in activeCOPY) {

                StreamWriter file = new StreamWriter(path + activeCOPY.ElementAt(copyloopCounter).Content_ID);
                string s = activeCOPY.ElementAt(copyloopCounter).CreateDCRXML(); ;
                file.Write(s);
                file.Close();
                copyloopCounter++;
            }
            
        }
        public void CreateResultFolder(string name)

        {

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (!(System.IO.Directory.Exists(desktopPath + @"\" + name)))

            {
                System.IO.Directory.CreateDirectory(desktopPath + @"\" + name + @"\data\ENGLISH\TESTforDEMO");
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            //creates a property object
            //stores your selection in the VALUE valueValue;
            //messagebox appears asking for NAME 
            //store entry in NAME
            //call add property on this
            Group g = new Group();
            g.grpTtl.valueValue = textBox2.Text;
            activeCOPY.ElementAt(copyCounter - 1).groupDef.AddGroup(g);
            TopTextBox.AppendText(activeCOPY.ElementAt(copyCounter - 1).groupDef.copyGroups.ElementAt(activeCOPY.ElementAt(copyCounter - 1).groupDef.groupCounter-1).printFriendlyGroupTitleXML());

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            //creates a property object
            //stores your selection in the VALUE valueValue;
            //messagebox appears asking for NAME 
            //store entry in NAME
            //call add property on this
            Property p = new Property();
            activeCOPY.ElementAt(0).groupDef.copyGroups.ElementAt(0).AddGroupattribute(p);
            MessageBox.Show(activeCOPY.ElementAt(0).groupDef.copyGroups.ElementAt(0).GrpAtts.ElementAt(0).createAsXML());
                //current copy
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Microsoft.Office.Interop.Excel.Application App = new Microsoft.Office.Interop.Excel.Application();
            if (App == null)
            {
                Console.WriteLine("EXCEL could not be started. Check that your office installation and project references are correct.");
                return;
            }
            App.Visible = true;
            Workbook wb = App.Workbooks.Add(path + "//Quick_Lock_Browser_Content_Mapping");
            Worksheet ws = (Worksheet)wb.Worksheets[1];

            if (ws == null)
            {
                Console.WriteLine("Worksheet could not be created. Check that your office installation and project references are correct.");
            }

            // Select the Excel cells, in the range c1 to c7 in the worksheet.
            Microsoft.Office.Interop.Excel.Range aRange = ws.get_Range("C1", "C7");

            if (aRange == null)
            {
                Console.WriteLine("Could not get a range. Check to be sure you have the correct versions of the office DLLs.");
            }

            // Fill the cells in the C1 to C7 range of the worksheet with the number 6.
            aRange.Value2 = 6;

            // Change the cells in the C1 to C7 range of the worksheet to the number 8.
            aRange.Value2 = 6;
            wb.SaveAs( path + "\\Mapping.xlsx");
            wb.Close();
            App.Quit();

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
