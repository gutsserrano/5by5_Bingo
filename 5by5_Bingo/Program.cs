// ** BINGO **

int playersQuantity = 2;

int[] cardsQuantity = new int[playersQuantity];

// sum is the amount of cards of the players summed
int sum = 0;
int[][,] gameCards;

int[] playersPoints;
string[] playersNames;

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
            Console.WriteLine($"How many Bingo Cards player {i + 1} will take?");
            array[i] = int.Parse(Console.ReadLine());

            if (array[i] < 1)
            {
                Console.WriteLine($"\nPlayer {i+1} must have at least one card!\n");
            }
        } while (array[i] < 1);
    }

    return array;
}

int[][,] createAllCards(int[] cardsQtt)
{
    int sum = 0;
    for (int i = 0; i < cardsQtt.Length; i++)
    {
        sum += cardsQtt[i];
    }
    return new int[sum][,];
}

playersQuantity = readPlayersQuantity();

cardsQuantity = readCardsQuantity(playersQuantity);

gameCards = createAllCards(cardsQuantity);

playersPoints = new int[playersQuantity];
playersNames = new string[playersQuantity];