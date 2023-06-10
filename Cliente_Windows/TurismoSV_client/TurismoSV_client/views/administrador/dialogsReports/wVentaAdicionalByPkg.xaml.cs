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
using TurismoSV_client.controllers.getPaquetesController;
using TurismoSV_client.models.AppModel.fpagoModel;
using TurismoSV_client.models.AppModel.vpaquetesDisp;
using TurismoSV_client.models.reportModels;
using TurismoSV_client.UitlsClass.AppConfig;

namespace TurismoSV_client.views.administrador.dialogsReports
{
    /// <summary>
    /// Interaction logic for wVentaAdicionalByPkg.xaml
    /// </summary>
    public partial class wVentaAdicionalByPkg : Window
    {
        protected String nombre = "";
        private async Task getPkgAsync()
        {
            bool resp = false;

            getPaquetesController ct = new getPaquetesController();
            resp = await ct.fn_GetPaquetesDispList();

            if (resp == true)
            {
                //var cadata = ct.GetDataAPI();
                cmbx_listaPkg.DataContext = ct.DataResponse;

                System.Diagnostics.Debug.WriteLine("Extrayendo paquetes");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No se pudo extraer paquetes");
            }

        }
        public wVentaAdicionalByPkg()
        {
            InitializeComponent();
            getPkgAsync();

            cmbx_listaPkg.SelectedIndex = 0;
        }

        private void cmbx_listaPkg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vpaquetesDisp selectedValue = (vpaquetesDisp)cmbx_listaPkg.SelectedValue;

            nombre = selectedValue.Nombre;

            if (selectedValue.Nombre.ToString() != null)
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
                if (cmbx_listaPkg.SelectedIndex != 0)
                {
                    //llama al control encargado para generar el reporte
                    ventasAdicionalesByPkgModel model = new ventasAdicionalesByPkgModel();
                    model.username = AppConfig.GetUserSetting("UserApp");
                    model.filtro = cmbx_listaPkg.Text.Trim();


                    r_ventasAdicionalesByPkgController reporte = new r_ventasAdicionalesByPkgController();
                    reporte.fn_GetVentasAdicionalesByPkgReport(model);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Seleccionar paquete para reporte");

                }


            }
            catch
            {
                MessageBox.Show("hubo un problema con obtener el reporte");
            }



        }

    }
}
