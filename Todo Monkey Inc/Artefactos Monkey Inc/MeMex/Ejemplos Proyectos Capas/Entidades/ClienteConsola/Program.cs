using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace ClienteConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Conferencia conf = new Conferencia();
            conf.Nombre = "Drogas";
            conf.Lugar = "ITSON";
            conf.Conferencista = "Andrew";
            conf.Fecha = DateTime.Now;
            conf.Tipo = Tipo.Publica;
            conf.Id = 2;

            conf.Eliminar();

        }
    }
}
