
namespace Methods
{
   class Program
   {
    static void Main(string[]args)
    {
        Console.WriteLine("Choose left or right door");
        Console.WriteLine("Type 'Left' or 'Right' to choose");
        string door = Console.ReadLine();
        if(door == "Left")
        {
            Room1();
        }
        else if(door == "Right")
        {
            Room2();
        }
        else
        {
            
        }
    }
    static void Room1()
    {
        Console.WriteLine("Door is open");
        Console.WriteLine("You see a heavy sack of coins in the room and nothing else");
        Console.WriteLine("Take the sack or leave it to be");
        Console.WriteLine("Type 'Take' or 'Leave'");
        Choice();
    }
    static void Room2()
    {
        Console.WriteLine("Door is open");
        Console.WriteLine("You see a heavy sack of coins in the room and nothing else");
        Console.WriteLine("Take the sack or leave it to be");
        Console.WriteLine("Type 'Take' or 'Leave'");
        Choice();

    }
    static void Choice()
        {
            string choice = Console.ReadLine();
            Random sack = new Random();
            int money = sack.Next(200,300);
            switch(choice)
            {
                case "Take":
                Console.WriteLine($"You now have {money} coins of gold!");
                break;

                case "Leave":
                Console.WriteLine("You leave this room with nothing");
                break;
            }
        }
    }
}
