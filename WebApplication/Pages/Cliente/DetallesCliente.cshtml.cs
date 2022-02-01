using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CreditoNeg.Entidad;
using CreditoNeg.Negocio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Pages.Cliente
{
    public class DetallesClienteModel : PageModel
    {
        [BindProperty]
        public CreditoNeg.Entidad.Cliente oCliente { get; set; }
        [BindProperty]
        public List<CuentaAhorro> oCuentaAhorro { get; set; }
        [BindProperty]
        public List<Transaccion> oTransaccion { get; set; }
        [BindProperty]
        public List<SelectListItem> Options { get; set; }
       
        public void OnGet(int id)
        {
            oCliente = ClienteNeg.getClienteById(id);

            oCuentaAhorro = CuentaAhorroNeg.getCuentaAhorroByIdCliente(id);

            /*Options = oCuentaAhorro.Select(a =>
                                    new SelectListItem {
                                        Value = a.id_cuenta.ToString(),
                                        Text = a.cuenta.ToString(),
                                    }).ToList();*/

            //oTransaccion = TransferenciaNeg.getTransaccionByIdCliente(id);
        }

        public IActionResult OnPostirCuentaAhorro()
        {
            return RedirectToPage("/Cliente/CuentaAhorro", new { id_cliente = oCliente.id_cliente });
        }
    }
}
