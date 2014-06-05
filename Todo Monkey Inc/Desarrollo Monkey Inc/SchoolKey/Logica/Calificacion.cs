using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    class Calificacion
    {
        int idCalificacion, idAlumno, idMateria, evaluacion1, evaluacion2, evaluacion3, promedioFinal, promedioGeneral;
        string aprovado;

        public int IdCalificacion
        {
            get { return idCalificacion; }
            set { idCalificacion = value; }
        }

        public int IdAlumno
        {
            get { return idAlumno; }
            set { idAlumno = value; }
        }

        public int IdMateria
        {
            get { return idMateria; }
            set { idMateria = value; }
        }

        public int Evaluacion1
        {
            get { return evaluacion1; }
            set { evaluacion1 = value; }
        }

        public int Evaluacion2
        {
            get { return evaluacion2; }
            set { evaluacion2 = value; }
        }

        public int Evaluacion3
        {
            get { return evaluacion3; }
            set { evaluacion3 = value; }
        }

        public int PromedioFinal
        {
            get { return promedioFinal; }
            set { promedioFinal = value; }
        }

        public int PromedioGeneral
        {
            get { return promedioGeneral; }
            set { promedioGeneral = value; }
        }

        public string Aprovado
        {
            get { return aprovado; }
            set { aprovado = value; }
        }

    }
}
