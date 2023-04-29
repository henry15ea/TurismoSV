﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using Newtonsoft.Json;
using TurismoSV_client.UitlsClass.RoutesApi;
using TurismoSV_client.controllers.LoginController;
using TurismoSV_client.models.UserModel;
using TurismoSV_client.models.ApiModels.LoginResponseModel;
using TurismoSV_client.views;
using TurismoSV_client.UitlsClass.AppConfig;
using System.Data.SqlClient;
using TurismoSV_client.views.administrador;
using System.Data.Common;
using System.Data;

namespace TurismoSV_client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RoutesApi rt = new RoutesApi();
            AppConfig.initSharedPreferences();
            

        }

        private async void btn_login_Click_1(object sender, RoutedEventArgs e)
        {
            LoginController loginController = new LoginController();
            String user = txt_username.Text;
            string password = txt_password.Password;
            Boolean isloggedIn = false;
           


            if (user == "" || password == "" )
            {
                MessageBox.Show("Rellene todos los campos", "Campos nulos", MessageBoxButton.OK, MessageBoxImage.Warning);


            }
            else
            {

                // //obtengo el estado que trae la api
                isloggedIn = await loginController.fn_loginUser(user, password);

                if (isloggedIn == true)
                {
                    LoginResponseModel md = new LoginResponseModel();
                    md = loginController.GetDataAPI();

                    

                    if (md.token_id != "null" ) {
                        //System.Diagnostics.Debug.WriteLine(_id.Length);

                        //MessageBox.Show(md.infoMsg, "Bienvenido", MessageBoxButton.OK, MessageBoxImage.Information);
                        AppConfig.SetUserSetting("TokenApp", md.token_id);
                        AppConfig.SetUserSetting("UserApp", md.user);
                        AppConfig.SetUserSetting("RoleApp", md.role_user);
                        AppConfig.SetUserSetting("MailApp", md.mail);
                       
                        frm_initialScreen fm = new frm_initialScreen();
                        Admin admin = new Admin();

                        ///
                        SqlConnection sc1 = Conexion.sc();
                        sc1.Open();
                        Md5 md5 = new Md5();
                        
                        String consulta = "select * from cuenta as c inner join usuarios as u on c.id_usuario = u.idusuario where c.u_name ='"+user+"' and c.u_pass ='"+md5.fn_MD5Builder(password.Trim()) + "'";
                        
                        SqlCommand comando=new SqlCommand(consulta, sc1);
                        SqlDataAdapter da = new SqlDataAdapter(comando);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        //MessageBox.Show(dt.Rows[0][0].ToString(), "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                        ///
                        if (dt.Rows[0][0].ToString() != null)
                        {
                            if (dt.Rows[0][0].ToString().Equals("1")){

                                admin.Show();
                            }
                            else
                            {
                                fm.Show();
                            }
                        }

                        sc1.Close();
                        this.Close();

                    } else {
                        MessageBox.Show(md.infoMsg, "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                        
                    }
                }
                else
                {
                    MessageBox.Show("Usuario y/o clave invalidas", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
        }

        private void txt_username_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registro rg = new Registro();
            this.Close();
            rg.Show();
        }
        //fin btn
    }
    //fin class
}
//fin annotation