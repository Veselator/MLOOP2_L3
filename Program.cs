using MLOOP2_L3.T1;
using MLOOP2_L3.T2;
using MLOOP2_L3.T3;

namespace MLOOP2_L2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool isRunning = true;
            do
            {
                Console.Write("\n Віберіть завлання від 1 до 3 (0 - вихід)\n > ");
                char userChoice = Console.ReadKey().KeyChar;

                switch (userChoice)
                {
                    case '1':
                        Task1.Start();
                        break;
                    case '2':
                        Task2.Start();
                        break;
                    case '3':
                        Task3.Start();
                        break;
                    case '0':
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
            while (isRunning);
        }
    }
}