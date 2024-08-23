using System.Diagnostics;

namespace MathTrainer
{
    public class UserSettings
    {
        public int MaxValue { get; set; }
        public Operation Operation { get; set; }

        public int TrainingDurationInSecond { get; set; }

        public GameMode GameMode { get; set; }

        public UserSettings(int maxValue, Operation operation, int trainingDurationInSecond, GameMode gameMode)
        {
            MaxValue = maxValue;
            Operation = operation;
            TrainingDurationInSecond = trainingDurationInSecond;
            GameMode = gameMode;
        }

        public static UserSettings GetUserSettings()
        {
            int MaxNumber = GetMaxNumber();
            Operation operation = GetOperation();
            int trainingDuration = GetTrainingDuration();
            GameMode gameMode = GetGameMode();
            return new UserSettings(MaxNumber, operation, trainingDuration, gameMode);
        }

        private static int GetTrainingDuration(int attempt = 3)
        {
            bool isCorrect;
            int duration;

            Console.WriteLine("Введите длительность тренировки в секундах");
            isCorrect = int.TryParse(Console.ReadLine(), out duration) && duration > 0;
            if (isCorrect)
            {
                return duration;
            }

            if (!isCorrect && attempt > 1)
            {
                Console.WriteLine("Введите число большее 0");
                return GetTrainingDuration(attempt - 1);
            }
            Console.WriteLine("Выбрана длительность по умолчанию: 60 секунд");
            duration = 60;
            return duration;
        }

        private static Operation GetOperation(int attempt = 3)
        {
            var operations = new Dictionary<string, Operation>
            {
                {"+", Operation.Add },
                {"-", Operation.Subtract},
                {"*", Operation.Multiply},
                {"/", Operation.Divide},
            };
            Console.WriteLine("Выбери тип математической операции, доступные на выбор:");
            foreach (var item in operations.Keys)
            {
                Console.WriteLine(item);
            }
            string userInput = Console.ReadLine();

            if (operations.ContainsKey(userInput))
            {
                return operations[userInput];
            }

            if (attempt > 1)
            {
                Console.WriteLine("Некорректный ввод. Повторите попытку снова");
                return GetOperation(attempt - 1);
            }

            Console.WriteLine("Исчерпано количество попыток ввода. Устанавливается операция сложения.");
            return Operation.Add;

            //return operations.ContainsKey(userInput) ? operations[userInput] : Operation.Invalid;
        }

        private static int GetMaxNumber()
        {
            int maxNumber;
            bool isCorrect;
            do
            {
                isCorrect = int.TryParse(Console.ReadLine(), out maxNumber);
                if (!isCorrect)
                {
                    Console.WriteLine("Это не число. Попробуй снова");
                }
            }
            while (!isCorrect);
            return maxNumber;
        }

        private static GameMode GetGameMode(int attempt = 3)
        {
            var gameMode = new Dictionary<string, GameMode>
            {
                {"standart", GameMode.Standart },
                {"hard", GameMode.Hard }
            };

            Console.WriteLine("Выбери уровень сложности: Standart или Hard. В Hard режиме допускается только одна ошибка.");
            string userInput = Console.ReadLine().ToLower();

            if (gameMode.ContainsKey(userInput))
            {
                return gameMode[userInput];
            }
            if (attempt > 1)
            {
                Console.WriteLine("Введен некорректный режим игры. Повторите попытку.");
                return GetGameMode(attempt - 1);
            }

            Console.WriteLine("Исчерпано количество попыток. Выбран стандартный режим игры");
            return GameMode.Standart;

            //return gameMode.ContainsKey(userInput) ? gameMode[userInput] : GameMode.Invalid;
        }
    }
}
