using SimpleQuizCreator.Abstractions;
using SimpleQuizCreator.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.DataAccess
{
    public class QuizLoader : Loader,  ILoader
    {
        public QuizLoader() : base("quizzes")
        {
            Console.WriteLine("Loader Created!");
        }

        public bool Load()
        {
            throw new NotImplementedException();
        }

        public List<string> GetFiles()
        {
            if (!Directory.Exists(DataFolder))
            {
                return new List<string>();
            }

            string[] files = Directory.GetFiles(DataFolder, extension);

            return files.ToList();
        }
    }
}
