using Prism.Mvvm;
using SimpleQuizCreator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Models
{
    public class ScoreTypeComboItem : BindableBase
    {
        private ScoreType type;
        public ScoreType Type
        {
            get { return type; }
            set { SetProperty(ref type, value); }
        }

        private string desc;
        public string Desc
        {
            get { return desc; }
            set { SetProperty(ref desc, value); }
        }

    }
}
