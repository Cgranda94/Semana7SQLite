using System;
using System.Collections.Generic;
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
    public partial class Elemento : ContentPage
    {
        public int idSel;
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> borrar;
        IEnumerable<Estudiante> actualizar;
        public Elemento(int id, string nombre)
        {
            InitializeComponent();
            idSel = id;
            con = DependencyService.Get<Database>().GetConnection();
            txtNombre.Text = nombre;

        }
        public static IEnumerable<Estudiante> borrar1(SQLiteConnection db, int id) {
            return db.Query<Estudiante>("Delete from Estudiante Where id = ?", id);

        }
        
        public static IEnumerable<Estudiante> actualizar1(SQLiteConnection db, int id, string nombre, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("Update Estudiante set Nombre =?, Usuario =?, Contrasenia =? where Id =?", nombre, usuario, contrasena, id);
        }
        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var datebasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"uisrael.db3");
                var db = new SQLiteConnection(datebasePath);
                actualizar = actualizar1(db, idSel, txtNombre.Text, txtUsuario.Text, txtContrasenia.Text);
                DisplayAlert("Mensaje", "Actualizado", "ok");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var datebasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(datebasePath);
            borrar = borrar1(db, idSel);
            DisplayAlert("Mensaje", "Eliminado", "ok");
        }
    }
}