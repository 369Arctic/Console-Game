using System;
using System.Text;


namespace tick_tack_toe
{
    internal class Program
    {
        public static MyTickTackGame game = new MyTickTackGame();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! This is a tick tack toe");

            Console.WriteLine(GetPrintableState());
            while (game.GetWinner() == GameWinner.Unfinished)
            {
                int index;
                while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > 9
                        || game.GetState(index) != StateTabel.Unset)
                {
                    Console.WriteLine("Incorrect inpup. Please enter a number again");
                }
                game.MakeMove(index);
                Console.WriteLine();
                Console.WriteLine(GetPrintableState());
            }

            Console.WriteLine($"Winner: {game.GetWinner()}");
            Console.ReadLine();


        }
        private static string GetPrintableState()
        {
            var sb = new StringBuilder();

            for (int i = 1; i <= 7; i += 3)
            {
                sb.AppendLine("     |     |     |")
                    .AppendLine(
                    $"  {GetPrintableChar(i)}  |  {GetPrintableChar(i + 1)}  |  {GetPrintableChar(i + 2)}  |  ")
                    .AppendLine("_____|_____|_____|");
            }
            return sb.ToString();
        }

        static string GetPrintableChar(int i)
        {
            StateTabel state = game.GetState(i);
            if (state == StateTabel.Unset)
                return i.ToString();
            return state == StateTabel.Cross ? "X" : "O";
        }

    }
}
