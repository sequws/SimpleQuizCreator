using Dapper;
using NLog;
using SimpleQuizCreator.Interfaces;
using SimpleQuizCreator.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.DataAccess
{
    public class ResultRepository : IResultRepository
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();


        public bool CreateResult(ScoreResultEntity scoreResult)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    con.Execute("insert into History " +
                        "(QuizName, Type, Date, " +
                        "QuestionAmount, AllPosiblePoints, AllGoodAnswers, " +
                        "PointsScore, PercentScore  ) values " +
                        "(@QuizName, @Type, @Date," +
                        "@QuestionAmount, @AllPosiblePoints, @AllGoodAnswers," +
                        "@PointsScore, @PercentScore )", scoreResult);
                    return true;
                } 
                catch (Exception e)
                {
                    logger.Error(e.Message);
                    return false;
                }   
            }
        }

        public IEnumerable<ScoreResultEntity> GetAllResult()
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                var result = con.Query<ScoreResultEntity>("select * from History", new DynamicParameters());
                return result.ToList();
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
