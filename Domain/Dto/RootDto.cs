using BobMarley.Domain.Entities.Secondary;

namespace BobMarley.Domain.Dto
{
    public class RootDto
    {
        public List<object>? data { get; set; }
        public Meta? meta { get; set; }
    }
}

