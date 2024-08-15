namespace MathTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет! Это тренажер для устного счета, введи, пожалуйста, максимальное число с которым бы ты хотел поработать");
            var userSettings = UserSettings.GetUserSettings();
            var trainer  = new MathTrainer(userSettings);

            trainer.StartTrainig();
        }

    }
}
