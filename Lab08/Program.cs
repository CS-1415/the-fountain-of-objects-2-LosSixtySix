namespace Lab08;
public partial class Program
{
    public bool ValidSizeInput(string x)
    {  
        if(x != null)
        {
            x = x.ToLower();
        }
        else
        {
            return false;
        }
       
        if(x == "small" || x == "medium" || x == "large")
        {
            return true;
        }
        return false;
    }
    public int TranslateToInt(string x)
    {
        if(ValidSizeInput(x))
        {
            x = x.ToLower();
            if(x == "small")
            {
                return 1;
            }
            else if(x == "medium")
            {
                return 2;
            }
            else if(x == "large")
            {
                return 3;
            }
        }
        return 0;
    }
    public void Run(int size)
    {
        Maze mainMaze = new Maze(size);
        bool play = true;
        Console.WriteLine("Type move and then a direction to move(east, west, north, south) example: 'move east' moves you one to the right");
        while(play)
        {
            mainMaze.PrintMessages();
            Console.WriteLine("Where would you like to move?");
            string? move = Console.ReadLine();
            mainMaze.Move(move);
            mainMaze.checkRoom();
        }
    }
    public void Main()
    {
        int tSize = 1;
        bool makeSize = true;
        while(makeSize)
        {
            Console.WriteLine("What size? Small, medium or large?");
            string? size = Console.ReadLine();
            tSize = TranslateToInt(size);
            if(tSize == 0)
            {
                Console.WriteLine("That is not a valid input");
            }
            else
            {
                makeSize = false;
            }
        }
        Run(tSize);
       
    }
}