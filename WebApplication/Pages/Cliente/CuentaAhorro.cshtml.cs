using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CreditoNeg.Entidad;
using CreditoNeg.Negocio;

namespace WebApplication.Pages.Cliente
{
    public class CuentaAhorroModel : PageModel
    {
        [BindProperty]
        public CreditoNeg.Entidad.Cliente oCliente { get; set; }
        [BindProperty]
        public CuentaAhorro oCuentaAhorro { get; set; }
        public void OnGet(int id)
        {
            oCliente = ClienteNeg.getClienteById(id);
        }

        public IActionResult OnPost()
        {
            //Creando cuenta de ahorro
            //oCuentaAhorro.id_cliente = oCliente.id_cliente;
            bool result = CuentaAhorroNeg.crearCuentaAhorro(oCuentaAhorro, oCliente.id_cliente);
            if (result is true)
            {
                return RedirectToPage("/Cliente/DetallesCliente", new { id = oCliente.id_cliente });
            }
            else
            {
                return RedirectToPage("/Cliente/AltaCliente");
            }
        }
    }
}
