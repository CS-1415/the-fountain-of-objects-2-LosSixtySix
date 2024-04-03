namespace Lab08;
public class Room
{
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
    }
    public void PrintMessage()
    {
        if(IsEntrance)
        {
            Console.WriteLine("This is the entrance");
        }
    }


}