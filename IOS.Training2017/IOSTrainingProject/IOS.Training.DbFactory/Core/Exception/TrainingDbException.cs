using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.Training.DbFactory.Core.Exception
{
    public class TrainingDbException : System.Exception
    {
        private string _errorMessage = string.Empty;

        public void Log(string loger)
        {
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public override string Message
        {
            get { return _errorMessage; }
        }
    }
}

