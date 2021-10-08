using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Interfaces
{
    public interface IGlobalSettingService
    {
        void Update(string settingName, object value);
        object Get(string settingName);
    }
}
