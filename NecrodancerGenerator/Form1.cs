using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using NecrodancerLevelGenerator;

namespace NecrodancerGenerator
{
    public partial class Form1 : Form
    {
        private List<Room> _rooms = new List<Room>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(XmlContainers.Dungeon));

            XmlContainers.Dungeon d = null;
            string name = null;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XML file|*.xml";
            openFileDialog1.Title = "Open XML";
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in openFileDialog1.FileNames)
                {
                    string roomName = Path.GetFileNameWithoutExtension(filePath);

                    StreamReader sr = new
                        StreamReader(filePath);
                    d = (XmlContainers.Dungeon) xs.Deserialize(sr);
                    sr.Close();

                    Room r = new Room(roomName, d);
                    _rooms.Add(r);
                }

                RefreshListBox(lbRooms, _rooms);
            }
        }

        private static void RefreshListBox<T>(ListControl lb, List<T> dataSource, string displayMember = "Name")
        {
            lb.DataSource = null;
            lb.DataSource = dataSource;
            lb.DisplayMember = displayMember;
        }

        private void buttonSaveDungeon_Click(object sender, EventArgs e)
        {
            XmlSerializer x = new XmlSerializer(typeof(XmlContainers.Dungeon));
    
            GeneratedDungeon g = new GeneratedDungeon(_rooms);
            XmlContainers.Dungeon d = g.GetXMLDungeon();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML file|*.xml";
            saveFileDialog1.Title = "Save as XML";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.  
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the  
                // File type selected in the dialog box.  
                // NOTE that the FilterIndex property is one-based.  
                x.Serialize(fs, d);

                fs.Close();
            }
        }
    }
}
