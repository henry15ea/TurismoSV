using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurismoSV_client.UitlsClass
{
    internal class saveFileDialogFuncs
    {

        public void fn_saveFile(MemoryStream dataReport)
        {
            //funcion que se encarga de mostrar un dialogo para guardar el reporte generado
            // Mostrar cuadro de diálogo de guardar
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
            saveFileDialog.Title = "Guardar como";
           

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {


                // User clicked "Save" 
                string filePath = saveFileDialog.FileName;
                // Do something with the file path
                FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
                dataReport.WriteTo(fileStream);
                fileStream.Close();
                this.fn_OpenFile(filePath);

            }
            else
            {
                // User clicked "Cancel" or closed the dialog
                // Handle accordingly 
            }
        }

        protected void fn_OpenFile(String filePath) {
            //funcion que se encarga de abrir el archivo luego de ser guardado
            // Obtener la extensión del archivo
            string extension = Path.GetExtension(filePath);

            // Verificar si la extensión del archivo es compatible con el programa predeterminado de Windows para PDF
            if (extension.ToLower() == ".pdf")
            {
                // Iniciar proceso para abrir archivo en programa predeterminado de Windows para PDF
                System.Diagnostics.Debug.WriteLine(filePath);
                //Process.Start(filePath);
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = $"/c start \"\" \"{filePath}\" exit";
                process.Start();

                // Wait for the process to exit
                process.WaitForExit();

                // Close the process
                process.Close();


                /*
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = $"/k start \"\" \"{filePath}\"";
                process.Start();

                // Wait for the process to exit
                process.WaitForExit();

                // Close the process
                process.Close();
                */
            }
        }
    }//end class
}//end namespaces
