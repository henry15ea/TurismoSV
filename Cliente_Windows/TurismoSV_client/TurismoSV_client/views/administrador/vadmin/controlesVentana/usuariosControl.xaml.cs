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
    /// Interaction logic for usuariosControl.xaml
    /// </summary>
    public partial class usuariosControl : UserControl
    {
        public usuariosControl()
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

            String consulta = "select  * from usuarios as u inner join rolusuario as r on u.id_rol=r.id_role";

            SqlCommand comando = new SqlCommand(consulta, sc1);
            comando.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //MessageBox.Show(dt.Rows[0][0].ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);



            String consulta2 = "SP_ReRolUsuario";

            SqlCommand comando2 = new SqlCommand(consulta2, sc1);
            comando2.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da2 = new SqlDataAdapter(comando2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);


            cboxrol.ItemsSource = dt2.DefaultView;
            cboxrol.DisplayMemberPath = "r_name";
            cboxrol.SelectedValuePath = "id_role";
            cboxrol.SelectedIndex = 0;




            //MessageBox.Show(cbox.SelectedValue.ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            DG.ItemsSource = dt.DefaultView;
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

                String consulta = "SP_InsUsuarios";

                SqlCommand comando = new SqlCommand(consulta, sc1);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", md5.fn_GenerateMd5Hash());
                comando.Parameters.AddWithValue("@nom", txtnombre.Text);
                comando.Parameters.AddWithValue("@apell", txtapellido.Text);
                comando.Parameters.AddWithValue("@edad", txtedad.Text);
                comando.Parameters.AddWithValue("@tel", txttelefono.Text);
                comando.Parameters.AddWithValue("@dir", txtdireccion.Text);
                comando.Parameters.AddWithValue("@correo", txtcorreo.Text);
                comando.Parameters.AddWithValue("@id_rol", cboxrol.SelectedValue.ToString());
                comando.Parameters.AddWithValue("@estado", chbestado.IsChecked);

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
            txtnombre.Text = "";
            txtapellido.Text = "";
            txtdireccion.Text = "";
            txtedad.Text = "";
            txttelefono.Text = "";
            txtcorreo.Text = "";
            cboxrol.SelectedIndex = 0;
            chbestado.IsChecked = false;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string st = ((Button)sender).CommandParameter.ToString();
            // MessageBox.Show(st, "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            try
            {
                SqlConnection sc1 = Conexion.sc();
                sc1.Open();
                Md5 md5 = new Md5();

                String consulta = "SP_BorrUsuarios";

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

                String consulta = "SP_AuxUsuarios";

                SqlCommand comando = new SqlCommand(consulta, sc1);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", st);



                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();

                da.Fill(dt);
                // MessageBox.Show(dt.Rows[0][1].ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                txtnombre.Text = dt.Rows[0]["nombre"].ToString();
                txtapellido.Text = dt.Rows[0]["apellido"].ToString();
                txtdireccion.Text = dt.Rows[0]["direccion"].ToString();
                txtedad.Text = dt.Rows[0]["edad"].ToString();
                txttelefono.Text = dt.Rows[0]["telefono"].ToString();
                txtcorreo.Text = dt.Rows[0]["correo"].ToString();
                cboxrol.SelectedValue = dt.Rows[0]["id_rol"].ToString();
                chbestado.IsChecked = (bool)dt.Rows[0]["estado"];


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
                SqlConnection sc1 = Conexion.sc();
                sc1.Open();
                Md5 md5 = new Md5();

                String consulta = "SP_ActuUsuarios";

                SqlCommand comando = new SqlCommand(consulta, sc1);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nom", txtnombre.Text);
                comando.Parameters.AddWithValue("@apell", txtapellido.Text);
                comando.Parameters.AddWithValue("@edad", txtedad.Text);
                comando.Parameters.AddWithValue("@tel", txttelefono.Text);
                comando.Parameters.AddWithValue("@dir", txtdireccion.Text);
                comando.Parameters.AddWithValue("@correo", txtcorreo.Text);
                comando.Parameters.AddWithValue("@id_rol", cboxrol.SelectedValue.ToString());
                comando.Parameters.AddWithValue("@estado", chbestado.IsChecked);


                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();

                da.Fill(dt);
                MessageBox.Show("Datos Actualizados", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
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

        public void comrpobar()
        {
            if (id.Equals(""))
            {
                Acl.IsEnabled = false;
            }
            else
            {
                Acl.IsEnabled = true;
            }
        }
    }//end class
}//end namespaces
