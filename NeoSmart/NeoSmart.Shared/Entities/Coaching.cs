using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSmart.Shared.Entities
{
    public class Coaching
    {
        public int Id { get; set; }

        [Display(Name = "Entrenamiento")]
        [MaxLength(120, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public int PositionId { get; set; }

        public Position? Position { get; set; }
    }
}
