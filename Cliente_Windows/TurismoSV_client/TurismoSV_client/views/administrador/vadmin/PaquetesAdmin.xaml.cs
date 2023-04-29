using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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

namespace TurismoSV_client.views.administrador.vadmin
{
    /// <summary>
    /// Interaction logic for PaquetesAdmin.xaml
    /// </summary>
    public partial class PaquetesAdmin : Window
    {
        public PaquetesAdmin()
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

            String consulta = "select idpaquete,p.nombre,p.descripcion,p.direccion,m.nombre as municipio,c.nombre as categoria,img from paquetes as p inner join municipios as m on m.idmunicipio=p.idmunicipio inner join categorias as c on p.idcategoria=c.idcategoria";

            SqlCommand comando = new SqlCommand(consulta, sc1);
            comando.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //MessageBox.Show(dt.Rows[0][0].ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);



            String consulta2 = "SP_ReMunicipios";

            SqlCommand comando2 = new SqlCommand(consulta2, sc1);
            comando2.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da2 = new SqlDataAdapter(comando2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);


            cboxmuni.ItemsSource = dt2.DefaultView;
            cboxmuni.DisplayMemberPath = "nombre";
            cboxmuni.SelectedValuePath = "idmunicipio";
            cboxmuni.SelectedIndex = 0;

            //----------------------------------------

            String consulta3 = "SP_ReCategorias";

            SqlCommand comando3 = new SqlCommand(consulta3, sc1);
            comando3.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da3 = new SqlDataAdapter(comando3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);


            cboxcate.ItemsSource = dt3.DefaultView;
            cboxcate.DisplayMemberPath = "nombre";
            cboxcate.SelectedValuePath = "idcategoria";
            cboxcate.SelectedIndex = 0;


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

                String consulta = "SP_InsPaquetes";

                SqlCommand comando = new SqlCommand(consulta, sc1);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", md5.fn_MD5Builder(GetRandomNumber().ToString()));
                comando.Parameters.AddWithValue("@nom", txtnombre.Text);
                comando.Parameters.AddWithValue("@des", txtdescripcion.Text);
                comando.Parameters.AddWithValue("@dir", txtdireccion.Text);
                comando.Parameters.AddWithValue("@img", txtimg.Text);
                comando.Parameters.AddWithValue("@idmun", cboxmuni.SelectedValue.ToString());
                comando.Parameters.AddWithValue("@idcate", cboxcate.SelectedValue.ToString());

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

        public static int GetRandomNumber()
        {
            using (RNGCryptoServiceProvider rngCrypt = new RNGCryptoServiceProvider())
            {
                byte[] tokenBuffer = new byte[4];        // `int32` toma 4 bytes en C#
                rngCrypt.GetBytes(tokenBuffer);
                return BitConverter.ToInt32(tokenBuffer, 0);
            }
        }

        public void limpiar()
        {
            txtnombre.Text = "";
            txtdescripcion.Text = "";
            txtdireccion.Text = "";
            txtimg.Text = "";
            cboxmuni.SelectedIndex = 0;
            cboxcate.SelectedIndex = 0;

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

                String consulta = "SP_BorrPaquetes";

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

                String consulta = "SP_AuxPaquetes";

                SqlCommand comando = new SqlCommand(consulta, sc1);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", st);



                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();

                da.Fill(dt);
                // MessageBox.Show(dt.Rows[0][1].ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                txtnombre.Text = dt.Rows[0]["nombre"].ToString();
                txtdescripcion.Text= dt.Rows[0]["descripcion"].ToString();
                txtdireccion.Text = dt.Rows[0]["direccion"].ToString();
                txtimg.Text= dt.Rows[0]["img"].ToString();
                cboxcate.SelectedValue = dt.Rows[0]["idcategoria"].ToString();
                cboxmuni.SelectedValue = dt.Rows[0]["idmunicipio"].ToString();

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

                String consulta = "SP_ActuPaquetes";

                SqlCommand comando = new SqlCommand(consulta, sc1);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nom", txtnombre.Text);
                comando.Parameters.AddWithValue("@des", txtdescripcion.Text);
                comando.Parameters.AddWithValue("@dir", txtdireccion.Text);
                comando.Parameters.AddWithValue("@img", txtimg.Text);
                comando.Parameters.AddWithValue("@idmun", cboxmuni.SelectedValue.ToString());
                comando.Parameters.AddWithValue("@idcate", cboxcate.SelectedValue.ToString());
                //comando.Parameters.AddWithValue("@idd", cbox.SelectedValue.ToString());


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


    }

}
