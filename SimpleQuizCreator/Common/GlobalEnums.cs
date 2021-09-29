using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Common
{
    public enum QuizType
    {
        SingleChoice,
        MultiChoice
    }

    public enum ScoreType
    {
        OneGoodZeroBad,         //  1pts for good answer, no minus points for bad answer, or lack answer
        OneGoodOneBad,          //  1pts for good answer, -1pts points for bad answer, zero for no answer
        OneGoodOneBadOneNo,     //  1pts for good, -1 for any bad, -1 for no answer
        AllGoodWithoutMinus,    //  1pts for all good answers checked, zero otherwise
        AllGoodWithMinus,       //  1pts for all good answers checked, -1pts otherwise
        Custom                  //  
    }

    public enum Language
    {
        EN,
        PL,
        UKR
    }
}
