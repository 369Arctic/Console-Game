namespace MathTrainer
{
    public class MathTrainer
    {
        private readonly UserSettings _settings;
        private readonly Random _random;
        private readonly TrainingStatistics _trainingStatistics;

        public MathTrainer(UserSettings settings)
        {
            _settings = settings;
            _random = new Random();
            _trainingStatistics = new TrainingStatistics();
        }

        public void StartTraining()
        {
            var endTime = DateTime.Now.AddSeconds(_settings.TrainingDurationInSecond);
            bool isHardModeFinished = false;

            while (DateTime.Now < endTime)
            {
                if (!ProcessQuestion())
                {
                    if (_settings.GameMode == GameMode.Hard)
                    {
                        Console.WriteLine("Был выбран режим Hard. Игра окончена");
                        isHardModeFinished = true;
                        break;
                    }
                }
            }
            _trainingStatistics.PrintStatistics(isHardModeFinished);
        }


        private bool ProcessQuestion()
        {
            var expression = GenerateMathExpression();
            var operationSymbol = expression.Operation switch
            {
                Operation.Add => "+",
                Operation.Subtract => "-",
                Operation.Multiply => "*",
                Operation.Divide => "/",
                _ => ""
            };

            Console.WriteLine($"{expression.Number1} {operationSymbol} {expression.Number2} = ?");

            bool correctInput = double.TryParse(Console.ReadLine(), out double userAnswer);
            bool isCorrectUserAnswer = correctInput && Math.Round(userAnswer, 2) == expression.CorrectAnswer;

            _trainingStatistics.RecordQuestions(isCorrectUserAnswer);
            if (isCorrectUserAnswer)
            {
                Console.WriteLine("Ответ верный!");
            }
            else
            {
                Console.WriteLine($"Неправильно! Корректный ответ: {expression.CorrectAnswer}");
            }
            return isCorrectUserAnswer;
        }

            private MathExpression GenerateMathExpression()
        {
            int number1 = _random.Next(0, _settings.MaxValue);
            int number2 = _random.Next(0, _settings.MaxValue);
            return new MathExpression(number1, number2, _settings.Operation);
        }
    }
}
