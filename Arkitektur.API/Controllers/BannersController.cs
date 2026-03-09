using Arkitektur.Business.DTOs.BannerDtos;
using Arkitektur.Business.Services.BannerServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IBannerService bannerService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerDto bannerDto)
        {
            var response = await bannerService.CreateAsync(bannerDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ResultBannerDto>>> GetAll()
        {
            var response = await bannerService.GetAllAsycn();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ResultBannerDto>> GetById(int id)
        {
            var response = await bannerService.GetByIdAllAsycn(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPut]

        public async Task<IActionResult> Update(UpdateBannerDto bannerDto)

        {
            var response = await bannerService.UpdateAsync(bannerDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var response = await bannerService.DeleteAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
