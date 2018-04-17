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


namespace PackagingDataHelper
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            EventHandler handler = (s, e) => {
                if (s == listBox1)
                    listBox2.TopIndex = listBox1.TopIndex;
                if (s == listBox2)
                    listBox1.TopIndex = listBox2.TopIndex;
            };

            this.listBox1.MouseCaptureChanged += handler;
            this.listBox2.MouseCaptureChanged += handler;
            this.listBox1.SelectedIndexChanged += handler;
            this.listBox2.SelectedIndexChanged += handler;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripImport036_Click(object sender, EventArgs e)
        {
            Import036();
        }

        private void Import036()
        {
            OpenFileDialog imported036 = new OpenFileDialog();
            imported036.Filter = ".036 Files (*.036)|*.036";
            imported036.Multiselect = false;

            string[] lines036 = new string[] { };
            try
            {
                if (imported036.ShowDialog() == DialogResult.OK)
                {
                    lines036 = File.ReadAllLines(imported036.FileName);
                    // Validate that the format ot the imported file.
                    //Each line in the file should be exactly 80 characters long.
                    for (int i = 0; i < lines036.Length; i++)
                    {
                        if (lines036[i].Length != 80)
                        {
                            throw new System.ArgumentException("File contains data that does not conform to expected format.", "Invalid formatting");
                        }
                    }
                }
                Parse036(lines036);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Parse036(string[] lines036)
        {
            if (lines036.Length > 0 && lines036[0].Length > 10)
            {
                List<string[]> partsList = new List<string[]>();
                List<string> tempPart = new List<string>();

                string currentPartID = GetPartRowID(lines036[0]);

                for (int i = 0; i < lines036.Length; i++)
                {
                    if (GetPartRowID(lines036[i]) == currentPartID)
                    {
                        tempPart.Add(lines036[i]);

                        if (i == lines036.Length - 1)
                        {
                            partsList.Add(tempPart.ToArray());
                        }
                    }
                    else
                    {
                        partsList.Add(tempPart.ToArray());
                        tempPart.Clear();
                        currentPartID = GetPartRowID(lines036[i]);
                        tempPart.Add(lines036[i]);
                    }
                }
            }
        }

        private string GetPartRowID(string input)
        {
            string partID = string.Empty;
            if (input.Length > 10)
            {
                partID = input.Remove(10, input.Length - 10);
            }            
            return partID;
        }
    }
}
