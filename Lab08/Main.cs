using homework1;
Items testItem = new Items();

Maelstrom y = new Maelstrom();
y.Inventory[0].WhatIsMyItem();
y.Inventory[1].WhatIsMyItem();
y.Inventory[2].WhatIsMyItem();
testItem = y.Attack();
Console.WriteLine(testItem.WhatIsMyItem());

homework1.Program x = new homework1.Program();

x.Main();