using ProyectoDI___Rick_and_Morty_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoDI___Rick_and_Morty_API.Views
{
    /// <summary>
    /// Lógica de interacción para DetallePersonaje.xaml
    /// </summary>
    public partial class DetallePersonaje : Window
    {
        public DetallePersonaje(Personaje personajeSeleccionado)
        {
            InitializeComponent();
            DataContext = personajeSeleccionado;
        }
    }
}
