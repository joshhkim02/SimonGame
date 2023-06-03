/*
    QDD Checklist:
    - Draw the maps -> found off github
    - Print the maps with a delay -> foreach loop + Thread.Sleep(1000); -> put into method
    - Print the maps a certain number of times -> Use for loop 
    - Get map to print each frame randomly -> Initialize random function and use rand.Next(1,5)
    - Figure out how to get input from key presses -> Use ConsoleKey and Console.ReadKey()
    - Make a method that can draw the map randomly a certain number of times WITH delay -> Use for loop with code that randomizes map with delay
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
*/

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
    @"    ║   ╚═══╗╚══╝╔═══╝███║ " + '\n' +
    @"    ║       ║    ║███████║ " + '\n' +
    @"    ║   ╔═══╝╔══╗╚═══╗███║ " + '\n' +
    @"    ╚═══╝   ╔╝  ╚╗   ╚═══╝ " + '\n' +
    @"           ╔╝    ╚╗        " + '\n' +
    @"           ║      ║        " + '\n' +
    @"           ╚══════╝        ",
	// 3
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
	// 4
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
    @"           ╚══════╝        "
    #endregion
};


void DrawMap()
{
    for (int i = 0; i < 4; i++)
    {
        Random rand = new Random();
        Console.WriteLine(Renders[rand.Next(1, 5)]);
        Thread.Sleep(1000);
        Console.Clear();
    }
    Console.WriteLine("Complete!");
}

DrawMap();

// Allow user to use their arrow keys
while (true)
{
    ConsoleKey ch = Console.ReadKey(false).Key;
    switch (ch)
    {
        case ConsoleKey.UpArrow:
            Console.WriteLine("You pressed the up arrow.");
            break;
        case ConsoleKey.DownArrow:
            Console.WriteLine("You pressed the down arrow.");
            break;
        case ConsoleKey.LeftArrow:
            Console.WriteLine("You pressed the left arrow.");
            break;
        case ConsoleKey.RightArrow:
            Console.WriteLine("You pressed the right arrow.");
            break;
    }
    // Exit loop if escape key is pressed
    if (ch == ConsoleKey.Escape)
    {
        break;
    }
}


bool isGameOver = false;

while (isGameOver == false)
{

}