namespace Lab08;
public class Room
{
    public Random rand = new Random();
    private string[] _roomStr;
    private char[][] _roomChars;
    private bool _isNew;
    Items[]? _floor;
    private bool _isEmpty = true;
    private bool _isFountain = false;
    private bool _isEntrance = false;
    private Monster[] _container = new Monster[]{};
    private bool _east = false;
    private bool _west = false;
    private bool _south = false;
    private bool _north = false;
    private Room? _eastR;
    private Room? _westR;
    private Room? _southR;
    private Room? _northR;


    public string[] RoomStr{get => _roomStr; set => _roomStr = value;}
    public char[][] RoomChar{get=> _roomChars; set => _roomChars = value;}
    public bool IsNew{get => _isNew; set => _isNew = value;}
    public Room? EastR{get => _eastR;set => _eastR = value;}
    public Room? WestR{get => _westR;set =>_westR  = value;}
    public Room? SouthR{get => _southR ;set =>_southR  = value;}
    public Room? NorthR{get =>_northR ;set => _northR = value;}
    public bool East{get => _east; set => _east = value;}
    public bool West{get => _west; set => _west = value;}
    public bool South{get => _south; set => _south = value;}
    public bool North{get => _north; set => _north = value;}
    public bool IsEntrance{get => _isEntrance; set => _isEntrance = value;}
    public bool IsFountain{get => _isFountain; set => _isFountain = value;}
    public Items[]? Floor{get => _floor; set => _floor = value;}
    public Monster[] Container
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
        RoomStr = File.ReadAllLines(@"C:\Users\Lanu\my-code-dir\the-fountain-of-objects-2-LosSixtySix\Lab08\Room.txt");
        RoomChar = RoomStr.Select(item => item.ToArray()).ToArray();
        AddDoors();
    }
    public void PrintMessage()
    {
        if(IsEntrance)
        {
            Console.WriteLine("This is the entrance");
        }
    }
    public void AddDoors()
    {
        int numDoors = rand.Next(1,3);
        for(int x = 0; x <= numDoors; x++)
        {
            int dirCreation = rand.Next(3);
            if(dirCreation == 0)
            {
                East = true;
            }
            else if(dirCreation == 1)
            {
                West = true;
            }
            else if(dirCreation == 2)
            {
                North = true;
            }
            else if(dirCreation == 3)
            {
                South = true;
            }
        }
        if(East)
        {
            RoomChar[1][3] = ' ';

        }
        if(West)
        {
            RoomChar[1][0] = ' ';
        }
        if(North)
        {
            RoomChar[0][1] = ' ';
        }
        if(South)
        {
            RoomChar[2][1] = ' ';
        }
    }
    public string printRoom()
    {
        string test = "";
        List<string> returnVal = new List<string>();
        int index = 0;
        foreach(char[] a in RoomChar)
        {
            string tempRow = "";
            foreach(char b in a)
            {
                test += b;
                tempRow += b;
            }
            test += "\n";
            returnVal.Add(tempRow);
            index ++;
        }
        return test;
    }
    
}