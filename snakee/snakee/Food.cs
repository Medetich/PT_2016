using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snakee
{
    class Food : Drawer
    {
        public Food()
        {
            color = ConsoleColor.Green;
            sign = '*';
        }
        public void SetNewPosition()
        {
            body.Clear();
            Game.food.body.Add(new Point(new Random().Next(3, 60), new Random().Next(4, 30)));
        }

        public static bool FoodinWall()
        {
            foreach (Point p in Game.wall.body)
                if (Game.food.body[0].x == p.x && Game.food.body[0].y == p.y)
                    return true;
                    return false;
        }

        public static bool FoodinSnake() 
        {
            for (int i = 0; i < Game.snake.body.Count; i++)
                if (Game.food.body[0].x == Game.snake.body[i].x && Game.food.body[0].y == Game.snake.body[i].y)
                    return true;
                    return false;
        }
    }
}
