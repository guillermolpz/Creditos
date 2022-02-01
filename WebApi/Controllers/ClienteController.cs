using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditoNeg.Entidad;
using CreditoNeg.Negocio;

namespace WebApi.Controllers
{
    [Route("api/Cliente/{action}/{id?}")]
    [ApiController]
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, ActionName("getAllClient")]
        public ActionResult<List<Cliente>> getClientes()
        {
            List<Cliente> listClientes = new List<Cliente>();
            listClientes = ClienteNeg.getClientes();
            return listClientes;
        }
    }
}
