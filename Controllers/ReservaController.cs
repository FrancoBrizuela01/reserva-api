using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservaApi.Data;
using ReservaApi.Models;

namespace ReservaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservaController(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todas las reservas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
        {
            return await _context.Reservas.ToListAsync();
        }

        // Crear una nueva reserva
        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(Reserva reserva)
        {
            bool clienteYaReservado = await _context.Reservas
                .AnyAsync(r => r.Cliente == reserva.Cliente && r.Fecha.Date == reserva.Fecha.Date);
            if (clienteYaReservado)
            {
                return BadRequest("El cliente ya tiene una reserva en este día.");
            }

            bool horarioOcupado = await _context.Reservas
                .AnyAsync(r => r.Fecha.Date == reserva.Fecha.Date && r.Horario == reserva.Horario);
            if (horarioOcupado)
            {
                return BadRequest("Ese horario ya está reservado.");
            }

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReservas), new { id = reserva.Id }, reserva);
        }

        // Obtener todos los servicios desde la base de datos (Corrección: cambiamos la ruta)
        [HttpGet("servicios")]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetServicios()
        {
            return await _context.Servicios.ToListAsync();
        }
    }
}
