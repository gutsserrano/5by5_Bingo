// ** BINGO **

// Variable to save the bingo card size
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
void DrawNumber(int[] drawnNumber)
{
    bool stop = false;
    int aux;
    do
    {
        aux = GetRandom(1, 100);
    } while(ExistsInArray(drawnNumber, aux));
    
    for (int i = 0; i < drawnNumber.Length && !stop; i++)
    {
        if (drawnNumber[i] == 0)
        {
            drawnNumber[i] = aux;
            stop = true;
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
    Title();
    count = 0;

    playersQuantity = readPlayersQuantity();

    cardsQuantity = readCardsQuantity(playersQuantity);

    gameCards = createAllCards(cardsQuantity);

    playersPoints = new int[playersQuantity];
    playersNames = new string[playersQuantity];

    // Fill all the matrixes with random numbers
    for(int i = 0; i < gameCards.Length; i++)
    {
        gameCards[i] = FillMatriX(cardSize, bingoDrawMaxValue);
    }

    // print all matrixes
    for (int i = 0; i < gameCards.Length; i++)
    {
        for (int line = 0; line < cardSize; line++)
        {
            for (int column = 0; column < cardSize; column++)
            {

                Console.Write($"{gameCards[i][line, column]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("\n-----------------------------\n");
    }

    DrawNumber(drawnNumbers);

    PrintArray(drawnNumbers);

} while(ExitMenu());