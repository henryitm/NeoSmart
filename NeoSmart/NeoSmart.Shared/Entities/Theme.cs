using System.ComponentModel.DataAnnotations;

namespace NeoSmart.Shared.Entities
{
    public class Theme
    {
        public int Id { get; set; }

        [Display(Name = "Tema")]
        [MaxLength(110, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public ICollection<CapacitationTheme>? CapacitationThemes { get; set; }

    }
}
