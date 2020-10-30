using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_EXCEPTIONS
{
    public class StudentException:ApplicationException
    {

        /// <summary>
        /// Custom Exception class created for Student
        /// </summary>
        /// <param name="emsg"></param>
        public StudentException(string emsg) :base(emsg)
        {

        }
    }
}
