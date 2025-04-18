using ProyectoDI___Rick_and_Morty_API.Controllers;
using ProyectoDI___Rick_and_Morty_API.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoDI___Rick_and_Morty_API
{

    /// <summary>
    /// Clase de la MainWidow que gestiona la interacción con la interfaz gráfica
    /// Carga los personajes desde una API pública.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Propiedades de la clase
        
        private PersonajesController personajesController; // Controlador
        private ListaPersonajes? listaPersonajes; // Lista para almacenar los personajes

        /// <summary>
        /// Constructor de la ventana principal.
        /// Inicializa componentes e inicia la carga de personajes.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Inicializar Controlador
            personajesController = new PersonajesController();

            // Obtener los personajes
            GetAllPersonajes();
        }

        /// <summary>
        /// Método asíncrono que obtiene todos los personajes desde la API y los muestra en el ListBox de la interfaz.
        /// </summary>
        private async void GetAllPersonajes()
        {
            listaPersonajes = await personajesController.GetAllPersonajes();

            if (listaPersonajes != null)
            {
                // Limpiar la lista antes de cargar nuevos datos
                PersonajesListBox.Items.Clear();

                // Rellenar el ListBox con los personajes
                foreach (var personaje in listaPersonajes.results!)
                {
                    PersonajesListBox.Items.Add(personaje);
                }
            }
        }

        /// <summary>
        /// Método de evento que se dispara al seleccionar un personaje del ListBox.
        /// Muestra los detalles del personaje seleccionado en los controles de la interfaz.
        /// </summary>
        /// <param name="sender">Elemento que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void SelectPersonaje(object sender, SelectionChangedEventArgs e)
        {
            // Verificar que el elemento seleccionado del ListBox es de tipo Personaje
            if (PersonajesListBox.SelectedItem is Personaje personajeSeleccionado)
            {
                // Instanciar nueva imagen
                BitmapImage imagen = new BitmapImage();
                // Configurar imagen, obteniendo la de la URI del personaje seleccionado
                imagen.BeginInit();
                imagen.UriSource = new Uri(personajeSeleccionado.image, UriKind.Absolute);
                imagen.EndInit();

                // Actualizar imagen de la UI
                ImagenPersonaje.Source = imagen;

                // Actualizar campos de la UI
                CampoID.Text = personajeSeleccionado.id.ToString();
                CampoNombre.Text = personajeSeleccionado.name;
                CampoGenero.Text = personajeSeleccionado.gender;
                CampoEspecie.Text = personajeSeleccionado.species;
                // origin? -> Solo accede a .name si no es == null
                // ?? -> Si origin?.name == null, usa "Desconocido"
                CampoOrigen.Text = personajeSeleccionado.origin?.name ?? "Desconocido";
            }
        }
    }
}