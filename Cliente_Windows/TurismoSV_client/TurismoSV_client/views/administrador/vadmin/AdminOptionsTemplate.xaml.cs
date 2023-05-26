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
using TurismoSV_client.UitlsClass.AppConfig;
using TurismoSV_client.views.administrador.vadmin.controlesVentana;

namespace TurismoSV_client.views.administrador.vadmin
{
    /// <summary>
    /// Interaction logic for AdminOptionsTemplate.xaml
    /// </summary>
    public partial class AdminOptionsTemplate : Window
    {
        public AdminOptionsTemplate()
        {
            InitializeComponent();
            this.fn_loadComponents();
        }

        protected void fn_loadComponents() {
            //funcion que carga elementos esenciales como los shared preferences y verificacion de datos 

            //analizo si el usuario ha iniciado session de lo contrario se redirige al formulario de login
            if (string.IsNullOrEmpty(AppConfig.GetUserSetting("UserApp")))
            {
                //hacia el form login
                MainWindow fm_login = new MainWindow();
                fm_login.Show();
                this.Close();
            }
            else
            {
                //muestro los al usuario en el panel 
                txt_user.Content = AppConfig.GetUserSetting("UserApp").ToUpper();

            }
        }
        //acciones de botones del menu lateral
        private void btn_reHome_Click(object sender, RoutedEventArgs e)
        {
      
        }

        private void btn_reDep_Click(object sender, RoutedEventArgs e)
        {
            var Contenedor = new ContentControl();
            Contenedor.Content = new departamentosControl();
            stkp_Body.Children.Clear();
            stkp_Body.Children.Add(Contenedor);
        }

        private void btn_reMun_Click(object sender, RoutedEventArgs e)
        {

            //integra el control de ventana dentro de un control de la ventana master
            var Contenedor = new ContentControl();
            Contenedor.Content = new MunicipiosAdminControl();
            stkp_Body.Children.Clear();
            stkp_Body.Children.Add(Contenedor);

        }

        private void btn_reFpago_Click(object sender, RoutedEventArgs e)
        {
            var Contenedor = new ContentControl();
            Contenedor.Content = new fpagoControl();
            stkp_Body.Children.Clear();
            stkp_Body.Children.Add(Contenedor);
        }

        private void btn_reRoles_Click(object sender, RoutedEventArgs e)
        {
            var Contenedor = new ContentControl();
            Contenedor.Content = new rolesControl();
            stkp_Body.Children.Clear();
            stkp_Body.Children.Add(Contenedor);
        }

        private void btn_reUsers_Click(object sender, RoutedEventArgs e)
        {
            var Contenedor = new ContentControl();
            Contenedor.Content = new usuariosControl();
            stkp_Body.Children.Clear();
            stkp_Body.Children.Add(Contenedor);
        }

        private void btn_reCuentas_Click(object sender, RoutedEventArgs e)
        {
            var Contenedor = new ContentControl();
            Contenedor.Content = new cuentasControl();
            stkp_Body.Children.Clear();
            stkp_Body.Children.Add(Contenedor);
        }

        private void btn_reCategorias_Click(object sender, RoutedEventArgs e)
        {
            //integra el control de ventana dentro de un control de la ventana master
            var Contenedor = new ContentControl();
            Contenedor.Content = new categoriaControl();
            stkp_Body.Children.Clear();
            stkp_Body.Children.Add(Contenedor);
        }

        private void btn_reAdicionales_Click(object sender, RoutedEventArgs e)
        {
            var Contenedor = new ContentControl();
            Contenedor.Content = new adicionalesControl();
            stkp_Body.Children.Clear();
            stkp_Body.Children.Add(Contenedor);
        }

        private void btn_rePkgCalif_Click(object sender, RoutedEventArgs e)
        {
            var Contenedor = new ContentControl();
            Contenedor.Content = new pkgCalificacionControl();
            stkp_Body.Children.Clear();
            stkp_Body.Children.Add(Contenedor);
        }

        private void btn_reInvExtras_Click(object sender, RoutedEventArgs e)
        {
            var Contenedor = new ContentControl();
            Contenedor.Content = new personasExtrasControl();
            stkp_Body.Children.Clear();
            stkp_Body.Children.Add(Contenedor);
        }

        private void btn_reAdicionalDisp_Click(object sender, RoutedEventArgs e)
        {
            var Contenedor = new ContentControl();
            Contenedor.Content = new adicionalesDisponiblesControl();
            stkp_Body.Children.Clear();
            stkp_Body.Children.Add(Contenedor);
        }

        private void btn_rePaquetes_Click(object sender, RoutedEventArgs e)
        {
            var Contenedor = new ContentControl();
            Contenedor.Content = new paquetesControl();
            stkp_Body.Children.Clear();
            stkp_Body.Children.Add(Contenedor);
        }

        private void btn_reContactos_Click(object sender, RoutedEventArgs e)
        {
            var Contenedor = new ContentControl();
            Contenedor.Content = new telefonosUsuarioControl();
            stkp_Body.Children.Clear();
            stkp_Body.Children.Add(Contenedor);
        }

        private void btn_rePaquetesDisp_Click(object sender, RoutedEventArgs e)
        {
            var Contenedor = new ContentControl();
            Contenedor.Content = new pkgDisponiblesControl();
            stkp_Body.Children.Clear();
            stkp_Body.Children.Add(Contenedor);
        }


        // fin acciones de botones del menu lateral

        //acciones de barra superior

        private void popupButton_Click(object sender, RoutedEventArgs e)
        {

            //MenuToggleButton.IsChecked = true;


        }

        private void btn_account_Click(object sender, RoutedEventArgs e)
        {
            //acciones para configuracion de cuenta
        }

        private void btn_closeSesion_Click(object sender, RoutedEventArgs e)
        {
            //acciones para cerrar sesion
            MessageBoxResult result = MessageBox.Show("¿Desea cerrar la sesion actual?", "Cerrar sesion", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
                AppConfig.SetUserSetting("TokenApp", "");
                AppConfig.SetUserSetting("UserApp", "");
                AppConfig.SetUserSetting("RoleApp", "");
                AppConfig.SetUserSetting("MailApp", "");

                MainWindow frm_login = new MainWindow();
                frm_login.Show();

            }
        }

    }//fin class
}//fin namespaces
