using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using SMS_BL;
using SMS_ENTITIES;
using SMS_EXCEPTIONS;

namespace SMS_WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StudentBL sBl = null;
        Student sobj = null;
        public MainWindow()
        {
            InitializeComponent();
            sBl = new StudentBL();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sobj = new Student();
                sobj.RollNo = Convert.ToInt32(txtRollNo_Copy.Text);
                sobj.Name = txtName.Text;
                sobj.Addr = txtAddr.Text;

                bool res = sBl.AddStudent(sobj);
                if (res)
                {
                    System.Windows.Forms.MessageBox.Show("RECORD ADDED");
                }
            }
            catch(StudentException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message,"Student Management system");
            }
            catch(Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message,"student management system");
            }
            
        }

        private void btnAlter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sobj = new Student();
                sobj.RollNo = Convert.ToInt32(txtRollNo_Copy.Text);
                sobj.Name = txtName.Text;
                sobj.Addr = txtAddr.Text;

                bool res = sBl.UpdateStudent(sobj);
                if (res)
                {
                    System.Windows.Forms.MessageBox.Show("RECORD UPDATED");
                }

            }
            catch(StudentException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message, "Student Management system");
            }
            catch(Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message, "Student Management system");
            }

        }

        private void btnDrop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sobj = new Student();
                sobj.RollNo = Convert.ToInt32(txtRollNo_Copy.Text);

                bool re = sBl.DropStudent(sobj.RollNo);
                if (re)
                {
                    System.Windows.Forms.MessageBox.Show("RECORD DROPPED");

                }
            }
           
             catch (StudentException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message, "Student Management system");
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message, "Student Management system");
            }

        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               List<Student> res = sBl.ShowAllStudents();
                gridresult.ItemsSource = res;
            }
            catch (StudentException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message, "Student Management system");
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message, "Student Management system");
            }

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               List<Student> mystudents;
                sobj = new Student();
                sobj.RollNo = Convert.ToInt32(txtRollNo_Copy.Text);

               mystudents = sBl.SearchByStudentId(sobj.RollNo);
                gridresult.ItemsSource = mystudents;


               System.Windows.Forms.MessageBox.Show("RECORD EXISTS");

               
            }
            catch (StudentException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message, "Student Management system");
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message, "Student Management system");
            }
        }

        private void gridresult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
