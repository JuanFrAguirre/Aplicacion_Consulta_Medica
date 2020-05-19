using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Stream_18_05
{
    class Medico
    {

        // -------------------------------------------------
        //  propiedades autoimplementadas

        public int Matricula { get; set; }
        public string Nombre { get; set; }
        public int Genero { get; set; }
        public int Especialidad { get; set; }
        public double Precio { get; set; }
        public DateTime Fecha { get; set; }
        public string FechaString { get; set; }

        // -------------------------------------------------
        //  constructores

        public Medico()
        {
            Matricula = 0;
            Nombre = "";
            Genero = 0;
            Especialidad = 0;
            Precio = 0;
            Fecha = DateTime.Today;
        }

        public Medico(int matricula, string nombre, int genero, int especialidad, double precio, string fecha)
        {
            Matricula = matricula;
            Nombre = nombre;
            Genero = genero;
            Especialidad = especialidad;
            Precio = precio;
            FechaString = fecha;
        }


        // -------------------------------------------------
        //  metodos

        public string MostrarDatos()
        {
            string generoSeleccionado;
            string especialidadSeleccionada;

            switch (Genero)
            {
                case 1: 
                    generoSeleccionado = "Masculino";
                    break;
                case 2:
                    generoSeleccionado = "Femenino";
                    break;                
                default: generoSeleccionado = "No binario";
                    break;
            }


            switch (Especialidad)
            {
                case 1:
                    especialidadSeleccionada = "Cardiologia";
                    break;
                case 2:
                    especialidadSeleccionada = "Odontologia";
                    break;
                case 3:
                    especialidadSeleccionada = "Pediatria";
                    break;
                default:
                    especialidadSeleccionada = "No seleccionado";
                    break;
            }




            string mensaje = $"---------------------------------\n" +
                $"Matricula: {Matricula}\n" +
                $"Nombre: {Nombre}\n" +
                $"Genero: {generoSeleccionado}\n" +
                $"Especialidad: {especialidadSeleccionada}\n" +
                $"Precio: {Precio}\n" +
                $"Fecha: {FechaString}";
            return mensaje;
        }

    }
}
