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
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ProductosController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(ProductDTO productdto)
        {
            Producto producto = new Producto();
            producto.nombre_producto = productdto.name;
            producto.valor_unitario = productdto.unitprice;
            producto.fecha_creacion = DateTime.Now;



            context.Add(producto);
            await context.SaveChangesAsync();
            return producto.Id;

        }

        [HttpPut]
        public async Task<ActionResult> Put(ProductDTO product)
        {
            Producto producto = context.Producto.Where(x => x.Id == product.Id).FirstOrDefault();
            if (producto == null)
            {
                return NotFound();
            }
            else
            {
                producto.nombre_producto=product.name;
                producto.valor_unitario = product.unitprice;
            

                context.Attach(producto).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return NoContent();
            }

          
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await context.Producto.AnyAsync(x => x.Id == id);
            if (!exists)
            {
                return NotFound();
            }
            else
            {
                context.Remove(new Producto { Id = id });
                await context.SaveChangesAsync();
                return NoContent();
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> Get([FromQuery] Pagin pagin)
        {
            var queryable = context.Producto.AsQueryable();
            var queryabledto = queryable.Select(x => new ProductDTO { name = x.nombre_producto,unitprice=x.valor_unitario ,creationDate = x.fecha_creacion, Id = x.Id });
            await HttpContext.InsertParametersPaginResponse(queryabledto, pagin.NRecords);


            return await queryabledto.Pagionation(pagin).ToListAsync();
        }

        [HttpGet("search/{name}")]
        public async Task<ActionResult<int>> Get(string name)
        {

            return await context.Producto.Where(x => x.nombre_producto == name).CountAsync();
        }
    }
}
