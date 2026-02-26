using Arkitektur.Business.DTOs.Base;

namespace Arkitektur.Business.DTOs.AboutDtos
{
    public class CreateAboutDto 
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int StartYear { get; set; }
    }
}
