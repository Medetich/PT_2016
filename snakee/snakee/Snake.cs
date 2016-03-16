using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Snake.Models
{
    [Serializable]
    public class Snake : Drawer
    {

        public Snake()
        {
            color = ConsoleColor.Blue;
            sign = 'o';


            int x, y;
            x = (new Random().Next()) % 70;
            y = (new Random().Next()) % 20;
            body.Add(new Point(x, y));
        }

        public override void Draw()
        {
            for (int i = 0; i < body.Count; i++)
            {
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(body[i].x, body[i].y);
                    Console.Write("O");
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(body[i].x, body[i].y);
                    Console.Write(sign);
                }
            }
        }


        public void move(int dx, int dy)
        {

            Console.SetCursorPosition(body[body.Count - 1].x, body[body.Count - 1].y);
            Console.Write(" ");


            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            int k = body.Count;

            if (body[0].x + dx < 0) dx = dx + 60;
            if (body[0].y + dy < 0) dy = dy + 30;
            if (body[0].x + dx > 60) dx = dx - 60;
            if (body[0].y + dy > 30) dy = dy - 30;

            body[0].x += dx;
            body[0].y += dy;

            if (body[0].x == Game.food.body[0].x && body[0].y == Game.food.body[0].y)
            {
                Game.food.NewRandom();
                body.Add(new Point(body[0].x, body[0].y));
            }

            for (int i = 0; i < Game.wall.body.Count - 1; i++)
            {
                if (body[0].x == Game.wall.body[i].x && body[0].y == Game.wall.body[i].y)
                {
                    Game.gameover = true;
                }
            }


        }
    }
}