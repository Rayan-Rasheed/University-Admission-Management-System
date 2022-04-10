using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMAS_PD.BL
{
    class Student
    {
        public string stu_name;
        public int stu_age;
        public int stu_fscMarks;
        public int stu_ecatMarks;
        public double stu_aggregate;
        public List<DegreeProgram> prefrences;
        public List<Subject> subjects;
        public bool admissionState;

        public Student(string stu_name,int stu_age,int stu_fscMarks,int stu_ecatMarks,double stu_aggregate, List<DegreeProgram> prefrences)
        {
            this.stu_name=stu_name;
            this.stu_age = stu_age;
            this.stu_fscMarks = stu_fscMarks;
            this.stu_ecatMarks = stu_ecatMarks;
            this.stu_aggregate = stu_aggregate;
            this.prefrences = prefrences;
            subjects = new List<Subject>();
            admissionState = false;



        }
        public Student(Student s)
        {
            stu_name = s.stu_name;
            stu_age = s.stu_age;
            stu_fscMarks = s.stu_fscMarks;
            stu_ecatMarks = s.stu_ecatMarks;
            stu_aggregate = s.stu_aggregate;
            prefrences = s.prefrences;
            subjects = s.subjects;

        }
        public Student()
        {

        }
        public float calculateMerit(int stu_fscMarks,int stu_ecatMarks)
        {
            float aggregate;
            aggregate = (70) * (stu_fscMarks)/1100 + (30) * (stu_ecatMarks)/1100;
            return aggregate;
        }
        public bool matchDegree(string s)
        {
            bool match = false;
            foreach (DegreeProgram var in prefrences)

            {
                if (s == var.degreeName)
                {
                    match = true;

                }

            }
            return match;
        }
        public int CreditHours()
        {
            int totalCH = 0;
            for(int i = 0; i < subjects.Count; i++)
            {
                totalCH = totalCH + subjects[i].subjectCreditHour;
            }
            return totalCH;
        }





    }
}
