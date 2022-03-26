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
    
    [Table("ActorFilms")]
    public class ActorFilm
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        public int FilmId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual Film Film { get; set; }

        public int ActorId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual Actor Actor { get; set; }

        public override string ToString()
        {
            return $"Actor name: {this.Actor.Name} - Film: {this.Film.Title}";
        }
    }
}
