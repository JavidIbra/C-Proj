using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject1
{
    public class Group
    {
        private static int count;
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public List<Student> Students { get; set; }

        private readonly int MaxStudentCount;
        public int _maxStudentCount /*{ get; set; }*/
        {
            get
            {
                return _maxStudentCount;
            }
            set
            {
                //_MaxStudentCount = value;

                if (!(value < 0 && value > 25))
                {
                    _maxStudentCount = value;
                }

                else
                {
                    Console.WriteLine("Qrupda Telebe sayi yalniz 1-25 araliginda ola biler ");
                }
            }
        }
        public Group()
        {
            count++;
            GroupId = count;
        }
        public Group(string groupName, int maxStudentCount) : this()
        {
            this.GroupName = groupName;
            this.MaxStudentCount = maxStudentCount;
            List<Student> stList = new List<Student>();
            this.Students = stList;
        }
    

        public override string ToString()
        {
            //, Current Student Count: { Students.Count}
            return $"Group Name: {GroupName} ,Id: {GroupId} ,Max Student count: {MaxStudentCount}";
        }

        public override bool Equals(object obj)
        {
            return ((GroupName == ((Group)obj).GroupName));
        }

        public bool AddStud(Student student)
        {
            if (!Students.Contains(student))
            {
                Students.Add(student);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Student FindStudent(string name)
        {
            foreach (Student item in Students)
            {
                if (item.Name.Contains(name) || item.Surname.Contains(name))
                {
                   return item;
                }
              
            }
                    return null;

        }

    }
}
