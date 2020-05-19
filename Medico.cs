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


        public string GetGenero()
        {
            switch (Genero)
            {
                case 1: return "Masculino";
                case 2: return "Femenino";
                default: return "No binario";
            }
        }

        public string CalcularEspecialidad(int genero)
        {
            switch (genero)
            {
                case 1: return "Cardiologia";
                case 2: return "Odontologia";
                default: return "Pediatria";
            }
        }

        public string MostrarDatos()
        {
            string mensaje = $"REGISTRO EXITOSO!\n" +
                $"---------------------------------\n" +
                $"Datos del registro:\n" +
                $"Matricula: {Matricula}\n" +
                $"Nombre: {Nombre}\n" +
                $"Genero: {GetGenero()}\n" +
                $"Especialidad: {CalcularEspecialidad(Especialidad)}\n" +
                $"Precio: {Precio}\n" +
                $"Fecha: {FechaString}\n" +
                $"---------------------------------";
            return mensaje;
        }

        public static double ElevarAlCuadrado(double numero, int potencia)
        {
            return Math.Pow(numero, potencia);
        }

    }
}
