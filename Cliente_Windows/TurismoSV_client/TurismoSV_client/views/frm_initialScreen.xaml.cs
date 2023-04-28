using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TurismoSV_client.controllers.categoriasController;
using TurismoSV_client.controllers.getPaquetesController;
using TurismoSV_client.models.AppModel.categoriasModel;
using TurismoSV_client.UitlsClass.AppConfig;

namespace TurismoSV_client.views
{
    /// <summary>
    /// Interaction logic for frm_initialScreen.xaml
    /// </summary>
    public partial class frm_initialScreen : Window
    {
        public List<String> ListaDeObjetos { get; set; }
        private string textvalue;

        //crea una imagen por defecto para las cards
        public string GetImageOrDefaultUrl(string apiUrl)
        {
            if (String.IsNullOrEmpty(apiUrl))
            {
                return "";
            }
            else
            {
                return apiUrl;
            }
        }

        private void popupButton_Click(object sender, RoutedEventArgs e)
        {
           
            //MenuToggleButton.IsChecked = true;


        }

        private async Task getDataCategoriesAsync() {
            bool resp = false;
         
                categoriasController ct = new categoriasController();
                resp = await ct.fn_GetCategoryList();

            if (resp == true)
            {
                //var cadata = ct.GetDataAPI();
                myListBox.ItemsSource = ct.DataResponse;

                System.Diagnostics.Debug.WriteLine("REspondio la api ");
            }
            else {
                System.Diagnostics.Debug.WriteLine("fallo en responder de la api ");
            }
           
        }

        private async Task getDataPaquetesAsync()
        {
            bool resp = false;

            getPaquetesController ct = new getPaquetesController();
            resp = await ct.fn_GetPaquetesDispList();

            if (resp == true)
            {
                //var cadata = ct.GetDataAPI();
                LastPackages.ItemsSource = ct.DataResponse;

                System.Diagnostics.Debug.WriteLine("REspondio la api ");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("fallo en responder de la api ");
            }

        }

        public frm_initialScreen()
        {
            InitializeComponent();

            try
            {
                btn_username.Content = AppConfig.GetUserSetting("UserApp");
                btn_profileMenu.Content = AppConfig.GetUserSetting("UserApp");
                //llenar el listbox
                getDataCategoriesAsync();
                getDataPaquetesAsync();



            }

            catch (Exception)
            {
                btn_username.Content = AppConfig.GetUserSetting("NONE");
            }
           
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

        private void btn_closeSesion_Click(object sender, RoutedEventArgs e)
        {
            //acciones para cerrar sesion
            this.Close();
        }
    }
}
