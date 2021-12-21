    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    namespace students
    {
    [Serializable]
    class Student
    {
        public string name;
        public string secondName;
        public string group;
    }
    [Serializable]
    class Baza
    {
        public List<Student> students = new List<Student>();
    }
    class Program
    {
        static void Main(string[] args)
        {
            Baza baza = new Baza();
            int otvet=0;            
            while (otvet != 3)
            {
                Console.WriteLine("\nЧто вы хотите сделать?\n Добавить (1) \t Сведения (2) \t Выход (3)\n");
                otvet = Int32.Parse(Console.ReadLine());
                //Console.Clear();
                BinaryFormatter formatter = new BinaryFormatter();        
                using (FileStream fs = new FileStream("stud.dat", FileMode.OpenOrCreate))
                {
                    baza = (Baza)formatter.Deserialize(fs);                                   
                }
                if (otvet == 1)
                {                    
                        Console.Clear();
                        Student student = new Student();
                        Console.WriteLine("Введите фамилие имя и группу студента через пробел:");
                        string e = Console.ReadLine();
                        string[] E = e.Split(" ");
                        student.name = E[1];
                        student.secondName = E[0];
                        student.group = E[2];
                        baza.students.Add(student);
                        Console.Clear();
                }
                else if (otvet == 2)
                {                  
                    Console.WriteLine("\n");
                    Console.WriteLine("Вывести информацию(1), Удалить(2), Изменить(3), Назад(4)\n");
                    int und = Int32.Parse(Console.ReadLine());
                    Console.Clear();
                    if (und == 1)
                    {
                        Console.WriteLine("Вывести по порядку(1), по именам(2), по фамилиям(3)");
                        int gg = Int32.Parse(Console.ReadLine());
                        if (gg == 1)
                        {
                            foreach (var i in baza.students)
                            {
                                Console.WriteLine("{0} {1} - {2}", i.secondName, i.name, i.group);
                            }                            
                        }
                        else  if(gg==2)
                        {
                            var newbaz = baza.students.OrderBy(x => x.name).ToList();
                            foreach (var i in newbaz)
                            {
                                Console.WriteLine("{0} {1} - {2}", i.secondName, i.name, i.group);
                            }
                        }
                        else if(gg==3)
                        {
                            var newbaz = baza.students.OrderBy(x => x.secondName).ToList();
                            foreach (var i in newbaz)
                            {
                                Console.WriteLine("{0} {1} - {2}", i.secondName, i.name, i.group);
                            }
                        }


                    }
                    else if(und==2)
                    {
                        int gg;
                        Console.WriteLine("Выберете параметр по каторому хотите удалить:\n(1)По фамилии, (2)По имени, (3)По группе, (4)По всем параметрам, (5)Назад");
                        gg = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("\n");
                        string Name;
                        switch (gg)
                        {
                            case 1:
                                Console.WriteLine("Введите фамилие:");
                                string secondName = Console.ReadLine();

                                foreach (Student i in baza.students)
                                {
                                    if (i.secondName == secondName)
                                    {
                                        Console.WriteLine("{0} {1} - {2}\tУдалить? (1)Да  (2)Нет", i.name, i.secondName, i.group);
                                        int p = Int32.Parse(Console.ReadLine());
                                        if(p==1)
                                        {
                                            baza.students.Remove(i);
                                            break;
                                        }

                                    }
                                }
                                break;
                            case 2:
                                Console.WriteLine("Введите Имя:");
                                Name = Console.ReadLine();

                                foreach (var i in baza.students)
                                {
                                    if (i.name == Name)
                                    {
                                        Console.WriteLine("{0} {1} - {2}\tУдалить? (1)Да  (2)Нет", i.name, i.secondName, i.group);
                                        int p = Int32.Parse(Console.ReadLine());
                                        if (p == 1)
                                        {
                                            baza.students.Remove(i);
                                            break;
                                        }
                                    }
                                }
                                break;
                            case 3:
                                Console.WriteLine("Введите Группу:");
                                Name = Console.ReadLine();

                                foreach (var i in baza.students)
                                {
                                    if (i.group == Name)
                                    {
                                        Console.WriteLine("{0} {1} - {2}\tУдалить? (1)Да  (2)Нет", i.name, i.secondName, i.group);
                                        int p = Int32.Parse(Console.ReadLine());
                                        if (p == 1)
                                        {
                                            baza.students.Remove(i);
                                            break;
                                        }
                                    }
                                }
                                break;
                            case 4:
                                Console.WriteLine("Введите Имя Фамилие Группу:");
                                Name = Console.ReadLine();
                                string[] fS = Name.Split(" ");
                                foreach (var i in baza.students)
                                {
                                    if (i.name == fS[0] && i.secondName == fS[1] && i.group == fS[2] )
                                    {
                                        Console.WriteLine("{0} {1} - {2}\tУдалить? (1)Да  (2)Нет", i.name, i.secondName, i.group);
                                        int p = Int32.Parse(Console.ReadLine());
                                        if (p == 1)
                                        {
                                            baza.students.Remove(i);
                                            break;
                                        }
                                    }
                                }
                                break;
                        }

                        Console.Clear();
                    } 
                    else if(und==3)
                    {
                        Console.WriteLine("\n");

                        Console.WriteLine("Введите фамилию и имя студента");
                        string pod = Console.ReadLine();
                        string[] a = pod.Split(" ");
                        Student newstudent = new Student();
                        newstudent.name = a[1];
                        newstudent.secondName = a[0];
                        foreach (var i in baza.students)
                        {
                            if (i.name == newstudent.name && i.secondName == newstudent.secondName)
                            {                                
                                int k = baza.students.IndexOf(i);
                                Console.WriteLine("{0} {1} {2}\nЧто вы хотите изменить?\n (1)Имя, (2)Фамилию, (3)Группу, (4)Все данные, Выход(5)\n", i.name, i.secondName, i.group);
                                int g = Int32.Parse(Console.ReadLine());
                                string nw;
                                switch(g)
                                {
                                    case 1:
                                        Console.WriteLine("Новое имя:");
                                        nw = Console.ReadLine();
                                        baza.students[k].name = nw;
                                        break;
                                    case 2:
                                        Console.WriteLine("Новое фамилие:");
                                        nw = Console.ReadLine();
                                        baza.students[k].secondName = nw;
                                        break;
                                    case 3:
                                        Console.WriteLine("Новая Группа:");
                                        nw = Console.ReadLine();
                                        baza.students[k].group = nw;
                                        break;
                                    case 4:
                                        Console.WriteLine("Новые фамилие имя и группа:");
                                        nw = Console.ReadLine();
                                        string[] Nw = nw.Split(" ");
                                        baza.students[k].name = Nw[1];
                                        baza.students[k].secondName = Nw[0];
                                        baza.students[k].group = Nw[3];
                                        break;
                                }
                                break;
                            }
                        }

                        Console.Clear();
                    }
                }
                using (FileStream fsi = new FileStream("stud.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fsi, baza);
                }                
            }
        }
    }
    }
