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
    public class AltaClienteModel : PageModel
    {
        [BindProperty]
        public CreditoNeg.Entidad.Cliente oCliente { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //SqlADOConexion.IniciarConexion("sa","Server01");
            //var resp = SqlADOConexion.SQLM.InsertObject(oCliente.TableName, oCliente);
            bool result = ClienteNeg.crearCliente(oCliente);

            if (result is true)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                return RedirectToPage("/Cliente/AltaCliente");
            }
        }
    }
}
