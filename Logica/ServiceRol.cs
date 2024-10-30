using Persistencia;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Logica
{
    public class ServiceRol
    {
        RolRepositorio rolRepositorio = new RolRepositorio();

        public string Eliminar(string idRol)
        {
            return rolRepositorio.Eliminar(idRol);
        }

        public void CargarComboBox(ComboBox comboBox)
        {
            rolRepositorio.CargarComboBoxRol(comboBox);
        }

        public string Guardar(Rol rol)
        {
            return rolRepositorio.Guardar(rol);
        }
    }
}
