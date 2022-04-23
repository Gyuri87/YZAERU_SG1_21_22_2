using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YZAERU_SG1_21_22_2.Models.Entities
{
    [Table("Films")]
    public class Film
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public int Length { get; set; }

        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
        public bool IsTheBest { get; set; }
        public int RelaseYear { get; set; }
        public string Type { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual Director Director { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<ActorFilm> ActorFilms { get; }

        public override string ToString()
        {
            return $"Id: {this.Id} - Title: {this.Title} - Length: {this.Length} - DirectorId: {this.DirectorId} - DirectorName: {this.Director.Name} - Relase date: {this.RelaseYear} - Type: {this.Type} - is the best movie: {this.IsTheBest}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Film)
            {
                Film another = obj as Film;
                return this.Director == another.Director && this.DirectorId == another.DirectorId && this.Id == another.Id &&
                        this.Title == another.Title;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
