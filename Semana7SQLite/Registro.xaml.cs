using Semana7SQLite.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana7SQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();

        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            
            try
            {
                var datosRegistro = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contrasenia = txtContrasenia.Text };
                con.InsertAsync(datosRegistro);
                DisplayAlert("Mensaje", "Ingreso Correcto", "Cerrar");
                txtNombre.Text = "";
                txtUsuario.Text = "";
                txtContrasenia.Text = "";
                

            }
            catch (Exception ex)
            {
                DisplayAlert("Mensaje", ex.Message, "Cerrar");

            }

        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }

        
    }
}