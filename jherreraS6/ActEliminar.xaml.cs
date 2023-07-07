using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jherreraS6
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActEliminar : ContentPage
	{
        private string URL = "http://192.168.10.39:8080/uisrael/post.php";
        public ActEliminar(estudiante datos)
		{
			InitializeComponent ();
            txtCodigo.Text = datos.codigo.ToString();
            txtNombre.Text = datos.nombre.ToString();
            txtApellido.Text = datos.apellido.ToString();
            txtEdad.Text = datos.edad.ToString();

        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            var datos = new System.Collections.Specialized.NameValueCollection();
            try
            {

                datos.Add("codigo", txtCodigo.Text);
                datos.Add("nombre", txtNombre.Text);
                datos.Add("apellido", txtApellido.Text);
                datos.Add("edad", txtEdad.Text);

                cliente.UploadValues(URL + "?codigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "PUT", datos);
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "Cerrar");

            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            var datos = new System.Collections.Specialized.NameValueCollection();
            try
            {

                datos.Add("codigo", txtCodigo.Text);
                cliente.UploadValues(URL + "?codigo=" + txtCodigo.Text, "DELETE", datos);
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "Cerrar");
            }
        }
    }
}