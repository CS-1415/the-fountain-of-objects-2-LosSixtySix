using Lab08;
Items testItem = new Items();

Maelstrom y = new Maelstrom();
y.Inventory[0].WhatIsMyItem();
testItem = y.Attack();
Console.WriteLine(testItem.WhatIsMyItem());

Lab08.Program x = new Lab08.Program();

x.Main();