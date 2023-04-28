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

namespace TurismoSV_client.views.usuarios
{
    /// <summary>
    /// Interaction logic for InfoPackage.xaml
    /// </summary>
    public partial class InfoPackage : Window
    {
        public List<String> ListaDeObjetos { get; set; }
        private string textvalue;

        public InfoPackage()
        {
            InitializeComponent();
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

        private void btn_closeSesion_Click(object sender, RoutedEventArgs e)
        {
            //acciones para cerrar sesion
            this.Close();
        }
        //fin clase
    }
}
