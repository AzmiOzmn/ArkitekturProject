using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.Business.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService aboutService;

        public AboutsController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

        [HttpGet]
        public async Task<ActionResult<ResultAboutDto>> GetAll()
        {
            var response = await aboutService.GetAllAsycn();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await aboutService.GetByIdAllAsycn(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto request)
        {
            var response = await aboutService.CreateAsync(request);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateAboutDto request)
        {
            var response = await aboutService.UpdateAsync(request);
            return response.IsSuccessful ? Ok() : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await aboutService.DeleteAsync(id);
            return response.IsSuccessful ? Ok() : BadRequest(response);
        }
    }
}