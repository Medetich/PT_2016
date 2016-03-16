using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{
    [Serializable]
    public class Drawer
    {
        public ConsoleColor color;
        public char sign;
        public List<Point> body = new List<Point>();
        public Drawer() { }

        public Drawer(char sign, ConsoleColor color)
        {
            this.sign = sign;
            this.color = color;
        }

        public virtual void Draw()
        {
            foreach (Point p in body)
            {
                Console.ForegroundColor = color; 
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }

        public void Save()
        {
            string FileName = "";
            if (sign == 'o')
                FileName = "snake.dat";
            if (sign == '*')
                FileName = "food.dat";
            if (sign == 'x')
                FileName = "wall.dat";
            FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //XmlSerializer xs = new XmlSerializer(GetType());
            BinaryFormatter bf = new BinaryFormatter();
            //xs.Serialize(fs, this);
            bf.Serialize(fs, this);
            fs.Close();
        }


        public void Resume()
        {
            string FileName = "";
            if (sign == 'o')
                FileName = "snake.dat";
            if (sign == '*')
                FileName = "food.dat";
            if (sign == 'x')
                FileName = "wall.dat";

            FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //XmlSerializer xs = new XmlSerializer(GetType());
            BinaryFormatter bf = new BinaryFormatter();

            if (sign == '*')
                Game.food = bf.Deserialize(fs) as Food;
            if (sign == 'x')
                Game.wall = bf.Deserialize(fs) as Wall;
            if (sign == 'o')
                Game.snake = bf.Deserialize(fs) as Snake;

            fs.Close();

        }

    }
}