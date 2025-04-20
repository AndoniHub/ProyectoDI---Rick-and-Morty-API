using Newtonsoft.Json;
using ProyectoDI___Rick_and_Morty_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDI___Rick_and_Morty_API.Controllers
{
    /// <summary>
    /// Servicio encargado de gestionar las peticiones HTTP a la API pública de Rick and Morty.
    /// </summary>
    public class APIService
    {
        // Propiedades del servicio
        private HttpClient client; // Instanciar cliente HTTP

        /// <summary>
        /// Constructor que inicializa el cliente HTTP.
        /// </summary>
        public APIService()
        {
            client = new HttpClient();
        }

        /// <summary>
        /// Método para obtener un personaje concreto de la API a partir de su ID.
        /// </summary>
        /// <param name="id">ID del personaje que se desea obtener.</param>
        /// <returns>Un objeto Personaje con los datos del personaje o null si ocurre un error.</returns>
        public async Task<Personaje> GetPersonajeById(int id)
        {
            try
            {
                Personaje personaje = new Personaje();
                HttpResponseMessage respuesta = await client.GetAsync("https://rickandmortyapi.com/api/character/" + id);

                respuesta.EnsureSuccessStatusCode();

                string respuestaStr = await respuesta.Content.ReadAsStringAsync();

                personaje = JsonConvert.DeserializeObject<Personaje>(respuestaStr);

                return personaje;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Método para obtener todos los personajes disponibles en la primera página de la API.
        /// </summary>
        /// <returns>Un objeto ListaPersonajes que contiene la lista de personajes y metadatos, o null si ocurre un error.</returns>
        public async Task<ListaPersonajes> GetAllPersonajes()
        {
            try
            {
                ListaPersonajes personajes = new ListaPersonajes();
                HttpResponseMessage respuesta = await client.GetAsync("https://rickandmortyapi.com/api/character");

                respuesta.EnsureSuccessStatusCode();

                string respuestaStr = await respuesta.Content.ReadAsStringAsync();

                // Serializar respuesta en base al modelo definido
                personajes = JsonConvert.DeserializeObject<ListaPersonajes>(respuestaStr);

                return personajes;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
