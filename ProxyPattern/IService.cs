using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    /// <summary>
    /// 抽象角色：通过接口或抽象类声明真实角色实现的业务方法。
    /// </summary>
    public interface IService
    {
        void SendMsg();
    }
}