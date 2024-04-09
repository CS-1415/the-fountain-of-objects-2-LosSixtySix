using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Room
    {
        public Random rand = new Random();
        private string[] _roomStr;
        private char[][] _roomChars;
        private bool _isNew;
        List<Items> _floor = new List<Items>();
        private bool _isEmpty = true;
        private bool _isFountain = false;
        private bool _isEntrance = false;
        private bool _isPit = false;
        private List<Monster> _container = new List<Monster>();
        private bool _east = false;
        private bool _west = false;
        private bool _south = false;
        private bool _north = false;
        private Room? _eastR = null;
        private Room? _westR = null;
        private Room? _southR = null;
        private Room? _northR = null;

        public bool IsPit { get => _isPit; set => _isPit =value; }
        public string[] RoomStr { get => _roomStr; set => _roomStr = value; }
        public char[][] RoomChar { get => _roomChars; set => _roomChars = value; }
        public bool IsNew { get => _isNew; set => _isNew = value; }
        public Room? EastR { get => _eastR; set => _eastR = value; }
        public Room? WestR { get => _westR; set => _westR = value; }
        public Room? SouthR { get => _southR; set => _southR = value; }
        public Room? NorthR { get => _northR; set => _northR = value; }
        public bool East { get => _east; set => _east = value; }
        public bool West { get => _west; set => _west = value; }
        public bool South { get => _south; set => _south = value; }
        public bool North { get => _north; set => _north = value; }
        public bool IsEntrance { get => _isEntrance; set => _isEntrance = value; }
        public bool IsFountain { get => _isFountain; set => _isFountain = value; }
        public List<Items> Floor { get => _floor; set => _floor = value; }
        public List<Monster> Container
        {
            get => _container;
            set => _container = value;
        }
        public bool isEmpty
        {
            get => _isEmpty;
            set => _isEmpty = value;
        }
        public Room()
        {
            isEmpty = true;
            RoomStr = File.ReadAllLines(@"C:\Users\Lanu\source\repos\WpfApp1\WpfApp1\Room.txt");
            RoomChar = RoomStr.Select(item => item.ToArray()).ToArray();
            AddrandDoors();

        }
        public string PrintMessage()
        {
            string str = "";
            if (IsEntrance)
            {
                isEmpty = false;
                str += "This is the entrance\n";
            }
            if(Container.Count > 0)
            {
                isEmpty = false;
                foreach (var item in Container)
                {
                    str += $"{item.DisplaySelf()}\n";
                }
            }
            if(Floor.Count() > 0)
            {
                isEmpty = false;
                int index = 0;
                foreach(var item in Floor)
                {
                    str += $"{index}:{item.WhatIsMyItem()}\n";
                    index++;
                }
            }
            if(IsPit)
            {
                isEmpty = false;
                str += "There is a pit in this room\n";
            }
            if(IsFountain)
            {
                isEmpty = false;
                str += "The Founatin is in this room\n";
            }
            if (isEmpty) { str = "Empty Room"; }
            return str;
        }
        public void AddrandDoors()
        {
            int numDoors = rand.Next(1, 3);
            for (int x = 0; x <= numDoors; x++)
            {
                int dirCreation = rand.Next(4);
                if (dirCreation == 0)
                {
                    if (East)
                    {
                        x--;
                    }
                    else
                    {
                        East = true;
                    }

                }
                else if (dirCreation == 1)
                {
                    if (West)
                    {
                        x--;
                    }
                    else
                    {
                        West = true;
                    }
                }
                else if (dirCreation == 2)
                {
                    if (North)
                    {
                        x--;
                    }
                    else
                    {
                        North = true;
                    }
                }
                else if (dirCreation == 3)
                {
                    if (South)
                    {
                        x--;
                    }
                    else
                    {
                        South = true;
                    }
                }
            }
        }

        public void AddDoors()
        {
            if (East)
            {
                RoomChar[1][3] = ' ';

            }
            if (West)
            {
                RoomChar[1][0] = ' ';
            }
            if (North)
            {
                RoomChar[0][1] = ' ';
                RoomChar[0][2] = ' ';
            }
            if (South)
            {
                RoomChar[2][1] = ' ';
                RoomChar[2][2] = ' ';
            }
        }

        public string printRoom()
        {
            string test = "";
            int index = 0;
            foreach (char[] a in RoomChar)
            {
                foreach (char b in a)
                {
                    test += b;
                }
                test += "\n";
                index++;
            }
            return test;
        }

    }
}
