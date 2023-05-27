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
using TurismoSV_client.controllers.adm;
using TurismoSV_client.models.reportModels;
using TurismoSV_client.UitlsClass.AppConfig;

namespace TurismoSV_client.views.administrador.dialogsReports
{
    /// <summary>
    /// Interaction logic for wradicionalesbynombre.xaml
    /// </summary>
    public partial class wradicionalesbynombre : Window
    {
        public wradicionalesbynombre()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_generaReport_Click(object sender, RoutedEventArgs e)
        {
            //llama al control encargado para generar el reporte
            adicionalesByNombreModel model = new adicionalesByNombreModel();
            try {
                if (String.IsNullOrEmpty(txt_nombreFiltro.Text)) { 
                    model.Username = AppConfig.GetUserSetting("UserApp");
                    model.AdicionalNombre = txt_nombreFiltro.Text.Trim();
                    
                } else {
                    model.Username = AppConfig.GetUserSetting("UserApp");
                    model.AdicionalNombre = "A";
                }

                workPanel.IsEnabled = false;
                r_adicionalesByNombreController reporte = new r_adicionalesByNombreController();
                reporte.fn_GetAdicionalesByNombreReport(model);
                workPanel.IsEnabled = true;
                this.Close();
            }
            catch {
                MessageBox.Show("hubo un problema con obtener el reporte");
            }
        }
    }//end class
}//end namespaces
