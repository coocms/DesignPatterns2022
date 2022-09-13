using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsExec
{
    //外观模式
    public class FacadePattern
    {
        public void Show()
        {
            SystemFacade facade = new SystemFacade();
            facade.Buy();
        }
        
            
    }
    // 身份认证子系统A
    public class AuthoriationSystemA
    {
        public void MethodA()
        {
            Console.WriteLine("执行身份认证");
        }
    }

    // 系统安全子系统B
    public class SecuritySystemB
    {
        public void MethodB()
        {
            Console.WriteLine("执行系统安全检查");
        }
    }

    // 网银安全子系统C
    public class NetBankSystemC
    {
        public void MethodC()
        {
            Console.WriteLine("执行网银安全检测");
        }
    }

    //更高层的Facade
    public class SystemFacade
    {
        private AuthoriationSystemA auth;
        private SecuritySystemB security;
        private NetBankSystemC netbank;

        public SystemFacade()
        {
            auth = new AuthoriationSystemA();
            security = new SecuritySystemB();
            netbank = new NetBankSystemC();
        }

        public void Buy()
        {
            auth.MethodA();//身份认证子系统
            security.MethodB();//系统安全子系统
            netbank.MethodC();//网银安全子系统

            Console.WriteLine("我已经成功购买了！");
        }
    }
}
