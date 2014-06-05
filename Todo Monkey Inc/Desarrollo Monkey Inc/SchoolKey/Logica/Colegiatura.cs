using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    class Colegiatura
    {
        int idColegiatura, idAlumno, abono, total;
        DateTime fechaPago;

        public int IdColegiatura
        {
            get { return idColegiatura; }
            set { idColegiatura = value; }
        }

        public int IdAlumno
        {
            get { return idAlumno; }
            set { idAlumno = value; }
        }

        public int Abono
        {
            get { return abono; }
            set { abono = value; }
        }
        
        public int Total
        {
            get { return total; }
            set { total = value; }
        }

        public DateTime FechaPago
        {
            get { return fechaPago; }
            set { fechaPago = value; }
        }
    }
}
