using Sistema.AccesoDatos.Repositorio.IRepositorio;
using Sistema.Modelos;
using Sistema.AccesoDatos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.AccesoDatos.Repositorio
{
    public class PersonaRepositorio : Repositorio<Persona>, IPersona
    {
        private readonly ApplicationDbContext _db;

        public PersonaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Persona persona)
        {
            var personaDb = _db.Personas.FirstOrDefault(p => p.Id == persona.Id);
            if(personaDb != null)
            {
                personaDb.NombreApellido = persona.NombreApellido;
                personaDb.TipoDocumento = persona.TipoDocumento;
                personaDb.FechaNacimiento = persona.FechaNacimiento;
                personaDb.ValorGanar = persona.ValorGanar;
                personaDb.EstadoCivil = persona.EstadoCivil;
            }
        }
    }
}
