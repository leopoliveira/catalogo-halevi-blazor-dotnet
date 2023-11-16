namespace Halevi.Core.Application.DTOs.Base
{
    public record BaseDto()
    {
        public Guid Id { get; set;
        }
        public int Code { get; set; }
    }
}
