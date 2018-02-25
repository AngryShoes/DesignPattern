using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    /// <summary>
    /// //代理角色：实现抽象角色，是真实角色的代理，通过真实角色的业务逻辑方法来实现抽象方法，并可以附加自己的操作。
    /// </summary>
    public class SinaServiceProxy
    {
        public IService service = null;

        public SinaServiceProxy()
        {
            service = new SinaService();
        }

        public void SendMsg()
        {
            Console.WriteLine("This is from the proxy service.");
            service.SendMsg();
        }
    }
}