﻿using SimpleQuizCreator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.DataAccess
{
    public class QuizParser : Parser
    {
        public QuizParser()
        {
            
        }

        public override bool TryParse(string input)
        {
            return true;
        }

        public override bool TryParse(List<string> input)
        {

            return true;
        }
    }
}
