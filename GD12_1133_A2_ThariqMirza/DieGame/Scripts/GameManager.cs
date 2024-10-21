using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    class GameManager
    {
        Player player;  // Change to nullable
        Room[] rooms;  // Change to nullable

        public void StartGame()
        {
            player = new Player();
            rooms = SetupRooms();

            Console.WriteLine("Welcome to the game.");
            AllowPlayerToSearchRoom(rooms[0]);  // Player starts by searching Room 1

            while (player?.hp > 0 && player?.poisonMeter < 100)
            {  // Check for null
                foreach (var room in rooms)
                {
                    if (room.enemy.IsDead()) continue;  // Skip already defeated enemies
                    StartRound(room);
                    if (player?.poisonMeter >= 100 || player?.hp <= 0)
                    {
                        break;
                    }
                }
            }

            if (player?.poisonMeter >= 100)
            {
                TriggerGameOver("madness");
            }
            else if (player?.hp <= 0)
            {
                TriggerGameOver("death");
            }
            else
            {
                Console.WriteLine("Congratulations, you survived the game!");
            }
        }

        private Room[] SetupRooms()
        {
            Room[] rooms = new Room[9];
            rooms[0] = new Room(1, "Easy");
            rooms[1] = new Room(2, "Medium");
            rooms[2] = new Room(3, "Medium");
            rooms[3] = new Room(4, "Hard");
            rooms[4] = new Room(5, "Boss");
            return rooms;
        }

        private void AllowPlayerToSearchRoom(Room room)
        {
            List<Item> foundItems = room.SearchRoom();
            foreach (var item in foundItems)
            {
                player.AddItem(item);
            }
        }

        private void StartRound(Room room)
        {
            Enemy enemy = room.enemy;
            Console.WriteLine($"You enter Room {room.roomNumber}, facing an enemy with difficulty: {enemy.difficultyLevel}");

            int playerScore = RollDice();
            int enemyScore = enemy.RollDice();  // Add RollDice method to Enemy class
            Console.WriteLine($"Your score: {playerScore}, Enemy's score: {enemyScore}");

            if (playerScore > enemyScore)
            {
                Console.WriteLine("You won the round!");
                AllowPlayerToSearchRoom(room);  // Allow search after winning
            }
            else
            {
                Console.WriteLine("You lost the round.");
                player.TakePill();
                enemy.TakePill();
            }

            player.CheckHealth();
            if (enemy.IsDead())
            {
                Console.WriteLine("Enemy defeated.");
            }
        }

        private int RollDice()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }

        private void TriggerGameOver(string reason)
        {
            if (reason == "madness")
            {
                Console.WriteLine("Game Over: You lost your mind.");
            }
            else if (reason == "death")
            {
                Console.WriteLine("Game Over: You died.");
            }
        }

        // Prompt player for input during a round
        private void PlayRound()
        {
            bool isValidInput = false;
            string userChoice;

            while (!isValidInput)
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Heal (if available)");
                Console.WriteLine("3. Use an item from inventory (if available)");
                Console.WriteLine("4. Search room");

                userChoice = Console.ReadLine();
                isValidInput = userChoice == "1" || userChoice == "2" || userChoice == "3" || userChoice == "4";
            }

            switch (userChoice)
            {
                case "1":
                    Attack(player, enemy);
                    break;
                case "2":
                    Heal(player);
                    break;
                case "3":
                    UseItemFromInventory(player);
                    break;
                case "4":
                    SearchRoom(player);
                    break;
            }
        }

        // Player attacks the enemy
        private void Attack(Player player, Enemy enemy)
        {
            int playerRoll = RollDice();
            Console.WriteLine($"Player rolled a {playerRoll}");

            int enemyRoll = enemy.RollDice();  // Add RollDice method to Enemy class
            Console.WriteLine($"Enemy rolled a {enemyRoll}");

            if (playerRoll > enemyRoll)
            {
                Console.WriteLine("You win this round!");
                enemy.TakePill();
            }
            else
            {
                Console.WriteLine("You lose this round.");
                player.TakePill();
            }

            player.CheckHealth();
        }

        // Player heals using an item from their inventory
        private void Heal(Player player)
        {
            if (player.inventory.items.Count == 0)
            {
                Console.WriteLine("No healing items available in your inventory.");
                return;
            }

            Console.WriteLine("Which item would you like to use for healing?");
            foreach (var item in player.inventory.items)
            {
                if (item.name.Contains("Health"))
                {
                    Console.WriteLine($"{item.name}");
                }
            }

            string userItemName = Console.ReadLine();
            Item selectedItem = player.inventory.items.FirstOrDefault(i => i.name == userItemName);

            if (selectedItem != null)
            {
                selectedItem.Use(player);
            }
            else
            {
                Console.WriteLine("Invalid item selected.");
            }
        }

        // Player uses an item from their inventory
        private void UseItemFromInventory(Player player)
        {
            if (player.inventory.items.Count == 0)
            {
                Console.WriteLine("No items available in your inventory.");
                return;
            }

            foreach (var item in player.inventory.items)
            {
                Console.WriteLine($"{item.name}");
            }

            string userItemName = Console.ReadLine();
            Item selectedItem = player.inventory.items.FirstOrDefault(i => i.name == userItemName);

            if (selectedItem != null)
            {
                selectedItem.Use(player);
            }
            else
            {
                Console.WriteLine("Invalid item selected.");
            }
        }

        // Player searches the current room
        private void SearchRoom(Player player)
        {
            int randomChance = new Random().Next(1, 4);  // 33% chance to find an item

            if (randomChance == 1)
            {
                Item foundItem = GetRandomItem();
                player.inventory.AddItem(foundItem);
                Console.WriteLine($"You found {foundItem.name}!");
            }
            else
            {
                Console.WriteLine("Nothing found in the room.");
            }
        }

        // Generate a random item
        private Item GetRandomItem()
        {
            Random random = new Random();

            switch (random.Next(0, 4))
            {
                case 0:
                    return new Item("Detox Pill", (player) => {
                        player.poisonMeter = Math.Max(0, player.poisonMeter - 20);
                        Console.WriteLine("Detox Pill used. Poison meter reduced by 20%.");
                    });
                case 1:
                    return new Item("Expired Cigarette", (player) => {
                        player.poisonMeter = Math.Max(0, player.poisonMeter - 10);
                        player.hp = Math.Max(0, player.hp - (int)(player.hp * 0.10)); // Reduce HP by 10%
                        Console.WriteLine("Expired Cigarette used. Poison meter reduced by 10%, but lost 10% HP.");
                    });
                case 2:
                    return new Item("Blade", (player) => {
                        player.poisonMeter = 0;
                        player.hp = Math.Max(0, player.hp - (int)(player.hp * 0.50)); // Reduce HP by 50%
                        Console.WriteLine("Blade used. Poison meter reset to 0, but lost 50% HP.");
                    });
                case 3:
                    return new Item("Small Health Pill", (player) => {
                        player.hp = Math.Min(100, player.hp + (int)(player.hp * 0.20)); // Increase HP by 20%
                        Console.WriteLine("Small Health Pill used. HP increased by 20%.");
                    });
                default:
                    return null;
            }
        }

        private void MoveToNextRoom()
        {
            // Prompt player to choose the next room
            // Implement logic to move to the selected room
            Console.WriteLine("Choose your next room:");
            // Logic to select and enter a new room
        }
    }
}

