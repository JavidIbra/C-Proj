using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject1
{
    public class Student
    {
        public int StudentId { get; set; }
        private static int counter;
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public int Average { 
            get 
            {
                return this.FindAverage(); 
            } set { } }
        //{
        //    get
        //    {
        //        int sum = 0;
        //        int average = 0;
        //        foreach (Mark item in Marks)
        //        {
        //            sum += item.Mark1;
        //        }
        //        average = Marks.Count / sum;
        //        return average;
        //    }
        //}

        private List<Mark> Marks;

        public List<Mark> _marks
        {
            get
            {
                return Marks;
            }
            set
            { 
                this.Marks = value;
            }
        }
        public Student()
        {
            counter++;
            StudentId = counter;
        }
        public Student(string name, string surname):this()
        {
            this.Name = name;
            this.Surname = surname;
            List<Mark> mrks =new List<Mark>();
            this.Marks = mrks;
        }
    

        public override string ToString()
        {
            return $"Student Id:{StudentId}, Student name: {Name} , Surname: {Surname} ,Average: {Average}";
        }
        
   
        public override bool Equals(object obj)
        {
            return Name == ((Student)obj).Name && Surname == ((Student)obj).Surname;
        }

        public int FindAverage()
        {
            int sum = 0;
            int average = 0;
            foreach (Mark item in Marks)
            {
                sum += item.Mark1;
            }
            average = sum / 3;
            return average;
        }

    }
}
