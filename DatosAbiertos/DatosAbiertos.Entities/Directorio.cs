using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosAbiertos.Entities
{
    public class Directorio
    {
        private String urlDirectorio;

        public String UrlDirectorio
        {
            get { return urlDirectorio; }
            set { urlDirectorio = value; }
        }

        private String nombreDirectorio;

        public String NombreDirectorio
        {
            get { return nombreDirectorio; }
            set { nombreDirectorio = value; }
        }

        private ObservableCollection<String> formatosFichero;

        public ObservableCollection<String> FormatosFichero
        {
            get { return formatosFichero; }
            set { formatosFichero = value; }
        }
    }
}
