namespace MathTrainer
{
    public class MathExpression
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public Operation Operation { get; set; }
        public double CorrectAnswer { get; set; }

        public MathExpression(int number1, int number2, Operation operation)
        {
            Number1 = number1;
            Number2 = number2;
            Operation = operation;
            CorrectAnswer = Calculate();
        }

        private double Calculate()
        {
            double result = Operation switch
            {
                Operation.Add => Number1 + Number2,
                Operation.Subtract => Number1 - Number2,
                Operation.Multiply => Number1 * Number2,
                Operation.Divide => Number2 != 0 ? (double)Number1 / Number2 : 0,
                _ => 0
            };
            return Math.Round(result, 2);

        }
    }
}
