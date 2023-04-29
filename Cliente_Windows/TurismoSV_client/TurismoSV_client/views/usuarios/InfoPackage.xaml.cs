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
using TurismoSV_client.controllers.adicionalesController;
using TurismoSV_client.controllers.infoPaqueteController;
using TurismoSV_client.UitlsClass.AppConfig;

namespace TurismoSV_client.views.usuarios
{
    /// <summary>
    /// Interaction logic for InfoPackage.xaml
    /// </summary>
    public partial class InfoPackage : Window
    {
        public List<String> ListaDeObjetos { get; set; }
        private string textvalue;

        private async Task geetInfoPaqueteAsync()
        {
            bool resp = false;
            string id_selectedPackage = AppConfig.GetUserSetting("SelectPackage").ToString();
            infoPaqueteController ct = new infoPaqueteController();
            resp = await ct.fn_GetPaqueteInfo(id_selectedPackage);
            System.Diagnostics.Debug.WriteLine("Paquete obtenido >> "+id_selectedPackage);

            if (resp == true)
            {
                //var cadata = ct.GetDataAPI();
                grd_infopaquete.DataContext = ct.DataResponse;
                grd_dataResumeInfo.DataContext = ct.DataResponse;   

                System.Diagnostics.Debug.WriteLine("REspondio la api ");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("fallo en responder de la api ");
            }

        }

        private async Task getAdicionalByIdAsync()
        {
            bool resp = false;
            string id_selectedPackage = AppConfig.GetUserSetting("SelectPackage").ToString();
            adicionalesController ad = new adicionalesController();
            resp = await ad.fn_GetAdicionalesByIdpkgList(id_selectedPackage);

            if (resp == true)
            {
                //var cadata = ct.GetDataAPI();
                lst_adicionalesList.ItemsSource = ad.DataResponse;

                System.Diagnostics.Debug.WriteLine("REspondio la api con adicionales");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("fallo en responder de la api ");
            }

        }
        public InfoPackage()
        {
            InitializeComponent();
            geetInfoPaqueteAsync();
            getAdicionalByIdAsync();
        }

        //acciones de los botones del panel izquierdo

        private void btn_closeSesion_Click(object sender, RoutedEventArgs e)
        {
            //acciones para cerrar sesion
            this.Close();
        }

        private void btn_inicio_click(object sender, RoutedEventArgs e)
        {
            //btn que lleva al usuario a la pantalla principal frm_initialScreen
            frm_initialScreen hm = new frm_initialScreen();
            hm.Show();
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

        private void popupButton_Click(object sender, RoutedEventArgs e)
        {

            //MenuToggleButton.IsChecked = true;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //acciones para el perfil del usuario
        }

        private void btn_selectedItem_Click(object sender, RoutedEventArgs e)
        {
            //acciones de boton de lista seleccionado
            Button button = sender as Button;
            textvalue = button.Tag as string;
            MessageBox.Show(textvalue);
        }

        private void btn_detallePaquete_Click(object sender, RoutedEventArgs e)
        {
            //acciones de boton de lista seleccionado
            Button button = sender as Button;
            textvalue = button.Tag as string;
            AppConfig.SetUserSetting("SelectPackage", textvalue);
            //MessageBox.Show(textvalue);
        }

        private void btn_account_Click(object sender, RoutedEventArgs e)
        {
            //acciones para configuracion de cuenta
        }

        private void btn_asignarPaquete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            String textvalue = btn.Tag as String;
            //MessageBox.Show(textvalue);
            frm_shopProduct sh = new frm_shopProduct();
            
            sh.ShowDialog();

        }
        //fin clase
    }
}
