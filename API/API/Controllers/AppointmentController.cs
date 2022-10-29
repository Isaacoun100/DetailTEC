using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[Route("api/")]
[ApiController]
public class AppointmentController: ControllerBase
{
    private static List<Appointment> appointments = new List<Appointment>();

    
    [HttpGet("getAllAppointments")]
    public async Task<ActionResult<List<Appointment>>> getAllAppointments()
    {
        if (appointments.Count == 0)
        {
            return BadRequest("No appointments found");
        }
        return Ok(appointments);
    }

    [HttpPost("addAppointment")]
    public async Task<ActionResult<List<Appointment>>> addAppointment(Appointment newAppointment)
    {
        appointments.Add(newAppointment);
        return Ok(appointments);
    }

    [HttpPost("getAppointment")]
    public async Task<ActionResult<Appointment>> getAppointment(AppointmentID appointmentToGet)
    {
        var appointment = appointments.Find(h => h.numeroCita == appointmentToGet.numeroCita);
        if (appointment == null)
        {
            return BadRequest("Appointment not found");
        }

        return Ok(appointment);
    }

    [HttpDelete("deleteAppointment")]
    public async Task<ActionResult<Appointment>> deleteAppointment(AppointmentID appointmentToDelete)
    {

        var appointment = appointments.Find(h => h.numeroCita == appointmentToDelete.numeroCita);
        if (appointment == null)
        {
            return BadRequest("Appointment not found");
        }

        return Ok(appointment);
    }

    [HttpPut("updateAppointment")]
    public async Task<ActionResult<Appointment>> updateAppointment(Appointment appointmentToUpdate)
    {
        var appointment = appointments.Find(h => h.numeroCita == appointmentToUpdate.numeroCita);
        if (appointment == null)
        {
            return BadRequest("Appointment not found");
        }

        appointment.cliente = appointmentToUpdate.cliente;
        appointment.placaVehiculo = appointmentToUpdate.placaVehiculo;
        appointment.sucursal = appointmentToUpdate.sucursal;
        appointment.tipoLavado = appointmentToUpdate.tipoLavado;
        appointment.responsable = appointmentToUpdate.responsable;
        appointment.factura = appointmentToUpdate.factura;
        appointment.numeroCita = appointmentToUpdate.numeroCita;

        return Ok(appointment);
        
    }
    
    
















}