using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SMS_ENTITIES;
using SMS_EXCEPTIONS;
using System.Runtime.Remoting.Channels;

namespace SMS_DAL
{
    public class StudentDAO
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;
        DataTable mydt = null;
        List<Student> myStudents = null;
        public StudentDAO()
        {
            con = new SqlConnection();
            con.ConnectionString = con.ConnectionString = "server = .\\SqlExpress ;Integrated Security = true;Database = Example1";
        }
        public List<Student> ShowAllStudent()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "Select *from Student ";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                sdr = cmd.ExecuteReader();
                mydt = new DataTable();
                mydt.Load(sdr);
                
                if(mydt.Rows.Count>0)
                {
                    myStudents = new List<Student>();
                    foreach(DataRow rw in mydt.Rows)
                    {
                        Student s1 = new Student();
                        s1.RollNo = Int32.Parse(rw[0].ToString());
                        s1.Name = rw[1].ToString();
                        s1.Addr = rw[2].ToString();

                        myStudents.Add(s1);
                    }
                }
            }
            catch(SqlException e)
            {
                throw new StudentException(e.Message);
            }
            catch(Exception e1)
            {
                throw new StudentException(e1.Message);
            }
            finally
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return myStudents;
        }

        public List<Student> SearchStudentById(int rollno)
        {
            try
            {
                con.Open();

                SqlParameter p1 = new SqlParameter("@rno", rollno);
                cmd = new SqlCommand();
                cmd.CommandText = "Select * from Student where rollno = @rno";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.Add(p1);

                sdr = cmd.ExecuteReader();
                mydt = new DataTable();
                mydt.Load(sdr);

                if (mydt.Rows.Count > 0)
                {
                    myStudents = new List<Student>();
                    foreach (DataRow rw in mydt.Rows)
                    {
                        Student s1 = new Student();
                        s1.RollNo = Int32.Parse(rw[0].ToString());
                        s1.Name = rw[1].ToString();
                        s1.Addr = rw[2].ToString();

                        myStudents.Add(s1);
                    }
                }
                else
                {
                    throw new StudentException("Roll Number dosen't exists");
                }
            }
            catch (SqlException e)
            {
                throw new StudentException(e.Message);
            }
            catch (Exception e1)
            {
                throw new StudentException(e1.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return myStudents;
        }
        public bool Addstudent(Student s1)
        {
            int recCount = 0;
            bool flag = false;
            try
            {
                con.Open();
                
                SqlParameter p1, p2, p3;
                p1 = new SqlParameter("@rno",s1.RollNo);
                p2 = new SqlParameter("@name", s1.Name);
                p3 = new SqlParameter("@addr", s1.Addr);

                cmd = new SqlCommand();
                cmd.CommandText = "Insert into Student(rollno,name,addr) values(@rno,@name,@addr)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;


                //Adding Parameter to command
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                //execute command
                //sdr = cmd.ExecuteReader();
                recCount = cmd.ExecuteNonQuery();
                if(recCount >=1)
                {
                    flag = true;
                }


            }

            catch (SqlException e)
            {
                throw new StudentException(e.Message);
            }
            catch (Exception e1)
            {
                throw new StudentException(e1.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return flag;
        }
        public bool UpdateStudent(Student s1)
        {
            int recCount = 0;
            bool flag = false;
            try
            {
                con.Open();

                SqlParameter p1,p2, p3;
                p1 = new SqlParameter("@rno", s1.RollNo);
                p2 = new SqlParameter("@name", s1.Name);
                p3 = new SqlParameter("@addr", s1.Addr);

                cmd = new SqlCommand();
                cmd.CommandText = "Update Student set name=@name,addr=@addr where rollno = @rno";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;


                //Adding Parameter to command
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                //execute command
               // sdr = cmd.ExecuteReader();
                recCount = cmd.ExecuteNonQuery();
                if(recCount>=1)
                {
                    flag = true;
                }


            }

            catch (SqlException e)
            {
                throw new StudentException(e.Message);
            }
            catch (Exception e1)
            {
                throw new StudentException(e1.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return flag;
        }
        public bool DropStudent(int rollno)
        {
            int rec = 0;
            bool flag = false;
            try
            {
                con.Open();
                SqlParameter p1;
                p1 = new SqlParameter("@rno", rollno);

                cmd = new SqlCommand();
                cmd.CommandText = "Delete from Student where rollno = @rno";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.Add(p1);

                rec = cmd.ExecuteNonQuery();
                if(rec >=1)
                {
                    flag = true;
                }
            }
            catch (SqlException e)
            {
                throw new StudentException(e.Message);
            }
            catch (Exception e1)
            {
                throw new StudentException(e1.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return flag;
        }
    }
}

