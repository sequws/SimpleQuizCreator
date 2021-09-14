using SimpleQuizCreator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Interfaces
{
    public interface ILoader<T>
    {
        List<string> GetFiles();
        IEnumerable<T> LoadData();
    }
}
