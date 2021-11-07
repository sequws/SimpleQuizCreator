using SimpleQuizCreator.Attributes;
using SimpleQuizCreator.Converters;
using SimpleQuizCreator.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum ScoreType
    {
        [LocalizedDescription("OneGoodZeroBad", typeof(EnumResources))]
        OneGoodZeroBad,         //  1pts for good answer, no minus points for bad answer, or lack answer
        [LocalizedDescription("OneGoodOneBad", typeof(EnumResources))]
        OneGoodOneBad,          //  1pts for good answer, -1pts points for bad answer, zero for no answer
        [LocalizedDescription("OneGoodOneBadOneNo", typeof(EnumResources))]
        OneGoodOneBadOneNo,     //  1pts for good, -1 for any bad, -1 for no answer
        [LocalizedDescription("AllGoodWithoutMinus", typeof(EnumResources))]
        AllGoodWithoutMinus,    //  1pts for all good answers checked, zero otherwise
        [LocalizedDescription("AllGoodWithMinus", typeof(EnumResources))]
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
