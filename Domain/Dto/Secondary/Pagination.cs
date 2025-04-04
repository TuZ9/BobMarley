﻿namespace BobMarley.Domain.Entities.Secondary
{
    public class Pagination
    {
        public int total { get; set; }
        public int? count { get; set; }
        public int? per_page { get; set; }
        public int? current_page { get; set; }
        public int? total_pages { get; set; }
        public Links? links { get; set; }
    }
}
