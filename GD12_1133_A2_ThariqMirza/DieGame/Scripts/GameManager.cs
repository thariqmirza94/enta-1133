using DieGame.Scripts;

public class GameManager
{
    private Player player = new Player();  // Initialize Player instance
    private Room[,] grid = new Room[3, 3];  // 3x3 grid representing the rooms of the asylum
    private int playerX = 1;  // Player starts in the middle of the grid (1,1)
    private int playerY = 1;

    private static Random random = new Random();  // Shared Random instance for dice rolls

    // Method to start the game
    public void StartGame()
    {
        SetupGrid();  // Initialize the room grid
        DisplayIntro();  // Display a welcome message and game intro

        // Main game loop
        while (player.hp > 0 && player.poisonMeter < 100)
        {
            Room currentRoom = grid[playerX, playerY];  // Room can't be null after initialization
            Console.WriteLine($"You are in the {currentRoom.RoomName}.");
            currentRoom.OnRoomEntered();  // Call the room's entry behavior

            // Check if the room is a CombatRoom and start combat automatically
            if (currentRoom is CombatRoom combatRoom)
            {
                StartPillDiceGame(combatRoom);  // Automatically start combat if it's a CombatRoom
            }
            else
            {
                // Present player with available options
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1: Move to another room");
                Console.WriteLine("2: Search the room");
                Console.WriteLine("3: Check your inventory");
                Console.WriteLine("4: Check your status");
                Console.WriteLine("5: Quit game");
                string? input = Console.ReadLine();  // Nullable input handling

                if (input != null)
                {
                    // Handle player's input
                    switch (input)
                    {
                        case "1":
                            MoveToNextRoom();  // Move to another room
                            break;
                        case "2":
                            SearchRoom();  // Search the room for items
                            break;
                        case "3":
                            player.Inventory.ShowInventory();  // Show player's inventory
                            break;
                        case "4":
                            player.CheckStatus();  // Show player's current status (HP, poison meter)
                            break;
                        case "5":
                            Console.WriteLine("Quitting the game...");
                            return;  // Exit the game
                        default:
                            Console.WriteLine("Invalid input.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Input cannot be null. Please try again.");
                }
            }
        }

        // End the game if the player dies or the poison meter reaches 100
        GameOver();
    }

    // Initializes the 3x3 grid of rooms
    private void SetupGrid()
    {
        grid[0, 2] = new TreasureRoom();  // Top left
        grid[1, 2] = new CombatRoom();    // Top middle
        grid[2, 2] = new PuzzleRoom();    // Top right

        grid[0, 1] = new PuzzleRoom();    // Mid left
        grid[1, 1] = new StartRoom();     // Starting room in the middle
        grid[2, 1] = new CombatRoom();    // Mid right

        grid[0, 0] = new TreasureRoom();  // Bottom left
        grid[1, 0] = new CombatRoom();    // Bottom middle
        grid[2, 0] = new PuzzleRoom();    // Bottom right
    }

    // Displays a simple introductory message for the game
    private void DisplayIntro()
    {
        Console.WriteLine("Welcome to the twisted asylum...");
        Console.WriteLine("You find yourself trapped inside, forced into twisted games by the asylum’s deranged inhabitants.");
    }

    // Allows the player to move to a new room in the grid
    private void MoveToNextRoom()
    {
        Console.WriteLine("Which direction would you like to go? (North, South, East, West)");
        string? direction = Console.ReadLine()?.ToLower();  // Nullable string input for direction
        int newX = playerX;  // Temporary variables to store new position
        int newY = playerY;

        // Update the player's coordinates based on the input
        switch (direction)
        {
            case "north":
                newY++;  // Move up
                break;
            case "south":
                newY--;  // Move down
                break;
            case "east":
                newX++;  // Move right
                break;
            case "west":
                newX--;  // Move left
                break;
            default:
                Console.WriteLine("Invalid direction.");
                return;  // Exit if invalid direction
        }

        // Ensure the player stays within the bounds of the grid
        if (newX >= 0 && newX < 3 && newY >= 0 && newY < 3)
        {
            playerX = newX;
            playerY = newY;
        }
        else
        {
            Console.WriteLine("You can't move in that direction.");
        }
    }

    // Searches the current room for items or events
    private void SearchRoom()
    {
        Room currentRoom = grid[playerX, playerY];  // Room can't be null after initialization
        currentRoom.OnRoomSearched(player);  // Trigger the search behavior of the room
    }

    // Start the Pill Dice Game when encountering an enemy in a CombatRoom
    private void StartPillDiceGame(CombatRoom room)
    {
        Console.WriteLine($"A deranged inmate forces you into their twisted dice game in the {room.RoomName}!");

        // Loop until the player or the enemy is defeated (or poisoned)
        while (player.hp > 0 && room.Enemy.IsAlive() && player.poisonMeter < 100)
        {
            Console.WriteLine("Choose your action:");
            Console.WriteLine("1: Roll dice and attack");
            Console.WriteLine("2: Defend");
            Console.WriteLine("3: Attempt to flee");
            string? action = Console.ReadLine();

            if (action == "1")
            {
                // Player and enemy roll their dice
                int playerRoll = DiceRoller.Roll(10);  // Player rolls a random dice (d4, d6, d8, d10)
                int enemyRoll = room.Enemy.RollDice();  // Enemy rolls a random dice (d4, d6, d8, d10)

                // Display the results of the dice rolls
                Console.WriteLine($"Your dice roll: {playerRoll}");
                Console.WriteLine($"Enemy's dice roll: {enemyRoll}");

                // Compare the rolls: if the player wins, they avoid taking a pill
                if (playerRoll > enemyRoll)
                {
                    Console.WriteLine("You win this round! You avoid taking a pill.");
                    room.Enemy.TakeDamage(playerRoll);  // Player deals damage based on dice roll
                }
                else
                {
                    Console.WriteLine("You lose this round... You must take a pill.");
                    player.TakePill();
                    room.Enemy.TakePill();  // The enemy also takes a pill
                }
            }
            else if (action == "2")
            {
                Console.WriteLine("You brace yourself and defend.");
                int enemyRoll = room.Enemy.RollDice();  // Enemy still rolls
                player.TakeDamage(Math.Max(0, enemyRoll / 2));  // Take reduced damage
            }
            else if (action == "3")
            {
                Console.WriteLine("You attempt to flee...");
                int fleeRoll = DiceRoller.Roll(6);  // Roll to determine if the player flees
                if (fleeRoll > 3)
                {
                    Console.WriteLine("You successfully fled!");
                    return;  // Exit the combat loop if the player flees
                }
                else
                {
                    Console.WriteLine("You failed to flee.");
                    player.TakePill();  // Player takes a pill as a consequence of failure
                }
            }
            else
            {
                Console.WriteLine("Invalid action, please choose 1, 2, or 3.");
            }

            // Check the player's health and poison meter
            player.CheckStatus();

            // If the player reaches 100% poison, the game ends
            if (player.poisonMeter >= 100)
            {
                Console.WriteLine("You've succumbed to the poison...");
                return;
            }
        }

        if (player.hp <= 0)
        {
            Console.WriteLine("You have been defeated...");
        }
        else if (!room.Enemy.IsAlive())
        {
            Console.WriteLine("You defeated the enemy!");
        }
    }

    // Game over logic when the player dies or gets poisoned
    private void GameOver()
    {
        if (player.poisonMeter >= 100)
        {
            Console.WriteLine("You've succumbed to the poison...");
        }
        else
        {
            Console.WriteLine("You were defeated...");
        }
    }
}