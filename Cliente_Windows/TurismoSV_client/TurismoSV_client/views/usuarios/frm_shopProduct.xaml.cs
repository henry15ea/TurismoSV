using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TurismoSV_client.controllers;
using TurismoSV_client.controllers.formaPagoController;
using TurismoSV_client.controllers.infoPaqueteController;
using TurismoSV_client.controllers.nuevoDetalleController;
using TurismoSV_client.controllers.NuevoEncabezadoController;
using TurismoSV_client.controllers.payments;
using TurismoSV_client.models.ApiModels;
using TurismoSV_client.models.AppModel.facturaModel.detalleFacturaModel;
using TurismoSV_client.models.AppModel.facturaModel.facturaEncabezadoModel;
using TurismoSV_client.models.AppModel.facturaModel.facturaResponseModel;
using TurismoSV_client.models.AppModel.fpagoModel;
using TurismoSV_client.models.AppModel.payment;
using TurismoSV_client.models.AppModel.users;
using TurismoSV_client.models.AppModel.vpaquetesDisp;
using TurismoSV_client.UitlsClass;
using TurismoSV_client.UitlsClass.AppConfig;

namespace TurismoSV_client.views.usuarios
{
    /// <summary>
    /// Interaction logic for frm_shopProduct.xaml
    /// </summary>
    public partial class frm_shopProduct : Window
    {
        protected List<vpaquetesDisp> detallePaquete;
        protected String id_pagoSelected = "538EA49919FBEFC0D7A3143E8805D378";
        private List<invitadosModel> personasExtras;
        
        protected double precioPaquete = 0.00;
        protected double Total = 0.00;
        protected int CantPersonas = 0;
        protected String TerminateShopMessage = "";
        protected String id_detalle = null;
        //funciones para llamada de api
        private async Task geetInfoPaqueteAsync()
        {
            bool resp = false;
            string id_selectedPackage = AppConfig.GetUserSetting("SelectPackage").ToString();
            infoPaqueteController ct = new infoPaqueteController();
            resp = await ct.fn_GetPaqueteInfo(id_selectedPackage);

            if (resp == true)
            {
                //var cadata = ct.GetDataAPI();
                txt_nombrePaquete.Content = "Elemento : "+ AppConfig.GetUserSetting("SelectPackage").ToString();
                detallePaquete = ct.DataResponse;
                System.Diagnostics.Debug.WriteLine("REspondio la api ");
                txt_pkgCost.Content = detallePaquete[0].PrecioFormateado.ToString();
                precioPaquete = double.Parse(detallePaquete[0].Precio.ToString());
                Total = precioPaquete;
                txt_pkgTotalCost.Content = detallePaquete[0].PrecioFormateado.ToString();            }
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

        private async Task<bool> fn_RegistrarInvitadosAsync() { 
            bool resp = false;

            //llamamos al controlador de invitados 
            invitadosCotroller cinvitados = new invitadosCotroller();
            resp = await cinvitados.fn_RegistroInvitados(personasExtras);
            
            if (resp == true) 
            {
                TerminateShopMessage = cinvitados.GetDataAPI().InfoMsg;
                System.Diagnostics.Debug.WriteLine(TerminateShopMessage);
                return resp;
            } else {
                System.Diagnostics.Debug.WriteLine("ERR : "+TerminateShopMessage);
                TerminateShopMessage = cinvitados.GetDataAPI().InfoMsg;
                return false;
            }
        }

        private async Task fn_ValidarTargetaAsync(paymentModel dataCard)
        {
            bool resp = false;

            //llamamos al controlador de invitados 
            paymentsController cpayment = new paymentsController();
            resp = await cpayment.fn_GetCardValidation(dataCard);
            
            if (resp == true )
            {
                paymentResponseModel datapayment = new paymentResponseModel();
                datapayment = cpayment.GetDataAPI();

                if (datapayment != null) {
                    if (datapayment.Validate == 1 || datapayment.Validate >0) {
                        fn_GenerateHeadingFact();
                        this.Close();
                    } else {
                        MessageBox.Show(datapayment.InfoMsg);
                    }
                } else {
                    MessageBox.Show("El servicio no puede responder a la solicitud");
                }

            } else {
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

        protected bool fn_AssingIdDetalleInvitados() 
        {
            int cont = 0;
            foreach (var item in personasExtras) {
                item.iddetalle = this.id_detalle;
                /*
                System.Diagnostics.Debug.WriteLine("\n- Asignando id_detalle-["+"iter > "+cont+"/lista >"+personasExtras.Count+"]");
                System.Diagnostics.Debug.WriteLine("nombre :"+item.nombre);
                System.Diagnostics.Debug.WriteLine("apellido :" + item.apellido);
                System.Diagnostics.Debug.WriteLine("n_doc :" + item.n_doc);
                System.Diagnostics.Debug.WriteLine("edad :" + item.edad.ToString());
                System.Diagnostics.Debug.WriteLine("id_paquete :" + item.id_paquete);
                System.Diagnostics.Debug.WriteLine("username :" + item.username);
                System.Diagnostics.Debug.WriteLine("iddetalle :" + item.iddetalle);
                */
                if (cont == personasExtras.Count-1) {
                    return true;
                } else { 
                    cont++;
                }
            }

            return false;
        }

        private async Task fn_GenerateHeadingFact() {
            //definiendo modelos para la factura

            //modelo encabezado
            facturaEncabezadoModel hd = new facturaEncabezadoModel();
            hd.Idencabezado = "demo";//este puede ser cualquier valor
            hd.Idcuenta = "nuas"; //este puede ser cualquier valor
            hd.Idformapago = id_pagoSelected.ToString().Trim();
            hd.Descuento = decimal.Parse("15");
            hd.Monto = decimal.Parse("" + Total);
            hd.State_emited = true;
            hd.Username = AppConfig.GetUserSetting("UserApp").ToString();

            



            NuevoEncabezadoController hcontrol = new NuevoEncabezadoController();

            if (await hcontrol.fn_InHeadFactura(hd) == true) {

                nuevoDetalleController dtt = new nuevoDetalleController();
                facturaResponseModel respuestaHeader;

                String tokenpaquete = hcontrol.Result.Token_paquete.ToString();
               // System.Diagnostics.Debug.WriteLine(tokenpaquete);
                //modelo detalle
               
                detalleFacturaModel dta = new detalleFacturaModel();
                dta.Iddetalle = "simple"; //este puede ser cualquier valor
                dta.Idencabezado = tokenpaquete.Trim();
                dta.Idpaqueted = AppConfig.GetUserSetting("SelectPackage").ToString();
                dta.Precio =  detallePaquete[0].Precio;
                dta.Descuento = 15;
                dta.Monto = decimal.Parse(""+Total);
                dta.Cupos = CantPersonas;
                dta.Username = AppConfig.GetUserSetting("UserApp").ToString();

                bool respa = await dtt.fn_InDetalleFactura(dta);
                if (respa == true) {

                    if (!string.IsNullOrEmpty(dtt.Restult.Token_paquete)) {
                        id_detalle = dtt.Restult.Token_paquete.Trim();
                        //registramos a los invitados Si hay
                        if (personasExtras.Count > 0) {
                            //hay personas extras en la lista por lo que se procede a registrarlas

                            if (fn_AssingIdDetalleInvitados() == true) {
                                bool respuestaInvitados = await fn_RegistrarInvitadosAsync();
                                if (respuestaInvitados == true)
                                {
                                    MessageBox.Show("Compra realizada");
                                    this.Close();

                                }
                                else
                                {
                                    MessageBox.Show(TerminateShopMessage);
                                }
                            } else {
                                System.Diagnostics.Debug.WriteLine("Problema al asignar id_detalle");
                            }
                            
                            //--------------------------------------------------------------------
                        } else {
                            //se asume que se adquirio el paquete para una persona
                            MessageBox.Show("Compra realizada");
                        }
                        
                        //fin registro invitados
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

            //inicializando lista de invitados 
            personasExtras = new List<invitadosModel>();
            
            cmbx_listaPago.SelectedIndex = 0;
            dtpck_vencimientoCard.SelectedDate = DateTime.Now;
            CantPersonas = personasExtras.Count + 1;
            txt_numPersons.Content = CantPersonas;
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
                    //rellenando datos de la targeta 
                    bool dataresp = false;
                    paymentModel indataPayment = new paymentModel();
                    indataPayment.CardNumber = txt_numcard.Text.ToString();
                    indataPayment.FechaVencimiento = dtpck_vencimientoCard.Text.Trim();
                    indataPayment.Cvv = txt_codeSec.Text.ToString();
                    //***********************Registro compra************************************
                    fn_ValidarTargetaAsync(indataPayment);

                    //fn_GenerateHeadingFact();
                    
                    //***********************************************************
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

        private void fn_cleanFields() {
            txt_pname.Clear();
            txt_plname.Clear();
            txt_ndoc.Clear();
            txt_pedad.Clear();
        }

        private void btn_addPersons_Click(object sender, RoutedEventArgs e)
        {

            //funcion para agregar personas 
            documentValidator ndo = new documentValidator();

            if (!string.IsNullOrEmpty(txt_ndoc.Text) && txt_ndoc.Text.Length == 9) {
                if (!string.IsNullOrEmpty(txt_pname.Text.Trim()) && txt_pname.Text.Length>=3) {
                    if (!string.IsNullOrEmpty(txt_plname.Text.Trim()) && txt_plname.Text.Length >= 4)
                    {
                        if (!string.IsNullOrEmpty(txt_pedad.Text.Trim()) && txt_pedad.Text.Length >= 2)
                        {
                            //asignamos la nueva persona a la lista

                            invitadosModel objInvitados = new invitadosModel();
                            objInvitados.nombre = txt_pname.Text.ToUpper().Trim();
                            objInvitados.apellido = txt_plname.Text.ToUpper().Trim();
                            objInvitados.n_doc = ndo.fn_FormatoDUI(txt_ndoc.Text.Trim());
                            objInvitados.edad = int.Parse(txt_pedad.Text.Trim());
                            objInvitados.id_paquete = AppConfig.GetUserSetting("SelectPackage").ToString();
                            objInvitados.username = AppConfig.GetUserSetting("UserApp").ToString();
                            objInvitados.iddetalle = "null";

                            if (precioPaquete > 0) {
                                personasExtras.Add(objInvitados);
                                Total += (precioPaquete / 2);
                                txt_pkgTotalCost.Content = Total.ToString();

                                CantPersonas++;
                                txt_numPersons.Content = CantPersonas; 
                                fn_cleanFields();
                            }
                            
                           
                        }
                        else
                        {
                            MessageBox.Show("Ingrese su edad");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese su apellido");
                    }
                } else {
                    MessageBox.Show("Ingrese su nombre");
                }
            } else {
                MessageBox.Show("Ingrese un documento valido ");
            }


        }

        private void txt_pname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }//end class
}//end namespaces
