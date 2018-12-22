using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAttributePractice
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Student stu = new Student { Name = "Tom", Address = "Lucient" };
            StudentInfoProcess studentInfoProcess = new StudentInfoProcess(stu);
            studentInfoProcess.ValidateName();
            Console.ReadKey();
        }
    }
}