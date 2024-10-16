using Sistema.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.AccesoDatos.Repositorio.IRepositorio
{
    public interface IPersona : IRepositorio<Persona>
    {
        void Actualizar(Persona personas);
    }
}
