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
    /// Interaction logic for personasExtrasControl.xaml
    /// </summary>
    public partial class personasExtrasControl : UserControl
    {
        protected DataTable dtfx;
        public personasExtrasControl()
        {
            InitializeComponent();
            refresh();
        }

        string id = "";

        protected void fn_searchElement(String ElementSearch)
        {
            string searchText = ElementSearch.Trim();

            try
            {
                if (!string.IsNullOrEmpty(searchText))
                {
                    // Filter the data based on the search text
                    DataTable filteredDT = dtfx.Select($"nom LIKE '%{searchText}%'").CopyToDataTable();

                    // Clear the data bindings for the DataGridView
                    dataTable.ItemsSource = null;
                    // Update the data bindings for the DataGridView
                    dataTable.AutoGenerateColumns = false;
                    dataTable.ItemsSource = filteredDT.DefaultView;
                }
                else
                {
                    // Clear the data bindings for the DataGridView
                    dataTable.ItemsSource = null;
                    // Update the data bindings for the DataGridView
                    dataTable.AutoGenerateColumns = false;
                    dataTable.ItemsSource = dtfx.DefaultView;
                }
            }
            catch
            {
                MessageBox.Show("Hubo un problema al buscar elemento en los datos obtenidos");
                this.refresh();
            }

        }
        private void refresh()
        {
            ///
            SqlConnection sc1 = Conexion.sc();
            sc1.Open();
            Md5 md5 = new Md5();

            String consulta = "select idagregado,pe.nombre as nom,pe.apellido as apelli, pe.n_doc as docu, pe.edad as edad, d.iddetalle as detalle,u.nombre as usu  from personasextras as pe inner join detalle as d on pe.iddetalle=d.iddetalle inner join usuarios as u on pe.idcuenta=u.idusuario";

            SqlCommand comando = new SqlCommand(consulta, sc1);
            comando.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            dtfx = dt;
            da.Fill(dt);
            //MessageBox.Show(dt.Rows[0][0].ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);



            String consulta2 = "SP_ReDetalle";

            SqlCommand comando2 = new SqlCommand(consulta2, sc1);
            comando2.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da2 = new SqlDataAdapter(comando2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);


            cboxdetalle.ItemsSource = dt2.DefaultView;
            cboxdetalle.DisplayMemberPath = "iddetalle";
            cboxdetalle.SelectedValuePath = "iddetalle";
            cboxdetalle.SelectedIndex = 0;

            //MessageBox.Show(cbox.SelectedValue.ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            dataTable.ItemsSource = dt.DefaultView;
            sc1.Close();
            comrpobar();

            String consulta3 = "SP_ReUsuarios";

            SqlCommand comando3 = new SqlCommand(consulta3, sc1);
            comando3.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da3 = new SqlDataAdapter(comando3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);


            cboxcuenta.ItemsSource = dt3.DefaultView;
            cboxcuenta.DisplayMemberPath = "nombre";
            cboxcuenta.SelectedValuePath = "idusuario";
            cboxcuenta.SelectedIndex = 0;

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

                String consulta = "SP_InsPersonasExtras";

                SqlCommand comando = new SqlCommand(consulta, sc1);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", md5.fn_GenerateMd5Hash());
                comando.Parameters.AddWithValue("@nombre", txtnombre.Text.ToUpper().Trim());
                comando.Parameters.AddWithValue("@apellido", txtapellido.Text.ToUpper().Trim());
                comando.Parameters.AddWithValue("@ndoc", txtdui.Text);
                comando.Parameters.AddWithValue("@edad", txtedad.Text);
                comando.Parameters.AddWithValue("@iddet", cboxdetalle.SelectedValue.ToString());
                comando.Parameters.AddWithValue("@idc", cboxcuenta.SelectedValue.ToString());
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
            txtdui.Text = "";
            txtedad.Text = "";
            cboxdetalle.SelectedIndex = 0;
            cboxcuenta.SelectedIndex = 0;

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

                    String consulta = "SP_BorrPersonasExtras";

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

                String consulta = "SP_AuxPersonasExtras";

                SqlCommand comando = new SqlCommand(consulta, sc1);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", st);



                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();

                da.Fill(dt);
                // MessageBox.Show(dt.Rows[0][1].ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);

                txtnombre.Text = dt.Rows[0]["nombre"].ToString();
                txtapellido.Text = dt.Rows[0]["apellido"].ToString();
                txtdui.Text = dt.Rows[0]["n_doc"].ToString();
                txtedad.Text = dt.Rows[0]["edad"].ToString();
                cboxdetalle.SelectedValue = dt.Rows[0]["iddetalle"].ToString();
                cboxcuenta.SelectedValue = dt.Rows[0]["idcuenta"].ToString();

                sc1.Close();
                comrpobar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Algo salio mal" + ex.ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
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

                    String consulta = "SP_ActuPersonasExtras";

                    SqlCommand comando = new SqlCommand(consulta, sc1);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@nombre", txtnombre.Text.ToUpper().Trim());
                    comando.Parameters.AddWithValue("@apellido", txtapellido.Text.ToUpper().Trim());
                    comando.Parameters.AddWithValue("@ndoc", txtdui.Text);
                    comando.Parameters.AddWithValue("@edad", txtedad.Text);
                    comando.Parameters.AddWithValue("@iddet", cboxdetalle.SelectedValue.ToString());
                    comando.Parameters.AddWithValue("@idc", cboxcuenta.SelectedValue.ToString());


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
            String dataSearch = txt_itemSearch.Text.Trim();
            if (dataSearch.Trim() == "ALL" || dataSearch.Trim() == "*" || dataSearch.Trim() == "")
            {
                txt_itemSearch.Text = "";
                this.refresh();
            }
            else
            {
                txt_itemSearch.Text = "";
                this.fn_searchElement(dataSearch.Trim());
            }
        }
    }//end class
}//end namespaces
