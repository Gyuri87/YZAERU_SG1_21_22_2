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
    
    [Table("Directors")]
    public class Director
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Film> Films { get; }

        
        public override string ToString()
        {
            return $"Id: {this.Id} - Name: {this.Name}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Director)
            {
                Director another = obj as Director;
                return this.Films == another.Films && this.Id == another.Id &&
                        this.Name == another.Name;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
