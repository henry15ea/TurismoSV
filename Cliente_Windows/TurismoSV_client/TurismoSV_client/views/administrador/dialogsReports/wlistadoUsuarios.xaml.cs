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
using System.Windows.Shapes;
using TurismoSV_client.controllers.adm;
using TurismoSV_client.models.reportModels;
using TurismoSV_client.UitlsClass.AppConfig;

namespace TurismoSV_client.views.administrador.dialogsReports
{
    /// <summary>
    /// Interaction logic for wlistadoUsuarios.xaml
    /// </summary>
    public partial class wlistadoUsuarios : Window
    {
        public wlistadoUsuarios()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_generaReport_Click(object sender, RoutedEventArgs e)
        {
            try {
                listadoUsuariosModel model = new listadoUsuariosModel();

                r_listadoUsuariosByFiltroController reporte = new r_listadoUsuariosByFiltroController();

                if (string.IsNullOrEmpty(txt_nombreFiltro.Text.Trim()))
                {
                    model.Username = AppConfig.GetUserSetting("UserApp");
                    model.filtro = "ALL";
                }
                else if (!String.IsNullOrEmpty(txt_nombreFiltro.Text.Trim())){

                    model.Username = AppConfig.GetUserSetting("UserApp");
                    model.filtro = txt_nombreFiltro.Text.Trim();
                }

                reporte.fn_GetUsuariosByNombreReport(model);
                this.Close();
            }
            catch (Exception ex) { 
                MessageBox.Show("Fallo al tratar de construir el reporte");
            }
        }
    }
}
