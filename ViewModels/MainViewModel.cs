using ProyectoDI___Rick_and_Morty_API.Controllers;
using ProyectoDI___Rick_and_Morty_API.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ProyectoDI___Rick_and_Morty_API.ViewModels
{
    /// <summary>
    /// ViewModel principal que gestiona los datos y la lógica para la vista MainWindow.
    /// Implementa INotifyPropertyChanged para notificar a la vista sobre cambios en las propiedades.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        // APIService: Servicio que gestiona las peticiones a la API
        private readonly APIService apiService;

        // Campos para las propiedades internas de la clase
        private Personaje? personajeSeleccionado;
        private BitmapImage? imagenSeleccionada;

        // Colección observable de personajes que se enlaza al ListBox en la vista
        // Se utiliza ObservableCollection en lugar de List para que la vista se actualice automáticamente
        public ObservableCollection<Personaje> Personajes { get; set; } = new();

        // Propiedad pública PersonajeSeleccionado que se vincula a la vista
        // Al modificar esta propiedad, se actualizan los detalles y la imagen del personaje
        public Personaje? PersonajeSeleccionado
        {
            get => personajeSeleccionado;
            set
            {
                personajeSeleccionado = value;
                OnPropertyChanged();
                ActualizarImagen();
            }
        }

        // Propiedad pública ImagenSeleccionada que se vincula a la vista
        public BitmapImage? ImagenSeleccionada
        {
            get => imagenSeleccionada;
            set
            {
                imagenSeleccionada = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Constructor del ViewModel.
        /// Inicializa el APIService, la imagen de inicio y comienza la carga de los personajes.
        /// </summary>
        public MainViewModel()
        {
            apiService = new APIService();

            // Establecer imagen de demo al inicio
            var imagenInicio = new BitmapImage();
            imagenInicio.BeginInit();
            imagenInicio.UriSource = new Uri("pack://application:,,,/Assets/Images/demo.png", UriKind.Absolute);
            imagenInicio.EndInit();
            ImagenSeleccionada = imagenInicio;

            // Cargar los personajes de forma asíncrona al inicio
            // Se utiliza el guion bajo para indicar que es un método asíncrono -> Se descarta el resultado del Task
            _ = CargarPersonajes();
        }

        /// <summary>
        /// Método asíncrono que obtiene la lista de personajes desde la API y la añade a la colección observable.
        /// </summary>
        private async Task CargarPersonajes()
        {
            var lista = await apiService.GetAllPersonajes();
            if (lista?.results != null)
            {
                foreach (var personaje in lista.results)
                {
                    Personajes.Add(personaje);
                }
            }
        }

        /// <summary>
        /// Actualiza la imagen seleccionada con la del personaje actualmente seleccionado.
        /// </summary>
        private void ActualizarImagen()
        {
            if (PersonajeSeleccionado != null)
            {
                var imagen = new BitmapImage();
                imagen.BeginInit();
                imagen.UriSource = new Uri(PersonajeSeleccionado.image, UriKind.Absolute);
                imagen.EndInit();
                ImagenSeleccionada = imagen;
            }
        }

        // Implementación de INotifyPropertyChanged para notificar a la vista de cambios en propiedades
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Método que lanza el evento PropertyChanged. Utiliza [CallerMemberName] para no tener que especificar el nombre de la propiedad manualmente.
        /// </summary>
        /// <param name="nombre">Nombre de la propiedad que cambió (se establece automáticamente)</param>
        private void OnPropertyChanged([CallerMemberName] string? nombre = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
    }
}