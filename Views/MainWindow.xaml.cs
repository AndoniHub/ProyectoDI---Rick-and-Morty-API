using ProyectoDI___Rick_and_Morty_API.Controllers;
using ProyectoDI___Rick_and_Morty_API.Models;
using ProyectoDI___Rick_and_Morty_API.ViewModels;
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
    /// Se encarga únicamente de inicializar los componentes visuales y 
    /// establecer el contexto de datos (DataContext) con el ViewModel correspondiente.
    /// 
    /// La lógica de presentación y la comunicación con el modelo se delega al MainViewModel.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(); // Vinculación con el ViewModel
        }
    }
}