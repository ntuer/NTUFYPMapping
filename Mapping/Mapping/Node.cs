﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    class Node
    {
        private int id, x, y, elevatorGroupNum;
        private string connetorName;
        private List<Node> neighbors;
        public enum POINT_TYPE
        {
            Normal, Elevator, Connector
        };
        public POINT_TYPE pointType;

        public Node(int x, int y)
        {
            this.x = x;
            this.y = y;
            neighbors = new List<Node>();
            pointType = POINT_TYPE.Normal;
        }

        public Node(int id, int x, int y)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            neighbors = new List<Node>();
            pointType = POINT_TYPE.Normal;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return this.id;
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public int getX()
        {
            return this.x;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public int getY()
        {
            return this.y;
        }


        public void addNeighbor(Node node)
        {
            if (!neighbors.Contains(node))
            {
                neighbors.Add(node);
            }   
        }

        public void removeNeighbor(Node node)
        {
            if (node != null)
            {
                while (neighbors.Contains(node))
                {
                    neighbors.Remove(node);
                }
            }                       
        }

        public void clearNeighbors()
        {
            neighbors.Clear();
        }

        public List<Node> getNeighbors()
        {
            return neighbors;
        }

        public string getConnectorName()
        {
            return this.connetorName;
        }

        public void setConnectorName(string name)
        {
            this.connetorName = name;
        }

        public int getElevatorGroupNum()
        {
            return this.elevatorGroupNum;
        }

        public void setElevatorGroupNum(int num)
        {
            this.elevatorGroupNum = num;
        }
    }
}
