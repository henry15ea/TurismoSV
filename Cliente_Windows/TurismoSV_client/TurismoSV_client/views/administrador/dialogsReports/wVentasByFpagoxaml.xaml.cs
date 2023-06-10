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
using TurismoSV_client.controllers.formaPagoController;
using TurismoSV_client.models.AppModel.fpagoModel;
using TurismoSV_client.models.reportModels;
using TurismoSV_client.UitlsClass.AppConfig;

namespace TurismoSV_client.views.administrador.dialogsReports
{
    /// <summary>
    /// Interaction logic for wVentasByFpagoxaml.xaml
    /// </summary>
    public partial class wVentasByFpagoxaml : Window
    {
        protected String id_pagoSelected = "";
        private async Task getFormasPagoAsync()
        {
            bool resp = false;

            formaPagoController ct = new formaPagoController();
            resp = await ct.fn_GetFormaPagoList();

            if (resp == true)
            {
                //var cadata = ct.GetDataAPI();
                cmbx_listaPago.DataContext = ct.DataResponse;

                System.Diagnostics.Debug.WriteLine("Extrayendo formas de pago ");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No se pudo extraer formas de pago  ");
            }

        }
        public wVentasByFpagoxaml()
        {
            InitializeComponent();
            getFormasPagoAsync();

            cmbx_listaPago.SelectedIndex = 0;
        }

        private void cmbx_listaPago_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fpagoModel selectedValue = (fpagoModel)cmbx_listaPago.SelectedValue;

            id_pagoSelected = selectedValue.Idformapago;

            if (selectedValue.Idformapago != null)
            {
                btn_generaReport.IsEnabled = true;    
            }
            else
            {
                btn_generaReport.IsEnabled = false;
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_generaReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbx_listaPago.SelectedIndex != 0)
                {
                    //llama al control encargado para generar el reporte
                    ventasByFpagoModel model = new ventasByFpagoModel();
                    model.username = AppConfig.GetUserSetting("UserApp");
                    model.filtro = cmbx_listaPago.Text.Trim();
                   
                    r_ventasByFpagoController reporte = new r_ventasByFpagoController();
                    reporte.fn_GetVentasByFpagoReport(model);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Seleccionar forma de pago para reporte");

                }
            }
            catch
            {
                MessageBox.Show("hubo un problema con obtener el reporte");
            }

        }
        
    }
}
