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
    /// Interaction logic for wVentaByName_Apellido.xaml
    /// </summary>
    public partial class wVentaByName_Apellido : Window
    {
        public wVentaByName_Apellido()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_generaReport_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                ventasByNameApellidoModel model = new ventasByNameApellidoModel();

                r_ventasByNameApellidoController reporte = new r_ventasByNameApellidoController();

                if (!string.IsNullOrEmpty(txt_nombreCliente.Text.Trim()) && !string.IsNullOrEmpty(txt_apellidoCliente.Text.Trim()))
                {
                    model.username = AppConfig.GetUserSetting("UserApp");
                    model.nombre = txt_nombreCliente.Text.Trim();
                    model.apellido = txt_apellidoCliente.Text.Trim();
                }
                else if (String.IsNullOrEmpty(txt_nombreCliente.Text.Trim()) && String.IsNullOrEmpty(txt_apellidoCliente.Text.Trim()))
                {

                    MessageBox.Show("Ingres nombre y apellido de cliente para obtener reporte");
                }

                reporte.fn_GetVentasByNameApellidoReport(model);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo al tratar de construir el reporte");
            }
            
        }
    }
}
