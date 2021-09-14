﻿using SimpleQuizCreator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Abstractions
{
    public abstract class Parser : ErrorCollector
    {
        public bool TryParse(List<string> input, Action failAction)
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
