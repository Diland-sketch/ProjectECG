using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GUI.Utilities
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        //clase base para todas las clases de ViewModel.Proporciona soporte para notificaciones de cambios de propiedad.
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
