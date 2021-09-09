using SimpleQuizCreator.Abstractions;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.DataAccess
{
    public class QuizLoader : Loader,  ILoader<QuizFile>
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

        public IEnumerable<QuizFile> LoadData()
        {
            var res = new List<QuizFile>();

            foreach (var file in GetFiles())
            {
                var name = GetQuizNameFromPath(file);
                var dataLines = File.ReadAllLines(file);

                if(dataLines.Count() > 0)
                {
                    res.Add(new QuizFile { FileName = file, Lines = dataLines.ToList(), Name = name });
                }
            }

            return res;
        }

        private string GetQuizNameFromPath(string path)
        {
            string name = "NoName";

            var parts = path.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            name = parts[parts.Length - 1];

            return name;
        }
    }
}
