using ProyectoDI___Rick_and_Morty_API.Controllers;
using ProyectoDI___Rick_and_Morty_API.Models;
using ProyectoDI___Rick_and_Morty_API.ViewModels;
using ProyectoDI___Rick_and_Morty_API.Views;
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
    /// Clase de la MainWidow.
    /// Se encarga de inicializar los componentes visuales y 
    /// establecer el contexto de datos (DataContext) con el ViewModel correspondiente.
    /// 
    /// Toda la lógica de presentación y la comunicación con los datos se delega al MainViewModel.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Establecer el ViewModel como el contexto de datos de la ventana
            DataContext = new MainViewModel();
        }

        /// <summary>
        /// Evento que se ejecuta cuando se selecciona un personaje en la lista.
        /// Abre una nueva ventana con los detalles del personaje seleccionado.
        /// </summary>
        /// <param name="sender">Origen del evento (ListBox).</param>
        /// <param name="e">Información sobre el cambio de selección.</param>
        private void ListaPersonajes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is Personaje personaje)
            {
                var ventanaDetalle = new DetallePersonaje(personaje);
                // Mostrar la ventana de detalle del personaje
                // .Show() -> No bloquea la ventana principal
                // .ShowDialog() -> Bloquea la ventana principal hasta que se cierre la ventana de detalle
                ventanaDetalle.ShowDialog();
            }

            // Deselecciona el personaje para permitir volver a seleccionarlo más adelante
            ((ListBox)sender).SelectedItem = null;
        }
    }
}