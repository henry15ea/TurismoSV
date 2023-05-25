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

namespace TurismoSV_client.views.administrador.vadmin.controlesVentana
{
    /// <summary>
    /// Interaction logic for pkgCalificacionControl.xaml
    /// </summary>
    public partial class pkgCalificacionControl : UserControl
    {
        public pkgCalificacionControl()
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

            String consulta = "select id_calificacion,u.nombre as nom,p.nombre as nomd, pc.nota as nota,pc.fecha as fecha from paqueteCalificacion as pc inner join usuarios as u on pc.id_usuario=u.idusuario inner join paquetes as p on pc.id_paquete=p.idpaquete";

            SqlCommand comando = new SqlCommand(consulta, sc1);
            comando.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //MessageBox.Show(dt.Rows[0][0].ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);



            String consulta2 = "SP_ReUsuarios";

            SqlCommand comando2 = new SqlCommand(consulta2, sc1);
            comando2.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da2 = new SqlDataAdapter(comando2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);


            cboxuser.ItemsSource = dt2.DefaultView;
            cboxuser.DisplayMemberPath = "nombre";
            cboxuser.SelectedValuePath = "idusuario";
            cboxuser.SelectedIndex = 0;

            //MessageBox.Show(cbox.SelectedValue.ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            dataTable.ItemsSource = dt.DefaultView;
            sc1.Close();
            comrpobar();

            String consulta3 = "SP_RePaquetes";

            SqlCommand comando3 = new SqlCommand(consulta3, sc1);
            comando3.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da3 = new SqlDataAdapter(comando3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);


            cboxpaquete.ItemsSource = dt3.DefaultView;
            cboxpaquete.DisplayMemberPath = "nombre";
            cboxpaquete.SelectedValuePath = "idpaquete";
            cboxpaquete.SelectedIndex = 0;

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

                String consulta = "SP_InsPaqueteCalificacion";

                SqlCommand comando = new SqlCommand(consulta, sc1);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", md5.fn_GenerateMd5Hash());
                comando.Parameters.AddWithValue("@idu", cboxuser.SelectedValue.ToString());
                comando.Parameters.AddWithValue("@idp", cboxpaquete.SelectedValue.ToString());
                comando.Parameters.AddWithValue("@nota", chblike.IsChecked);

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
            chblike.IsChecked = false;
            cboxuser.SelectedIndex = 0;
            cboxpaquete.SelectedIndex = 0;

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

                    String consulta = "SP_BorrPaqueteCalificacion";

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

                String consulta = "SP_AuxPaqueteCalificacion";

                SqlCommand comando = new SqlCommand(consulta, sc1);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", st);



                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();

                da.Fill(dt);
                // MessageBox.Show(dt.Rows[0][1].ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                chblike.IsChecked = Boolean.Parse(dt.Rows[0]["nota"].ToString());
                cboxuser.SelectedValue = dt.Rows[0]["id_usuario"].ToString();
                cboxpaquete.SelectedValue = dt.Rows[0]["id_paquete"].ToString();

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

                    String consulta = "SP_ActuPaqueteCalificacion";

                    SqlCommand comando = new SqlCommand(consulta, sc1);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@idu", cboxuser.SelectedValue.ToString());
                    comando.Parameters.AddWithValue("@idp", cboxpaquete.SelectedValue.ToString());
                    comando.Parameters.AddWithValue("@nota", chblike.IsChecked);


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
    }//end class
}//end namespaces
