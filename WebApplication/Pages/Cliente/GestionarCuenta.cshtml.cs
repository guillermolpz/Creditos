using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CreditoNeg.Entidad;
using CreditoNeg.Negocio;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages.Cliente
{
    public class GestionarCuentaModel : PageModel
    {
        [BindProperty]
        public CuentaAhorro oCuentaAhorro { get; set; }
        [BindProperty]
        public List<Transaccion> oTransacciones { get; set; }

        public void OnGet(int id)
        {
            oCuentaAhorro = CuentaAhorroNeg.getCuentaAhorroByIdCuenta(id);
            oTransacciones = TransferenciaNeg.getTransaccionesByIdClienteIdCuenta(oCuentaAhorro.id_cliente, oCuentaAhorro.id_cuenta);
        }
    }
}
