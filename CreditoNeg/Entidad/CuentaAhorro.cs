using System;
using System.Collections.Generic;
using System.Text;

namespace CreditoNeg.Entidad
{
    public class CuentaAhorro
    {
        public string TableName = "CuentaAhorro";
        public int id_cuenta { get; set; }
        public int cuenta { get; set; }
        public decimal saldo_actual { get; set; }
        public int id_cliente { get; set; }
    }
}
