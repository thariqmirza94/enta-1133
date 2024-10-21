using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    class Enemy
    {
        public int hp;
        public int poisonMeter = 0;
        public string difficultyLevel;

        public Enemy(string difficultyLevel)
        {
            this.difficultyLevel = difficultyLevel;
            SetupEnemyProperties();
        }

        void SetupEnemyProperties()
        {
            switch (difficultyLevel)
            {
                case "Easy":
                    hp = 30;
                    break;
                case "Medium":
                    hp = 50;
                    break;
                case "Hard":
                    hp = 70;
                    break;
                case "Boss":
                    hp = 100;
                    break;
            }
        }

        public void TakePill()
        {
            poisonMeter = Math.Min(100, poisonMeter + 10);
            Console.WriteLine($"Enemy took a pill. Enemy Poison meter: {poisonMeter}%.");
        }

        public bool IsDead()
        {
            return hp <= 0;
        }

        // Add RollDice method to Enemy class
        public int RollDice()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }
    }
}
