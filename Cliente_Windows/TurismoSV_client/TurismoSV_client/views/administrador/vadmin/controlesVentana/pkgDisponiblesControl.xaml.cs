﻿using System;
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
    /// Interaction logic for pkgDisponiblesControl.xaml
    /// </summary>
    public partial class pkgDisponiblesControl : UserControl
    {
        public pkgDisponiblesControl()
        {
            InitializeComponent();
            refresh();
            dpickinicial.SelectedDate = DateTime.Now;
            dpickfinal.SelectedDate = DateTime.Now;
            /*var dateString = "5/1/2008 8:30:52 AM";
            DateTime date1 = DateTime.Parse(dateString,System.Globalization.CultureInfo.InvariantCulture);

            dpickfinal.SelectedDate = date1;*/


        }

        string id = "";
        private void refresh()
        {
            ///
            SqlConnection sc1 = Conexion.sc();
            sc1.Open();
            Md5 md5 = new Md5();

            String consulta = "select idpaqueted,p.nombre as nom,precio,cupos_disp,cuposllenos,fechainicial,fechafinal,pd.estado from paquetes as p inner join paquetesdisponible as pd on p.idpaquete=pd.idpaquete";

            SqlCommand comando = new SqlCommand(consulta, sc1);
            comando.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //MessageBox.Show(dt.Rows[0][0].ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);



            String consulta2 = "SP_RePaquetes";

            SqlCommand comando2 = new SqlCommand(consulta2, sc1);
            comando2.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da2 = new SqlDataAdapter(comando2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);


            cboxpaquete.ItemsSource = dt2.DefaultView;
            cboxpaquete.DisplayMemberPath = "nombre";
            cboxpaquete.SelectedValuePath = "idpaquete";
            cboxpaquete.SelectedIndex = 0;




            //MessageBox.Show(cbox.SelectedValue.ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            DG.ItemsSource = dt.DefaultView;
            sc1.Close();
            comrpobar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // MessageBox.Show(dpickinicial.SelectedDate.ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            try
            {
                SqlConnection sc1 = Conexion.sc();
                sc1.Open();
                Md5 md5 = new Md5();

                String consulta = "SP_InsPaquetesDisponible";
                //string fecha = "2023-04-25 21:28:30.123";
                SqlCommand comando = new SqlCommand(consulta, sc1);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", md5.fn_GenerateMd5Hash());
                comando.Parameters.AddWithValue("@idp", cboxpaquete.SelectedValue.ToString());
                comando.Parameters.AddWithValue("@precio", txtprecio.Text);
                comando.Parameters.AddWithValue("@cdisp", txtdisponibles.Text);
                comando.Parameters.AddWithValue("@cllenos", txtllenos.Text);
                comando.Parameters.AddWithValue("@finicial", dpickinicial.SelectedDate.ToString());
                comando.Parameters.AddWithValue("@ffinal", dpickfinal.SelectedDate.ToString());
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
                MessageBox.Show("Algo salio mal" + ex.ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void limpiar()
        {
            txtdisponibles.Text = "";
            txtllenos.Text = "";
            txtprecio.Text = "";
            cboxpaquete.SelectedIndex = 0;
            chbestado.IsChecked = false;
            dpickinicial.SelectedDate = DateTime.Now;
            dpickfinal.SelectedDate = DateTime.Now;

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

                String consulta = "SP_BorrPaquetesDisponible";

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

                String consulta = "SP_AuxPaquetesDisponible";

                SqlCommand comando = new SqlCommand(consulta, sc1);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", st);



                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();

                da.Fill(dt);
                // MessageBox.Show(dt.Rows[0][1].ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                txtprecio.Text = dt.Rows[0]["precio"].ToString();
                txtdisponibles.Text = dt.Rows[0]["cupos_disp"].ToString();
                txtllenos.Text = dt.Rows[0]["cuposllenos"].ToString();

                DateTime fecha = DateTime.Parse(dt.Rows[0]["fechainicial"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                dpickinicial.SelectedDate = fecha;
                fecha = DateTime.Parse(dt.Rows[0]["fechafinal"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                dpickfinal.SelectedDate = fecha;
                cboxpaquete.SelectedValue = dt.Rows[0]["idpaquete"].ToString();
                chbestado.IsChecked = (bool)dt.Rows[0]["estado"];


                sc1.Close();
                comrpobar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Algo salio mal ", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Acl_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection sc1 = Conexion.sc();
                sc1.Open();
                Md5 md5 = new Md5();

                String consulta = "SP_ActuPaquetesDisponible";

                SqlCommand comando = new SqlCommand(consulta, sc1);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@idp", cboxpaquete.SelectedValue.ToString());
                comando.Parameters.AddWithValue("@precio", txtprecio.Text);
                comando.Parameters.AddWithValue("@cdisp", txtdisponibles.Text);
                comando.Parameters.AddWithValue("@cllenos", txtllenos.Text);
                comando.Parameters.AddWithValue("@finicial", dpickinicial.SelectedDate.ToString());
                comando.Parameters.AddWithValue("@ffinal", dpickfinal.SelectedDate.ToString());
                comando.Parameters.AddWithValue("@estado", chbestado.IsChecked);


                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();

                da.Fill(dt);
                MessageBox.Show("Datos Actualizados" + dt.Rows[0][0].ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
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