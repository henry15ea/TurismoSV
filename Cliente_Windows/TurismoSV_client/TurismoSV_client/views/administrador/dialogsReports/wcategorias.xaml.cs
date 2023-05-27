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
using TurismoSV_client.controllers.adm;
using TurismoSV_client.controllers.categoriasController;
using TurismoSV_client.models.AppModel.categoriasModel;
using TurismoSV_client.models.reportModels;
using TurismoSV_client.UitlsClass.AppConfig;

namespace TurismoSV_client.views.administrador.dialogsReports
{
    /// <summary>
    /// Interaction logic for wcategorias.xaml
    /// </summary>
    public partial class wcategorias : Window
    {
        public wcategorias()
        {
            InitializeComponent();
            this.getDataCategoriesAsync();
        }

        private async Task getDataCategoriesAsync()
        {
            bool resp = false;

            categoriasController ct = new categoriasController();
            resp = await ct.fn_GetCategoryList();

            if (resp == true)
            {
                //var cadata = ct.GetDataAPI();

                categoriasModel modelo = new categoriasModel();
                cmbx_listadoCategorias.Items.Clear();  

                foreach (var item in ct.DataResponse) { 
                    cmbx_listadoCategorias.Items.Add(item.Nombre.Trim());
                }
                cmbx_listadoCategorias.SelectedIndex = 0;

                System.Diagnostics.Debug.WriteLine("Respondio la api ");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("fallo en responder de la api ");
            }

        }

        private void PreviewTextInputHandler(object sender, TextCompositionEventArgs e)
        {
            //Solo permitir dígitos enteros
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

        private void cmbx_listadoCategorias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void btn_generaReport_Click(object sender, RoutedEventArgs e)
        {
            
            try {
                String selectedItem = cmbx_listadoCategorias.SelectedValue.ToString();
                categoriaListModels modelo = new categoriaListModels();
                r_paquetesByCategoria reporte = new r_paquetesByCategoria();
                //asignando datos
                modelo.CategoriaId = selectedItem.Trim();
                modelo.cantidadElementos = int.Parse(txt_numElements.Text.Trim());
                modelo.Username = AppConfig.GetUserSetting("UserApp");

                reporte.fn_GetPaquetesByCateggoryReport(modelo);

                this.Close();


            }
            catch(Exception) {
                MessageBox.Show("Hubo un problema al tratar de generar el reporte");
            } 
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }//end class
}//end namespaces
