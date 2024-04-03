namespace Lab08;

public class Maze()
{  
    private int _numOfRooms;
    private bool _fountainFound;
    private bool _enabled;
    int _size;
    private List<List<Room>> location = new List<List<Room>>();
    private int _row;
    private int _column;
    private int _lastRow;
    private int _lastColumn;

    private Monster[] monsterList = [];

    private string[] validDirections = {"move east","move west","move north","move south", "move up","move down", "move right","move left","east","west","north","south","up","down","right","left"};
    public int NumOfRooms{get => _numOfRooms; set => _numOfRooms = value;}
    public bool FountainFound{get => _fountainFound; set => _fountainFound = value;}
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
    public int LastRow
    {
        get => _lastRow;
        set => _lastRow = value;
    }
    public int LastColumn
    {
        get => _lastColumn;
        set => _lastColumn = value;
    }
    public int Row
    {
        get => _row;
        set => _row = value;
    }
        public int Column
    {
        get => _column;
        set => _column = value;
    }
    public Maze(int size) : this()
    {
        Enabled = false;
        Size = size;
        if(size == 1)
        {
            LastColumn = 4;
            LastRow = 4;
        }
        else if (size == 2)
        {
            LastColumn = 6;
            LastRow = 6;
        }
        else if(size ==3)
        {
            LastColumn =8;
            LastRow = 8;
        }
        CreateMaze();
        Row = 0;
        Column = 0;

    }

    public int[] RandEmptyLocation()
    {
        int[] x = new int[2] ;
        Random rnd = new Random();
        int randRow = rnd.Next(LastRow);
        int randCol = rnd.Next(LastColumn);
        if(location[randRow][randCol].isEmpty)
        {
            x[0] = randRow;
            x[1] = randCol;
            return x;
        }
        else
        {
            return RandEmptyLocation();
        }
    }

    public void AddRoom(string direction)
    {
        if(direction == "east")
        {
            Random rand = new Random();
            Room newRoom = new Room();
            newRoom.West = true;
            if(rand.NextDouble() <= .25)
            {
                int randMon = rand.Next(monsterList.Length);
                newRoom.Container.Append(monsterList[randMon]);
                newRoom.isEmpty = false;
            }
            if(rand.NextDouble()<= .005 && NumOfRooms < LastColumn*LastRow - 3)
            {
                newRoom.IsFountain = true;
            }
            if(NumOfRooms == LastColumn*LastRow -3)
            {
                newRoom.IsFountain = true;
            }
            location[Row][Column+1] = newRoom;
        }
        
        if(direction == "west")
        {
            Random rand = new Random();
            Room newRoom = new Room();
            newRoom.East = true;
            if(rand.NextDouble() <= .25)
            {
                int randMon = rand.Next(monsterList.Length);
                newRoom.Container.Append(monsterList[randMon]);
                newRoom.isEmpty = false;
            }
            if(rand.NextDouble()<= .005 && NumOfRooms < LastColumn*LastRow - 3)
            {
                newRoom.IsFountain = true;
            }
            if(NumOfRooms == LastColumn*LastRow -3)
            {
                newRoom.IsFountain = true;
            }
            location[Row][Column-1] = newRoom;
        }

        if(direction == "south")
        {
            Random rand = new Random();
            Room newRoom = new Room();
            newRoom.North = true;
            if(rand.NextDouble() <= .25)
            {
                int randMon = rand.Next(monsterList.Length);
                newRoom.Container.Append(monsterList[randMon]);
                newRoom.isEmpty = false;
            }
            if(rand.NextDouble()<= .005 && NumOfRooms < LastColumn*LastRow - 3)
            {
                newRoom.IsFountain = true;
            }
            if(NumOfRooms == LastColumn*LastRow -3)
            {
                newRoom.IsFountain = true;
            }
            location[Row-1][Column] = newRoom;
        }

        if(direction == "north")
        {
            Random rand = new Random();
            Room newRoom = new Room();
            newRoom.South = true;
            if(rand.NextDouble() <= .25)
            {
                int randMon = rand.Next(monsterList.Length);
                newRoom.Container.Append(monsterList[randMon]);
                newRoom.isEmpty = false;
            }
            if(rand.NextDouble()<= .005 && NumOfRooms < LastColumn*LastRow - 3)
            {
                newRoom.IsFountain = true;
            }
            if(NumOfRooms == LastColumn*LastRow -3)
            {
                newRoom.IsFountain = true;
            }
            location[Row+1][Column] = newRoom;
        }
    }
    public void CreateMaze()
    {
        for(int x = 0; x < LastColumn; x++)
        {
            List<Room> emptyRooms = new List<Room>();
            for(int k = 0; k < LastRow; k++)
            {
                Room newRoom = new Room();
                emptyRooms.Add(newRoom);
                
            }
            location.Add(emptyRooms);
        }

        Maelstrom mRef1 = new Maelstrom();
        Amarok mRef2 = new Amarok();
        monsterList.Append(mRef1);
        monsterList.Append(mRef2);

        location[0][0].IsEntrance = true;
        location[0][0].East = true;
        location[0][0].South = true;
    }
    public Room GetRoom()
    {
        return location[Row][Column];
    }
    public void MoveLeft()
    {
        if(Column -1 > 0)
        {
            AddRoom("west");
            Column --;
        }
        else
        {
            Console.WriteLine("You hit a wall.");
        }
    }
    public void MoveRight()
    {
        if(Column + 1 < LastColumn -1)
        {
            AddRoom("east");
            Column ++;
        }
        else
        {
            Console.WriteLine("You hit a wall.");
        }
        
    }
    public void MoveUp()
    {
        if(Row + 1< LastRow -1){AddRoom("north"); Row += 1;}
        else{Console.WriteLine("You hit a wall");}
    }
    public void MoveDown()
    {

        if(Row -1 > 0){AddRoom("south"); Row --;}
        else{Console.WriteLine("You hit a wall");}
    }
    public void PrintMessages()
    {
        location[Row][Column].PrintMessage();
    }
    public string? GetNearRoomMessage()
    {
        List<Room> rooms = new List<Room>();
        if(Row-1 > 0)
        {
            rooms.Add(location[Row-1][Column]);
        }
        if(Row +1 < LastRow)
        {
            rooms.Add(location[Row+1][Column]);
        }
        if(Column -1 > 0)
        {
            rooms.Add(location[Row][Column -1]);
        }
        if(Column +1 < LastColumn)
        {
            rooms.Add(location[Row][Column + 1]);
        }
        string? returnValue = "";
        return returnValue;

    }
    public bool ValidMove(string x)
    {  
        if(validDirections.Contains(x))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Move(string x)
    {

        if(x != null)
        {
            if(ValidMove(x.ToLower()))
            {
                if(x == "move east" || x == "move right" || x == "east" || x == "right")
                {
                    if(location[Row][Column].East)
                    {
                        MoveRight();
                    }
                    else{Console.WriteLine("You hit a wall");}
                }
                else if(x == "move west"|| x == "move left"|| x == "west" || x == "left")
                {
                    if(location[Row][Column].West)
                    {
                        MoveLeft();
                    }
                    else{Console.WriteLine("You hit a wall");}
                }
                else if(x == "move north" || x == "move up" || x == "north" || x == "up")
                {
                    if(location[Row][Column].North)
                    {
                        MoveUp();  
                    }
                    else{Console.WriteLine("You hit a wall");}
                }
                else if(x == "move south"|| x == "move down" || x == "south" || x == "down")
                {
                    if(location[Row][Column].South)
                    {
                        MoveDown();   
                    }
                    else{Console.WriteLine("You hit a wall");}   
                }
            }
            else
            {
                Console.WriteLine("That is not a valid move direction");
            }


        }
        else
        {
            Console.WriteLine("You did not move as you didn't enter anything");
        }
    }
    public void checkRoom()
    {
        Room x = GetRoom();
    }
   
   
}