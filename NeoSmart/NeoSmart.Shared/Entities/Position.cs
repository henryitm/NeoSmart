
using System.ComponentModel.DataAnnotations;

namespace NeoSmart.Shared.Entities
{
    public class Position
    {
        public int Id { get; set; }

        [Display(Name = "Cargo")]
        [MaxLength(110, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;



        public ICollection<Coaching>? Coachings { get; set; }

        [Display(Name = "Entrenamientos")]
        public int CoachingsNumber => Coachings == null ? 0 : Coachings.Count;
    }
}
