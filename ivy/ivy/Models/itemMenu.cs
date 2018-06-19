using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivy.Models
{
    public class itemMenu
    {
        public string id { get; set; }
        public string texto { get; set; }
        public string imagem { get; set; }
        public string idPai { get; set; }
        public List<itemMenu> filhos { get; set; }
        public bool visivel { get; set; }
        public bool habilitado { get; set; }
    }
}
