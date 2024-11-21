using Entidades;
using Logica;
using Persistencia;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PRUEBA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceRol serviceRol = new ServiceRol();
        ServiceUser ServiceUser = new ServiceUser();
        ServiceIncidente serviceIncidente = new ServiceIncidente();
       
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            // Rol rol = new Rol();

            // rol.NombreRol = txt2.Text;

            //    var message = serviceRol.Guardar(rol);
            //    MessageBox.Show(message);
            // var message = serviceRol.Guardar(rol);
            // MessageBox.Show(message);
            string num = serviceIncidente.MostrarNumeroIncidente(7).ToString();
            int prueba = int.Parse(num[0].ToString());
            txt1.Text = prueba.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string idRol = txt3.Text;
            //var message = serviceRol.Eliminar(idRol);
            //MessageBox.Show(message);


        }

        private void guaradarusu_Click_1(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();
            //usuario.IdUsuario = txt1.Text;
            usuario.NombreUsuario = txt2.Text;
            usuario.Contrasenha = txt3.Text;
            
            var message = ServiceUser.Guardar(usuario);
            MessageBox.Show(message);

        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            RolRepositorio rolRepositorio = new RolRepositorio();
            Medico IdRol = new Medico();
            
            MessageBox.Show(IdRol.FechaNacimiento.ToString());
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario= new Usuario();
            //usuario.IdUsuario = txt1.Text;
           
            UsuarioRepositorio userRepository = new UsuarioRepositorio();
            usuario = userRepository.ConsultarId(usuario.IdUsuario);
            MessageBox.Show(usuario.NombreUsuario +usuario.Contrasenha );
            
            
            
        }

        private void dvg_Loaded(object sender, RoutedEventArgs e)
        {
        //    ServiceSesionECG serviceMedic = new ServiceSesionECG();
        //    datagriv.ItemsSource = serviceMedic.ConsultarTodo().DefaultView;
        }

        private void btnGuardarIncidente_Click(object sender, RoutedEventArgs e)
        {
            Incidentes incidente = new Incidentes();
            incidente.Descripcion = txtDescripcion.Text;
            DateTime fecha = fechaHora.SelectedDate.HasValue ? fechaHora.SelectedDate.Value : DateTime.Now.Date;
            DateTime fechaHoraActual = DateTime.Now;
            fechaHoraActual = fecha.Add(DateTime.Now.TimeOfDay);
            incidente.FechaHoraIncidente = fechaHoraActual;
            incidente.IdSesionECG = int.Parse(txtIdSesion.Text);


            var message = serviceIncidente.Guardar(incidente);
            MessageBox.Show(message);

        }
    }
}