using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMAS_PD.BL
{
    class DegreeProgram
    {
        public string degreeName;
        public string degreeDuration;
        public int degreeSeats;
        
        public List<Subject> Subjects=new List<Subject>();
        public DegreeProgram(string degreeName)
        {
            this.degreeName = degreeName;
        }
        public DegreeProgram(string degreeName,string degreeDuration, int degreeSeats,List<Subject>Subjects)
        {
            this.degreeName = degreeName;
            this.degreeDuration = degreeDuration;
            this.degreeSeats = degreeSeats;
            this.Subjects = Subjects;
            
            

        }
        public void addsSeats(int degreeSeats)
        {
            this.degreeSeats = degreeSeats;
           
        }
        public int calculateCreditHour()
        {
            int count = 0;
            for (int i = 0; i < Subjects.Count; i++)
            {
                count = count + Subjects[i].subjectCreditHour;

            }
            return count;
        }
        public void addSubject(Subject s)
        {
            int credithour = calculateCreditHour();
            if (credithour < 20)
            {
                Subjects.Add(s);
            }
            else
            {
                Console.WriteLine("20 credit hour is maximum limit.");
            }
        }
        


    }
}
