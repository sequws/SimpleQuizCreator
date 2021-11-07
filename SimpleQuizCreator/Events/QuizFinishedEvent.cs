using Prism.Events;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Events
{
    public class QuizFinishedEvent : PubSubEvent<ScoreResult>
    {
    }
}
