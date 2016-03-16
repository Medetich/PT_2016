using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{
    [Serializable]
    public class Food : Drawer
    {
        public Food()
        {
            color = ConsoleColor.Yellow;
            sign = '*';
        }
        public void NewRandom()
        {
            int x = 0, y = 0;
            bool find = false;

            while (!find)
            {
                x = (new Random().Next()) % 49;
                y = (new Random().Next()) % 24;
                find = true;
                for (int i = 0; i < Game.wall.body.Count - 1; i++)
                {
                    if (i < Game.snake.body.Count)
                    {
                        if ((x == Game.wall.body[i].x && y == Game.wall.body[i].y) || (x == Game.snake.body[i].x && y == Game.snake.body[i].y) || x == 49 || x == 0 || y == 24 || y == 0)
                        {
                            find = false;
                        }
                    }

                    else
                    if ((x == Game.wall.body[i].x && y == Game.wall.body[i].y) || x == 49 || x == 0 || y == 24 || y == 0)
                    {
                        find = false;
                    }
                }
            }
            if (body.Count == 0)
            {
                body.Add(new Point(x, y));
            }
            else
            {
                body[0].x = x;
                body[0].y = y;
            }
        }

    }
}