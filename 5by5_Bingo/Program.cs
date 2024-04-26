// ** BINGO **

// Variable to save the bingo card size
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

int cardSize = 5;

// Variable to set the max value in the card
int cardMaxValue = 26;

// Variable to set the max value to draw 
int bingoDrawMaxValue = 100;

// Array to save all the drawn numbers
int[] drawnNumbers  = new int[bingoDrawMaxValue - 1];

// The quantity of players in the game
int playersQuantity;

// The amount of cards of each player
int[] cardsQuantity;

// gameCards has the amount of cards of the players summed
int[][,] gameCards;

int[] playerReferences;

// The points of each player
int[] playersPoints;

// The name of each player
string[] playersNames;

// Variable to count the point in gameCards
int count;


// Function to read the amount of players
int readPlayersQuantity()
{
    int quantity;
    do
    {
        Console.WriteLine("\nHow many people will play?");
        quantity = int.Parse(Console.ReadLine());

        if (quantity < 2)
        {
            Console.WriteLine("\nMust have 2 players or more to play\n");
        }
    } while (quantity < 2);

    return quantity;
}

// Function to read te amount of cards fow wich player
int[] readCardsQuantity(int quantity)
{
    int[] array = new int[quantity];

    for (int i = 0; i < quantity; i++)
    {
        do
        {
            Console.WriteLine($"\nHow many Bingo Cards player {i + 1} will take?");
            array[i] = int.Parse(Console.ReadLine());

            if (array[i] < 1)
            {
                Console.WriteLine($"\nPlayer {i+1} must have at least one card!\n");
            }
        } while (array[i] < 1);
    }

    return array;
}

// Function to create the array of all cards in the game 
int[][,] createAllCards(int[] cardsQtt)
{
    int sum = 0;
    for (int i = 0; i < cardsQtt.Length; i++)
    {
        sum += cardsQtt[i];
    }
    return new int[sum][,];
}

// Function to create the array of references to the players index
int[] createReferences(int[] cardsQtt)
{
    int sum = 0;
    bool stop = false;
    for (int i = 0; i < cardsQtt.Length; i++)
    {
        sum += cardsQtt[i];
    }

    int[] reference = new int[sum];

    for(int player = 0, count = 0; player < cardsQtt.Length; player++)
    {
        for (int i = 0; i < cardsQtt[player]; i++, count++)
        {
            reference[count] = player;
        }
    }

    return reference;
}

// Function to fill a matrix of random numbers
int[,] FillMatriX(int sideSize, int maxValue)
{
    int[,] matrix = new int[sideSize, sideSize];
    int aux;
    for (int line = 0; line < sideSize; line++)
    {
        for (int column = 0; column < sideSize; column++)
        {
            do
            {
                aux = new Random().Next(1, maxValue);
            } while (ExistsInMatrix(matrix, aux));
            matrix[line, column] = aux;
        }
    }
    return matrix;
}

// Function to draw a number
int DrawNumber(int[] drawnNumber, int max)
{
    bool stop = false;
    int aux;
    do
    {
        aux = GetRandom(1, max);
    } while(ExistsInArray(drawnNumber, aux));
    
    for (int i = 0; i < drawnNumber.Length && !stop; i++)
    {
        if (drawnNumber[i] == 0)
        {
            drawnNumber[i] = aux;
            stop = true;
        }
    }
    
    return aux;
    
}

// Function to verify all cards
void VerifyGameCards(int[][,] matrix, int[] numbers)
{
    for (int i = 0; i < matrix.GetLength(0); i++) 
    {
        for (int j = 0; j < numbers.Length && numbers[i] != 0; j++)
        {
            MarkValue(matrix[i], numbers[j]);
        }
    }
}

// Function no mark a value if exists
void MarkValue(int[,] matrix, int value)
{
    for (int line = 0; line < matrix.GetLength(0); line++) 
    {
        for (int column = 0; column < matrix.GetLength(1); column++) 
        {
            if (matrix[line, column] == value)
            {
                matrix[line, column] = value * (-1);
            }
        }   
    }
}

// Function to verify if a number exists in a matrix
bool ExistsInMatrix(int[,] matrix, int number)
{
    for (int line = 0; line < matrix.GetLength(0); line++)
    {
        for(int column = 0; column < matrix.GetLength(1); column++)
        {
            if(number == matrix[line, column]) 
                return true;
        }
    }
    return false;
}

// Function to verify if a number exists in a array
bool ExistsInArray(int[] array, int number)
{
    for (int i = 0; i < array.Length; i++)
    {
        if(number == array[i]) 
            return true;
    }
    return false;
}

// Function to print an array
void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length && array[i] != 0;i++)
    {
        Console.Write($"{array[i]} - ");
    }

    Console.WriteLine("\n");
}

// Function to print all cards in the game
void printAllCards(int[][,] cards, int[] reference)
{
    for (int i = 0; i < cards.Length; i++)
    {
        Console.WriteLine($"Player {reference[i]}");
        Console.WriteLine(" ______________________");
        Console.WriteLine("|                      |");
        printMatrix(cards[i]);
    }
}

// Function to print a Matrix (card)
void printMatrix(int[,] matrix)
{
    for (int line = 0; line < cardSize; line++)
    {
        for (int column = 0; column < cardSize; column++)
        {
            if (column == 0)
            {
                Console.Write("| ");
            }
            if (matrix[line, column] > 0)
            {
                Console.Write($" {matrix[line, column]:00} ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write($"{matrix[line, column]:00}-");
                Console.ResetColor();
            }
            if (column == 4)
            {
                Console.Write(" |");
            }
        }

        if (line != 4)
        {
            Console.WriteLine();
            Console.WriteLine("|                      |");
        }
        else
        {
            Console.WriteLine();
        }
    }
    Console.WriteLine("|______________________| ");
    Console.WriteLine();

}

// Function to geta a random number
int GetRandom(int min, int max)
{
    return new Random().Next(min, max);
}

// Function to clear the screen and print a "Bingo" title
void Title()
{
    Console.Clear();
    Console.WriteLine("   ____   _                      \r\n  |  _ \\ (_)                     \r\n  | |_) | _  _ __    __ _   ___  \r\n  |  _ < | || '_ \\  / _` | / _ \\ \r\n  | |_) || || | | || (_| || (_) |\r\n  |____/ |_||_| |_| \\__, | \\___/ \r\n                     __/ |       \r\n                    |___/        ");
}

// Function to play again or not
bool ExitMenu()
{
    string option = "";
    Console.WriteLine("\nDo you wanna play again?");
    Console.WriteLine("Type 'y' for yes");
    Console.WriteLine("Type any other key to exit");
    option = Console.ReadLine();

    if(option == "y")
    {
        return true;
    }
    return false;
}

do
{
    playersQuantity = readPlayersQuantity();
    cardsQuantity = readCardsQuantity(playersQuantity);
    gameCards = createAllCards(cardsQuantity);
    playerReferences = createReferences(cardsQuantity);

    playersPoints = new int[playersQuantity];
    playersNames = new string[playersQuantity];

    // Fill all the matrixes with random numbers
    for (int i = 0; i < gameCards.Length; i++)
    {
        gameCards[i] = FillMatriX(cardSize, bingoDrawMaxValue);
    }

    do
    {
        Title();
        int drawn;
        drawn = DrawNumber(drawnNumbers, bingoDrawMaxValue);

        PrintArray(drawnNumbers);
        Console.WriteLine($"Drawn Number {drawn}");

        VerifyGameCards(gameCards, drawnNumbers);

        printAllCards(gameCards, playerReferences);
        Console.ReadKey();
    } while (true);

} while(ExitMenu());