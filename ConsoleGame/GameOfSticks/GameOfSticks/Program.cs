namespace GameOfSticks
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет, давай сыграем в палочки. Необходимо по очереди тянуть от 1 до 3х палочек из общей кучи. Проигрывает тот, кто вытянул последнюю.");
            Console.WriteLine("Введи начальное количество палочек");
            int initialSticksNumber;

            while (!int.TryParse(Console.ReadLine(), out initialSticksNumber) || initialSticksNumber < 7 || initialSticksNumber > 30)
            {
                Console.WriteLine("Нужно ввести число от 7 до 30");
            }

            var game = new GameOfSticks(initialSticksNumber, Player.Human);
            game.MachinePlayed += Game_MachinePlayed;
            game.HumanTurnToMakeMove += Game_HumanTurnToMakeMove;
            game.EndOfGame += Game_EndOfGame;
            game.Start();
        }

        private static void Game_EndOfGame(Player player)
        {
            Console.WriteLine($"Победитель: {player}");
            Console.ReadLine();
        }

        private static void Game_HumanTurnToMakeMove(object sender, int remainingSticks)
        {
            Console.WriteLine($"Оставшееся количество палочек = {remainingSticks}");
            Console.WriteLine("Возьми несколько палочек");

            bool takenCorrectly = false;

            while (!takenCorrectly)
            {
                if (int.TryParse(Console.ReadLine(), out int takenSticks))
                {
                    var game = (GameOfSticks)sender;

                    try
                    {
                        game.HumanTakeSticks(takenSticks);
                        takenCorrectly = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private static void Game_MachinePlayed(int sticksTaken)
        {
            Console.WriteLine($"Компьютер взял {sticksTaken}");
        }
    }
}
