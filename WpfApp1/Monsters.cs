using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{

    public class Monster
    {
        int _hp;
        int _defence;
        string? _name;
        List<Items> _inventory = new List<Items>();

        public int Hp { get => _hp; set => _hp = value; }
        public int Defence { get => _defence; set => _defence = value; }
        public string? Name { get => _name; set => _name = value; }
        public List<Items> Inventory { get => _inventory; set => _inventory = value; }
        public List<Items> dropItems()
        {
            return Inventory;
        }
        public string DisplaySelf()
        {
            return $"{Name}: HitPoints:{Hp} Defence:{Defence}\n";
        }
        public int Attack(Items weapon)
        {
            float tempNum = (float)weapon.Damage * weapon.Durability;
            return (int)tempNum;
        }
    }
    public class Maelstrom : Monster
    {
        public Maelstrom()
        {
            Hp = 10;
            Defence = 30;
            Name = "Maelstrom";
            for (int start = 0; start < 1; start++)
            {
                Pike baseWeapon = new Pike();
                Inventory.Add(baseWeapon);
            }
        }

    }
    public class Amarok : Monster
    {
        public Amarok()
        {
            Hp = 25;
            Defence = 25;
            Name = "Amarok";
            for (int start = 0; start < 2; start++)
            {
                Claws baseWeapon = new Claws();
                Inventory.Add(baseWeapon);
            }
        }

    }
    public class Player : Monster
    {
        public Player()
        {
            Hp = 50;
            Defence = 50;
            Name = "Player";
            Sword startItem = new Sword();
            HealPotion startPotion = new HealPotion();
            Inventory.Add(startItem);
            Inventory.Add(startPotion);
        }
        public string PickUpItems(Room currentRoom)
        {
            string str = "";
            if (currentRoom.Floor.Count() > 0)
            {
                foreach (Items item in currentRoom.Floor)
                {
                    Inventory.Append(item);
                    str = $"{item.Name} has been added to your inventory \n";
                }
            }
            return str;
        }
        public string DisplayInventory()
        {
            string str = "";
            if(Inventory.Count > 0)
            {
                int index = 0;
                string weaponStr = "";
                string potionStr = "";
                foreach(Items item in Inventory)
                {
                    str += $"{index}:{item.WhatIsMyItem()}\n";
                    index++;  
                }
            }
            return str;
        }
    }
}
