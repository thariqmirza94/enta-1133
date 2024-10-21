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
        Player player;
        Room[] rooms;

        public void StartGame()
        {
            player = new Player();
            rooms = SetupRooms();

            Console.WriteLine("Welcome to the game.");
            AllowPlayerToSearchRoom(rooms[0]);  // Player starts by searching Room 1

            while (player.hp > 0 && player.poisonMeter < 100)
            {
                foreach (var room in rooms)
                {
                    if (room.enemy.IsDead()) continue;  // Skip already defeated enemies
                    StartRound(room);
                    if (player.poisonMeter >= 100 || player.hp <= 0)
                    {
                        break;
                    }
                }
            }

            if (player.poisonMeter >= 100)
            {
                TriggerGameOver("madness");
            }
            else if (player.hp <= 0)
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
                player.inventory.AddItem(item);
            }
        }

        private void StartRound(Room room)
        {
            Enemy enemy = room.enemy;
            Console.WriteLine($"You enter Room {room.roomNumber}, facing an enemy with difficulty: {enemy.difficultyLevel}");

            int playerScore = RollDice();
            int enemyScore = RollDice();

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
    }
}
