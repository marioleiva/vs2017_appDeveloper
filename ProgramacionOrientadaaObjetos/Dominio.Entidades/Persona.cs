using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Persona
    {
        public DateTime FechaNacimiento { get; set; }
        public string Nombre { get; set; }
        public Sexo Sexo{ get; set; }
        public int Edad { get; set; }
        public static int NumeroPersonas { get; private set; } = 0;

        public void Saludar()
        {
            //Saludo usando caracteristicas antiguas
            Console.WriteLine("Hola me llamo " + this.Nombre + " tengo " + this.Edad + " años");
            //Manejando cadena de caracteres con las nuevas caracteristicas de C#
            Console.WriteLine($"Hola me llamo {this.Nombre} tengo {this.Edad} años");
        }
        public Persona()
        {
            Persona.NumeroPersonas++;
        }
        public override string ToString()
        {
            return $"Hola me llamo {this.Nombre} tengo {this.Edad} años";
        }
    }
    public enum Sexo
    {
        Hombre = 1,
        Mujer = 2
    }
}
