using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.AccesoDatos.Configuracion
{
    public class PersonaConfiguracion : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.NombreApellido).IsRequired();
            builder.Property(x => x.TipoDocumento).IsRequired();
            builder.Property(x => x.FechaNacimiento).IsRequired();
            builder.Property(x => x.ValorGanar).IsRequired();
            builder.Property(x => x.EstadoCivil).IsRequired();
        }
    }
}
