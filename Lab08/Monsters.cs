namespace Lab08;

public class Monster
{
    int _hp;
    int _defence;
    string? _name;
    List<Items> _inventory = new List<Items>();

    public int Hp{get => _hp; set => _hp = value;}
    public int Defence{get => _defence; set => _defence = value;}
    public string? Name{get => _name; set => _name = value;}
    public List<Items> Inventory{get => _inventory; set=> _inventory = value;}
    public List<Items> dropItems()
    {
        return Inventory;
    }
    public void DisplaySelf()
    {
        
    }
    public Items Attack()
    {
        int selectionNum = 0;
        List<Items> Weapons = new List<Items>();
        foreach(Items item in Inventory)
        {
            if(item.IsWeapon)
            {
                Weapons.Add(item);
                string text = item.WhatIsMyItem();
                Console.WriteLine($"{selectionNum}: {text}\n");
                selectionNum ++;
            }
        }
        selectionNum = Convert.ToInt32(Console.ReadLine());
        return Weapons[selectionNum];
    }
}
public class Maelstrom: Monster
{
    public Maelstrom()
    {
        Hp = 10;
        Defence = 20;
        Name = "Maelstrom";
        for(int start = 0; start < 1; start++)
        {
            Pike baseWeapon = new Pike();
            Inventory.Add(baseWeapon);
        }
    }

}
public class Amarok: Monster
{
    public Amarok()
    {
        Hp = 25;
        Defence = 15;
        Name = "Amarok";
        for(int start = 0; start< 2; start++)
        {
            Claws baseWeapon = new Claws();
            Inventory.Add(baseWeapon);
        }
    }

}
public class Player: Monster
{
    public Player()
    {
        Hp = 50;
        Defence = 10;
        Name = "Player";
    }
    public void PickUpItems(Room currentRoom)
    {
        if(currentRoom.Floor.Count() > 0)
        {
            foreach(Items item in currentRoom.Floor)
            {
                Inventory.Append(item);
                Console.WriteLine($"{item.Name} has been added to your inventory \n");
            }
        }
    }
}