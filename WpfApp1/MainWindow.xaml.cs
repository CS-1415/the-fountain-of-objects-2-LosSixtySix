using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int tSize;
        public Maze? mainMaze;
        public Thickness current = new Thickness(450,450,0,0);
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("Welcome!\nTo start the game input a size(small, medium, or large) then press start\n To move indicate a direction with the cardinal directions\neast, west, north and south\nTo pickup items off of the ground type Pickup and then it will ask for an index.\n Find the fountain and return to the entrance.\nGoodluck!");
        }
        public bool ValidSizeInput(string x)
        {
            if (x != null)
            {
                x = x.ToLower();
            }
            else
            {
                return false;
            }

            if (x == "small" || x == "medium" || x == "large")
            {
                return true;
            }
            return false;
        }
        public int TranslateToInt(string x)
        {
            if (ValidSizeInput(x))
            {
                x = x.ToLower();
                if (x == "small")
                {
                    return 1;
                }
                else if (x == "medium")
                {
                    return 2;
                }
                else if (x == "large")
                {
                    return 3;
                }
            }
            return 0;
        }
        private void buildMaze()
        {
            mainMaze = new Maze(tSize);
        }

        private void takeInput1(object sender, RoutedEventArgs e)
        {
            tSize = 1;
            string? size = input1.Text;
            tSize = TranslateToInt(size);
            if (tSize == 0) { MessageBox.Show("That is not a valid input"); }
            else { buildMaze(); Drawer("null"); grid1.Children.Remove(input1); grid1.Children.Remove(button1); statistics.Text = mainMaze.CurrentRoom.PrintMessage(); inventory.Text = mainMaze.Player.DisplaySelf(); inventory.Text += mainMaze.Player.DisplayInventory(); }

        }

        private void Toggle(object sender, EventArgs e)
        {
            int[] memory = new int[] { (Int32)current.Left, (Int32)current.Top, (Int32)current.Right, (Int32)current.Bottom };
            if (mainMaze.NumOfRooms < Math.Pow(mainMaze.Size, 2) && mainMaze.Combat == false)
            {

                if (input2.Text == "east")
                {
                    string checkWall1 = mainMaze.CheckMemory("east", memory);
                    if (checkWall1 == "exists")
                    {
                        current.Left += 22;
                        location.Margin = current;
                    }
                    else if (checkWall1 == "wall")
                    {
                        Log.Text += "You hit a Wall\n";
                    }
                    else
                    {
                        string checkWall = mainMaze.Move("east");
                        if (checkWall == "wall")
                        {
                            Log.Text += "You hit a Wall\n";
                        }
                        else
                        {
                            Drawer("east");
                            Log.Text += $"{input2.Text}\n";
                        }

                    }

                }
                else if (input2.Text == "west")
                {
                    string checkWall1 = mainMaze.CheckMemory("west", memory);
                    if (checkWall1 == "exists")
                    {
                        current.Left -= 22;
                        location.Margin = current;
                    }
                    else if (checkWall1 == "wall")
                    {
                        Log.Text += "You hit a Wall\n";
                    }
                    else
                    {
                        string checkWall = mainMaze.Move("west");
                        if (checkWall == "wall")
                        {
                            Log.Text += "You hit a Wall\n";
                        }
                        else
                        {
                            Drawer("west");
                            Log.Text += $"{input2.Text}\n";
                        }

                    }

                }
                else if (input2.Text == "north")
                {
                    string checkWall1 = mainMaze.CheckMemory("north", memory);
                    if (checkWall1 == "exists")
                    {
                        current.Top -= 30;
                        location.Margin = current;
                    }
                    else if (checkWall1 == "wall")
                    {
                        Log.Text += "You hit a Wall\n";
                    }
                    else
                    {
                        string checkWall = mainMaze.Move("north");
                        if (checkWall == "wall")
                        {
                            Log.Text += "You hit a Wall\n";
                        }
                        else
                        {
                            Drawer("north");
                            Log.Text += $"{input2.Text}\n";
                        }

                    }

                }
                else if (input2.Text == "south")
                {
                    string checkWall1 = mainMaze.CheckMemory("south", memory);
                    if (checkWall1 == "exists")
                    {
                        current.Top += 30;
                        location.Margin = current;
                    }
                    else if (checkWall1 == "wall")
                    {
                        Log.Text += "You hit a Wall\n";
                    }
                    else
                    {
                        string checkWall = mainMaze.Move("south");
                        if (checkWall == "wall")
                        {
                            Log.Text += "You hit a Wall\n";
                        }
                        else
                        {
                            Drawer("south");
                            Log.Text += $"{input2.Text}\n";
                        }

                    }

                }
            }
            else if (input2.Text == "Pickup Item" || input2.Text == "pickup" || input2.Text == "pick up" || input2.Text == "Pickup" || input2.Text == "Pick up")
            {
                if(mainMaze.CurrentRoom.Floor.Count()>0)
                {
                    mainMaze.Pickup = true;
                }
                else
                {
                    Log.Text += "There are no items to pickup\n";
                }
            }
            else if(mainMaze.Combat)
            {
                Log.Text += "Combat has ensued, you can not leave this room\n";
            }
            else
            {
                Log.Text += "There is Rubble in your way\n";
            }
            inventory.Text = mainMaze.Player.DisplaySelf();
            inventory.Text += mainMaze.Player.DisplayInventory();
            
            statistics.Text = mainMaze.CurrentRoom.PrintMessage();

            mainMaze.checkRoom();
            if(mainMaze.GameWon)
            {
                MessageBox.Show("You have won the Game!");
                this.Close();
            }
            else if(mainMaze.Lost)
            {
                MessageBox.Show("You have lost the Game!");
                this.Close();
            }
            input2.Text = "";
            Log.ScrollToEnd();
            if (mainMaze.CurrentRoom.Floor.Count() <= 0)
            {
                mainMaze.CurrentRoom.isEmpty= true;
            }

        }
        private void Pickup(object sender, EventArgs e)
        {
            Log.Text += "Select an Item by the index to pick it up, type done to end\n";
            int index = 0;
            if(int.TryParse(input2.Text,out index) && index < mainMaze.Player.Inventory.Count())
            {
                mainMaze.Player.Inventory.Add(mainMaze.CurrentRoom.Floor[index]);
                mainMaze.CurrentRoom.Floor.Remove(mainMaze.CurrentRoom.Floor[index]);
            }
            else
            {
                Log.Text += "No item at that index\n";
            }

            if(input2.Text == "done" || input2.Text == "Done")
            {
                mainMaze.Pickup = false;
            }
            if(mainMaze.CurrentRoom.Floor.Count() <= 0)
            {
                mainMaze.Pickup = false;
            }
        }
        private void Combat(object sender, EventArgs e)
        {
            Random rand = new Random();
            if(mainMaze.Combat)
            {
                Log.Text += "Combat has started!";
                Log.Text += "Select and item using its index to use it!\n";
            }
            int index = 0;
            int damage = 0;
            int attackRoll = 0;
            if(int.TryParse(input2.Text, out index) && index < mainMaze.Player.Inventory.Count())
            {
                damage = mainMaze.Player.Attack(mainMaze.Player.Inventory[index]);
                double durLoss = 0;
                while(durLoss > .10)
                {
                    durLoss = rand.NextDouble();
                }
                mainMaze.Player.Inventory[index].Durability -= (float)durLoss;
                attackRoll = mainMaze.Player.Inventory[index].BonusToHit + rand.Next(101);
            }
            else
            {
                Log.Text += "No item at that index\n";
            }
            float tempNum = damage * (attackRoll / mainMaze.CurrentRoom.Container[0].Defence);
            mainMaze.CurrentRoom.Container[0].Hp -= (int)tempNum;
            Log.Text += $"Your Damage:{(int)tempNum}\n";
            if (mainMaze.CurrentRoom.Container[0].Hp <= 0)
            {
                mainMaze.Combat = false;
                mainMaze.CurrentRoom.Floor = mainMaze.CurrentRoom.Container[0].dropItems();
                mainMaze.CurrentRoom.Container.Clear();
            }
            else
            {
                damage = mainMaze.CurrentRoom.Container[0].Attack(mainMaze.CurrentRoom.Container[0].Inventory[0]);
                attackRoll = mainMaze.CurrentRoom.Container[0].Inventory[0].BonusToHit + rand.Next(101);
                float monTempNum = damage * (attackRoll / mainMaze.Player.Defence);
                mainMaze.Player.Hp -= (int)monTempNum;
                Log.Text += $"Enemy Damage:{(int)monTempNum}\n";
                if (mainMaze.Player.Hp <= 0)
                {
                    mainMaze.Combat = false;
                    mainMaze.Lost = true;
                }
            }



            input2.Text = "";
            inventory.Text = mainMaze.Player.DisplaySelf();
            inventory.Text += mainMaze.Player.DisplayInventory();
            statistics.Text = mainMaze.CurrentRoom.PrintMessage();
            Log.ScrollToEnd();
        }
        private void Drawer(string dir)
        {
            

            if (mainMaze.NumOfRooms == 0)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.FontFamily = new FontFamily("Consolas");
                textBlock.Foreground = Brushes.LightSeaGreen;
                textBlock.Margin = current;
                textBlock.Width = 100;
                textBlock.Height = 97;
                textBlock.HorizontalAlignment = HorizontalAlignment.Left;
                textBlock.VerticalAlignment = VerticalAlignment.Top;
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.Text = $"{mainMaze.CurrentRoom.printRoom()}";
                grid1.Children.Add(textBlock);
                mainMaze.NumOfRooms += 1;
                location.FontFamily = new FontFamily("Consolas");
                location.FontSize = 25;
                location.Content = "+";
                location.Margin = current;
                int[] memory = new int[] { (Int32)current.Left, (Int32)current.Top, (Int32)current.Right, (Int32)current.Bottom };
                mainMaze.AddtoMemory(memory);
            }
            else if(mainMaze.NumOfRooms < Math.Pow(mainMaze.Size,2))
            {
                TextBlock textBlock = new TextBlock();
                textBlock.FontFamily = new FontFamily("Consolas");
                if (dir == "east")
                {
                    current.Left += 22;
                    textBlock.Margin = current;
                    int[] memory = new int[] { (Int32)current.Left, (Int32)current.Top, (Int32)current.Right, (Int32)current.Bottom };
                    mainMaze.AddtoMemory(memory);
                }
                else if(dir == "west")
                {
                    current.Left -= 22;
                    textBlock.Margin = current;
                    int[] memory = new int[] { (Int32)current.Left, (Int32)current.Top, (Int32)current.Right, (Int32)current.Bottom };
                    mainMaze.AddtoMemory(memory);
                }
                else if(dir == "north")
                {
                    current.Top -= 30;
                    textBlock.Margin = current;
                    int[] memory = new int[] { (Int32)current.Left, (Int32)current.Top, (Int32)current.Right, (Int32)current.Bottom };
                    mainMaze.AddtoMemory(memory);
                }
                else if(dir == "south")
                {
                    current.Top += 30;
                    textBlock.Margin = current;
                    int[] memory = new int[] { (Int32)current.Left, (Int32)current.Top, (Int32)current.Right, (Int32)current.Bottom };
                    mainMaze.AddtoMemory(memory);
                }
                textBlock.Width = 100;
                textBlock.Height = 97;
                textBlock.Foreground = Brushes.LightSeaGreen;
                textBlock.HorizontalAlignment = HorizontalAlignment.Left;
                textBlock.VerticalAlignment = VerticalAlignment.Top;
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.Text = $"{mainMaze.CurrentRoom.printRoom()}";
                grid1.Children.Add(textBlock);
                mainMaze.NumOfRooms += 1;
                location.Margin = current;

            }
        }

        private void Log_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void input2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter && mainMaze.Combat == false) { Toggle(this, new EventArgs()); }
            else if(e.Key == Key.Enter && mainMaze.Combat) { Combat(this, new EventArgs()); }
            else if(e.Key == Key.Enter && mainMaze.Pickup) { Pickup(this,new EventArgs()); }
        }

    }
}