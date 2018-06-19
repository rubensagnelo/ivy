using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ivy.Config
{
    public class config
    {
        public static string corpadrao = "00008B";
        /* 10.38.55.186 */

        //private static string server = @"192.168.0.109";//Casa
        private static string server = @"192.168.0.102:80";//Casa
        //private static string server = @"192.168.0.109:80";
        //private static string server = @"10.38.55.186:80";//MB
        //private static string server = @"169.254.80.80:80";//Meu Celular
        //private static string server = @"169.254.80.80";//Roteado Celular
        public static string Rootwebapi { get { return @"http://[server]/web.api.ivy/api/".Replace("[server]", server); } }
        public static string Service_login { get { return new StringBuilder(Rootwebapi).Append("usuario/login/").ToString(); } }
        public static string Service_usuario_incluir { get { return new StringBuilder(Rootwebapi).Append("usuario/incluir/").ToString(); } }
    }
}


