using DatosAbiertos.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Net.Http;
using System.IO;
using System.Windows;

namespace DatosAbiertos.ViewModel
{
    public class MainViewModel
    {
        private ObservableCollection<Directorio> directorios;

        public ObservableCollection<Directorio> Directorios
        {
            get { return directorios; }
            set { directorios = value; }
        }

        public async void LeerDirectorios()
        {
            HttpClient httpClient = new HttpClient();
            Stream stream = await httpClient.GetStreamAsync("http://www.datosabiertos.jcyl.es/web/jcyl/risp/es/otros/general/1284166186527.csv");

            if (stream != null)
            {
                TextReader reader = new StreamReader(stream);

                CsvReader csvReader = new CsvReader(reader);
                try
                {
                    while (csvReader.Read())
                    {
                        String nombreDirectorio = csvReader.GetField<String>("Titulo");
                        if (!String.IsNullOrEmpty(nombreDirectorio))
                        {
                            directorios.Add(new Directorio()
                            {
                                NombreDirectorio = nombreDirectorio
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("No se puede acceder al servidor");
            }
            
        }
    }
}
