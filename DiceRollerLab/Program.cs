using System.Text.RegularExpressions;
int dieSides = 0;
int die1 = 0;
int die2 = 0;
int roll = 1;
int total = 0;
bool rollDice = true;
bool setupDice = true;

//Greeting//
Console.WriteLine("Welcome to the dice roller");

//Set die sides, user-proof input. Loops until user enters valid input
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
    total = die1 + die2;

    //Starts the roll for 6 sided dice. loops until user enters "n" to stop program
    //uses getCombos method to return pairings
    if (dieSides == 6)
    {
        Console.WriteLine($"Roll {roll}:");
        Console.WriteLine($"You rolled a {die1} and a {die2} (Total {total})");
        Console.WriteLine(getCombos(die1, die2) + " " + diceTotals(total));
        while (true)
        {
            Console.WriteLine("Roll Again? y/n");
            string choice = Console.ReadLine();
            if (choice == "y")
            {
                roll++;
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
        //Starts the dice roll for user specified dice. 
        //uses userDice method to return pairings
        Console.WriteLine($"Roll {roll}:");
        Console.WriteLine(getCombos(die1, die2) + " " + diceTotals(total));
        Console.WriteLine(userDice(die1, die2));
        while (true)
        {
            Console.WriteLine("Roll Again? y/n");
            string choice = Console.ReadLine();
            if (choice == "y")
            {
                roll++;
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
    else
    {
        return " ";
    }
}

static string diceTotals(int x)
{
    if (x == 3 || x == 12 || x == 2)
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
        return "Hey! Doubles!";
    }
    if (x + y == 69)
    {
        return "nice";
    }
    if (x + y == 314 || (x == 3 && y == 14) || (y == 3 && x == 14))
    {
        return "pi";
    } 
    if (x == 2 && y == 2)
    {
        return "hop on the two-two train!";
    }
    else
    {
        return "";
    }
}
