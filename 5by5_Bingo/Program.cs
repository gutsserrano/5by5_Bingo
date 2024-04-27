// ** BINGO **

// Variable to save the bingo card size
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

int cardSize = 5;

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

bool lineBingo;
bool columnBingo;
bool bingo;

int[,] lineBingoMatrix = null;
int[,] columnBingoMatrix = null;
int[,] bingoMatrix = null;


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

string[] readPlayerNames(int quantity)
{
    string[] array = new string[quantity];

    for (int i = 0; i < quantity; i++)
    {
        do
        {
            Console.WriteLine($"Name of the player {i+1}:");
            array[i] = Console.ReadLine();

            if (array[i] == "")
            {
                Console.WriteLine("\nPlease, write the name\n");
            }
        } while (array[i] == "");
    }

    return array;
}

void ReadNameAndCards(string[] name, int[] cardsQtt, int quantity)
{
    for (int i = 0; i < quantity; i++)
    {
        do
        {
            Console.WriteLine($"\nName of the player {i + 1}:");
            name[i] = Console.ReadLine();

            if (name[i] == "")
            {
                Console.WriteLine("\nPlease, write the name\n");
            }
        } while (name[i] == "");

        do
        {
            Console.WriteLine($"\nHow many Bingo Cards player {name[i]} will take?");
            cardsQtt[i] = int.Parse(Console.ReadLine());

            if (cardsQtt[i] < 1)
            {
                Console.WriteLine($"\nPlayer {name[i]} must have at least one card!\n");
            }
        } while (cardsQtt[i] < 1);
    }
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

    int sort;
    for (int i = 0; i < drawnNumber.Length; i++)
    {
        for (int j = 0; j < drawnNumber.Length - 1; j++)
        {
            if (drawnNumber[j] < drawnNumber[j + 1])
            {
                sort = drawnNumber[j + 1];
                drawnNumber[j + 1] = drawnNumber[j];
                drawnNumber[j] = sort;
            }
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
        Console.Write($"- {array[i]} ");
    }

    Console.WriteLine("\n");
}

// Function to print all cards in the game
void printAllCards(int[][,] cards, int[] reference, string[] names)
{
    for (int i = 0; i < cards.Length; i++)
    {
        if(i > 0)
        {
            if (reference[i] != reference[i - 1] || i == 0)
            {
                Console.WriteLine($"{names[reference[i]]} cards: ");
            }
        }
        else
        {
            Console.WriteLine($"{names[i]} cards: ");
        }        
        printMatrix(cards[i]);
    }
}

void printAlignedMatrixes(int[][,] cards, int[] reference, int[] cardsQtt, string[] names)
{
    // TODO
}

// Function to print a Matrix (card)
void printMatrix(int[,] matrix)
{
    Console.WriteLine(" ______________________");
    Console.WriteLine("|                      |");
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

// Function to verify the line bingo and return the index of the matrix
int verifyLineBingo(int[][,] cards)
{
    int counter;
    if (!lineBingo)
    {
        for(int i = 0; i < cards.Length && !lineBingo; i++) 
        {          
            for (int line = 0; line < cardSize && !lineBingo; line++) 
            {
                counter = 0;
                for (int column = 0; column < cardSize; column++)
                {
                    if (cards[i][line, column] < 0)
                    {
                        counter++;
                    }

                    if(counter == cardSize)
                    {                       
                        lineBingo = true;
                        lineBingoMatrix = cards[i];
                        return i;
                    }
                }
            }
        }
    }

    return -1;
}

// Function to verify the column bingo and return the index of the matrix
int verifyColumnBingo(int[][,] cards)
{
    int counter;
    if (!columnBingo)
    {
        for (int i = 0; i < cards.Length && !columnBingo; i++)
        {
            for (int line = 0; line < cardSize && !columnBingo; line++)
            {
                counter = 0;
                for (int column = 0; column < cardSize; column++)
                {
                    if (cards[i][column, line] < 0)
                    {
                        counter++;
                    }

                    if (counter == cardSize)
                    {
                        columnBingo = true;
                        columnBingoMatrix = cards[i];
                        return i;
                    }
                }
            }
        }
    }

    return -1;
}

int verifyBingo(int[][,] cards)
{
    int counter = 0;
    int auxIndex = 0;
    for (int i = 0; i < playerReferences.Length; i++)
    {
        auxIndex = i;
        counter = 0;
        for (int line = 0; line < cardSize; line++)
        {
            for (int column = 0; column < cardSize; column++)
            {
                if (cards[i][line, column] < 0)
                {
                    counter++;
                }
            }

            if (counter == cardSize * cardSize)
            {
                bingo = true;
                bingoMatrix = cards[auxIndex];
                return auxIndex;
            }
        }
    }

    return -1;
}

void verifyPoints(int[][,] cards, int[] references, int[] points)
{
    int auxLine = verifyLineBingo(cards);

    if (auxLine != -1)
    {
        points[references[auxLine]] += 1;
    }

    int auxColumn = verifyColumnBingo(cards);
    if (auxColumn != -1)
    {
        points[references[auxColumn]] += 1;
    }

    int auxBingo = verifyBingo(cards);
    if (auxBingo != -1)
    {
        points[references[auxBingo]] += 5;
    }

    if (lineBingoMatrix != null)
    {
        Console.WriteLine("card with Horizontal bingo!\n");
        printMatrix(lineBingoMatrix);
    }

    if (columnBingoMatrix != null)
    {
        Console.WriteLine("card with Vertical Bingo\n");
        printMatrix(columnBingoMatrix);
    }

    if (bingoMatrix != null)
    {
        Console.WriteLine("Bingo card!\n");
        printMatrix(bingoMatrix);
    }
}

void PrintPlayersPoints(int[] points, string[] names)
{
    Console.WriteLine("Players points:");
    for (int i = 0; i < points.Length; i++)
    {
        Console.WriteLine($"{names[i]}: {points[i]} points");
    }
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
    playersNames = new string[playersQuantity];
    cardsQuantity = new int[playersQuantity];
    ReadNameAndCards(playersNames, cardsQuantity, playersQuantity);
    gameCards = createAllCards(cardsQuantity);
    playerReferences = createReferences(cardsQuantity);

    lineBingo = false;
    columnBingo = false;
    bingo = false;

    playersPoints = new int[playersQuantity];

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
        Console.WriteLine($"Drawn Number {drawn}\n");

        VerifyGameCards(gameCards, drawnNumbers);

        verifyPoints(gameCards, playerReferences, playersPoints);

        //printAllCards(gameCards, playerReferences, playersNames);
        printAlignedMatrixes(gameCards, playerReferences, cardsQuantity, playersNames);

        PrintPlayersPoints(playersPoints, playersNames);

        Console.ReadKey();
    } while (!bingo);

} while(ExitMenu());