using System;
using System.IO;
using System.Collections.Generic;

namespace phaseCproject
{
    internal class Program
    {
        static void Main(string[] args)
        {
                string file = @"D:\phase1project\Teacherrecord.txt";



                if (File.Exists(file))
                {
                    Console.WriteLine("File Exists");
                    Console.WriteLine("\n 1.Display \n 2.Update \n 3.Delete  \n 4.Search ");

                    Selection();
                }
                else
                {
                    Console.WriteLine("File does not Exists");
                }

            }



            public static void Selection()
            {

                Console.WriteLine("\nEnter option for the required operation ");


                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nDisplaying the file\n");
                        display();
                        break;
                    case 2:
                        Console.WriteLine("Adding new line to file\n");
                        update();
                        break;
                    case 3:
                        Console.WriteLine("Deleting a line in text file\n ");
                        Deleting();
                        break;

                    case 4:
                        Console.WriteLine("Seaching data in file\n");
                        Searching();
                        break;

                    default:
                        Console.WriteLine("Invalid input\n");
                        break;
                }

            }



            public static void display()
            {
                String file = @"D:\phase1project\Teacherrecord.txt";
                String[] lines = File.ReadAllLines(file);
                Array.Sort(lines);
                foreach (string t in lines)
                {
                    Console.WriteLine(t + " ");
                }



            }

            public static void update()
            {


                string file = @"D:\phase1project\Teacherrecord.txt";


                StreamWriter sw = File.AppendText(file);

                Console.WriteLine("Please Enter New Line : ");
                string NewLine = Console.ReadLine();


                sw.WriteLine(NewLine);
                sw.Close();


                StreamReader sr = new StreamReader(file);

                string str = sr.ReadLine();

                {
                    str = sr.ReadLine();
                }

                display();


            }
            public static void Deleting()
            {
                string file = @"D:\phase1project\Teacherrecord.txt";
                string[] lines = System.IO.File.ReadAllLines(file);
                List<Teacherrecord> listTeachers = new List<Teacherrecord>();
                foreach (string line in lines)
                {
                    string[] column = line.Split(',');

                    Teacherrecord teacher = new Teacherrecord();
                    teacher.Id = column[0];
                    teacher.Name = column[1];
                    teacher.Class = column[2];
                    teacher.Section = column[3];
                    listTeachers.Add(teacher);
                }
                Console.WriteLine(file);
                string id;
                Console.WriteLine("Enter the id to delete:");
                id = Console.ReadLine();
                foreach (Teacherrecord t in listTeachers)
                {
                    if (t.Id == id)
                    {
                        listTeachers.Remove(t);
                        break;

                    }
                    else
                    {
                        Console.WriteLine("enterd id is not there");
                        break;


                    }
                }
            int count = 0;
            string[] arr = new string[listTeachers.Count];
            foreach(Teacherrecord t1 in listTeachers)
            {
                string s = ($"{t1.Id},{t1.Name},{t1.Class},{t1.Section}");
                arr[count] = s;
                count++;
            }
            File.WriteAllLines(@"D:\phase1project\Teacherrecord.txt", arr);



            }

            private static void Searching()
            {
                List<Teacherrecord> listTeachers = new List<Teacherrecord>();
                string file = @"D:\phase1project\Teacherrecord.txt";
                string[] teacherarray = File.ReadAllLines(file);



                foreach (string line in teacherarray)
                {
                    string[] l = line.Split(',');
                    Teacherrecord teacher = new Teacherrecord();
                    teacher.Id = l[0];
                    teacher.Name = l[1];
                    teacher.Class = l[2];
                    teacher.Section = l[3];
                    listTeachers.Add(teacher);

                }
                Console.WriteLine(file);
                Console.WriteLine("enter id:");
                string id = Console.ReadLine();
                foreach (Teacherrecord t in listTeachers)
                {
                    if (t.Id == id)
                    {
                        Console.WriteLine("given {0} is present in the given file", id);
                        Console.WriteLine($"{t.Id},{t.Name},{t.Class},{t.Section}");
                        break;

                    }
                    else
                    {
                    Console.WriteLine("entered id is not there");
                    }
                }




            }
        }
    }

