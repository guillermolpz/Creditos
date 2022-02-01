using System;
using System.Collections.Generic;
using System.Text;

namespace CreditoNeg.Entidad
{
    public class Transaccion
    {
        public string TableName = "Transaccion";
        public int id_transaccion { get; set; }
        public decimal monto { get; set; }
        public string tipo { get; set; }
        public int id_cuenta { get; set; }
        public int id_cliente { get; set; }
    }
}
