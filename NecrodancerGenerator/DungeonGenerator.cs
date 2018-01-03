using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;
using LevelGenerator;
using LevelGenerator.Serialization;
using Microsoft.Msagl.Drawing;

namespace NecrodancerGenerator
{
    public partial class DungeonGenerator : Form
    {
        private List<Room> _rooms = new List<Room>();
        private List<Corridor> _corridors;
        private Graph _productonGraph;

        public DungeonGenerator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateDungeon();
        }

        public void GenerateDungeon()
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
                    d = (XmlContainers.Dungeon)xs.Deserialize(sr);
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
    
            GeneratedDungeon g = new GeneratedDungeon(_rooms, _corridors);
            XmlContainers.Dungeon d = g.GetXMLDungeon();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML file|*.xml";
            saveFileDialog1.Title = "Save as XML";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.  
                FileStream fs =
                    (FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the  
                // File type selected in the dialog box.  
                // NOTE that the FilterIndex property is one-based.  
                x.Serialize(fs, d);

                fs.Close();
            }
        }

        private void bLoadGraph_Click(object sender, EventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(SerializedGraph));

            SerializedGraph g = null;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XML file|*.xml";
            openFileDialog1.Title = "Open XML";
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                StreamReader sr = new
                    StreamReader(openFileDialog1.FileName);
                g = (SerializedGraph)xs.Deserialize(sr);
                sr.Close();

                _productonGraph = g.Deserialize();
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Generator generator = new Generator(_rooms, _productonGraph);
            generator.GenerateRoomLayout();

            Grid grid = generator.GetGrid();
            IntVector2 centerPos = grid.GetGridCenter();

            List<Room> finalRooms = new List<Room>();
            foreach (Cell cell in grid.GetCells())
            {
                if (cell.room != null)
                {
//                    cell.room.MoveBy((cell.gridPos - centerPos)*grid.GetCellSize());
                    finalRooms.Add(cell.room);
                }
            }

            _corridors = grid.GetCorridors();
            _rooms = finalRooms;
        }
    }
}
