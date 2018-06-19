using estrutura.ivy.usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivy.Services
{
    public class svrusuario
    {

        public static async Task<EstruturaUsuarioLoginRetorno> login(EstruturaUsuarioLoginEntrada ent)
        {
            EstruturaUsuarioLoginRetorno result = await proxy.proxy.post<EstruturaUsuarioLoginRetorno>(ivy.Config.config.Service_login, ent);
            return result;
        }


    }
}
