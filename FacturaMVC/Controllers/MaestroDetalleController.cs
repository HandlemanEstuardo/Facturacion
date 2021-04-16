using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FacturaMVC.Models.ViewModel;
using FacturaMVC.Models;

namespace FacturaMVC.Controllers
{
    public class MaestroDetalleController : Controller
    {
        // GET: MaestroDetalle
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(VentaViewModel model)
        {
            try
            {
                using (ExaFacturaEntities db = new ExaFacturaEntities())
                {
                    cliente oCliente = new cliente();
                    oCliente.fecha = model.fecha;
                    oCliente.Nombre = model.nombre;
                    oCliente.Nit = model.nit;
                    db.cliente.Add(oCliente);
                    db.SaveChanges();

                    foreach(var oC in model.detalle)
                    {
                        detalle oDetalle = new detalle();
                        oDetalle.cantidad = oC.cantidad;
                        oDetalle.nombre = oC.nombre;
                        oDetalle.precioUnitario = oC.precioUnitario;
                        oDetalle.total = oC.cantidad * oC.precioUnitario;
                        oDetalle.idVenta = oCliente.idCliente;
                        db.detalle.Add(oDetalle);
                    }


                    db.SaveChanges();

                }
                ViewBag.Message="Registro Insertado";
                return View();
            }
            catch (Exception ex)
            {
                return View(model);
            }

            
        }

        //Listado de Facturas
        public ActionResult ListadoFactura()
        {
            List<FacturaListViewModel> lst;
            using (ExaFacturaEntities db = new ExaFacturaEntities())
            {
                lst = (from d in db.detalle
                       select new FacturaListViewModel
                       {
                           id = d.id,
                           idVenta = d.idVenta,
                           cantidad = d.cantidad,
                           nombre = d.nombre,
                           precioUnitario=d.precioUnitario,
                           total=d.total

                       }).ToList();
            }
            return View(lst);
        }
        // GET: Taba listado de Cliente
        public ActionResult ListadoCliente()
        {
            List<ClienteListTablaViewModel> lst;
            using (ExaFacturaEntities db = new ExaFacturaEntities())
            {
                lst = (from d in db.cliente
                       select new ClienteListTablaViewModel
                       {
                           idCliente = d.idCliente,
                           Nombre = d.Nombre,
                           Nit=d.Nit
                       }).ToList();
            }
            return View(lst);
        }

        //Eliminar Cliente
        public ActionResult EliminarCliente(int id)
        {

            using (ExaFacturaEntities db = new ExaFacturaEntities())
            {

                var oCliente = db.cliente.Find(id);
                db.cliente.Remove(oCliente);
                db.SaveChanges();
            }
            return Redirect("~/MaestroDetalle/ListadoCliente/");
        }
        //Eliminar Factura
        public ActionResult EliminarFactura(int id)
        {

            using (ExaFacturaEntities db = new ExaFacturaEntities())
            {

                var oDetalle = db.detalle.Find(id);
                db.detalle.Remove(oDetalle);
                db.SaveChanges();
            }
            return Redirect("~/MaestroDetalle/ListdoFactura/");
        }



    }
}