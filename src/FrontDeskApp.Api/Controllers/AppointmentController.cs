using FrontDeskApp.Application.Common;
using FrontDeskApp.Application.DTOs;
using FrontDeskApp.Application.Services;
using FrontDeskApp.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrontDeskApp.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {

        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // Only admins can create patients
        [HttpPost("create")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentDto dto)
        {
            ResponseInfo<Appointment> appointment = await _appointmentService.CreateAppointmentAsync(dto);
            return Ok(appointment);
        }


        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(
    [FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 10,
    [FromQuery] string? sortBy = null,
    [FromQuery] bool sortDescending = false,
    [FromQuery] string? search = null)
        {
            var result = await _appointmentService.GetAppointmentsPagedAsync(
                pageNumber,
                pageSize,
                sortBy,
                sortDescending,
                search
            );

            return Ok(result);
        }


    }
}