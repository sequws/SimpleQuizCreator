using System.Collections.Generic;

namespace SimpleQuizCreator.Abstractions
{
    /// <summary>
    /// Common class for any other classes collecting errors.
    /// </summary>
    public class ErrorCollector
    {
        protected List<string> errors = new List<string>();
        protected int errorCoutner = 0;

        public ErrorCollector()
        {
            ClearData();
        }

        protected void AddError(string text)
        {
            errors.Add(text);
            errorCoutner++;
        }

        protected void AddErrors(List<string> errorList)
        {
            errors.AddRange(errorList);
            errorCoutner += errorList.Count;
        }

        public virtual void ClearData()
        {
            errors.Clear();
            errorCoutner = 0;
        }

        public int ErrorCounter => errorCoutner;
        public List<string> Errors => new List<string>(errors);
    }
}
