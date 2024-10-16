using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Modelos
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public string NombreApellido { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public string TipoDocumento { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public int ValorGanar { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public string EstadoCivil { get; set; }

    }
}
