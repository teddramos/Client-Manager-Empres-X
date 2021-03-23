using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_Manager_Empres_X.Models
{
    public class Cliente
    {
        public long id { get; set; }
        public string Nombre_Completo { get; set; }
        public List<Direccion> dircciones { get; set; }
        public Cliente()
        {
            this.dircciones = new List<Direccion>();
        }
    }
}
