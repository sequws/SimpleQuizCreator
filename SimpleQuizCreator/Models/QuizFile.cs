using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Models
{
    public class QuizFile
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public List<string> Lines { get; set; } = new List<string>();
    }
}
