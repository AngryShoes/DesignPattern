using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace AOP
{
    public class UnityAop
    {
        public void Test()
        {
            User user = new User { Name = "Jack", Age = 52 };
            {
                UserProcessor userProcessorCommon = new UserProcessor();
                userProcessorCommon.RegisterUser(user);
            }

            {
                IUnityContainer unitityContainer = new UnityContainer();// 声明容器
                unitityContainer.RegisterType<IUserProcessor, UserProcessor>();// 注册接口类型
                IUserProcessor userProcessor = unitityContainer.Resolve<IUserProcessor>();// 创建实例
                userProcessor.RegisterUser(user);

                unitityContainer.AddNewExtension<Interception>().Configure<Interception>()
                    .SetInterceptorFor<IUserProcessor>(new InterfaceInterceptor());

                IUserProcessor userProcessor2 = unitityContainer.Resolve<IUserProcessor>();
                userProcessor2.RegisterUser(user);
            }
            Console.ReadKey();
        }
    }

    #region Attributes Behavior

    public class UserHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            User user = input.Inputs[0] as User;
            if (user.Age > 100)
            {
                Console.WriteLine("The user is too old......");
            }
            else
            {
                Console.WriteLine("The user is a good person...");
            }
            IMethodReturn methodReturn = getNext()(input, getNext);
            return methodReturn;
        }
    }

    internal class LogUserInfoHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            User user = input.Inputs[0] as User;

            Console.WriteLine($"Log User: Name={user.Name}, Age={user.Age}");
            IMethodReturn methodReturn = getNext()(input, getNext);
            return methodReturn;
        }
    }

    #endregion Attributes Behavior

    #region Attributes

    public class UserHandlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            ICallHandler userHandler = new UserHandler() { Order = this.Order };
            return userHandler;
        }
    }

    public class LogUserInfoAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            ICallHandler LogUserHandler = new LogUserInfoHandler() { Order = this.Order };
            return LogUserHandler;
        }
    }

    #endregion Attributes

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    /// <summary>
    /// AOP对接口上的方法进行拦截
    /// 继承这个接口实现类的方法能够被拦截
    /// </summary>
    [UserHandler(Order = 2)]
    [LogUserInfo(Order = 1)]
    public interface IUserProcessor
    {
        void RegisterUser(User user);

        User GetUser(User user);
    }

    public class UserProcessor : IUserProcessor
    {
        public User GetUser(User user)
        {
            return user;
        }

        public void RegisterUser(User user)
        {
            Console.WriteLine("user register...");
        }
    }
}