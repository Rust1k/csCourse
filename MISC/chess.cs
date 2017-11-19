using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        // рекурсивная расстановка ферзей
        static bool PutQueen(bool[] desk, int position, int ind, int cnt)
        {
            desk[position] = true;
            if (ind == cnt)
            {
                PrintDesk(desk, cnt);
                desk[position] = false;
                return true;
            }

            for (int i = (position / cnt + 1) * cnt; i <  (position / cnt + 2) * cnt; i++)
            {
                if (CheckCorrectnessMove(desk, i))
                    PutQueen(desk, i, ind + 1, cnt);
            }

            desk[position] = false;
            return false;
        }

        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Введите число n");
            while (! Int32.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("вы ввели некорректное число. Введите число n");
            }

            bool[] desk = new bool[n * n];

            for (int i = 0; i < n; i++)
                PutQueen(desk, i, 1, n);
        }

        static bool CheckCorrectnessXY(int x, int y, int cnt)
        {
            int n = (int)Math.Sqrt(cnt);
            return !(x % n + x / n == y % n + y / n || x % n - x / n == y % n - y / n
                    || x % n == y % n || x / n == y / n);
        }

        static bool CheckCorrectnessFull(bool[] desk)
        {
            bool result = true;
            int i = 0;
            while (i < desk.Length && result)
            {
                if (desk[i])
                {
                    int j = i;
                    while (j < desk.Length && result)
                    {
                        if (desk[j])
                            result = CheckCorrectnessXY(i, j, desk.Length);
                        j++;
                    }
                }
                i++;
            }
            return result;
        }

        static bool CheckCorrectnessMove(bool[] desk, int pos)
        {
            bool result = true;
            int i = 0;
            while (i < desk.Length && result)
            {
                if (desk[i])
                    result = CheckCorrectnessXY(i, pos, desk.Length);
                i++;
            }
            return result;
        }

        static void PrintDesk(bool[] desk, int cnt)
        {
            for (int i = 0; i < cnt; i++)
            {
                for (int j = 0; j < cnt; j++)
                    Console.Write(desk[i*cnt+j] ? "* " : ". ");
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
        }
    }
}
