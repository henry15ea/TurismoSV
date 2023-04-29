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
using TurismoSV_client.views.administrador.vadmin;

namespace TurismoSV_client.views.administrador
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CategoriasAdmin categoriasAdmin = new CategoriasAdmin();
            categoriasAdmin.Show();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            DepartamentosAdmin departamentosAdmin = new DepartamentosAdmin();
            departamentosAdmin.Show();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            MunicipiosAdmin municipiosAdmin = new MunicipiosAdmin();
            municipiosAdmin.Show();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            RolUsuarioAdmin rolUsuarioAdmin = new RolUsuarioAdmin();    
            rolUsuarioAdmin.Show();
        }

        private void Button_Click10(object sender, RoutedEventArgs e)
        {
            PaquetesAdmin paquetesAdmin = new PaquetesAdmin();
            paquetesAdmin.Show();
        }

        private void Button_Click11(object sender, RoutedEventArgs e)
        {
            UsuariosAdmin usuariosAdmin = new UsuariosAdmin();
            usuariosAdmin.Show();
        }

        private void Button_Click12(object sender, RoutedEventArgs e)
        {
            CuentaAdmin cuentaAdmin = new CuentaAdmin();
            cuentaAdmin.Show();
        }

        private void Button_Click13(object sender, RoutedEventArgs e)
        {
            PaquetesDisponiblesAdmin paquetesDisp = new PaquetesDisponiblesAdmin();
            paquetesDisp.Show();
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            AdicionalesAdmin adicionalesAdmin = new AdicionalesAdmin();
            adicionalesAdmin.Show();
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            FormaPagoAdmin formaPagoAdmin = new FormaPagoAdmin();
            formaPagoAdmin.Show();
        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            TelefonosAdmin telefonosAdmin = new TelefonosAdmin();
            telefonosAdmin.Show();

        }

        private void Button_Click7(object sender, RoutedEventArgs e)
        {
            PaqueteCalificacionAdmin paqueteCalificacionAdmin = new PaqueteCalificacionAdmin();
            paqueteCalificacionAdmin.Show();
        }

        private void Button_Click8(object sender, RoutedEventArgs e)
        {
            PersonasExtraAdmin personasExtraAdmin = new PersonasExtraAdmin();
            personasExtraAdmin.Show();
        }

        private void Button_Click9(object sender, RoutedEventArgs e)
        {
            AdicionalesDisponiblesAdmin adicionalesDisponiblesAdmin = new AdicionalesDisponiblesAdmin();
            adicionalesDisponiblesAdmin.Show();
        }
    }
}
