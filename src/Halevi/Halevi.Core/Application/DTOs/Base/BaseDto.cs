namespace Halevi.Core.Application.DTOs.Base
{
    public record BaseDto()
    {
        public int? Code { get; set; }

        public bool Active { get; set; } = true;
    }
}
