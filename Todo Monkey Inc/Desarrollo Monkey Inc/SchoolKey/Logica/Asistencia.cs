using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    class Asistencia
    {
        int idAsistencia, idMateria, idAlumno;
        string asistencia, falta, justificada;
        DateTime fecha;

        public int IdAsistencia
        {
            get { return idAsistencia; }
            set { idAsistencia = value; }
        }

        public int IdMateria
        {
            get { return idMateria; }
            set { idMateria = value; }
        }

        public int IdAlumno
        {
            get { return idAlumno; }
            set { idAlumno = value; }
        }

        public string Asistencia1
        {
            get { return asistencia; }
            set { asistencia = value; }
        }

        public string Falta
        {
            get { return falta; }
            set { falta = value; }
        }

        public string Justificada
        {
            get { return justificada; }
            set { justificada = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
    }
        
}
