using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Semana7SQLite.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace Semana7SQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> tablaEstudiante;
        public ConsultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
            Datos();
        }

       
       public async void Datos()
        {
            var Resultado = await con.Table<Estudiante>().ToListAsync();
            tablaEstudiante = new ObservableCollection<Estudiante>(Resultado);
            ListaEstudiantes.ItemsSource = tablaEstudiante;
        }

        private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Estudiante)e.SelectedItem;
            var item = Obj.Id.ToString();
            var Idseleccionado = Convert.ToInt32( item);
            var nombre = Obj.Nombre;
            try
            {
                Navigation.PushAsync(new Elemento(Idseleccionado, nombre));

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}