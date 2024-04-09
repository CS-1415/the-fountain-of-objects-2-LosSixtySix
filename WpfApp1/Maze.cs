using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class Maze()
    {
        private int _numOfRooms;
        private bool _fountainFound;
        private bool _enabled;
        int _size;
        private Room _currentRoom;
        private string[] monsterList = { "Mael", "Ama" };
        private bool _newRoomBool = false;
        private List<Tuple<int[], Room>> _memory = new List<Tuple<int[], Room>>();
        private Player _player = new Player();
        private bool _gameWon = false;
        private bool _combat = false;
        private bool _pickup = false;
        private bool _lost = false;


        public bool Lost { get => _lost; set => _lost = value; }
        public bool Pickup { get => _pickup; set => _pickup = value; }
        public bool Combat { get => _combat; set => _combat = value; }
        public bool GameWon { get => _gameWon; set => _gameWon =value; }
        public Player Player { get => _player; set => _player = value; }
        public List<Tuple<int[], Room>> Memory { get=> _memory; set => _memory = value; }
        public Room CurrentRoom { get => _currentRoom; set => _currentRoom = value; }
        public bool newRoomBool { get => _newRoomBool; set => _newRoomBool = value; }
        private string[] validDirections = { "move east", "move west", "move north", "move south", "move up", "move down", "move right", "move left", "east", "west", "north", "south", "up", "down", "right", "left" };
        public int NumOfRooms { get => _numOfRooms; set => _numOfRooms = value; }
        public bool FountainFound { get => _fountainFound; set => _fountainFound = value; }
        public bool Enabled
        {
            get => _enabled;
            set => _enabled = value;
        }
        public int Size
        {
            get => _size;
            set => _size = value;
        }

        public Maze(int size) : this()
        {
            Enabled = false;
            Size = size;
            if (size == 1)
            {
                Size = 4;
            }
            else if (size == 2)
            {
                Size = 6;
            }
            else if (size == 3)
            {
                Size = 8;
            }
            CreateMaze();

        }


        public void AddRoom(string direction)
        {
            if (direction == "east")
            {
                Random rand = new Random();
                Room newRoom = new Room();
                newRoom.West = true;
                newRoom.AddDoors();
                if (rand.NextDouble() <= .40)
                {
                    string randMon = monsterList[rand.Next(monsterList.Count())];
                    if (randMon == "Mael")
                    {
                        Maelstrom newMael = new Maelstrom();
                        newRoom.Container.Add(newMael);
                    }
                    else if (randMon == "Ama")
                    {
                        Amarok newAma = new Amarok();
                        newRoom.Container.Add(newAma);
                    }
                    newRoom.isEmpty = false;
                }
                if (rand.NextDouble() <= .05 && NumOfRooms < Size * Size - 3 && FountainFound == false)
                {
                    newRoom.IsFountain = true;
                }
                if (NumOfRooms == Size * Size - 3 && FountainFound == false)
                {
                    newRoom.IsFountain = true;
                }
                newRoom.WestR = CurrentRoom;
                CurrentRoom.EastR = newRoom;
                CurrentRoom = newRoom;

            }

            if (direction == "west")
            {
                Random rand = new Random();
                Room newRoom = new Room();
                newRoom.East = true;
                newRoom.AddDoors();
                if (rand.NextDouble() <= .40)
                {
                    string randMon = monsterList[rand.Next(monsterList.Count())];
                    if (randMon == "Mael")
                    {
                        Maelstrom newMael = new Maelstrom();
                        newRoom.Container.Add(newMael);
                    }
                    else if (randMon == "Ama")
                    {
                        Amarok newAma = new Amarok();
                        newRoom.Container.Add(newAma);
                    }
                    newRoom.isEmpty = false;
                }
                if (rand.NextDouble() <= .005 && NumOfRooms < Size * Size - 3 && FountainFound == false)
                {
                    newRoom.IsFountain = true;
                }
                if (NumOfRooms == Size * Size - 3 && FountainFound == false)
                {
                    newRoom.IsFountain = true;
                }
                newRoom.EastR = CurrentRoom;
                CurrentRoom.WestR = newRoom;
                CurrentRoom = newRoom;
            }

            if (direction == "south")
            {
                Random rand = new Random();
                Room newRoom = new Room();
                newRoom.North = true;
                newRoom.AddDoors();
                if (rand.NextDouble() <= .40)
                {
                    string randMon = monsterList[rand.Next(monsterList.Count())];
                    if (randMon == "Mael")
                    {
                        Maelstrom newMael = new Maelstrom();
                        newRoom.Container.Add(newMael);
                    }
                    else if (randMon == "Ama")
                    {
                        Amarok newAma = new Amarok();
                        newRoom.Container.Add(newAma);
                    }
                    newRoom.isEmpty = false;
                }
                if (rand.NextDouble() <= .005 && NumOfRooms < Size * Size - 3 && FountainFound == false)
                {
                    newRoom.IsFountain = true;
                }
                if (NumOfRooms == Size * Size - 3 && FountainFound == false)
                {
                    newRoom.IsFountain = true;
                }
                newRoom.NorthR = CurrentRoom;
                CurrentRoom.SouthR = newRoom;
                CurrentRoom = newRoom;
            }

            if (direction == "north")
            {
                Random rand = new Random();
                Room newRoom = new Room();
                newRoom.South = true;
                newRoom.AddDoors();
                if (rand.NextDouble() <= .40)
                {
                    string randMon = monsterList[rand.Next(monsterList.Count())];
                    if (randMon == "Mael")
                    {
                        Maelstrom newMael = new Maelstrom();
                        newRoom.Container.Add(newMael);
                    }
                    else if (randMon == "Ama")
                    {
                        Amarok newAma = new Amarok();
                        newRoom.Container.Add(newAma);
                    }
                    newRoom.isEmpty = false;
                }
                if (rand.NextDouble() <= .005 && NumOfRooms < Size * Size - 3 && FountainFound == false) 
                {
                    newRoom.isEmpty = false;
                    newRoom.IsFountain = true;
                }
                if (NumOfRooms == Size * Size - 3 && FountainFound == false)
                {
                    newRoom.isEmpty = false;
                    newRoom.IsFountain = true;
                }
                newRoom.SouthR = CurrentRoom;
                CurrentRoom.NorthR = newRoom;
                CurrentRoom = newRoom;
            }
        }
        public void CreateMaze()
        {

            Room startRoom = new Room();
            startRoom.IsEntrance = true;
            startRoom.East = true;
            startRoom.South = true;
            startRoom.AddDoors();

            CurrentRoom = startRoom;

        }
        public string MoveLeft()
        {
            string x = "null";
            if (CurrentRoom.West)
            {
                AddRoom("west");
            }
            else
            {
                x = "wall";
            }
            return x;
        }
        public string MoveRight()
        {
            string x = "null";
            if (CurrentRoom.East)
            {
                AddRoom("east");
            }
            else
            {
                x = "wall";
            }
            return x;
        }
        public string MoveUp()
        {
            string x = "null";
            if (CurrentRoom.North) { AddRoom("north"); }
            else { x = "wall"; }
            return x;
        }
        public string MoveDown()
        {
            string x = "null";
            if (CurrentRoom.South) { AddRoom("south"); }
            else { x = "wall"; }
            return x;

        }
        public void PrintMessages()
        {

        }
        public bool ValidMove(string x)
        {
            if (validDirections.Contains(x))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddtoMemory(int[] check)
        {
            Memory.Add(new Tuple<int[], Room>(check, CurrentRoom));
        }
        public string CheckMemory(string dir, int[] current)
        {
            if(dir == "east")
            {
                if(CurrentRoom.East == false)
                {
                    return "wall";
                }
                current[0] += 22;

                foreach(Tuple<int[],Room> x in Memory)
                {
                    if (x.Item1[0] == current[0] && x.Item1[1] == current[1])
                    {
                        if(x.Item2.West)
                        {
                            x.Item2.WestR = CurrentRoom;
                            CurrentRoom.EastR = x.Item2;
                            CurrentRoom = x.Item2;
                            return "exists";
                        }
                        else
                        {
                            return "wall";
                        }

                    }
                }
            }
            else if(dir == "west")
            {
                if (CurrentRoom.West == false)
                {
                    return "wall";
                }
                current[0] -= 22;
                foreach (Tuple<int[], Room> x in Memory)
                {
                    if (x.Item1[0] == current[0] && x.Item1[1] == current[1])
                    {
                        if (x.Item2.East)
                        {
                            x.Item2.EastR = CurrentRoom;
                            CurrentRoom.WestR = x.Item2;
                            CurrentRoom = x.Item2;
                            return "exists";
                        }
                        else
                        {
                            return "wall";
                        }
                    }
                }
            }
            else if(dir == "north")
            {
                if (CurrentRoom.North == false)
                {
                    return "wall";
                }
                current[1] -= 30;
                foreach (Tuple < int[], Room> x in Memory)
                {
                    if(x.Item1[0] == current[0] && x.Item1[1] == current[1])
                    {
                        if(x.Item2.South)
                        {
                            x.Item2.NorthR = CurrentRoom;
                            CurrentRoom.SouthR = x.Item2;
                            CurrentRoom = x.Item2;
                            return "exists";
                        }
                        else
                        {
                            return "wall";
                        }

                    }
                }

            }
            else if(dir == "south")
            {
                if (CurrentRoom.South == false)
                {
                    return "wall";
                }
                current[1] += 30;
                foreach(Tuple< int[], Room> x in Memory)
                {
                    if(x.Item1[0] == current[0] && x.Item1[1] == current[1])
                    {
                        if(x.Item2.North)
                        {
                            x.Item2.SouthR = CurrentRoom;
                            CurrentRoom.NorthR = x.Item2;
                            CurrentRoom = x.Item2;
                            return "exists";
                        }
                        else
                        {
                            return "wall";
                        }
                    }

                }
            }
            return "null";
        }
        public string Move(string x)
        {

            if (x != null)
            {
                if (ValidMove(x.ToLower()) && NumOfRooms < Math.Pow(Size, 2))
                {
                    if (x == "move east" || x == "move right" || x == "east" || x == "right")
                    {
                        if (CurrentRoom.EastR == null)
                        {
                            newRoomBool = true;
                            return MoveRight();
                            
                        }
                        else
                        {
                            newRoomBool = false;
                            CurrentRoom = CurrentRoom.EastR;
                        }
                    }
                    else if (x == "move west" || x == "move left" || x == "west" || x == "left")
                    {
                        if (CurrentRoom.WestR == null)
                        {
                            newRoomBool = true;
                            return MoveLeft();
                        }
                        else
                        {
                            newRoomBool = false;
                            CurrentRoom = CurrentRoom.WestR;
                        }
                    }
                    else if (x == "move north" || x == "move up" || x == "north" || x == "up")
                    {
                        if (CurrentRoom.NorthR == null)
                        {
                            newRoomBool = true;
                            return MoveUp();
                        }
                        else
                        {
                            newRoomBool = false;
                            CurrentRoom = CurrentRoom.NorthR;
                        }
                    }
                    else if (x == "move south" || x == "move down" || x == "south" || x == "down")
                    {
                        if (CurrentRoom.SouthR == null)
                        {
                            newRoomBool = true;
                            return MoveDown();
                        }
                        else
                        {
                            newRoomBool = false;
                            CurrentRoom = CurrentRoom.SouthR;
                        }
                    }

                }

                
            }
            return "null";
        }
        public void checkRoom()
        {
            if (CurrentRoom.IsEntrance)
            {
                if(Enabled)
                {
                    GameWon = true;
                }
            }
            if (CurrentRoom.Container.Count > 0)
            {
                Combat = true;
            }
        }


    }
}
