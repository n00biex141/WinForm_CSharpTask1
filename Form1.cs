using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1StudentStruct
{
    enum Religion : byte
    {
        Islam = 1,
        Christian = 2,
        Hindu = 3,
        Other = 4
    }

    enum City : short
    {
        Kohat = 1,
        Peshawar = 2,
        Islamabad = 3,
        Karachi = 4, 
        Other = 5
    }

    struct Student
    {
        public string RegNo, Name, CNIC;
        public Enum Religion, City;
    }

    public partial class Form1 : Form
    {
        int i = 0;
        Student[] student = new Student[5];
        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(Religion));
            comboBox2.DataSource = Enum.GetValues(typeof(City));
            comboBox1.SelectedItem = Religion.Other;
            comboBox2.SelectedItem = City.Other;
            button2.Enabled = false;

            for (int c = 0; c < student.Length; c++)
                student[c] = new Student();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != string.Empty && 
                textBox2.Text.Trim() != string.Empty &&
                textBox3.Text.Trim() != string.Empty)
            {
                if (i < student.Length - 1)
                {
                    if (i == 0)
                    {
                        student[i].RegNo = textBox1.Text;
                        student[i].Name = textBox2.Text;
                        student[i].CNIC = textBox3.Text;
                        student[i].Religion = (Enum)comboBox1.SelectedItem;
                        student[i].City = (Enum)comboBox2.SelectedItem;
                    }
                    else
                    {
                        for (int j = 0; j < i; j++)
                        {
                            if (textBox1.Text != student[j].RegNo &&
                                textBox3.Text != student[j].CNIC)
                            {
                                student[i].RegNo = textBox1.Text;
                                student[i].Name = textBox2.Text;
                                student[i].CNIC = textBox3.Text;
                                student[i].Religion = (Enum)comboBox1.SelectedItem;
                                student[i].City = (Enum)comboBox2.SelectedItem;
                            }
                            else
                            {
                                MessageBox.Show("Record already exists!");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    button1.Enabled = false;
                    button2.Enabled = true;
                    student[i].RegNo = textBox1.Text;
                    student[i].Name = textBox2.Text;
                    student[i].CNIC = textBox3.Text;
                    student[i].Religion = (Enum)comboBox1.SelectedItem;
                    student[i].City = (Enum)comboBox2.SelectedItem;
                }
                i++;
            }
            else
            {
                MessageBox.Show("Please fill all entries!");
                return;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] students = new string[student.Length];

            int k = 0;
            foreach(Student s in student)
            {
                students[k] = $"Student {k + 1}: \nStudent RegNo: " + s.RegNo + "\nStudent Name: " + s.Name + "\nStudent CNIC: " + s.CNIC + "\nStudent Relgion: " + s.Religion + "\nStudent City: " + s.City + "\n\n";
                k++;
            }

            MessageBox.Show(students[0] +
                            students[1] +
                            students[2] +
                            students[3] +
                            students[4]);
        }
    }

   
}
