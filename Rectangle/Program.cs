using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rectangle
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    class Main
    {
        Random rand = new Random();

        public void RecTan(int N, TextBox pole)
        {
            Rectangle[] Mass = new Rectangle[N];
            float sum = 0;

            pole.Text = "";

            for (int i = 0; i < N; i++)
            {
                Mass[i] = new Rectangle((float)rand.Next(9) + 1,(float)rand.Next(11) + 1);
                sum += Mass[i].getSpace();
            }
            float Sredn = (float) (sum / N);

            pole.Text += "Больше среднего прямоугольник(и)" + "\r\n";

            for (int i = 0; i < N; i++)
            {

                if (Mass[i].getSpace() > Sredn)
                {
                    pole.Text +=  "№"  + (i + 1)  + "\r\n";
                }
            }

            pole.Text += "\r\n" + "Информация о всех прямоугольниках:" + "\r\n";

            for (int i = 0; i < N; i++)
                pole.Text += "\r\n" + "Прямоугольник №" + (i + 1) + "\r\n" + Mass[i].getInfo() + "\r\n";
        }

        public void Kub(int M, TextBox pole)
        {
            Parallelepiped[] Mass = new Parallelepiped[M];

            pole.Text ="";

            pole.Text +="Кубы:";

            for (int i = 0; i < M; i++)
            {
                Mass[i] = new Parallelepiped((float)rand.Next(5) + 1, (float)rand.Next(5) + 1, (float)rand.Next(5) + 1);
                if (Mass[i].getLenght() == Mass[i].getWight() && Mass[i].getLenght() == Mass[i].getHeight())
                {
                    pole.Text += "\r\n" + "№" + (i + 1);
                }
            }

            pole.Text += "\r\n" + "\r\n"  + "Информация о всех параллелепипедах:" + "\r\n" + "\r\n";

            for (int i = 0; i < M; i++)

                pole.Text += "Параллелепипед №" + (i + 1) + "\r\n" + Mass[i].getInfo() + "\r\n";
        }
    }

    class Rectangle
    {
        public float side1; //Стороны прямоугольника
        public float side2;
        public Rectangle(float side1,float side2)
        {
            this.side1 = side1;
            this.side2 = side2;
        }
        public float getLenght() //Узнать длинну
        {
            return (float)(this.side1);
        }
        public float getWight() //Узнать ширину
        {
            return (float)(this.side2);
        }
        public float getDiagonal() //Узнать диагональ
        {
            return (float)(Math.Sqrt(this.side1 * this.side1 + this.side2 * this.side2));
        }
        public float getPerimeter() //Узнать периметр
        {
            return (float)(2 * this.side1 + 2 * this.side2);
        }
        public float getSpace() //Узнать площадь
        {
            return (float)(this.side1 * this.side2);
        }
        public string getInfo() //Вывод инфы про прямоугольник
        {
            return "\r\nДлина: " + getLenght() + "\r\nШирина: " + getWight() + "\r\nДиагональ: " + getDiagonal() + "\r\nПериметр: " + getPerimeter() + "\r\nПлощадь: " + getSpace() + "\r\n";
        }
    }

    class Parallelepiped : Rectangle
    {
        float side3; //Высота параллелепипеда

        public Parallelepiped(float side1, float side2, float side3) : base(side1, side2)
        {
            this.side3 = side3;
        }
        public float getHeight() //Узнать высоту
        {
            return (float)(this.side3);
        }
        public float getVolume() //Узнать объем
        {
            return (float)(getSpace() * side3);
        }
        public new float getSpace() //Узнать площадь
        {
            return (float)(2 * base.getSpace() + 2 * this.side1 * this.side3 + 2 * this.side2 * this.side3);
        }
        public new string getInfo() //Вывод инфы про параллелепипед
        {
            return "\r\nДлина: " + getLenght() + "\r\nШирина: " + getWight() + "\r\nВысота: " + getHeight() + "\r\nОбъем: " + getVolume() + "\r\nПлощадь: " + getSpace() + "\r\n";
        }
    }
}

