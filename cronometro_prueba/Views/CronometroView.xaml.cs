using cronometro_prueba.Services;
using cronometro_prueba.Interfaces;
using cronometro_prueba.ViewModels;
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

namespace cronometro_prueba.Views
{
    /// <summary>
    /// Lógica de interacción para CronometroView.xaml
    /// </summary>
    public partial class CronometroView : Window
    {
        public CronometroView()
        {
            InitializeComponent();
            //Para la inyección de dependencias manual, instanciamos un CronometroService (Servicio que implementa la Interface)
            var cronometro = new CronometroService();
            //Le decimos al DataContext que el ViewModel CronometroViewModel tiene como parámetro nuestro servicio CronometroService
            DataContext = new CronometroViewModel(cronometro);
        }

    }
}
