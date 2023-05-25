using PdfiumViewer.Core;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace TurismoSV_client.views.general
{
    /// <summary>
    /// Interaction logic for frm_pdfView.xaml
    /// </summary>
    public partial class frm_pdfView : Window
    {
        protected MemoryStream pdfData = null;
        public void fn_SetMemoryStreamPDF(MemoryStream pdfResource)
        {
            pdfData = pdfResource;
        }
          
        public frm_pdfView()
        {
            InitializeComponent();

            if (pdfData != null) {
                PdfDocument document = PdfDocument.Load(pdfData);

                // Asignar el documento al objeto PdfRenderer "pdfViewer"
                pdfViewer.Document = document;
            }
           
        }
    }
}
