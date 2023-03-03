using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp1
{
    public class Map
    {
        public bool lol = false;
        public Map(int x, int y, int r)
        {
            SX = x;
            SY = y;
            Range = r;
            int a = (int)Math.Pow(2, (Range+1));
            directions = new Direction[a];
            for (int  i = 0;i < a; i++ )
            { directions[i] = new Direction(); }
            intsMap = new int[x, y];
            bools = new bool[x, y];
            for (int X = 0; X < SX; X++)
            {
                for (int Y = 0; Y < SY; Y++)
                {
                    bools[X, Y] = false;
                }
            }
        }
        public void SetRange(int r)
        { Range = r; }
        private int[,] intsMap;
        private int 
            StartX, StartY, 
            EndX, EndY,
            SX,SY;
        /// <summary>
        /// Установка точек
        /// Setting points
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="End"></param>
        /// <returns></returns>
        public Map Set(Coordinates Start, Coordinates End)
        {
            StartX = Start.X;
            StartY = Start.Y;
            EndX = End.X;
            EndY = End.Y;
            return this;
        }
        /// <summary>
        /// Заполнение карты
        /// Filling out the card
        /// </summary>
        /// <returns></returns>
        public Map Set(int a)
        {
            //С рандомными числами
            //With random numbers
            Random random = new Random(a);
            for (int X = 0;X < SX; X++)
            {
                for (int Y = 0;Y < SY; Y++)
                {
                    intsMap[X, Y] = random.Next(1, 40);
                }
            }
            return this;
        }
        /// <summary>
        /// Заполнение "DataGridView" и поиск
        /// Filling in the "DataGridView" and search
        /// </summary>
        /// <param name="DGV"></param>
        /// <returns></returns>
        public void Set(DataGridView DGV)
        {
            this.DGV = DGV;
            DGV.RowCount = SX;
            DGV.ColumnCount = SY;
            Clear();
        }
        public void Clear()
        {
            for (int X = 0; X < SX; X++)
            {
                for (int Y = 0; Y < SY; Y++)
                {
                    DGV.Rows[X].Cells[Y].Value = intsMap[X, Y].ToString();
                    bools[X, Y] = false;
                    DGV.Rows[X].Cells[Y].Style.BackColor = Color.White;
                }
            }
        }
        public async Task Start(Label label) => await Task.Run(() =>
        {
            Clear();
            label.Text = "Сумма всех путей: " + Search(StartX, StartY, 0).ToString();
            UpDate();
        });
        DataGridView DGV;
        public void Painting(int Y, int X)
        {
            DGV.Rows[X].Cells[Y].Style.BackColor = Color.Red;
        }
        public void UpDate()
        {
            for (int X = 0; X < SX; X++)
            {
                for (int Y = 0; Y < SY; Y++)
                {
                    DGV.Rows[X].Cells[Y].Value = intsMap[X, Y].ToString();
                    if (bools[X, Y])
                    {
                        DGV.Rows[X].Cells[Y].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        DGV.Rows[X].Cells[Y].Style.BackColor = Color.White;
                    }
                }
            }
        }
        private bool[,] bools;
        public int Range = 2 , Min = int.MaxValue;
        private bool GR = false;
        /// <summary>
        /// Поиск оптимального пути
        /// Finding the optimal path
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="Con"></param>
        /// <returns></returns>
        public int Search(int x, int y, int Con)
        {
            bools[y, x] = true;
            if (x == EndX)
            {
                if (y == EndY) { return 0; }
                return Con + Search(x, (y + 1), intsMap[y, x]);
            }
            else if (y == EndY)
            {
                if (x == EndX) { return 0; }
                return Con + Search((x + 1), y, intsMap[y, x]);
            }
            else
            {
                Ghost(x,y);
                //Оценка путей
                //Evaluating paths
                foreach (Direction direction in directions)
                {
                    
                    if (direction.Value > Min)
                    {
                        direction.Value = int.MaxValue;
                        continue; 
                    }
                    Min = direction.Value;
                    GR = direction.GostRight;
                    direction.Value = int.MaxValue;
                }
                Min = int.MaxValue;
                if (GR)
                {
                    return Con + Search(x, (y + 1), intsMap[y, x]);
                }
                else 
                {
                    return Con + Search((x + 1), y, intsMap[y, x]);
                }
                
            }

        }
        private Direction[] directions;
        private int Ghosts = 0;
        /// <summary>
        /// Просмотр выгодности пути
        /// Viewing the profitability of the path
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Ghost(int x, int y)
        {
            Ghosts = 0;
            GhostR((x + 1), y, 0, intsMap[y, (x + 1)], false);
            //Thread.Sleep(5);
            //Cler();
            GhostD(x, (y + 1), 0, intsMap[(y + 1), x], true);
            //Thread.Sleep(5);
            //Cler();
        }
        /// <summary>
        /// Просмотр выгодности пути
        /// Viewing the profitability of the path
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="Con"></param>
        /// <param name="Poin"></param>
        /// <param name="GostLeft"></param>
        public void GhostR(int x, int y, int Con, int Poin, bool GostLeft)
        {
            if (Con >= Range) 
            {
                directions[Ghosts].Value = Poin;
                directions[Ghosts].GostRight = GostLeft;
                Ghosts++;
                if (lol)
                {
                    UpDate();
                }
                return;
            }
            if (lol)
            {
                Painting(x, y);
                Thread.Sleep(1);
            }
            bool a = false;
            if (x < (SY -1))
            { 
            GhostR((x+1), y, (Con+1), (Poin + intsMap[y, (x + 1)]), GostLeft);
            } else { a = true; }
            if (y < (SX-1))
            {
            GhostR(x, (y+1), (Con+1), (Poin + intsMap[(y + 1), x]), GostLeft);
            }
            else if (a)
            {
                directions[Ghosts].Value = Poin;
                directions[Ghosts].GostRight = GostLeft;
                Ghosts++;
                if (lol)
                {
                    UpDate();
                }
            }
        }
        public void GhostD(int x, int y, int Con, int Poin, bool GostLeft)
        {
            if (Con >= Range)
            {
                directions[Ghosts].Value = Poin;
                directions[Ghosts].GostRight = GostLeft;
                Ghosts++;
                if (lol)
                {
                    UpDate();
                }
                return;
            }
            if (lol)
            {
                Painting(x, y);
                Thread.Sleep(1);
            }
            bool a = false;
            if (y < (SX - 1))
            {
                GhostD(x, (y + 1), (Con + 1), (Poin + intsMap[(y + 1), x]), GostLeft);
            }
            else { a = true; }
            if (x < (SY - 1))
            {
                GhostD((x + 1), y, (Con + 1), (Poin + intsMap[y, (x + 1)]), GostLeft);
            }
            else if (a)
            {
                directions[Ghosts].Value = Poin;
                directions[Ghosts].GostRight = GostLeft;
                Ghosts++;
                if (lol)
                { UpDate(); }
                
            }
        }
    }
}
