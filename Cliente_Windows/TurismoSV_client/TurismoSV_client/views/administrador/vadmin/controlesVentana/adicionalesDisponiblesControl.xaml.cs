using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TurismoSV_client.controllers.adm;
using TurismoSV_client.models.AppModel.admin;
using TurismoSV_client.UitlsClass.AppConfig;

namespace TurismoSV_client.views.administrador.vadmin.controlesVentana
{
    /// <summary>
    /// Interaction logic for adicionalesDisponiblesControl.xaml
    /// </summary>
    public partial class adicionalesDisponiblesControl : UserControl
    {
        public adicionalesDisponiblesControl()
        {
            InitializeComponent();
            refresh();
        }


        string id = "";
        private void refresh()
        {
            ///
            SqlConnection sc1 = Conexion.sc();
            sc1.Open();
            Md5 md5 = new Md5();

            String consulta = "select idadicionald,p.nombre as paquete,a.nombre as adicional from adicionalesdisponible as ad inner join paquetesdisponible as pd on ad.idpaqueted=pd.idpaqueted inner join paquetes as p on pd.idpaquete=p.idpaquete inner join adicionales as a on ad.idadicional=a.idadicional";

            SqlCommand comando = new SqlCommand(consulta, sc1);
            comando.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //MessageBox.Show(dt.Rows[0][0].ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);



            String consulta2 = "select idpaqueted,p.nombre as nombre from paquetesdisponible as pd inner join paquetes as p on pd.idpaquete=p.idpaquete";

            SqlCommand comando2 = new SqlCommand(consulta2, sc1);
            comando2.CommandType = CommandType.Text;
            SqlDataAdapter da2 = new SqlDataAdapter(comando2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);


            cboxpaquete.ItemsSource = dt2.DefaultView;
            cboxpaquete.DisplayMemberPath = "nombre";
            cboxpaquete.SelectedValuePath = "idpaqueted";
            cboxpaquete.SelectedIndex = 0;

            //MessageBox.Show(cbox.SelectedValue.ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            dataTable.ItemsSource = dt.DefaultView;
            sc1.Close();
            comrpobar();

            String consulta3 = "SP_ReAdicionales";

            SqlCommand comando3 = new SqlCommand(consulta3, sc1);
            comando3.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da3 = new SqlDataAdapter(comando3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);


            cboxadicional.ItemsSource = dt3.DefaultView;
            cboxadicional.DisplayMemberPath = "nombre";
            cboxadicional.SelectedValuePath = "idadicional";
            cboxadicional.SelectedIndex = 0;

            //MessageBox.Show(cbox.SelectedValue.ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            dataTable.ItemsSource = dt.DefaultView;
            sc1.Close();
            comrpobar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection sc1 = Conexion.sc();
                sc1.Open();
                Md5 md5 = new Md5();

                String consulta = "SP_InsAdicionalesDisponible";

                SqlCommand comando = new SqlCommand(consulta, sc1);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", md5.fn_GenerateMd5Hash());
                comando.Parameters.AddWithValue("@idpd", cboxpaquete.SelectedValue.ToString());
                comando.Parameters.AddWithValue("@idad", cboxadicional.SelectedValue.ToString());
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();

                da.Fill(dt);
                MessageBox.Show("Datos agregados", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                id = "";
                refresh();
                limpiar();
                sc1.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Algo salio mal", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        public void limpiar()
        {

            cboxpaquete.SelectedIndex = 0;
            cboxadicional.SelectedIndex = 0;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string st = ((Button)sender).CommandParameter.ToString();
            // MessageBox.Show(st, "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            try
            {
                MessageBoxResult result = MessageBox.Show("¿Desea eliminar elemento seleccionado?", "Eliminar elemento", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    SqlConnection sc1 = Conexion.sc();
                    sc1.Open();
                    Md5 md5 = new Md5();

                    String consulta = "SP_BorrAdicionalesDisponible";

                    SqlCommand comando = new SqlCommand(consulta, sc1);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id", st);


                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    MessageBox.Show("Dato Eliminado", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    id = "";
                    refresh();
                    limpiar();
                    sc1.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Algo salio mal", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string st = ((Button)sender).CommandParameter.ToString();
            id = st;

            try
            {
                SqlConnection sc1 = Conexion.sc();
                sc1.Open();
                Md5 md5 = new Md5();

                String consulta = "SP_AuxAdicionalesDisponible";

                SqlCommand comando = new SqlCommand(consulta, sc1);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", st);



                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();

                da.Fill(dt);
                // MessageBox.Show(dt.Rows[0][1].ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);

                cboxpaquete.SelectedValue = dt.Rows[0]["idpaqueted"].ToString();
                cboxadicional.SelectedValue = dt.Rows[0]["idadicional"].ToString();

                sc1.Close();
                comrpobar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Algo salio mal", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Acl_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("¿Desea actualizar la informacion?", "Actualizar Elemento", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    SqlConnection sc1 = Conexion.sc();
                    sc1.Open();
                    Md5 md5 = new Md5();

                    String consulta = "SP_ActuAdicionalesDisponible";

                    SqlCommand comando = new SqlCommand(consulta, sc1);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@idpd", cboxpaquete.SelectedValue.ToString());
                    comando.Parameters.AddWithValue("@idad", cboxadicional.SelectedValue.ToString());


                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    MessageBox.Show("Datos Actualizados", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    id = "";
                    refresh();
                    limpiar();
                    sc1.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Algo salio mal", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void comrpobar()
        {
            if (id.Equals(""))
            {
                btn_saveData.IsEnabled = true;
                Acl.IsEnabled = false;
            }
            else
            {
                btn_saveData.IsEnabled = false;
                Acl.IsEnabled = true;
            }
        }

        private void btn_searchElement_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_crearReporte_Click(object sender, RoutedEventArgs e)
        {

            r_ListadoUsuariosController reporte = new r_ListadoUsuariosController();

            userModel modelo = new userModel();
            modelo.username = AppConfig.GetUserSetting("UserApp");

            reporte.fn_GetListadoUsuariosReport(modelo);


        }
    }//end class
}//end namespaces
