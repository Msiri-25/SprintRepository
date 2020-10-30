using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS_EXCEPTIONS;
using SMS_ENTITIES;
using SMS_DAL;

namespace SMS_BL
{
    public class StudentBL
    {
        StudentDAO sDao = null;
        public StudentBL()
        {
            sDao = new StudentDAO();
        }
        public bool ValidateAll()
        {
            return true;
        }
        public List<Student> ShowAllStudents()
        {
            return sDao.ShowAllStudent();
        }
        public List<Student> SearchByStudentId(int rollno)
        {
            return sDao.SearchStudentById(rollno);
        }
        public bool AddStudent(Student s1)
        {
            return sDao.Addstudent(s1);
        }
        public bool UpdateStudent(Student st)
        {
            bool flag = false;
            if(ValidateAll())
            {
                flag = sDao.UpdateStudent(st);
            }
            return sDao.UpdateStudent(st);
        }
        public bool DropStudent(int rollno)
        {
            return sDao.DropStudent(rollno);
        }
    }
}

