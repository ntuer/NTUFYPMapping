using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Mapping
{
    public partial class Form1 : Form
    {
        Bitmap imagePointer;
        bool pointConfirmed = false;
        double imageWidth = 0, imageHeight = 0, mapWidth = 0, mapHeight = 0;
        List<Node> nodeList;
        List<Edge> edgeList;
        double EDGE_SLOP_PRECISION = 0.2;
        int EDGE_PRECISION = 5;
       
        ArrayList xArray = new ArrayList(), yArray = new ArrayList(), x1Array = new ArrayList(), y1Array = new ArrayList(), x2Array = new ArrayList(), y2Array = new ArrayList(), x1Index = new ArrayList(), x2Index = new ArrayList();
        Node firstNode = null;
        Node secondNode = null;
        Node node1 = null;
        Node node2 = null;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Please select map file";
            mainLabel.Text = "Please select map file";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            PointPlot(true,-1);
            LinePlot(false);
        }

        private void newMapButton_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult imageResult = openFileDialog1.ShowDialog();
            if (imageResult == DialogResult.OK) // Test result.
            {


                string imageFileName = openFileDialog1.FileName;
                this.Text = imageFileName;
                imagePointer = new Bitmap(imageFileName);
                pictureBox1.Image = imagePointer;


                imageWidth = 0;
                imageHeight = 0;
                mapWidth = 0;
                mapHeight = 0;
                nodeList = new List<Node>();
                edgeList = new List<Edge>();
                xArray = new ArrayList();
                yArray = new ArrayList();
                x1Array = new ArrayList();
                y1Array = new ArrayList(); 
                x2Array = new ArrayList(); 
                y2Array = new ArrayList();
                x1Index = new ArrayList();
                x2Index = new ArrayList();
                pointListBox.Items.Clear();

                mainLabel.Text = "Please input map size";
                sizeWidthTextBox.Visible = true;
                sizeHeightTextBox.Visible = true;
                sizeWidthLabel.Visible = true;
                sizeHeightLabel.Visible = true;
                sizeOKButton.Visible = true;
                sizeWidthLabel.Text = "Width:";
                sizeHeightLabel.Text = "Height:";
                pointListBox.Visible = false;
                pointDeleteButton.Visible = false;
                pointConfirmButton.Visible = false;
                saveButton.Visible = false;

            }
            //Console.WriteLine(imageResult); // <-- For debugging use.
        }


        //Setting the size of the map
        private void sizeOKButton_Click(object sender, EventArgs e)
        {
            mapWidth = double.Parse(sizeWidthTextBox.Text);
            mapHeight = double.Parse(sizeHeightTextBox.Text);
            if (mapWidth > 0 && mapHeight > 0)
            {
                imageWidth = (double)imagePointer.Size.Width;
                imageHeight = (double)imagePointer.Size.Height;

                sizeWidthTextBox.Visible = false;
                sizeHeightTextBox.Visible = false;
                sizeOKButton.Visible = false;
                sizeWidthLabel.Text = "Width: " + mapWidth.ToString();
                sizeHeightLabel.Text = "Height: " + mapHeight.ToString();
                pointListBox.Visible = true;
                pointDeleteButton.Visible = true;
                pointConfirmButton.Visible = true;
                saveButton.Visible = true;
                mainLabel.Text = "Map is good! Please proceed to select points.";

                //Enlarge the map size by 10 times first to improve precision --zpx
                mapWidth *= 10;
                mapHeight *= 10;
            }
            else
            {
                mainLabel.Text = "Map size error!";
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            if (mapWidth > 0 && mapHeight > 0)
            {
                Point clickPoint = pictureBox1.PointToClient(Control.MousePosition);
                //String myText = String.Format("x: {0}, y: {1}", clickPoint.X, clickPoint.Y);
                //PointLabel.Text = myText;
                double pictureBoxWidth = (double)pictureBox1.Size.Width;
                double pictureBoxHeight = (double)pictureBox1.Size.Height;
                double clickedX = 0, clickedY = 0;

                //Get the X and Y of the clicked point --zpx
                if ((imageWidth / imageHeight) > (pictureBoxWidth / pictureBoxHeight))
                {
                    clickedX = (clickPoint.X) / pictureBoxWidth * mapWidth;
                    double offset = (pictureBoxHeight - pictureBoxWidth / imageWidth * imageHeight) / 2;
                    clickedY = (clickPoint.Y - offset) / (pictureBoxHeight - offset * 2) * mapHeight;
                }
                else
                {
                    clickedY = (clickPoint.Y) / pictureBoxHeight * mapHeight;
                    double offset = (pictureBoxWidth - pictureBoxHeight / imageHeight * imageWidth) / 2;
                    clickedX = (clickPoint.X - offset) / (pictureBoxWidth - offset * 2) * mapWidth;
                }                

                //Get the rounded coordinates of the clicked point --zpx
                bool flag = false;
                int x = Convert.ToInt32(clickedX);
                int y = Convert.ToInt32(clickedY);
                Node clickedNode = new Node(x, y);//create an object of the clicked node --zpx

                
                /*-----------------------------------------------*/
                //Input the points
                if (pointConfirmed == false)
                {
                    if (nodeList.Count > 0)
                    {
                        for (int i = 0; i < nodeList.Count; i++)
                        {

                            if ((x == nodeList[i].getX()) && (y == nodeList[i].getY()))
                            {
                                flag = true;//same point, no need to add it to the nodeList --zpx
                                //mainLabel.Text = "You have already added this point!";
                                pointListBox.SelectedIndex = i;
                                mainLabel.Text = "Id= " + i + "   " + "x=" + x + "   " + "y=" + y + "   nodeListID: " + i;
                            }

                        }
                    }

                    if (flag == false)//different points --zpx
                    {
                        

                        xArray.Add(x);
                        yArray.Add(y);

                        //add the item to the pointListBox
                        pointListBox.Items.Add(x.ToString() + ", " + y.ToString());

                        //set the property of the clickedNode --zpx
                        
                        nodeList.Add(clickedNode);
                        clickedNode.setId(nodeList.IndexOf(clickedNode));

                        pointListBox.SelectedIndex = pointListBox.Items.Count - 1;

                        //display the node info --zpx
                        mainLabel.Text = "Id= " + clickedNode.getId() + "   " + "x=" + clickedNode.getX() + "   " + "y=" + clickedNode.getY();
                    }
                }

                //Input the edges
                else
                {
                    if (isIncluded(nodeList, clickedNode) && firstNode == null)//add first node
                    {
                        firstNode = clickedNode;
                        mainLabel.Text = "Please click the second point of the edge.";
                    }
                    else if (isIncluded(nodeList, clickedNode) && firstNode != null)//add second node
                    {
                        secondNode = clickedNode;
                        if (!node1.Equals(node2))
                        {
                            setNeighbors(node1, node2);//node 1 and 2 are the actual nodes in nodeList
                            refreshEdgeList();//refresh th edge list to ensure that it is synchronized with the x1Index and x2Index
                            firstNode = null;
                            secondNode = null;
                            node1 = null;
                            node2 = null;
                            mainLabel.Text = "Edge added. Please click two points for a new edge.";
                        }
                        else
                        {
                            mainLabel.Text = "Must be connected to different nodes.";
                            node2 = null;
                            secondNode = null;
                        }
                        
                    }
                    else if (removeEdge(clickedNode))//check whether it is in line with any edges, if yes, delete the edge
                    {
                        mainLabel.Text = "Edge removed.";
                        refreshEdgeList();
                    }
                    else
                    {
                        mainLabel.Text = "Please click the exact position.";
                    }
                   
                }

            }
        }

        private bool isIncluded(List<Node> nodeList, Node testNode)//to check whether the clicked node is within nodeList
        {
            foreach(Node node in nodeList)
            {
                if (Math.Abs(node.getX() - testNode.getX()) < 5 && Math.Abs(node.getY() - testNode.getY()) < 5)
                //if (node.getX() == testNode.getX() && node.getY() == testNode.getY())
                {//as long as the horizontal and vertical deifference is less than 3, we consider as the same point
                    if (node1 == null)
                    {
                        node1 = node;//copy the actual reference of the node in the nodeList
                    }
                    else if(node1 != null && node2 == null)
                    {
                        node2 = node;
                    }        
                    return true;
                }                
            }
            return false;
        }



        private void btnLoadConf_Click(object sender, EventArgs e)
        {
            OpenFileDialog openConfFile = new OpenFileDialog();
            openConfFile.Title = "Open Conf file";
            openConfFile.FileName = ".conf";
            openConfFile.Filter = "Conf files (*.conf)|*.conf|All files (*.*)|*.*";

            if (openConfFile.ShowDialog() == DialogResult.OK)
            {
                initializeMap();//reset the map

                

                List<List<int>> nodeNeighborsList = new List<List<int>>();
                string confFileName = openConfFile.FileName;               
                XmlDocument confFile = new XmlDocument();
                confFile.Load(confFileName);
                //node info
                XmlNode NTUTag = confFile.DocumentElement.SelectSingleNode("/NTU");


                //get the map size info
                XmlNode widthTag = confFile.SelectSingleNode("/NTU/width");
                XmlNode heightTag = confFile.SelectSingleNode("/NTU/height");
                string width = widthTag.InnerText;
                string height = heightTag.InnerText;

                mainLabel.Text = "width: " + width + ", height: " + height;

                //initialize sizeOkButton click event
                sizeWidthTextBox.Text = width;
                sizeHeightTextBox.Text = height;
                sizeOKButton.PerformClick();


                foreach (XmlNode pointNode in NTUTag.SelectNodes("/NTU/p"))//loop through each point
                {
                    
                    List<int> neighborIDList = new List<int>();//a list of nodeID of neighbors

                    int id = Convert.ToInt32(pointNode.Attributes["id"].InnerText);
                    int x = Convert.ToInt32(pointNode.Attributes["x"].InnerText);
                    int y = Convert.ToInt32(pointNode.Attributes["y"].InnerText);
                    Node node = new Node(id, x, y);
                    xArray.Add(x);
                    yArray.Add(y);
                    pointListBox.Items.Add(x.ToString() + ", " + y.ToString());

                    nodeList.Add(node);

                    //get neighbors info
                    string connect = pointNode.Attributes["connect"].InnerText;
                    if (connect != "")
                    {
                        if (connect.Contains(','))
                        {
                            string[] neighbors = connect.Split(',');
                            for (int i = 0; i < neighbors.Length; i++)
                            {
                                int neighborID = Convert.ToInt32(neighbors[i]);
                                neighborIDList.Add(neighborID);
                            }
                            nodeNeighborsList.Add(neighborIDList);
                        }
                        else
                        {
                            neighborIDList.Add(Convert.ToInt32(connect));
                            nodeNeighborsList.Add(neighborIDList);
                        }

                    }
                    else
                    {
                        neighborIDList.Add(0);
                        nodeNeighborsList.Add(neighborIDList);
                    }
                }
                for (int i = 0; i < nodeNeighborsList.Count; i++)
                {
                    for (int j = 0; j < nodeNeighborsList[i].Count; j++)
                    {
                        int neighborID = nodeNeighborsList[i][j];
                        if (neighborID != 0)
                        {
                            setNeighbors(nodeList[i], nodeList[neighborID]);
                        }                   
                    }                    
                }
                refreshEdgeList();
                PointPlot(false, nodeNeighborsList.Count);
                LinePlot(false);
            }
        }

        private void initializeMap()
        {
            nodeList.Clear();
            xArray.Clear();
            yArray.Clear();
            x1Array.Clear();
            y1Array.Clear();
            x2Array.Clear();
            y2Array.Clear();
            x1Index.Clear();
            x2Index.Clear();
            pointListBox.Items.Clear();
            PointPlot(true, -1);
            LinePlot(true);
        }

        private void setNeighbors(Node node1, Node node2)
        {
            if (!isNeighbors(node1, node2))
            {
                node1.addNeighbor(node2);
                node2.addNeighbor(node1);
                //add a line between two points
                Edge edge = new Edge(node1, node2);


                x1Array.Add(node1.getX());
                y1Array.Add(node1.getY());
                x2Array.Add(node2.getX());
                y2Array.Add(node2.getY());
                x1Index.Add(node1);
                x2Index.Add(node2);

                edge.id = x1Array.Count - 1;
                edgeList.Add(edge);
                LinePlot(false);
            }            
        }

        private bool isNeighbors(Node node1, Node node2)
        {
            foreach (Node node in node1.getNeighbors())
            {
                if (node.Equals(node2))
                {
                    return true;
                }
            }
            return false;
        }

        private void refreshEdgeList()//need to find node based on x1Array()
        {
            edgeList.Clear();
            for (int i = 0; i < x1Array.Count; i++)
            {
                int x1 = int.Parse(x1Array[i].ToString());
                int y1 = int.Parse(y1Array[i].ToString());
                int x2 = int.Parse(x2Array[i].ToString());
                int y2 = int.Parse(y2Array[i].ToString());

                Node node1 = findNodeByCoordinates(x1, y1);
                Node node2 = findNodeByCoordinates(x2, y2);
                Edge edge = new Edge(node1, node2);
                edgeList.Add(edge);
            }
        }

        private Node findNodeByCoordinates(int x, int y)
        {
            foreach(Node node in nodeList)
            {
                if (node.getX() == x && node.getY() == y)
                {
                    return node;
                }
            }
            return null;
        }

        private bool removeEdge(Node node)
        {
            double x = node.getX();
            double y = node.getY();
            for (int i = 0; i < x1Array.Count; i++)
            {  
                Edge edge = edgeList[i];

                Node node1 = edge.node1;
                Node node2 = edge.node2;
                //Node node1 = nodeList[int.Parse(x1Index[i].ToString())];
                //Node node2 = nodeList[int.Parse(x2Index[i].ToString())];
                double x1 = double.Parse(x1Array[i].ToString());
                double y1 = double.Parse(y1Array[i].ToString());
                double x2 = double.Parse(x2Array[i].ToString());
                double y2 = double.Parse(y2Array[i].ToString());

                

                if (x1 == x || x2 == x)//check whether they have the same x value
                {
                    if (Math.Abs(x1 - x) <= EDGE_PRECISION && Math.Abs(x2 - x) <= EDGE_PRECISION && (y - y1)*(y - y2) < 0)//if 3 points are almost in line and y is in the middle
                    {
                        
                        x1Array.RemoveAt(i);
                        y1Array.RemoveAt(i);
                        x2Array.RemoveAt(i);
                        y2Array.RemoveAt(i);
                        x1Index.RemoveAt(i);
                        x2Index.RemoveAt(i);

                        btnLoadConf.Text = "[1]," + node1.getId() + ", " + node2.getId();

                        node1.removeNeighbor(node2);
                        node2.removeNeighbor(node1);
                        edgeList.Remove(edge);

                        LinePlot(true);
                        PointPlot(false, pointListBox.SelectedIndex);
                        return true;
                    }

                }
                else if (y1 == y || y2 == y )
                {
                    if (Math.Abs(y1 - y) <= EDGE_PRECISION && Math.Abs(y2 - y) < EDGE_PRECISION && (x - x1)*(x - x2) < 0)//if 3 points are in line and x is in the middle
                    {
                        x1Array.RemoveAt(i);
                        y1Array.RemoveAt(i);
                        x2Array.RemoveAt(i);
                        y2Array.RemoveAt(i);
                        x1Index.RemoveAt(i);
                        x2Index.RemoveAt(i);

                        btnLoadConf.Text = "[2]," + node1.getId() + ", " + node2.getId();

                        node1.removeNeighbor(node2);
                        node2.removeNeighbor(node1);
                        edgeList.Remove(edge);

                        LinePlot(true);
                        PointPlot(false, pointListBox.SelectedIndex);
                        return true;
                    }
                }
                else
                {
                    double slope1 = (y1 - y) / (x1 - x);
                    double slope2 = (y2 - y) / (x2 - x);
                    if(Math.Abs((slope1 - slope2) / slope1) < EDGE_SLOP_PRECISION && (x - x1) * (x - x2) < 0 && (y - y1)*(y - y2) < 0)
                    {                                   //similar slope and clickedPoint in the middle
                        x1Array.RemoveAt(i);
                        y1Array.RemoveAt(i);
                        x2Array.RemoveAt(i);
                        y2Array.RemoveAt(i);
                        x1Index.RemoveAt(i);
                        x2Index.RemoveAt(i);

                        btnLoadConf.Text = "[3]," + node1.getId() + ", " + node2.getId();

                        node1.removeNeighbor(node2);
                        node2.removeNeighbor(node1);
                        edgeList.Remove(edge);

                        LinePlot(true);
                        PointPlot(false, pointListBox.SelectedIndex);
                        return true;
                    }
                }    
            }
            return false;
        }

        private int getDistance(Node node1, Node node2)
        {
            int xDist = Math.Abs(node1.getX() - node2.getX());
            int yDist = Math.Abs(node1.getY() - node2.getY());
            return (int)Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2));
        }

        private void pointDeleteButton_Click(object sender, EventArgs e)
        {
            if (xArray.Count > 0)
            {
                int temp = pointListBox.SelectedIndex;

                //Remove the linked edges first
                for (int j = 0; j < x1Array.Count; j++)
                {
                    if (j < x1Array.Count)
                    {
                        if ((double.Parse(x1Array[j].ToString()) == double.Parse(xArray[temp].ToString()) && double.Parse(y1Array[j].ToString()) == double.Parse(yArray[temp].ToString())) || (double.Parse(x2Array[j].ToString()) == double.Parse(xArray[temp].ToString()) && double.Parse(y2Array[j].ToString()) == double.Parse(yArray[temp].ToString())))
                        {
                            x1Array.RemoveAt(j);
                            y1Array.RemoveAt(j);
                            x2Array.RemoveAt(j);
                            y2Array.RemoveAt(j);
                            x1Index.RemoveAt(j);
                            x2Index.RemoveAt(j);
                            j--;
                        }
                    }
                }

                //remove the point from the pointListBox and update the index--zpx               
                foreach (Node node in nodeList[temp].getNeighbors())//remove neighbor
                {
                    node.removeNeighbor(nodeList[temp]);//remove it from other node's neighbor list
                    
                }
                nodeList[temp].clearNeighbors();//clear its neighbors
                nodeList[temp] = null;//set it to null
                nodeList.RemoveAt(temp);
                updateNodeID();//update ID property of node object

                //possible need to update edgeList
                refreshEdgeList();

                pointListBox.Items.RemoveAt(temp);
                xArray.RemoveAt(temp);
                yArray.RemoveAt(temp);

                LinePlot(true);
                
                if (temp < (pointListBox.Items.Count - 1)) 
                {
                    pointListBox.SelectedIndex = temp;
                }
                else
                {
                    pointListBox.SelectedIndex = pointListBox.Items.Count - 1;
                }

                if (pointListBox.Items.Count > 0)
                {
                    mainLabel.Text = "ID= " + pointListBox.SelectedIndex + "   " + "x=" + xArray[pointListBox.SelectedIndex].ToString() + "   " + "y=" + yArray[pointListBox.SelectedIndex].ToString();
                }
                else
                {
                    mainLabel.Text = "No points in database!";
                }
            }
        }
        private void updateNodeID()
        {
            foreach (Node node in nodeList)
            {
                node.setId(nodeList.IndexOf(node));
            }
        }


        private void pointListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PointPlot(false, pointListBox.SelectedIndex);
            if (pointListBox.SelectedIndex != -1)
            {
                mainLabel.Text = "ID= " + pointListBox.SelectedIndex + "   " + "x=" + xArray[pointListBox.SelectedIndex] + "   " + "y=" + yArray[pointListBox.SelectedIndex];
            }
            
        }


        private void pointConfirmButton_Click(object sender, EventArgs e)
        {
            if (pointConfirmed == false)
            {
                pointConfirmed = true;
                pointConfirmButton.Text = "Add Point";
                mainLabel.Text = "Points confirmed! Please click two points to confirm an edge.";
            }
            else
            {
                pointConfirmed = false;
                pointConfirmButton.Text = "Add Edge";
                mainLabel.Text = "Please repick points.";

                //reset the adding edge action
                node1 = null;
                node2 = null;
                firstNode = null;
                secondNode = null;
            }
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            string saveHeader = "<?xml version=\"1.0\" encoding=\"gb2312\"?>\r\n<NTU>\r\n";
            string saveMapSize = "<width>" + mapWidth/10 + "</width>\r\n";
            saveMapSize += "<height>" + mapHeight/10 + "</height>\r\n";            
            string saveFooter = "</NTU>";
            string saveBody="";

            for (int i=0;i<xArray.Count;i++)
            {
                //saveBody = saveBody + "<p id=\"" + (i).ToString() + "\" x=\"" + xArray[i].ToString() + "\" y=\"" + yArray[i].ToString() + "\" connect=\"";
                saveBody = saveBody + "<p id=\"" + nodeList[i].getId() + "\" x=\"" + xArray[i].ToString() + "\" y=\"" + yArray[i].ToString() + "\" connect=\"";
                string pointLine = "";
                foreach(Node node in nodeList[i].getNeighbors())
                {
                    if (node != null)
                    {
                        pointLine += node.getId() + ",";
                    }
                }
                if (pointLine.Contains(","))//if there are edges connnected to it, remove the last ","--zpx
                {
                    pointLine = pointLine.Substring(0, pointLine.Length - 1);
                }           
                saveBody = saveBody + pointLine + "\"/>\r\n";
            }

            //save conf file
            String fileToSave = saveHeader + saveMapSize + saveBody + saveFooter;

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = ".conf";
            saveFile.Filter = "Conf files (*.conf)|*.conf|All files (*.*)|*.*";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFile.FileName))
                sw.WriteLine(fileToSave);
            }

            //System.IO.File.WriteAllText(@"MapConfig.conf", saveHeader + saveBody + saveFooter);
            mainLabel.Text = "Saving Completed!";
        }




        //Plotting points
        private void PointPlot(bool refreshFlag,int focusIndex)
        {
            if (refreshFlag == true)
                pictureBox1.Refresh();
            Graphics pictureGraphic = pictureBox1.CreateGraphics();
            double pictureBoxWidth = (double)pictureBox1.Size.Width;
            double pictureBoxHeight = (double)pictureBox1.Size.Height;
            if ((imageWidth / imageHeight) > (pictureBoxWidth / pictureBoxHeight))
            {
                for (int i = 0; i < xArray.Count; i++)
                {
                    double offset = (pictureBoxHeight - pictureBoxWidth / imageWidth * imageHeight) / 2;
                    int x_temp = (int)(double.Parse(xArray[i].ToString()) / mapWidth * pictureBoxWidth);
                    int y_temp = (int)(double.Parse(yArray[i].ToString()) / mapHeight * (pictureBoxHeight - offset * 2) + offset);
                    if (focusIndex == i)
                    {
                        pictureGraphic.DrawLine(new Pen(Color.Navy), x_temp - 3, y_temp - 3, x_temp + 3, y_temp + 3);
                        pictureGraphic.DrawLine(new Pen(Color.Navy), x_temp + 3, y_temp - 3, x_temp - 3, y_temp + 3);
                    }
                    else
                    {
                        pictureGraphic.DrawLine(new Pen(Color.Red), x_temp - 3, y_temp - 3, x_temp + 3, y_temp + 3);
                        pictureGraphic.DrawLine(new Pen(Color.Red), x_temp + 3, y_temp - 3, x_temp - 3, y_temp + 3);
                    }
                }
            }
            else
            {
                for (int i = 0; i < xArray.Count; i++)
                {
                    double offset = (pictureBoxWidth - pictureBoxHeight / imageHeight * imageWidth) / 2;
                    int x_temp = (int)(double.Parse(xArray[i].ToString()) / mapWidth * (pictureBoxWidth - offset * 2) + offset);
                    int y_temp = (int)(double.Parse(yArray[i].ToString()) / mapHeight * pictureBoxHeight);
                    if (focusIndex == i)
                    {
                        pictureGraphic.DrawLine(new Pen(Color.Green), x_temp - 3, y_temp - 3, x_temp + 3, y_temp + 3);
                        pictureGraphic.DrawLine(new Pen(Color.Green), x_temp + 3, y_temp - 3, x_temp - 3, y_temp + 3);
                    }
                    else
                    {
                        pictureGraphic.DrawLine(new Pen(Color.Red), x_temp - 3, y_temp - 3, x_temp + 3, y_temp + 3);
                        pictureGraphic.DrawLine(new Pen(Color.Red), x_temp + 3, y_temp - 3, x_temp - 3, y_temp + 3);
                    }
                }
            }
        }

        ////Plotting lines --zpx
        //private void LinePlot(bool addLineFlag)
        //{

        //    //pictureBox1.Refresh();

        //    Graphics pictureGraphic = pictureBox1.CreateGraphics();
        //    mainLabel.Text = "Edges added 1";
        //    double pictureBoxWidth = (double)pictureBox1.Size.Width;
        //    double pictureBoxHeight = (double)pictureBox1.Size.Height;
        //    if ((imageWidth / imageHeight) > (pictureBoxWidth / pictureBoxHeight))
        //    {
        //        double offset = (pictureBoxHeight - pictureBoxWidth / imageWidth * imageHeight) / 2;
        //        int x1_temp = (int)(firstNode.getX() / mapWidth * pictureBoxWidth);
        //        int y1_temp = (int)(firstNode.getY() / mapHeight * (pictureBoxHeight - offset * 2) + offset);
        //        int x2_temp = (int)(secondNode.getX() / mapWidth * pictureBoxWidth);
        //        int y2_temp = (int)(secondNode.getY() / mapHeight * (pictureBoxHeight - offset * 2) + offset);
        //        pictureGraphic.DrawLine(new Pen(Color.Green), x1_temp, y1_temp, x2_temp, y2_temp);
        //        firstNode = null;
        //        secondNode = null;
        //    }
        //    else
        //    {

        //        double offset = (pictureBoxWidth - pictureBoxHeight / imageHeight * imageWidth) / 2;
        //        int x1_temp = (int)(firstNode.getX() / mapWidth * (pictureBoxWidth - offset * 2) + offset);
        //        int y1_temp = (int)(firstNode.getY() / mapHeight * pictureBoxHeight);
        //        int x2_temp = (int)(secondNode.getX() / mapWidth * (pictureBoxWidth - offset * 2) + offset);
        //        int y2_temp = (int)(secondNode.getY() / mapHeight * pictureBoxHeight);
        //        pictureGraphic.DrawLine(new Pen(Color.Green), x1_temp, y1_temp, x2_temp, y2_temp);
        //        firstNode = null;
        //        secondNode = null;
        //    }
        //}

        //Plotting lines --original
        private void LinePlot(bool refreshFlag)
        {
            if (refreshFlag == true)
                pictureBox1.Refresh();
            Graphics pictureGraphic = pictureBox1.CreateGraphics();
            double pictureBoxWidth = (double)pictureBox1.Size.Width;
            double pictureBoxHeight = (double)pictureBox1.Size.Height;
            if ((imageWidth / imageHeight) > (pictureBoxWidth / pictureBoxHeight))
            {
                for (int i = 0; i < x1Array.Count; i++)
                {
                    double offset = (pictureBoxHeight - pictureBoxWidth / imageWidth * imageHeight) / 2;
                    int x1_temp = (int)(double.Parse(x1Array[i].ToString()) / mapWidth * pictureBoxWidth);
                    int y1_temp = (int)(double.Parse(y1Array[i].ToString()) / mapHeight * (pictureBoxHeight - offset * 2) + offset);
                    int x2_temp = (int)(double.Parse(x2Array[i].ToString()) / mapWidth * pictureBoxWidth);
                    int y2_temp = (int)(double.Parse(y2Array[i].ToString()) / mapHeight * (pictureBoxHeight - offset * 2) + offset);
                    pictureGraphic.DrawLine(new Pen(Color.Green), x1_temp, y1_temp, x2_temp, y2_temp);
                }
            }
            else
            {
                for (int i = 0; i < x1Array.Count; i++)
                {
                    double offset = (pictureBoxWidth - pictureBoxHeight / imageHeight * imageWidth) / 2;
                    int x1_temp = (int)(double.Parse(x1Array[i].ToString()) / mapWidth * (pictureBoxWidth - offset * 2) + offset);
                    int y1_temp = (int)(double.Parse(y1Array[i].ToString()) / mapHeight * pictureBoxHeight);
                    int x2_temp = (int)(double.Parse(x2Array[i].ToString()) / mapWidth * (pictureBoxWidth - offset * 2) + offset);
                    int y2_temp = (int)(double.Parse(y2Array[i].ToString()) / mapHeight * pictureBoxHeight);
                    pictureGraphic.DrawLine(new Pen(Color.Green), x1_temp, y1_temp, x2_temp, y2_temp);
                }
            }
        }

    }
}
