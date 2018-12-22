using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CustomerAttributePractice
{
    public class StudentInfoProcess
    {
        private Student Student { get; set; }
        private const string sayHiMethodName = "SayHi";
        private const string answerMethodName = "Answer";
        private const string questionMethodName = "Question";

        public StudentInfoProcess(Student student)
        {
            Student = student;
        }

        public void ValidateName()
        {
            Validation(sayHiMethodName);
            Validation(answerMethodName);
            ValidationWithParam(questionMethodName);
        }

        /// <summary>
        /// validation on method
        /// </summary>
        /// <param name="methodName"></param>
        private void Validation(string methodName)
        {
            var stuType = Student.GetType();
            if (stuType.IsDefined(typeof(CustomerAttribute), true))
            {
                MethodInfo methodInfo = stuType.GetMethod(methodName);

                CustomerAttribute ca = methodInfo.GetCustomAttribute(typeof(CustomerAttribute)) as CustomerAttribute;
                bool isValidNameLength = ca.Validate(Student.Name);
                if (isValidNameLength)
                {
                    Console.WriteLine("valid student name");
                    if (methodInfo.Name.Equals(sayHiMethodName))
                    {
                        methodInfo.Invoke(Student, null);
                    }
                    else if (methodInfo.Name.Equals(answerMethodName))
                    {
                        methodInfo.Invoke(Student, new object[] { "Liangfengyouxing" });
                    }
                }
            }
        }

        // Test for parameters
        private void ValidationWithParam(string methodName)
        {
            var stuType = Student.GetType();
            MethodInfo methodInfo = stuType.GetMethod(methodName);
            foreach (var paramAttr in methodInfo.GetParameters())
            {
                if (paramAttr.IsDefined(typeof(CustomerAttribute), true))
                {
                    CustomerAttribute attribute = paramAttr.GetCustomAttribute(typeof(CustomerAttribute), true) as CustomerAttribute;
                    attribute.Validate(Student.Name);
                }
            }
            if (methodInfo.ReturnParameter.IsDefined(typeof(CustomerAttribute), true))
            {
                CustomerAttribute attribute = methodInfo.ReturnParameter.GetCustomAttribute(typeof(CustomerAttribute), true) as CustomerAttribute;
            }
        }
    }
}