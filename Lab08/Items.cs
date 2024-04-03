namespace Lab08;
public class Items
{
    int _uses;
    int _healBonus;
    string? _name;
    float _durability;
    int _damage;
    int _bounusToHit;
    bool _isWeapon;
    public Random Rand = new Random();
    public string[] ItemNames = {"Love","Mighty","Weak","Gigantic","Oversized","Worthless","Priceless","Gold","Basic","Pointy","Wide"};
    bool _isPotion;

    public int Uses{get => _uses; set => _uses = value;}
    public int HealBonus{get => _healBonus; set => _healBonus = value;}
    public bool IsPotion{get => _isPotion; set => _isPotion = value;}
    public bool IsWeapon{get => _isWeapon; set => _isWeapon = value;}
    public string? Name{get => _name; set => _name = value;}
    public float Durability{get => _durability; set => _durability = value;}
    public int Damage{get => _damage; set => _damage = value;}
    public int BonusToHit{get => _bounusToHit; set => _bounusToHit = value;}
    public string WhatIsMyItem()
    {
        if(IsWeapon)
        {
            return $"{Name}: Damage:{Damage} Durability:{Durability} Attack Bonus:{BonusToHit}";
        }
        if(IsPotion)
        {
            return $"{Name}: Heal Amount:{HealBonus} Uses Left:{Uses}";
        }
        return "";
    }
}
public class Sword : Items
{
    public Sword()
    {
        IsWeapon = true;
        Name = ItemNames[Rand.Next(ItemNames.Length)] + " Sword";
        while(Durability < .5)
        {
            Durability = (float)Rand.NextDouble();
        }
        BonusToHit = Rand.Next(1,25);
        Damage = Rand.Next(1,100);
    }

}
public class Pike : Items
{
    public Pike()
    {
        IsWeapon = true;
        Name = ItemNames[Rand.Next(ItemNames.Length)] + " Pike";
        while(Durability < .6)
        {
            Durability = (float)Rand.NextDouble();
        }
        BonusToHit = Rand.Next(10,75);
        Damage = Rand.Next(25,50);
    }
}
public class Claws : Items
{
    public Claws()
    {
        IsWeapon = true;
        Name = ItemNames[Rand.Next(ItemNames.Length)] + " Claw";
        while(Durability < .9)
        {
            Durability = (float)Rand.NextDouble();
        }
        BonusToHit = Rand.Next(10,50);
        Damage = Rand.Next(30,75);
    }
}
public class HealPotion : Items
{
    public HealPotion()
    {
        IsPotion = true;
        Name = ItemNames[Rand.Next(ItemNames.Length)] + " Healing Potion";
        HealBonus = Rand.Next(5,10);
        Uses = Rand.Next(1,5);
    }
}