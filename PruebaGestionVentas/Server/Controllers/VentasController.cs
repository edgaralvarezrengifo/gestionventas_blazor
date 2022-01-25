using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaGestionVentas.Server.Helpers;
using PruebaGestionVentas.Server.Models;
using PruebaGestionVentas.Shared.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaGestionVentas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public VentasController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(SalesDTO sale)
        {
            Venta venta = new Venta();
            venta.cantidad = sale.Productsquantity;
            venta.valor_total = sale.Totalprice;
            venta.fecha_venta = DateTime.Now;
            context.Add(venta);
            await context.SaveChangesAsync();

            foreach (ProductDTO p in sale.Products)
            {
                Venta_detalle vd = new Venta_detalle();
                vd.ProductoId = p.Id;
                vd.VentaId = venta.Id;
                vd.ClienteId = sale.Client.Id;
                vd.Cantidad = p.quantity;
                vd.Valor_total = p.unitprice * p.quantity;
                context.Add(vd);
                await context.SaveChangesAsync();

            }


           
            return venta.Id;

        }
        /*
        [HttpPut]
        public async Task<ActionResult> Put(ClientDTO client)
        {
            Cliente cliente = context.Cliente.Where(x => x.Id == client.Id).FirstOrDefault();
            if (cliente == null)
            {
                return NotFound();
            }
            else
            {
                cliente.nombre = client.name;
                cliente.apellido = client.lastname;
                cliente.cedula = client.DocumentId;
                cliente.telefono = client.phone;

                context.Attach(cliente).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return NoContent();
            }

            context.Attach(cliente).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
        */
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            await context.Database.ExecuteSqlInterpolatedAsync($"delete from Venta_detalle WHERE VentaId = {id};");
            var exists = await context.Venta.AnyAsync(x => x.Id == id);
            if (!exists)
            {
                return NotFound();
            }
            else
            {
                context.Remove(new Venta { Id = id });
                await context.SaveChangesAsync();
                return NoContent();
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<SalesDTO>>> Get([FromQuery] Pagin pagin)
        {


            var result = from vd in context.Venta_detalle
                         join v in context.Venta
                         on vd.VentaId equals v.Id
                         join c in context.Cliente
                         on vd.ClienteId equals c.Id
                         join p in context.Producto
                         on vd.ProductoId equals p.Id
                         select new SalesDTO()
                         {
                             Id = v.Id,
                             Productsquantity = v.cantidad,
                             Totalprice = v.valor_total,
                             Client = new ClientDTO { Id = c.Id, DocumentId = c.cedula, name = c.nombre, lastname = c.apellido, creation_date = c.fecha_creacion, phone = c.telefono },
                             Products = new List<ProductDTO>(),
                             SaleDate = v.fecha_venta
                         };


            var queryabledto = result.Distinct().AsQueryable();

            await HttpContext.InsertParametersPaginResponse(queryabledto, pagin.NRecords);

            return await queryabledto.Pagionation(pagin).ToListAsync();
        }

        [HttpGet("search/{name}")]
        public async Task<ActionResult<int>> Get(string name)
        {

            return await context.Cliente.Where(x => x.nombre == name).CountAsync();
        }
    }
}
