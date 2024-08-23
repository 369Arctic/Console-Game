using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTrainer
{
    public class TrainingStatistics
    {
        public int TotalQuestions { get; private set; }
        public int CorrectAnswers { get; private set; }
        public int IncorrectAnswers { get; private set; }

        public void RecordQuestions(bool isCorrect)
        {
            TotalQuestions++;
            if (isCorrect)
            {
                CorrectAnswers++;
            }
            else
            {
                IncorrectAnswers++;
            }
        }
        
        public void PrintStatistics(bool isHardModeFinished)
        {
            Console.WriteLine(isHardModeFinished ? "Игра окончена" : "Время тренировки завершено!");
            Console.WriteLine($"Задано вопросов: {TotalQuestions}");
            Console.WriteLine($"Правильных ответов: {CorrectAnswers}");
            Console.WriteLine($"Ошибок: {IncorrectAnswers}");
        }
    }
}
