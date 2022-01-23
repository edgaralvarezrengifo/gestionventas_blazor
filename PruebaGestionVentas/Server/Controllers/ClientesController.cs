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
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ClientesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(ClientDTO clientedto)
        {
            Cliente  cliente= new Cliente();
            cliente.nombre = clientedto.name;
            cliente.apellido = clientedto.lastname;
            cliente.telefono = clientedto.phone;
            cliente.fecha_creacion = DateTime.Now;
            cliente.cedula = clientedto.DocumentId;


            context.Add(cliente);
            await context.SaveChangesAsync();
            return cliente.Id;

        }

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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await context.Cliente.AnyAsync(x => x.Id == id);
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
        public async Task<ActionResult<List<ClientDTO>>> Get([FromQuery] Pagin pagin)
        {
            var queryable = context.Cliente.AsQueryable();
            var queryabledto = queryable.Select(x => new ClientDTO { DocumentId = x.cedula, name = x.nombre, lastname = x.apellido, phone = x.telefono, creation_date = x.fecha_creacion, Id = x.Id });
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
