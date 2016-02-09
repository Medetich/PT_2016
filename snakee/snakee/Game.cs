using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snakee
{
    class Game
    {
        public static Food food = new Food();
        public static Snake1 snake = new Snake1();
        public static Wall wall = new Wall();
        public static bool GameOver = false;
        public Game()
        {

            Init();
            Play();
        }
        public void Init()
        {
            food.SetNewPosition();
            wall.Level(Wall.lvl);
            while (Food.FoodinSnake() == true || Food.FoodinWall() == true)
            {
                food.SetNewPosition();
            }

            while (Game.snake.CollisionWithWall())
            {
                Snake1.SnakeAtNewPosition();
            }
        }


        public void Play()
        {
            while (!GameOver) 
            {
                Draw(); 
                ConsoleKeyInfo button = Console.ReadKey();

                if (button.Key == ConsoleKey.UpArrow)
                    snake.move(0, -1);
                if (button.Key == ConsoleKey.DownArrow)
                    snake.move(0, 1);
                if (button.Key == ConsoleKey.LeftArrow)
                    snake.move(-1, 0);
                if (button.Key == ConsoleKey.RightArrow)
                    snake.move(1, 0);
                if (button.Key == ConsoleKey.F2)
                    Save();
                if (button.Key == ConsoleKey.F3)
                    Resume();
                if (button.Key == ConsoleKey.F5)
                    wall.Level(2);
            }
        }
        public static void GameEnd()
        {
            Console.Clear();
            Console.SetCursorPosition(10, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game Over!");
            Console.ReadKey();

        }
        public static void Draw()
        {
            Console.Clear();
            Scoreregister.scoreregister();
            snake.Draw();
            food.Draw();
            wall.Draw();
        }
        public void Save()
        {
            snake.Save();
            food.Save();
            wall.Save();
        }
        public void Resume()
        {
            snake.Resume();
            food.Resume();
            wall.Resume();
        }
    }
}
