using System.Text.Json.Serialization;

namespace Arkitektur.Business.Base
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; }
    }
}
