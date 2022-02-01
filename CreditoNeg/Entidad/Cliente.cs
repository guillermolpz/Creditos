using System;
using System.Collections.Generic;
using System.Text;

namespace CreditoNeg.Entidad
{
    public class Cliente
    {
        /*private string TableName = "Clientes";*/
        public string TableName = "Clientes";
        public int id_cliente { get; set; }
        public string nombre { get; set; }
        public int no_identificacion { get; set; }
    }
}
