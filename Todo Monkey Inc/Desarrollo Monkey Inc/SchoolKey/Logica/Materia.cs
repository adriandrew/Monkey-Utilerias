using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    class Materia
    {
        int idMateria, idProfesor, idNivelAcademico, idAlumno;
        string nombre, ciclo;

        public int IdAlumno
        {
            get { return idAlumno; }
            set { idAlumno = value; }
        }

        public string Ciclo
        {
            get { return ciclo; }
            set { ciclo = value; }
        }

        public int IdMateria
        {
            get { return idMateria; }
            set { idMateria = value; }
        }

        public int Idprofesor
        {
            get { return idProfesor; }
            set { idProfesor = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int IdNivelAcademico
        {
            get { return idNivelAcademico; }
            set { idNivelAcademico = value; }
        }
    }
}
