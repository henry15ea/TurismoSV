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
using TurismoSV_client.controllers.categoriasController;
using TurismoSV_client.controllers.getPaquetesController;
using TurismoSV_client.UitlsClass.AppConfig;

namespace TurismoSV_client.views.template
{
    /// <summary>
    /// Interaction logic for templateview.xaml
    /// </summary>
    public partial class templateview : Window
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
        public templateview()
        {
            InitializeComponent();
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
        //fin clase
    }
}
