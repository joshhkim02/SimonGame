/*
QDD Checklist:
- Draw the maps -> found off github
- Print the maps with a delay -> foreach loop + Thread.Sleep(1000); -> put into method
- Print the maps a certain number of times -> Use for loop 
- Get map to print each frame randomly -> Initialize random function and use rand.Next(1,5)
- Figure out how to get input from key presses -> Use ConsoleKey and Console.ReadKey()
- Make a method that can draw the map randomly a certain number of times WITH delay -> Use for loop with code that randomizes map with delay
- Program logic of the game ->
*/

/*
    Notes:
    1. Do not have to use await Task.Delay() in this case as Thread.Sleep is fine for console apps
       However, if you want to use Task.Delay(), DON'T FORGET to add "await" before calling a method
    EX:
    async Task DrawMap()
    {
        foreach (string s in Renders)
        {
            Console.WriteLine(s);
            await Task.Delay(1000);
            Console.Clear();
        }
        Console.WriteLine("Complete!");
    }
    await DrawMap();

    2. Thread.Sleep() is not asynchronous unlike Task.Delay(), can define the method normally

    3.
    // void version of lighting up map
    //void LightUpMap()
    //{
    //        Random rand = new Random();
    //        Console.WriteLine(Renders[rand.Next(1, 5)]);
    //        Thread.Sleep(1000);
    //        Console.Clear();
    //}
*/

using System.ComponentModel;
using System.Xml.Schema;

Random rand = new Random();
int score = 0;
List<Direction> pattern = new();

string[] Renders = new string[]
{
	#region Frames
    // 0
    @"           ╔══════╗        " + '\n' +
    @"           ║      ║        " + '\n' +
    @"           ╚╗    ╔╝        " + '\n' +
    @"    ╔═══╗   ╚╗  ╔╝   ╔═══╗ " + '\n' +
    @"    ║   ╚═══╗╚══╝╔═══╝   ║ " + '\n' +
    @"    ║       ║    ║       ║ " + '\n' +
    @"    ║   ╔═══╝╔══╗╚═══╗   ║ " + '\n' +
    @"    ╚═══╝   ╔╝  ╚╗   ╚═══╝ " + '\n' +
    @"           ╔╝    ╚╗        " + '\n' +
    @"           ║      ║        " + '\n' +
    @"           ╚══════╝        ",
	// 1
	@"           ╔══════╗        " + '\n' +
    @"           ║██████║        " + '\n' +
    @"           ╚╗████╔╝        " + '\n' +
    @"    ╔═══╗   ╚╗██╔╝   ╔═══╗ " + '\n' +
    @"    ║   ╚═══╗╚══╝╔═══╝   ║ " + '\n' +
    @"    ║       ║    ║       ║ " + '\n' +
    @"    ║   ╔═══╝╔══╗╚═══╗   ║ " + '\n' +
    @"    ╚═══╝   ╔╝  ╚╗   ╚═══╝ " + '\n' +
    @"           ╔╝    ╚╗        " + '\n' +
    @"           ║      ║        " + '\n' +
    @"           ╚══════╝        ",
	// 2
    @"           ╔══════╗        " + '\n' +
    @"           ║      ║        " + '\n' +
    @"           ╚╗    ╔╝        " + '\n' +
    @"    ╔═══╗   ╚╗  ╔╝   ╔═══╗ " + '\n' +
    @"    ║   ╚═══╗╚══╝╔═══╝   ║ " + '\n' +
    @"    ║       ║    ║       ║ " + '\n' +
    @"    ║   ╔═══╝╔══╗╚═══╗   ║ " + '\n' +
    @"    ╚═══╝   ╔╝██╚╗   ╚═══╝ " + '\n' +
    @"           ╔╝████╚╗        " + '\n' +
    @"           ║██████║        " + '\n' +
    @"           ╚══════╝        ",
	// 3
    @"           ╔══════╗        " + '\n' +
    @"           ║      ║        " + '\n' +
    @"           ╚╗    ╔╝        " + '\n' +
    @"    ╔═══╗   ╚╗  ╔╝   ╔═══╗ " + '\n' +
    @"    ║███╚═══╗╚══╝╔═══╝   ║ " + '\n' +
    @"    ║███████║    ║       ║ " + '\n' +
    @"    ║███╔═══╝╔══╗╚═══╗   ║ " + '\n' +
    @"    ╚═══╝   ╔╝  ╚╗   ╚═══╝ " + '\n' +
    @"           ╔╝    ╚╗        " + '\n' +
    @"           ║      ║        " + '\n' +
    @"           ╚══════╝        ",
	// 4
    @"           ╔══════╗        " + '\n' +
    @"           ║      ║        " + '\n' +
    @"           ╚╗    ╔╝        " + '\n' +
    @"    ╔═══╗   ╚╗  ╔╝   ╔═══╗ " + '\n' +
    @"    ║   ╚═══╗╚══╝╔═══╝███║ " + '\n' +
    @"    ║       ║    ║███████║ " + '\n' +
    @"    ║   ╔═══╝╔══╗╚═══╗███║ " + '\n' +
    @"    ╚═══╝   ╔╝  ╚╗   ╚═══╝ " + '\n' +
    @"           ╔╝    ╚╗        " + '\n' +
    @"           ║      ║        " + '\n' +
    @"           ╚══════╝        "
    #endregion
};

bool appStatus = true;
while (appStatus == true)
{
    pattern.Add((Direction)rand.Next(1, 5));
    DrawPattern();
    DrawBase();
    for (int i = 0; i < pattern.Count; i++)
    {
        ConsoleKey ch = Console.ReadKey(false).Key;
        switch (ch)
        {
            case ConsoleKey.UpArrow:
                if (pattern[i] == Direction.Up)
                {
                    DrawPlayerChoice(Direction.Up);
                    score++;
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine($"Game over, your score was {score}");
                    appStatus = false;
                }
                break;
            case ConsoleKey.DownArrow:
                if (pattern[i] == Direction.Down)
                {
                    DrawPlayerChoice(Direction.Down);  
                    score++;
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine($"Game over, your score was {score}");
                    appStatus = false;
                }
                break;
            case ConsoleKey.LeftArrow:
                if (pattern[i] == Direction.Left)
                {
                    DrawPlayerChoice(Direction.Left);
                    score++;
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine($"Game over, your score was {score}");
                    appStatus = false;
                }
                break;
            case ConsoleKey.RightArrow:
                if (pattern[i] == Direction.Right)
                {
                    DrawPlayerChoice(Direction.Right);
                    score++;
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine($"Game over, your score was {score}");
                    appStatus = false;
                }
                break;
            case ConsoleKey.Escape:
                Console.WriteLine("Goodbye!");
                appStatus = false;
                break;
        }
    }
}

void DrawPattern()
{
    for (int i = 0; i < pattern.Count; i++)
    {
        Console.Clear();
        Console.WriteLine(Renders[(int)pattern[i]]);
        Thread.Sleep(1000);
    }
}

void DrawBase()
{
    Console.Clear();
    Console.WriteLine(Renders[0]);
}

void DrawPlayerChoice(Direction direction)
{
    Console.Clear();
    Console.WriteLine(Renders[(int)direction]);
    Thread.Sleep(1000);
    DrawBase();
}

enum Direction
{
    Up = 1,
    Down = 2,
    Left = 3,
    Right = 4
}