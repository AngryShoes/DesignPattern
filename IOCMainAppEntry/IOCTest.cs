using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using IOC.Service;
using Unity;
using IOC.Interface;
using Unity.Lifetime;
using System.Threading;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using System.IO;

namespace IOCMainAppEntry
{
    public class IOCTest
    {
        public static void Test()
        {
            #region instance from service

            /// we can take place it with config settings, need add IOC.Service.Teacher and IOC.Service.Student
            Console.WriteLine("************New instance of Teacher***************");
            {
                Teacher teacher = new Teacher();
                Console.WriteLine($"teacher leg == null?{teacher.Leg == null}");
                Console.WriteLine($"teacher hand == null?{teacher.Hand == null}");
            }

            Console.WriteLine("****************Teacher unity instance***************");
            {
                IUnityContainer container = new UnityContainer();
                container.RegisterType<IPeople, Teacher>();
                container.RegisterType<ILeg, Leg>();
                container.RegisterType<IHand, Hand>();

                IPeople teacher2 = container.Resolve<IPeople>();
                teacher2.SayHello();
                Console.WriteLine($"teacher2 ==null?{teacher2 == null}");
                Console.WriteLine($"teacher2 leg == null?{teacher2.Leg == null}");
                Console.WriteLine($"teacher2 hand == null?{teacher2.Hand == null}");
            }

            Console.WriteLine("****************Student unity instance***************");
            {
                IUnityContainer container = new UnityContainer();
                container.RegisterType<IPeople, Student>();
                container.RegisterType<ILeg, Leg>();
                container.RegisterType<IHand, Hand>();

                IPeople student = container.Resolve<IPeople>();
                student.SayHello();
                Console.WriteLine($"teacher2 ==null?{student == null}");
                Console.WriteLine($"teacher2 leg == null?{student.Leg == null}");
                Console.WriteLine($"teacher2 hand == null?{student.Hand == null}");
            }

            Console.WriteLine("**************** unity container lifetime***************");
            {
                IUnityContainer container = new UnityContainer();
                //container.RegisterType<IPeople, Student>(new TransientLifetimeManager());// default transient lifetime, create new instance everytime
                //container.RegisterType<IPeople, Student>(new ContainerControlledLifetimeManager());// container singleton
                container.RegisterType<IPeople, Student>(new PerThreadLifetimeManager());
                IPeople student = container.Resolve<IPeople>();
                IPeople student2 = container.Resolve<IPeople>();
                Console.WriteLine($"student == student2?{object.ReferenceEquals(student, student2)}");

                IPeople stu1 = null;
                Action action1 = () =>
                {
                    stu1 = container.Resolve<IPeople>();
                    Console.WriteLine($"stu1 is created by Thread:{Thread.CurrentThread.ManagedThreadId.ToString()}");
                };
                var act1result = action1.BeginInvoke(null, null);

                IPeople stu2 = null;
                Action action2 = () =>
                {
                    stu2 = container.Resolve<IPeople>();
                    Console.WriteLine($"stu2 is created by Thread:{Thread.CurrentThread.ManagedThreadId.ToString()}");
                };

                IPeople stu3 = null;
                var act2result = action2.BeginInvoke(x =>
                {
                    stu3 = container.Resolve<IPeople>();
                    Console.WriteLine($"stu3 is created by Thread:{Thread.CurrentThread.ManagedThreadId.ToString()}");
                    Console.WriteLine($"stu2==stu3?{object.ReferenceEquals(stu2, stu3)}");
                }, null);
                Console.WriteLine($"stu2==stu3?{object.ReferenceEquals(stu2, stu3)}");

                action1.EndInvoke(act1result);
                action2.EndInvoke(act2result);
                Console.WriteLine($"stu1==stu2?{object.ReferenceEquals(stu1, stu2)}");
            }

            #endregion instance from service

            #region instance from unity config settings

            /// we can remove service, it dependent with interface rather than concrete layer
            Console.WriteLine("************Unity container by config file************");
            {
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "ConfigFiles\\Unity.config");
                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);

                IUnityContainer container = new UnityContainer();
                section.Configure(container, "container");
                IPeople people = container.Resolve<IPeople>();
                people.SayHello();
                IPeople people1 = container.Resolve<IPeople>("student");// One more instance to impement a interface
                                                                        // use name to distinguish them
                                                                        // The name is given in unity config settings
                people1.SayHello();
            }

            #endregion instance from unity config settings
        }
    }
}