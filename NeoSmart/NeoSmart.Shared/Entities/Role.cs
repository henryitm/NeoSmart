
using System.ComponentModel.DataAnnotations;

namespace NeoSmart.Shared.Entities
{
    public class Role
    {
        public int Id { get; set; }

        [Display(Name = "Role")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;
    }
}
