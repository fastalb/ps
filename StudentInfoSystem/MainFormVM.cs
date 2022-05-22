using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace StudentInfoSystem
    {
    internal class MainFormVM : ObservableObject
        {
        private Student _student;
        public Student Student
            {
            get { return _student; }
            set { _student = value; RaisePropertyChangedEvent ( "Student" ); }
            }

        public List<string> StudStatusChoices { get; set; }
        public List<string> StudOKSChoices { get; set; }

        private TestCommand _testCommand = new TestCommand();

        public TestCommand TestCommand
            {
            get { return _testCommand; }
            }

        public ImageSource Picture
            {
            get
                {
                if ( Student.Photo != null )
                    {
                    MemoryStream ms = new MemoryStream(Student.Photo);
                    Bitmap bmp = new Bitmap(ms);
                    var handle = bmp.GetHbitmap();
                    return Imaging.CreateBitmapSourceFromHBitmap ( handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions ( ) );
                    }
                return null;
                }
            }


        public MainFormVM ( )
            {
            Student = ( from s in new StudentInfoContext ( ).Students
                        where s.FacNum.Equals ( "123219015" )
                        select s ).DefaultIfEmpty ( null ).First ( );

            FillStudStatusChoices ( );
            FillStudOKSChoices ( );
            }

        private void FillStudStatusChoices ( )
            {
            StudStatusChoices = new List<string> ( );
            using ( IDbConnection connection = new SqlConnection ( Properties.Settings.Default.DbConnect ) )
                {
                string sqlquery = @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open ( );
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read ( );
                while ( notEndOfResult )
                    {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add ( s );
                    notEndOfResult = reader.Read ( );
                    }
                }
            }

        private void FillStudOKSChoices ( )
            {
            StudOKSChoices = new List<string> ( );
            using ( IDbConnection connection = new SqlConnection ( Properties.Settings.Default.DbConnect ) )
                {
                string sqlquery = @"SELECT OKSDescr FROM StudOKS";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open ( );
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read ( );
                while ( notEndOfResult )
                    {
                    string s = reader.GetString(0);
                    StudOKSChoices.Add ( s );
                    notEndOfResult = reader.Read ( );
                    }
                }
            }
        }
    }
