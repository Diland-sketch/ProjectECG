﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal interface ICrud<T>
    {
        string Guardar(T entity);
        List<T> ConsultarTodo();
        T ConsultarId(string id);
        string Actualizar(T entity);
        string Eliminar(string id);
    }
}
