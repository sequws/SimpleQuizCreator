using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Interfaces
{
    public interface IParser
    {
        bool TryParse(string input);
        bool TryParse(string input, Action failAction);
        bool TryParse(List<string> input);
    }
}
