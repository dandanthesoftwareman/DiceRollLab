using System.Text.RegularExpressions;
int dieSides = 0;
int die1 = 0;
int die2 = 0;
bool rollDice = true;
bool setupDice = true;
Console.WriteLine("Welcome to the dice roller");

while (setupDice)
{
    try
    {
        Console.WriteLine("How many sides should each die have?");
        dieSides = int.Parse(Console.ReadLine());

        if (dieSides <= 0)
        {
            throw new Exception("Please enter a poisitve number. You can't have a negative sided die.");
        } 
        break;
    }
    catch (FormatException e)
    {
        Console.WriteLine(e.Message);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

while (rollDice)
{
    die1 = rollDie(dieSides);
    die2 = rollDie(dieSides);
    if (dieSides == 6)
    {
        Console.WriteLine($"You rolled a {die1} and a {die2} (Total {die1 + die2})");
        Console.WriteLine(getCombos(die1, die2));
        while (true)
        {
            Console.WriteLine("Roll Again? y/n");
            string choice = Console.ReadLine();
            if (choice == "y")
            {
                break;
            }
            else if (choice == "n")
            {
                rollDice = false;
                break;
            }
            else
            {
                continue;
            }
        }
    }
    else
    {
        Console.WriteLine($"You rolled a {die1} and a {die2} (Total {die1 + die2})");
        Console.WriteLine(userDice(die1, die2));
        while (true)
        {
            Console.WriteLine("Roll Again? y/n");
            string choice = Console.ReadLine();
            if (choice == "y")
            {
                break;
            }
            else if (choice == "n")
            {
                rollDice = false;
                break;
            }
            else
            {
                continue;
            }
        }
    }
}

static int rollDie(int x)
{
    Random rnd = new Random();
    x = rnd.Next(1, x);
    return x;
}

static string getCombos(int x, int y)
{
    if (x + y == 7 || x + y == 11)
    {
        return "Win!";
    }
    if (x == 1 && y == 1)
    {
        return "Snake Eyes!";
    }
    if (x == 6 && y == 6)
    {
        return "Box Cars!";
    }
    if (x + y == 3 || x + y == 12 || x + y == 2)
    {
        return "Craps!";
    }
    else
    {
        return " ";
    }
}

static string userDice(int x, int y)
{
    if (x == y)
    {
        return "Mathcing Baby";
    }
    else
    {
        return "";
    }
}