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
using TurismoSV_client.controllers.payments;
using TurismoSV_client.controllers.users;
using TurismoSV_client.models.ApiModels;
using TurismoSV_client.models.AppModel.fpagoModel;
using TurismoSV_client.models.AppModel.payment;
using TurismoSV_client.models.AppModel.users;
using TurismoSV_client.UitlsClass.AppConfig;

namespace TurismoSV_client.views.usuarios
{
    /// <summary>
    /// Interaction logic for frm_PopUpPay.xaml
    /// </summary>
    public partial class frm_PopUpPay : Window
    {
        protected String id_pagoSelected = "538EA49919FBEFC0D7A3143E8805D378";

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
        private async Task fn_CompletedReserveAsync()
        {
            bool resp = false;
            cUpFacturaStatus model = new cUpFacturaStatus();
            model.Username = AppConfig.GetUserSetting("UserApp");
            model.Id_encabezado = AppConfig.GetUserSetting("ID_facturaSelect");
            model.Id_fpago = id_pagoSelected.Trim();

          
            
            CompraPaqueteReservaController pck = new CompraPaqueteReservaController();

            resp = await pck.fn_CompraPaqueteReserva(model);

            if (resp == true) {

                facturaUpdateStatusResponse modelresp = new facturaUpdateStatusResponse();

                modelresp = pck.GetDataAPI();

                if (modelresp != null || modelresp.token_paquete != "" ) {
                    MessageBox.Show("La compra del paquete se realizo con exito !");
                } else {
                    MessageBox.Show("Hubo un problema al tratar de realizar la compra del paquete");
                }

            } else {
                MessageBox.Show("El servicio no puede responder a la solicitud");
            }
          
        }

        private async Task fn_ValidarTargetaAsync(paymentModel dataCard)
        {
            bool resp = false;

            //llamamos al controlador de invitados 
            paymentsController cpayment = new paymentsController();
            resp = await cpayment.fn_GetCardValidation(dataCard);

            if (resp == true)
            {
                paymentResponseModel datapayment = new paymentResponseModel();
                datapayment = cpayment.GetDataAPI();

                if (datapayment != null)
                {
                    if (datapayment.Validate == 1 || datapayment.Validate > 0)
                    {
                        this.fn_CompletedReserveAsync();
                       
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(datapayment.InfoMsg);
                    }
                }
                else
                {
                    MessageBox.Show("El servicio no puede responder a la solicitud");
                }

            }
            else
            {
                MessageBox.Show("Servicio de pago no disponible");
            }
        }

        private void txtNumero_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Verificar si el texto introducido es un número
            bool esNumero = int.TryParse(e.Text, out int resultado);

            // Permitir números y espacios en blanco
            e.Handled = !esNumero && e.Text != " ";
        }

        public frm_PopUpPay()
        {
            InitializeComponent();
            getFormasPagoAsync();
            cmbx_listaPago.SelectedIndex = 0;
            
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

                   
                    if (id_pagoSelected == null || id_pagoSelected.Contains("76650EA21121DF42C017DAB332F447EE"))
                    {
                        MessageBox.Show("Seleccione una forma de pago valida");
                    }
                    else {
                        //rellenando datos de la targeta 
                        bool dataresp = false;
                        paymentModel indataPayment = new paymentModel();
                        indataPayment.CardNumber = txt_numcard.Text.ToString();
                        indataPayment.FechaVencimiento = dtpck_vencimientoCard.Text.Trim();
                        indataPayment.Cvv = txt_codeSec.Text.ToString();
                        //***********************Registro compra************************************
                        fn_ValidarTargetaAsync(indataPayment);

                        //fn_GenerateHeadingFact();
                    }
                    //***********************************************************
                }
                else
                {
                    MessageBox.Show("Rellena los datos de la targeta");
                }
            }
            else
            {
                // La compra se canceló. Realiza la lógica de cancelación aquí

            }
        }

        private void btn_closed_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void txt_numcard_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }//end class
}//end namespaces
