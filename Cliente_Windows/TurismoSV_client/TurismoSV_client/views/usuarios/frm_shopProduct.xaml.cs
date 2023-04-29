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
using TurismoSV_client.controllers.formaPagoController;
using TurismoSV_client.controllers.infoPaqueteController;
using TurismoSV_client.controllers.nuevoDetalleController;
using TurismoSV_client.controllers.NuevoEncabezadoController;
using TurismoSV_client.models.AppModel.facturaModel.detalleFacturaModel;
using TurismoSV_client.models.AppModel.facturaModel.facturaEncabezadoModel;
using TurismoSV_client.models.AppModel.facturaModel.facturaResponseModel;
using TurismoSV_client.models.AppModel.facturaModel.personasExtrasModel;
using TurismoSV_client.models.AppModel.fpagoModel;
using TurismoSV_client.models.AppModel.vpaquetesDisp;
using TurismoSV_client.UitlsClass.AppConfig;

namespace TurismoSV_client.views.usuarios
{
    /// <summary>
    /// Interaction logic for frm_shopProduct.xaml
    /// </summary>
    public partial class frm_shopProduct : Window
    {
        protected vpaquetesDisp detallePaquete;
        protected String id_pagoSelected = "538EA49919FBEFC0D7A3143E8805D378";
        List<personasExtrasModel> personasExtrasList;
        //funciones para llamada de api
        private async Task geetInfoPaqueteAsync()
        {
            bool resp = false;
            string id_selectedPackage = AppConfig.GetUserSetting("SelectPackage").ToString();
            infoPaqueteController ct = new infoPaqueteController();
            resp = await ct.fn_GetPaqueteInfo(id_selectedPackage);
            System.Diagnostics.Debug.WriteLine("Paquete obtenido >> " + id_selectedPackage);

            if (resp == true)
            {
                //var cadata = ct.GetDataAPI();
                txt_nombrePaquete.Content = "Elemento : "+ AppConfig.GetUserSetting("SelectPackage").ToString();
                System.Diagnostics.Debug.WriteLine("REspondio la api ");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("fallo en responder de la api ");
            }

        }
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


        private async Task fn_GenerateHeadingFact() {
            //definiendo modelos para la factura

            //modelo encabezado
            facturaEncabezadoModel hd = new facturaEncabezadoModel();
            hd.Idencabezado = "demo";
            hd.Idcuenta = "nuas";
            hd.Idformapago = id_pagoSelected.ToString().Trim();
            hd.Descuento = 0;
            hd.Monto = decimal.Parse("145");
            hd.State_emited = true;
            hd.Username = AppConfig.GetUserSetting("UserApp").ToString();

            



            NuevoEncabezadoController hcontrol = new NuevoEncabezadoController();

            if (await hcontrol.fn_InHeadFactura(hd) == true) {

                nuevoDetalleController dtt = new nuevoDetalleController();
                facturaResponseModel respuestaHeader;

                String tokenpaquete = hcontrol.Result.Token_paquete.ToString();
                System.Diagnostics.Debug.WriteLine(tokenpaquete);
                //modelo detalle
               
                detalleFacturaModel dta = new detalleFacturaModel();
                dta.Iddetalle = "simple";
                dta.Idencabezado = tokenpaquete.Trim();
                dta.Idpaqueted = AppConfig.GetUserSetting("SelectPackage").ToString();
                dta.Precio = decimal.Parse("145");
                dta.Descuento = 0;
                dta.Monto = decimal.Parse("145");
                dta.Cupos = 4;
                dta.Username = AppConfig.GetUserSetting("UserApp").ToString();

                bool respa = await dtt.fn_InDetalleFactura(dta);
                if (respa == true) {

                    if (!string.IsNullOrEmpty(dtt.Restult.Token_paquete)) {
                        MessageBox.Show("Compra realizada");
                    } else {
                        MessageBox.Show("Hubo un problema al registrar el detalle");
                    }
                } else {
                    MessageBox.Show("Hubo un problema al registrar la compra");
                };
               
            } else {
                MessageBox.Show("Datos Erroneos");
            }
            //fin metodos
        }
        public frm_shopProduct()
        {
            InitializeComponent();
            getFormasPagoAsync();
            geetInfoPaqueteAsync();
        }

        private void btn_closed_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void chk_addpersons_Checked(object sender, RoutedEventArgs e)
        {
            //accion para activar elementos de personas
            
        }

        private void cmbx_listaPago_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fpagoModel selectedValue = (fpagoModel)cmbx_listaPago.SelectedValue;
            id_pagoSelected = selectedValue.Idformapago;
            
        }

        private void btn_asignPackage_Click(object sender, RoutedEventArgs e)
        {
            //esta accion ya realiza la compra del paquete
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea comprar este artículo?", "Confirmar compra", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // La compra se confirmó. Realiza la lógica de compra aquí
                if (!string.IsNullOrEmpty(txt_codeSec.Text.ToString()) &&
                    !String.IsNullOrEmpty(txt_numcard.Text.ToString())
                    && !string.IsNullOrEmpty(dtpck_vencimientoCard.Text.ToString())
                    ) 
                {
                    fn_GenerateHeadingFact();
                    this.Close();

                }
                else {
                    MessageBox.Show("Rellena los datos de la targeta");
                }
            }
            else
            {
                // La compra se canceló. Realiza la lógica de cancelación aquí

            }
        }

        private void btn_addPersons_Click(object sender, RoutedEventArgs e)
        {
            //funcion para agregar personas 
            if (String.IsNullOrEmpty(txt_pname.Text))
            {
                System.Diagnostics.Debug.WriteLine(txt_plname.Text.ToString());
            }
        }
    }
}
