using Sistema.AccesoDatos.Repositorio.IRepositorio;
using Sistema.AccesoDatos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;

        public IPersona Persona { get; private set; }


        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Persona = new PersonaRepositorio(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }

    }
}
