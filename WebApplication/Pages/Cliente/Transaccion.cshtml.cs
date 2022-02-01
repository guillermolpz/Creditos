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
    public class TransaccionModel : PageModel
    {
        [BindProperty]
        public CuentaAhorro oCuentaAhorro { get; set; }
        [BindProperty]
        public Transaccion oTransaccion { get; set; }
        [BindProperty]
        public int tipo { get; set; }
        [BindProperty]
        public string mensaje { get; set; }
        public decimal saldoActualizado { get; set; }
        public void OnGet(int id)
        {
            oCuentaAhorro = CuentaAhorroNeg.getCuentaAhorroByIdCuenta(id);
        }

        public IActionResult OnPost()
        {
            if (tipo == 2)
            {
                if (oCuentaAhorro.saldo_actual >= oTransaccion.monto)
                {
                    mensaje = "";
                    saldoActualizado = oCuentaAhorro.saldo_actual - oTransaccion.monto;
                    //Llenando datos de trasferencia
                    oTransaccion.id_cuenta = oCuentaAhorro.id_cuenta;
                    oTransaccion.id_cliente = oCuentaAhorro.id_cliente;
                    oTransaccion.tipo = "Retiro";
                    //Actualizando datos de cuenta
                    oCuentaAhorro.saldo_actual = saldoActualizado;
                    bool resp = TransferenciaNeg.crearTransferencia(oTransaccion);
                    if (resp == true)
                    {
                        bool respCA = CuentaAhorroNeg.updateCuentaAhorro(oCuentaAhorro);
                        return RedirectToPage("/Cliente/GestionarCuenta", new { id = oCuentaAhorro.id_cuenta });
                    }
                }
                else
                {
                    mensaje = "El monto a retirar excede su saldo disponible";
                }
            }
            else
            {
                saldoActualizado = oCuentaAhorro.saldo_actual + oTransaccion.monto;
                //Llenando datos de trasferencia
                oTransaccion.id_cuenta = oCuentaAhorro.id_cuenta;
                oTransaccion.id_cliente = oCuentaAhorro.id_cliente;
                oTransaccion.tipo = "Deposito";
                //Actualizando datos de cuenta
                oCuentaAhorro.saldo_actual = saldoActualizado;
                bool resp = TransferenciaNeg.crearTransferencia(oTransaccion);

                if (resp == true)
                {
                    bool respCA = CuentaAhorroNeg.updateCuentaAhorro(oCuentaAhorro);
                    return RedirectToPage("/Cliente/GestionarCuenta", new { id = oCuentaAhorro.id_cuenta });
                }
            }
            return RedirectToPage("/Cliente/GestionarCuenta", new { id = oCuentaAhorro.id_cuenta });
        }
    }
}
