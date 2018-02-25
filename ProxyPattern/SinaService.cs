using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    /// <summary>
    /// 真实角色：实现抽象角色，定义真实角色所要实现的业务逻辑，供代理角色调用。
    /// </summary>
    public class SinaService : IService
    {
        public void SendMsg()
        {
            Console.WriteLine("Hello");
        }
    }
}