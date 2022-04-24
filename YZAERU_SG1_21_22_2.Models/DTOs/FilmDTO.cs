using System;

namespace YZAERU_SG1_21_22_2.Models.DTOs
{
    public class FilmDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Length { get; set; }

        public int DirectorId { get; set; }
        public bool IsTheBest { get; set; }
        public string Type { get; set; }
        public DateTime RelaseYear { get; set; }
    }
}
