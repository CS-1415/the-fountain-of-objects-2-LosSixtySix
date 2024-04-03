namespace Lab08;

public class Maze()
{  
    private int _numOfRooms;
    private bool _fountainFound;
    private bool _enabled;
    int _size;
    private Room _currentRoom;
    private Monster[] monsterList = [];

    public Room CurrentRoom{get => _currentRoom; set => _currentRoom = value;}
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

    public Maze(int size) : this()
    {
        Enabled = false;
        Size = size;
        if(size == 1)
        {
            Size = 4;
        }
        else if (size == 2)
        {
            Size = 6;
        }
        else if(size ==3)
        {
            Size =8;
        }
        CreateMaze();

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
            if(rand.NextDouble()<= .005 && NumOfRooms < Size*Size - 3)
            {
                newRoom.IsFountain = true;
            }
            if(NumOfRooms == Size*Size -3)
            {
                newRoom.IsFountain = true;
            }
            newRoom.WestR = CurrentRoom;
            CurrentRoom.EastR = newRoom;
            CurrentRoom = newRoom;
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
            if(rand.NextDouble()<= .005 && NumOfRooms < Size*Size - 3)
            {
                newRoom.IsFountain = true;
            }
            if(NumOfRooms == Size*Size -3)
            {
                newRoom.IsFountain = true;
            }
            newRoom.EastR = CurrentRoom;
            CurrentRoom.WestR = newRoom;
            CurrentRoom = newRoom;
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
            if(rand.NextDouble()<= .005 && NumOfRooms < Size*Size - 3)
            {
                newRoom.IsFountain = true;
            }
            if(NumOfRooms == Size*Size -3)
            {
                newRoom.IsFountain = true;
            }
            newRoom.SouthR = CurrentRoom;
            CurrentRoom.NorthR = newRoom;
            CurrentRoom = newRoom;
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
            if(rand.NextDouble()<= .005 && NumOfRooms < Size*Size - 3)
            {
                newRoom.IsFountain = true;
            }
            if(NumOfRooms == Size*Size -3)
            {
                newRoom.IsFountain = true;
            }
            newRoom.NorthR = CurrentRoom;
            CurrentRoom.SouthR = newRoom;
            CurrentRoom = newRoom;
        }
    }
    public void CreateMaze()
    {

        Room startRoom = new Room();
        startRoom.IsEntrance = true;
        startRoom.East = true;
        startRoom.South = true;

        CurrentRoom = startRoom;

        Maelstrom mRef1 = new Maelstrom();
        Amarok mRef2 = new Amarok();
        monsterList.Append(mRef1);
        monsterList.Append(mRef2);


    }
    public Room GetRoom()
    {
        return CurrentRoom;
    }
    public void MoveLeft()
    {
        if(CurrentRoom.West)
        {
            AddRoom("west");
        }
        else
        {
            Console.WriteLine("You hit a wall.");
        }
    }
    public void MoveRight()
    {
        if(CurrentRoom.East)
        {
            AddRoom("east");
        }
        else
        {
            Console.WriteLine("You hit a wall.");
        }
        
    }
    public void MoveUp()
    {
        if(CurrentRoom.North){AddRoom("north");}
        else{Console.WriteLine("You hit a wall");}
    }
    public void MoveDown()
    {

        if(CurrentRoom.South){AddRoom("south");}
        else{Console.WriteLine("You hit a wall");}
    }
    public void PrintMessages()
    {
        
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
                    MoveRight();
                }
                else if(x == "move west"|| x == "move left"|| x == "west" || x == "left")
                {
                    MoveLeft();
                }
                else if(x == "move north" || x == "move up" || x == "north" || x == "up")
                {
                    MoveUp();
                }
                else if(x == "move south"|| x == "move down" || x == "south" || x == "down")
                {
                    MoveDown();   
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