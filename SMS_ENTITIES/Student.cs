using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_ENTITIES
{
    public class Student
    {
        #region Variables
        int rollno;
        string name;
        string addr;


        #endregion

        #region Properties
        public int RollNo { get => rollno; set => rollno = value; }
        public string Name { get => name; set => name = value; }
        public string Addr { get => addr; set => addr = value; }
        #endregion

        #region Constructor
        public Student()
        {

        }
        /// <summary>
        /// Param Constructor for Student Entity
        /// </summary>
        /// <param name="rno">Roll Number</param>
        /// <param name="nm">Name of Candidate</param>
        /// <param name="adr">Address of Student</param>
        public Student(int rno,string nm, string adr)
        {
            rollno = rno;
            name = nm;
            addr = adr;
        }
        #endregion
    }
}
