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
    /// Interaction logic for wVentasByFechas.xaml
    /// </summary>
    public partial class wVentasByFechas : Window
    {
        public wVentasByFechas()
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
            ventasByFechasModel model = new ventasByFechasModel();
            try
            {
                if (inicio.SelectedDate != null || fin.SelectedDate != null)
                {
                    model.username = AppConfig.GetUserSetting("UserApp");
                    model.fechaInicio = inicio.Text.Trim();
                    model.fechaFinal = fin.Text.Trim();

                    workPanel.IsEnabled = false;
                    r_ventasByFechaController reporte = new r_ventasByFechaController();
                    reporte.fn_GetVentasByFechaReport(model);
                    workPanel.IsEnabled = true;
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Indicar fechas de inicio y fin para reporte");

                }

                
            }
            catch
            {
                MessageBox.Show("hubo un problema con obtener el reporte");
            }
        }
    }
}
