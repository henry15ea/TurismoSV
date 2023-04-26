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
using TurismoSV_client.controllers.SingnupController;
using TurismoSV_client.models.AppModel.cuentaModel;

namespace TurismoSV_client.views
{
    /// <summary>
    /// Interaction logic for Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void PreviewTextInputHandler(object sender, TextCompositionEventArgs e)
        {
            //Solo permitir dígitos enteros
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

        private void btn_cleanFields_Click(object sender, RoutedEventArgs e)
        {
           fn_ClearFields();
        }

        private void GetMessage(String msj) {
            MessageBox.Show(msj, "Campo Requerido", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void fn_ClearFields() {
            //vaciamos los campos del registro
            txt_name.Clear();
            txt_apellido.Clear();
            txt_correo.Clear();
            txt_dirrecihon.Clear();
            txt_edad.Clear();
            txt_telefono.Clear();
            txt_clave.Clear();
            txt_claverep.Clear();
            txt_usuario.Clear();
        }


        private async void fn_registrarUsuario() {
            try {
                bool stateSingup = false;
                cuentaModel ctm = new cuentaModel();
                SingnupController snp = new SingnupController();

               ctm.Nombre = txt_name.Text.ToUpper().Trim();
                ctm.Apellido = txt_apellido.Text.ToUpper().Trim();
                ctm.Edad = int.Parse(txt_edad.Text);
                ctm.Correo = txt_correo.Text.Trim();
                ctm.Direccion = txt_dirrecihon.Text.ToUpper().Trim();
                ctm.Estado = -1;
                ctm.Idusuario = "null";
                ctm.Id_cuenta = "null";
                ctm.Id_rol = -4;
                ctm.Id_usuario = "null";
                ctm.Telefono = txt_telefono.Text;
                ctm.U_name = txt_usuario.Text;
                ctm.U_pass = txt_clave.Password.ToString();
                ctm.U_state = -1;
                
                stateSingup = await snp.fn_SingUpUser(ctm);

                if (stateSingup == true)
                {
                    fn_ClearFields();
                    MessageBox.Show("Se ha registrado el usuario", "Registro Completado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el usuario", "No se pudo registrar", MessageBoxButton.OK, MessageBoxImage.Information);
                }
              
            }
            catch(Exception) {
                MessageBox.Show("No se pudo registrar al usuario", "Fallo al registrar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        
        }

        private void txt_name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_singnup_Click(object sender, RoutedEventArgs e)
        {
            //acciones para el boton de registro
            if (txt_clave.Password.ToString() == txt_claverep.Password.ToString()) {
                if (txt_name.Text.Length > 0) {
                    if (txt_apellido.Text.Length > 0)
                    {
                        if (txt_correo.Text.Length > 0) {
                            if (txt_dirrecihon.Text.Length > 0) {

                                if (txt_usuario.Text.Length > 0) {

                                    if (txt_telefono.Text.Length > 0) {

                                        if (txt_edad.Text.Length > 0) {

                                            //ejecuta el codigo de registro 
                                            fn_registrarUsuario();

                                            


                                        }
                                        else{
                                            GetMessage("Campo edad es requerido");
                                        }

                                    } else {
                                        GetMessage("Campo telefono es requerido");
                                    }

                                }
                                else{
                                    GetMessage("Campo usuario es requerido");
                                }

                            } else {
                                GetMessage("Campo direccion es requerido");
                            }
                        } else {
                            GetMessage("Campo correo es requerido");
                        }
                    }
                    else
                    {
                        GetMessage("Campo apellido es requerido");
                    }
                } else {
                    GetMessage("Campo nombre es requerido");
                }


            } else {
                MessageBox.Show("las claves no coinciden", "No coiciden campos", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            this.Close();
            inicio.Show();
        }
    }
}
