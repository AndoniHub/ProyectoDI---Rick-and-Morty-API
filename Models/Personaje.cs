using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDI___Rick_and_Morty_API.Models
{
    /// <summary>
    /// Representa una ubicación en la que se encuentra un personaje.
    /// </summary>
    public class Location
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    /// <summary>
    /// Representa el origen de un personaje.
    /// </summary>
    public class Origin
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    /// <summary>
    /// Representa un personaje con toda su información detallada.
    /// </summary>
    public class Personaje
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public Origin origin { get; set; }
        public Location location { get; set; }
        public string image { get; set; }
        public List<string> episode { get; set; }
        public string url { get; set; }
        public DateTime created { get; set; }
    }
}