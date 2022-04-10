using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMAS_PD.BL;

namespace UMAS_PD
{
    class Program
    {

        static List<Student> students = new List<Student>();
        static List<DegreeProgram> degreePrograms = new List<DegreeProgram>();
        static void Main(string[] args)
        {
            


            int option = 0;
            while (option < 8)
            {
                Console.Clear();
                header();
                option = choose();
                if (option == 1)
                {
                    header();
                    students.Add(addStudent());
                }
                else if (option == 2)
                {
                    header();
                    degreePrograms.Add(addDegreeProgram());
                }
                else if (option == 3)
                {
                    Console.Clear();
                    header();
                    generateMeritList();
                    Console.ReadKey();

                }
                else if (option == 4)
                {
                    viewRegisteredStudent();
                    Console.ReadKey();


                }
                else if (option == 5)
                {
                    specifDegree();
                    Console.ReadKey();

                }
                else if (option == 6)
                {
                    registerSubject();
                    Console.ReadKey();

                }
                else if (option == 7)
                {
                    double fee = generateFee();
                    Console.WriteLine("Total Fees : " + fee);
                    Console.ReadKey();
                }
            }

        }
        static void header()
        {
            Console.WriteLine("***********************************************************************************************");
            Console.WriteLine("*****************************University Admission Management Systen****************************");
            Console.WriteLine("***********************************************************************************************\n");


        }
        static int choose()
        {
            int option;
            Console.WriteLine("MainMenu>>\n");

            Console.WriteLine("1.Add Student");
            Console.WriteLine("2.Add Degree Program");
            Console.WriteLine("3.Generate Merit");
            Console.WriteLine("4.View registered student");
            Console.WriteLine("5.View Student of a Specific program");
            Console.WriteLine("6.Register Subjects for a Specific Student");
            Console.WriteLine("7.Calculate Fees for all Registered Student");
            Console.WriteLine("8.Exit");
            Console.Write("Choose a option...");
            option = int.Parse(Console.ReadLine());
            return option;








        }

        static Student addStudent( )
        {
            Console.Clear();
            header();
            Console.Write("MainMenu>>Add Student>\n");

            Console.Write("Enter Student name: ");
             string stu_name=Console.ReadLine();
             Console.Write("Enter Student age: ");
             int stu_age =int.Parse(Console.ReadLine());
             Console.Write("Enter Student Fsc marks: ");
             int stu_fscMarks =int.Parse(Console.ReadLine());
             Console.Write("Enter Student Ecat marks: ");
             int stu_ecatMarks = int.Parse(Console.ReadLine());
             Student merit = new Student();
             double stu_aggregate = merit.calculateMerit(stu_fscMarks,stu_ecatMarks);
             List<DegreeProgram> preferences=showAvailableProgram();
             Student info = new Student(stu_name, stu_age, stu_fscMarks, stu_ecatMarks,stu_aggregate,preferences);
             return info;

        }
        static List<DegreeProgram> showAvailableProgram()
        {
            Console.Clear();
            header();
            Console.WriteLine("The avaliable Programs are given below:-\n");
            List<DegreeProgram> info = new List<DegreeProgram>();
            
            for (int i = 0;i<degreePrograms.Count;i++)
            {
                Console.WriteLine(i + 1 + ":" + degreePrograms[i].degreeName);
            }
            Console.Write("How many prefrence you want to enter..");
            int time = int.Parse(Console.ReadLine());
            string s=null;
            for (int i=0;i<time;i++)
            {
                
                bool match = false;
                while (match == false)
                {
                    Console.Write("Enter your " + (i + 1 )+ " prefrence:");
                     s= Console.ReadLine();
                    match = DegreeMatch( s);
                    if (match == false)
                    {
                        Console.WriteLine("Not found/available..Try again..");
                    }
                   


                }
                if (match == true)
                {
                    DegreeProgram stu = new DegreeProgram(s);
                    stu.degreeName = s;
                    info.Add(stu);
                    
                }
                

            }
            return info;
         }
        static bool DegreeMatch(string s)
        {
            bool match=false;
            foreach(DegreeProgram var in degreePrograms) {
                if (s == var.degreeName)
                {
                    match = true;
                    
                }

            }
            return match;
        }
        static DegreeProgram addDegreeProgram()
        {
            Console.Clear();
            header();
            Console.WriteLine("MainMenu>>Add Degree Programs:-\n");
            DegreeProgram addDegree = null;
            int totalHour = 21;
            
           
            Console.Write("Enter Degree Name: ");
            string degreeName = Console.ReadLine();
            Console.Write("Enter Degree Duration: ");
            string degreeduration = Console.ReadLine();
            Console.Write("Enter Seats for Degree: ");
            int degreeSeats = int.Parse(Console.ReadLine());
            Console.Write("How many subject you want to enter: ");
            int num = int.Parse(Console.ReadLine());
            while (totalHour > 20)
            {
                Console.Clear();
                List<Subject> Subjects = addSubject(num);
                addDegree = new DegreeProgram(degreeName, degreeduration, degreeSeats, Subjects);
                totalHour = addDegree.calculateCreditHour();
                if (totalHour > 20)
                {
                    Console.WriteLine("Your entered subject exceed 20 credit hour..Try again");

                }
            }
            return addDegree;
            
            
            
        }
        static List<Subject> addSubject(int times)
        {
            Console.WriteLine("Add information of Subjects.Subject should be no more than 9 Credit Hour\n");
            List<Subject> infoSubjects = new List<Subject>();
            for (int i = 0; i < times; i++)
            {
                Console.Write("Enter subject name: ");

                string subjectName = Console.ReadLine();
                Console.Write("Enter subject creditHour: ");

                int subjectCreditHour = int.Parse(Console.ReadLine());
                Console.Write("Enter subject type: ");

                int subjectCode = int.Parse(Console.ReadLine());
                Console.Write("Enter subject fee: ");

                double subjectFee = double.Parse(Console.ReadLine());
                Subject addSubject = new Subject(subjectName, subjectCreditHour, subjectCode, subjectFee);
                infoSubjects.Add(addSubject);
            }
            return infoSubjects;


        }
        static void generateMeritList()
        {
            
            Console.WriteLine("Students Merit List is given below:-\n");
            for(int  x= 0; x < students.Count; x++)
            {
                int LargeIdx = getLargestIndex(x);
                //name
                //string tempString = students[x].stu_name;
                //students[x].stu_name = students[LargeIdx].stu_name;
                //students[LargeIdx].stu_name = tempString;
                ////age
                //int tempInteger = students[x].stu_age;
                //students[x].stu_age = students[LargeIdx].stu_age;
                //students[LargeIdx].stu_age = tempInteger;
                ////fscMarks
                //tempInteger = students[x].stu_fscMarks;
                //students[x].stu_fscMarks = students[LargeIdx].stu_fscMarks;
                //students[LargeIdx].stu_fscMarks = tempInteger;
                ////matricMarks
                //tempInteger = students[x].stu_ecatMarks;
                //students[x].stu_ecatMarks = students[LargeIdx].stu_ecatMarks;
                //students[LargeIdx].stu_ecatMarks = tempInteger;
                ////aggregate
                //double tempDouble = students[x].stu_aggregate;
                //students[x].stu_aggregate = students[LargeIdx].stu_aggregate;
                //students[LargeIdx].stu_aggregate = tempDouble;
                ////preferences
                //List<DegreeProgram> tempPrefrences = new List<DegreeProgram>();
                //tempPrefrences = students[x].prefrences;
                //students[x].prefrences = students[LargeIdx].prefrences;
                //students[LargeIdx].prefrences = tempPrefrences;
                ////subject
                //List<Subject> tempsubjects = new List<Subject>();
                //tempsubjects = students[x].subjects;
                //students[x].subjects = students[LargeIdx].subjects;
                //students[LargeIdx].subjects = tempsubjects;
                Student temp = new Student(students[x]);
                students[x].stu_name = students[LargeIdx].stu_name;
                students[x].stu_age = students[LargeIdx].stu_age;
                students[x].stu_fscMarks = students[LargeIdx].stu_fscMarks;
                students[x].stu_ecatMarks = students[LargeIdx].stu_ecatMarks;
                students[x].prefrences = students[LargeIdx].prefrences;
                students[x].subjects = students[LargeIdx].subjects;
                students[LargeIdx].stu_name = temp.stu_name;
                students[LargeIdx].stu_age = temp.stu_age;
                students[LargeIdx].stu_fscMarks = temp.stu_fscMarks;
                students[LargeIdx].stu_ecatMarks = temp.stu_ecatMarks;
                students[LargeIdx].prefrences = temp.prefrences;
                students[LargeIdx].subjects = temp.subjects;


            }
            manageAdmission();

        }
        static int getLargestIndex(int start)
        {
            int largestIdx = start;
            double highestMerit = students[start].stu_aggregate;
            for(int i = start; i < students.Count; i++)
            {
                if (students[i].stu_aggregate> highestMerit)
                {
                    highestMerit = students[i].stu_aggregate;

                    largestIdx = i;
                }
            }
            return largestIdx;

        }
        static void manageAdmission()
        {
            for(int i = 0; i < students.Count; i++)
            {
                matchPrefrence(students[i]);
            }
        }
        static void matchPrefrence(Student s)
        {
            //deciding the admission in which preference he will got admission
            
            string firstPref;
            for (int i = 0; i < s.prefrences.Count; i++)
            {
                 firstPref = s.prefrences[i].degreeName;
                for(int j = 0; j < degreePrograms.Count; j++)
                {
                    if (firstPref == degreePrograms[j].degreeName&& degreePrograms[j].degreeSeats>0&&s.admissionState==false)
                    {
                        degreePrograms[j].degreeSeats--;
                        s.admissionState =   true;
                        Console.WriteLine(s.stu_name + "  Got Admission in " + firstPref);
                    }
                }
            }
            if(s.admissionState == false)
            {
                Console.WriteLine(s.stu_name + "  Sorry!Did not get Admission.");
            }
            
        }
        static void viewRegisteredStudent()
        {
            Console.WriteLine("Name\tFsc\tEcat\tAge");
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].admissionState == true)
                {

                    Console.WriteLine(students[i].stu_name + "\t" + students[i].stu_fscMarks + "\t" + students[i].stu_ecatMarks + "\t" + students[i].stu_age);
                }
            }
            Console.ReadKey();

        }
        static void specifDegree()
        {
            Console.Clear();
            header();
            bool match = false;
            Console.WriteLine("Enter the degree name: ");
            string inspection = Console.ReadLine();

            Console.WriteLine("Students enrolled in "+inspection+" are:-\n");
            Console.WriteLine("Name\tFsc\tEcat\tAge");
            for (int i = 0; i<students.Count; i++)
            {
                for (int j = 0; j < students[i].prefrences.Count; j++)
                {
                    if (students[i].admissionState == true&& students[i].prefrences[j].degreeName==inspection)
                    {
                        match = true;
                        Console.WriteLine(students[i].stu_name + "\t" + students[i].stu_fscMarks + "\t" + students[i].stu_ecatMarks + "\t" + students[i].stu_age);

                    }
                }
            }
            if (match == false)
            {
                Console.WriteLine("No Student has enrolled in this Program.");
            }
        }
        static void registerSubject()
        {
            Console.Clear();
            header();
            bool register = false;
            bool exceedHour = false;
            Console.WriteLine("Enter Student Name: ");
            string regStudent= Console.ReadLine();
            Console.WriteLine("Enter Subject Code: ");
            int subCode = int.Parse(Console.ReadLine());
            for(int i = 0; i < students.Count; i++)
            {
                if (regStudent == students[i].stu_name&&students[i].admissionState==true&&register==false)
                {
                    for (int j = 0; i < degreePrograms.Count; j++)
                    {
                        Subject s = subjectExist(subCode, degreePrograms[i],ref register);
                        if (s!=null && register == true && students[i].CreditHours()<10)
                        {
                            students[i].subjects.Add(s);
                            break;
                        }
                        if( students[i].CreditHours() > 9)
                        {
                            exceedHour = true;
                        }
                        
                    }
                    if (register == false)
                    {
                        Console.WriteLine("No such Subject Has exist in your program!");
                        break;
                    }
                    else if (exceedHour == true)
                    {
                        Console.WriteLine("Cannot add subject!Exceeding 9 Credit Hour!");
                        break;

                    }


                }
            }
           
        }
        static Subject subjectExist(int subCode,DegreeProgram d, ref bool register)
        {
                Subject s=null;
                for (int j = 0; j < d.Subjects.Count; j++) {

                    if (subCode == d.Subjects[j].subjectCode)
                    {
                        register = true;
                         s = new Subject(d.Subjects[j].subjectName, d.Subjects[j].subjectCreditHour, d.Subjects[j].subjectCode, d.Subjects[j].subjectFee);
                       
                    }
                }

            return s;
        }
        static double generateFee()
        {
            double fee=0;
            Console.Clear();
            header();
            Console.Write("Enter the name of student: ");
            string stu_name = Console.ReadLine();
            for(int i = 0; i < students.Count; i++)
            {
                if (stu_name == students[i].stu_name)
                {
                    fee = calculateFee(students[i]);
                }
            }
            return fee;
        }
        static double calculateFee(Student stu)
        {
            double total = 0;
            for(int i = 0; i < stu.subjects.Count; i++)
            {
                total = total + stu.subjects[i].subjectFee;
            }
            return total;
        }
        

    }
}
