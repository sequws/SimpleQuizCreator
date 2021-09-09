using SimpleQuizCreator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Abstractions
{
    public abstract class Parser : ErrorCollector, IParser
    {
        public abstract bool TryParse(string input);

        public bool TryParse(string input, Action failAction)
        {
            if (!TryParse(input))
            {
                failAction();
                return false;
            }
            return true;
        }

        public abstract bool TryParse(List<string> input);
    }
}
