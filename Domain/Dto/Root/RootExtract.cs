using BobMarley.Domain.Entities.Secondary;

namespace BobMarley.Domain.Dto.Root
{
    public class RootExtract
    {
        public List<ExtractDto> data { get; set; }
        public Meta meta { get; set; }
    }
}
