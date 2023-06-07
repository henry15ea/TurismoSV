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
using TurismoSV_client.controllers.general;
using TurismoSV_client.controllers.users;
using TurismoSV_client.models.AppModel.users;
using TurismoSV_client.UitlsClass.AppConfig;

namespace TurismoSV_client.views.usuarios
{
    /// <summary>
    /// Interaction logic for frm_historialCompras.xaml
    /// </summary>
    public partial class frm_historialCompras : Window
    {
        private string textvalue;
        protected String nameButton= "Generar Factura";
        //funciones que obtienen valores o datos de la api 
        private async Task getDatagHistorialCompraAsync()
        {
            bool resp = false;

            historialComprasController ct = new historialComprasController();
            String username = AppConfig.GetUserSetting("UserApp");
            resp = await ct.fn_GetFacturaList(username);

            if (resp == true)
            {
                //var cadata = ct.GetDataAPI();
                //listadoFacturas.Items.Clear();
                listadoFacturas.ItemsSource = ct.DataResponse;
                

                System.Diagnostics.Debug.WriteLine("Respondio la api Comprados");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("fallo en responder de la api ");
            }

        }



        private async Task getDatagReservasCompraAsync()
        {
            bool resp = false;

            historialReservasController ct = new historialReservasController();
            String username = AppConfig.GetUserSetting("UserApp");
            resp = await ct.fn_GetReservasList(username);

            if (resp == true)
            {
                //var cadata = ct.GetDataAPI();
                //listadoFacturas.Items.Clear();
                listadoReservas.ItemsSource = ct.DataResponse;

                System.Diagnostics.Debug.WriteLine("Respondio la api Reservados");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("fallo en responder de la api ");
            }

        }
        //fin funciones que obtienen valores o datos de la api 

        public void fn_updateListHistorial() 
        {
            //listado de facturas de compras realizadas
            getDatagHistorialCompraAsync();
            //listado de facturas pendientes
            getDatagReservasCompraAsync();

        }

        public frm_historialCompras()
        {
            InitializeComponent();
            try
            {
                btn_username.Content = AppConfig.GetUserSetting("UserApp");
                btn_profileMenu.Content = AppConfig.GetUserSetting("UserApp");

                //llamamos a los controladores de la api para obtener el listado de cada uno
                //listado de facturas de compras realizadas
                getDatagHistorialCompraAsync();
                //listado de facturas pendientes
                getDatagReservasCompraAsync();
               
                
            }

            catch (Exception)
            {
                btn_username.Content = AppConfig.GetUserSetting("NONE");
            }

        }


        private void popupButton_Click(object sender, RoutedEventArgs e)
        {

            //MenuToggleButton.IsChecked = true;


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //acciones para el perfil del usuario
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

        private void btn_inicio_click(object sender, RoutedEventArgs e)
        {
            //btn que lleva al usuario a la pantalla principal frm_initialScreen
            frm_initialScreen inicio = new frm_initialScreen();
            inicio.ShowDialog();
            this.Close();
        }

        private void btn_comprar_Click(object sender, RoutedEventArgs e)
        {
            //btn que lleva al formulario de listas de paquetes para que el usuario
            //elija y compre el paquete
        }

        private void btn_cuenta_Click(object sender, RoutedEventArgs e)
        {
            //btn que lleva al usario a administrar datos de su cuenta de usuario
        }
        private void btn_historial_Click(object sender, RoutedEventArgs e)
        {
            //btn que lleva al usuario al historial de compras realizadas
        }

        //acciones de contenido body
        private void btn_selectedItem_Click(object sender, RoutedEventArgs e)
        {
   
                //acciones de boton de lista seleccionado
                Button button = sender as Button;
                textvalue = button.Tag as string;
                // MessageBox.Show(textvalue);

                getFacturaController fc = new getFacturaController();
                cInFacturaModel dtm = new cInFacturaModel();
                dtm.Id_factura = textvalue.Trim();
                dtm.Username = AppConfig.GetUserSetting("UserApp");
                fc.fn_GetFacturaReport(dtm);
        }

        private void btn_selectedItemReservas_Click(object sender, RoutedEventArgs e)
        {
            String id_factura = "";
            //acciones de boton de lista seleccionado
            Button button = sender as Button;
            textvalue = button.Tag as string;

            id_factura = textvalue.Trim();
            //asignando elementos
            AppConfig.SetUserSetting("ID_facturaSelect", id_factura);

            frm_PopUpPay mpay = new frm_PopUpPay();
            mpay.ShowDialog();



        }

        private void btn_refreshData_Click(object sender, RoutedEventArgs e)
        {
            this.fn_updateListHistorial();
        }
    }//end class
}//end namespaces
