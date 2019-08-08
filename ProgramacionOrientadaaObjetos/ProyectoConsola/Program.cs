using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona persona = new Persona();
            persona.Nombre = "Katherine";
            persona.Edad = 26;
            persona.Sexo = Sexo.Mujer;

            var segundaPersona = new Persona()
            {
                Nombre = "Mario",
                FechaNacimiento = DateTime.Now.AddYears(-30),
                Edad = 30,
                Sexo = Sexo.Hombre
            };

            //persona.Saludar();
            //segundaPersona.Saludar();

            // Console.WriteLine($"Hay {Persona.NumeroPersonas} {persona.Saludar()} ");
            List<object> listaGenerica = new List<object>();
            listaGenerica.Add(Persona.NumeroPersonas);
            listaGenerica.Add(DateTime.Now);
            listaGenerica.Add(segundaPersona);
            listaGenerica.Add(persona);

            Console.WriteLine("Impresion por for normal");
            for (int i = 0; i < listaGenerica.Count; i++)
            {
                Console.WriteLine(listaGenerica.ElementAt(i));
            }

            Console.WriteLine("Impresion con iteradores");
            foreach (var objecto in listaGenerica)
            {
                Console.WriteLine(objecto);
            }

            Console.WriteLine("Impresion por linq");
            listaGenerica.ForEach(y => Console.WriteLine(y));

            Console.ReadKey();

        }

    }
}
