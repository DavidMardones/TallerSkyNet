using SkyNetModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyNetModel.DAL
{
    public class SkyNetDAL
    {
        private List<Eliminador> eliminadores = new List<Eliminador>();

        public void AgregarEliminador(Eliminador eliminador)
        {
            eliminadores.Add(eliminador);
        }

        public List<Eliminador> ObtenerEliminadores()
        {
            return eliminadores;
        }
    }
}