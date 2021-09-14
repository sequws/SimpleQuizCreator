using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Interfaces
{
    public interface IParser<T>
    {
        bool TryParse(List<string> input, Action failAction);
        bool TryParse(List<string> input);
        T GetData();
    }
}
