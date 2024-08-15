namespace MathTrainer
{
    public class MathTrainer
    {
        private readonly UserSettings _settings;
        private readonly Random _random;

        public MathTrainer(UserSettings settings)
        {
            _settings = settings;
            _random = new Random();
        }

        public void StartTrainig()
        {
            var endTime = DateTime.Now.AddSeconds(_settings.TrainingDurationInSecond);


            while (DateTime.Now < endTime)
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

                bool correct = double.TryParse(Console.ReadLine(), out double userAnswer);
                if (correct && Math.Round(userAnswer, 2) == expression.CorrectAnswer)
                {
                    Console.WriteLine("Ответ верный!");
                }
                else
                {
                    Console.WriteLine($"Неправильно! Корректный ответ: {expression.CorrectAnswer}");
                }
            }
            Console.WriteLine("Время тренировки завершено!");
        }

        private MathExpression GenerateMathExpression()
        {
            int number1 = _random.Next(0, _settings.MaxValue);
            int number2 = _random.Next(0, _settings.MaxValue);
            return new MathExpression(number1, number2, _settings.Operation);
        }
    }
}
