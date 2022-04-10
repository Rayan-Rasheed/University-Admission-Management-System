using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMAS_PD.BL
{
    class Subject
    {
        public string subjectName;
        public int subjectCreditHour;
        public int subjectCode;
        public double subjectFee;
        public Subject(string subjectName,int subjectCreditHour,int subjectCode,double subjectFee)
        {
            this.subjectName = subjectName;
            this.subjectCreditHour = subjectCreditHour;
            this.subjectCode = subjectCode;
            this.subjectFee = subjectFee;
        }
       
       
       


    }
}
