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

namespace TurismoSV_client.views
{
    /// <summary>
    /// Interaction logic for frm_initialScreen.xaml
    /// </summary>
    public partial class frm_initialScreen : Window
    {
        public List<String> ListaDeObjetos { get; set; }
        public frm_initialScreen()
        {
            InitializeComponent();
           
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            btn_username.Content = AppConfig.GetUserSetting("UserApp");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
