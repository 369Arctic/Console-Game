namespace MathTrainer
{
    public class UserSettings
    {
        public int MaxValue { get; set; }
        public Operation Operation { get; set; }

        public int TrainingDurationInSecond { get; set; }

        public UserSettings(int maxValue, Operation operation, int trainingDurationInSecond)
        {
            MaxValue = maxValue;
            Operation = operation;
            TrainingDurationInSecond = trainingDurationInSecond;
        }

        public static UserSettings GetUserSettings()
        {
            int MaxNumber = GetMaxNumber();
            Operation operation = GetOperation();
            int trainingDuration = GetTrainingDuration();
            return new UserSettings(MaxNumber, operation, trainingDuration);
        }

        private static int GetTrainingDuration()
        {
            bool isCorrect;
            int duration;

            do
            {
                Console.WriteLine("Введите длительность тренировки в секундах");
                isCorrect = int.TryParse(Console.ReadLine(), out duration);

                if (!isCorrect && duration < 0)
                {
                    Console.WriteLine("Введите число больше 0");
                }
            }
            while (!isCorrect);

            return duration;
        }

        private static Operation GetOperation()
        {
            var operations = new Dictionary<string, Operation>
            {
                {"+", Operation.Add },
                {"-", Operation.Subtract},
                {"*", Operation.Multiply},
                {"/", Operation.Divide},
            };
            Console.WriteLine("Выбери тип математической операции, доступные на выбор:");
            foreach (var item in operations)
            {
                Console.WriteLine(item);
            }
            string userInput = Console.ReadLine();

            return operations.ContainsKey(userInput) ? operations[userInput] : Operation.Invalid;
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
    }
}
