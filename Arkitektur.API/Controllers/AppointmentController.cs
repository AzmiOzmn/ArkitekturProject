using Arkitektur.Business.DTOs.AppointmentDtos;
using Arkitektur.Business.Services.AppointmentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController(IAppointmentService appointmentService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentDto appointmentDto)
        {
            var response = await appointmentService.CreateAsync(appointmentDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}