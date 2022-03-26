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
    
    [Table("Actors")]
    public class Actor
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(5)]
        [Required]
        public string Gender { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<ActorFilm> ActorFilms { get; }

        public override string ToString()
        {
            return $"Id: {this.Id} - Actor name: {this.Name} - Gender: {this.Gender}";
        }
    }
}
