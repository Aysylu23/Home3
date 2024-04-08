
namespace Home3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] labirynth = new int[,]
            {
                {1, 1, 1, 1, 1, 1, 1 },
                {1, 0, 0, 0, 0, 0, 1 },
                {1, 0, 1, 1, 1, 0, 1 },
                {0, 0, 0, 0, 1, 0, 0 },
                {1, 1, 0, 0, 0, 0, 1 },
                {1, 1, 1, 0, 1, 0, 1 },
                {1, 1, 1, 0, 1, 1, 1 }
            };



            Console.WriteLine(HasExit(1, 3, labirynth));

            Console.WriteLine(HasExitRecursive(1, 3, labirynth));

        }

        static int HasExit(int i, int j, int[,] lab)
        {
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();

            if (lab[i, j] == 0)
                stack.Push(new(i, j));
            int count = 0;

            while (stack.Count > 0)
            {
                Tuple<int, int> current = stack.Pop();
                if (current.Item1 < 0 || current.Item2 == lab.GetLength(0))
                    continue;
                if (current.Item2 < 0 || current.Item2 == lab.GetLength(1))
                    continue;
                if (lab[current.Item1, current.Item2] == 1 || lab[current.Item1, current.Item2] == 2)
                    continue;
                lab[current.Item1, current.Item2] = 2;
                if (lab.GetLength(0) - 1 == current.Item1 || lab.GetLength(1) - 1 == current.Item2 || current.Item1 == 0 || current.Item2 == 0)
                {
                    count++;
                    continue;
                }
                            

                stack.Push(new(current.Item1 + 1, current.Item2));
                stack.Push(new(current.Item1 - 1, current.Item2));
                stack.Push(new(current.Item1, current.Item2 + 1));
                stack.Push(new(current.Item1, current.Item2 - 1));
            }
            return count;
        }


        static bool HasExitRecursive(int i, int j, int[,] lab)
        {
            if (lab[i, j] != 0)
                return false;
            return HasExitRec(i, j, lab);
        }

        static bool HasExitRec(int i, int j, int[,] lab)
        {
            lab[i, j] = 2;

            if (lab.GetLength(0) - 1 == i || lab.GetLength(1) - 1 == j || i == 0 || j == 0)
                return true;

            bool exit = false;

            if (lab[i + 1, j] == 0)
                if (HasExitRec(i + 1, j, lab))
                    return true;
            if (lab[i - 1, j] == 0)
                if (HasExitRec(i - 1, j, lab))
                    return true;
            if (lab[i, j + 1] == 0)
                if (HasExitRec(i, j + 1, lab))
                    return true;
            if (lab[i, j - 1] == 0)
                if (HasExitRec(i, j - 1, lab))
                    return true;
            return exit;
        }

        public static void Print(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
