using System;
using System.Collections.Generic;

namespace FinalProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "My App";
            // Console.SetWindowSize(170,200);
            List<Group> GroupContext = new List<Group>();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Menu: 1- Add Group | 2-Add Student | 3- Add Student Mark|" +
                    " 4-View Student List| 5-Find Student | 6-Delete Group| Exit ");
                Console.ResetColor();

                string Edit = Console.ReadLine();

                if (Edit.ToLower() == "exit")
                {
                    Console.Beep();
                    break;
                }

                int selection;
                bool IsValid = int.TryParse(Edit, out selection);

                if (IsValid && selection > 0 && selection <= 6)
                {
                    switch (selection)
                    {
                        case (int)Options.AddGroup:

                            Console.WriteLine("Please add Group name:");
                            string grpName = Console.ReadLine();
                            if (string.IsNullOrEmpty(grpName))
                            {
                                //Console.OpenStandardError(); to do
                                Console.WriteLine("Invalid");
                                break;
                            }
                            Console.WriteLine("Please add student count of group(P.S:Max 25):");
                            string grpStCount = Console.ReadLine();
                            if (string.IsNullOrEmpty(grpStCount))
                            {
                                Console.WriteLine("Invalid");
                                break;
                            }
                            int count;
                            bool stCount = int.TryParse(grpStCount, out count);
                            if (!stCount)
                            {
                                Console.WriteLine("invalid!");
                                break;
                            }
                            if (!(count > 0 && count <= 25))
                            {
                                Console.WriteLine("Group's student count can be only in 1-25 avarage!");
                                break;
                            }
                            Group newGrp = new Group(grpName, count);

                            if (GroupContext.Contains(newGrp))
                            {
                                Console.WriteLine("group already exist!");
                                break;
                            }

                            GroupContext.Add(newGrp);

                            Console.WriteLine("Group added succesfully");
                            foreach (Group item in GroupContext)
                            {
                                Console.WriteLine(item);
                            }
                            break;

                        case (int)Options.Addstudent:

                            if (GroupContext.Count == 0)
                            {
                                Console.WriteLine("Add Group Firstly!");
                                break;
                            }
                            Console.WriteLine("Please add Student Name:");
                            string StName = Console.ReadLine();
                            if (string.IsNullOrEmpty(StName))
                            {
                                Console.WriteLine("Invalid");
                                break;
                            }
                            Console.WriteLine("Please add Student Surname:");
                            string StSurName = Console.ReadLine();
                            if (string.IsNullOrEmpty(StSurName))
                            {
                                Console.WriteLine("Invalid");
                                break;
                            }

                            Console.WriteLine("Please add GroupId that which group u want to add student:");
                            string grpId = Console.ReadLine();

                            int nm;
                            bool vld = int.TryParse(grpId, out nm);

                            if (vld)
                            {
                                Group addSt = null;
                                foreach (Group item in GroupContext)
                                {
                                    if (item.GroupId == nm)
                                    {
                                        addSt = item;
                                    }
                                }
                                if (addSt == null)
                                {
                                    Console.WriteLine("There is no such a group with this id !");
                                }

                                Student st = new Student(StName, StSurName);
                                addSt.AddStud(st);
                                Console.WriteLine("Student added succesfully");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("invalid id number!");
                                break;
                            }

                            break;

                        case (int)Options.AddStudentMArk:
                            if (GroupContext.Count == 0)
                            {
                                Console.WriteLine("Add Group and Student Firstly!");
                                break;
                            }
                            //foreach (Student student in stList.Students)
                            //{
                            //    Console.WriteLine(student);
                            //}
                            Console.WriteLine("add Student Name that u want to add marks!");
                            string studName = Console.ReadLine();

                            Student ss = null;
                            foreach (Group item in GroupContext)
                            {
                                ss = item.FindStudent(studName);
                                Console.WriteLine(ss);
                            }
                            if (ss == null)
                            {
                                Console.WriteLine("There is no Student with this Name!");
                                break;
                            }

                            for (int i = 1; i < 4; i++)
                            {
                                Console.WriteLine($"Please add Student's {i} mark(P.s: student can have only 3 mark!):");
                                string StMarks = Console.ReadLine();
                                int mrk1;
                                bool IsValid1 = int.TryParse(StMarks, out mrk1);
                                if (IsValid1 && mrk1 > 0 && mrk1 <= 100)
                                {
                                    Mark mr = new Mark(mrk1);
                                    ss._marks.Add(mr);
                                    Console.WriteLine("Mark added succesfully!");
                                }
                                else
                                {
                                    Console.WriteLine("not valid!");
                                    break;
                                }
                            }
                            Console.WriteLine($"students average is: {ss.FindAverage()}");
                            break;

                        //view student

                        case (int)Options.ViewStudentList:

                            if (GroupContext.Count == 0)
                            {
                                Console.WriteLine("Add Group and Student Firstly!");
                                break;
                            }
                            foreach (Group item in GroupContext)
                            {
                                Console.WriteLine(item);
                            }

                            Console.WriteLine("add Group id which group's student u want to see!");
                            string grId = Console.ReadLine();
                            int numb;
                            bool vald = int.TryParse(grId, out numb);

                            if (vald)
                            {
                                Group stList = null;
                                foreach (Group item in GroupContext)
                                {
                                    if (item.GroupId == numb)
                                    {
                                        stList = item;
                                    }
                                }
                                if (stList == null)
                                {
                                    Console.WriteLine("There is no such a group with this id!");
                                }
                                Console.WriteLine("here you are!");

                                foreach (Student student in stList.Students)
                                {
                                    Console.WriteLine(student);
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("invalid id number!");
                                break;
                            }

                        //  break;

                        case (int)Options.FindStudent:

                            if (GroupContext.Count == 0)
                            {
                                Console.WriteLine("Add Group Firstly!");
                                break;
                            }
                            Console.WriteLine("Current groups:");
                            foreach (Group item in GroupContext)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("Please add Query of student which u want to find!");
                            string str = Console.ReadLine();
                            if (string.IsNullOrEmpty(str))
                            {
                                Console.WriteLine("Invalid");
                                break;
                            }
                            str.ToLower();

                            foreach (Group item in GroupContext)
                            {
                                item.FindStudent(str);

                                if ((item.FindStudent(str)==null))
                                {
                                    Console.WriteLine("Student did not found!");
                                    break;
                                }


                                Console.WriteLine(item.FindStudent(str));
                                Console.WriteLine("student showed!");
                                 break;

                            }

                            break;


                        case (int)Options.DeleteGroup:

                            if (GroupContext.Count == 0)
                            {
                                Console.WriteLine("Add Group Firstly!");
                                break;
                            }

                            foreach (Group item in GroupContext)
                            {
                                Console.WriteLine(item);
                            }

                            Console.WriteLine("Add GroupId which u want to delete!");
                            string deleteId = Console.ReadLine();

                            int id;
                            bool valid = int.TryParse(deleteId, out id);
                            if (valid)
                            {
                                int l = GroupContext.Count;
                                for (int i = 0; i < l; i++)
                                {
                                    if (id == GroupContext[i].GroupId)
                                    {
                                        GroupContext.RemoveAt(i);

                                    }
                                }
                                Console.WriteLine("Group deleted succesfully");
                                Console.WriteLine("Entire groups are here! ");
                                foreach (Group item in GroupContext)
                                {
                                    Console.WriteLine(item);
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("your choice is not valid");
                                break;
                            }
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Add Appropriate Menu Number!");
                }
            }

            //Console.ReadKey();
        }
    }
}
