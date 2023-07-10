using SkyNetModel.DAL;
using SkyNetModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerSkyNet
{
    public class Program
    {
        private static SkyNetDAL dal = new SkyNetDAL();

        static void Main(string[] args)
        {
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("===== Menú Principal =====");
                Console.WriteLine("1. Ingresar Eliminador");
                Console.WriteLine("2. Buscar Eliminador");
                Console.WriteLine("3. Mostrar Eliminadores");
                Console.WriteLine("4. Destruir SkyNet");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        IngresarEliminador();
                        break;
                    case "2":
                        BuscarEliminador();
                        break;
                    case "3":
                        MostrarEliminadores();
                        break;
                    case "4":
                        DestruirSkyNet();
                        break;
                    case "5":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void IngresarEliminador()
        {
            Console.WriteLine("===== Ingreso de Eliminador =====");

            Eliminador nuevoEliminador = new Eliminador();

            bool numeroSerieValido = false;
            while (!numeroSerieValido)
            {
                Console.Write("Número de Serie (7 caracteres): ");
                string numeroSerie = Console.ReadLine();

                if (numeroSerie.Length != 7)
                {
                    Console.WriteLine("El Número de Serie debe tener 7 caracteres.");
                }
                else
                {
                    nuevoEliminador.NumeroSerie = numeroSerie;
                    numeroSerieValido = true;
                }
            }

            bool tipoValido = false;
            while (!tipoValido)
            {
                Console.Write("Tipo (T-1, T-800, T-1000, T-3000): ");
                string tipo = Console.ReadLine();

                if (tipo == "T-1" || tipo == "T-800" || tipo == "T-1000" || tipo == "T-3000")
                {
                    nuevoEliminador.Tipo = tipo;
                    tipoValido = true;
                }
                else
                {
                    Console.WriteLine("El Tipo ingresado es inválido. Por favor, ingrese un Tipo válido.");
                }
            }

            bool prioridadBaseValida = false;
            while (!prioridadBaseValida)
            {
                Console.Write("Prioridad Base (1-5): ");
                string prioridadBaseStr = Console.ReadLine();

                if (int.TryParse(prioridadBaseStr, out int prioridadBase))
                {
                    if (prioridadBase >= 1 && prioridadBase <= 5)
                    {
                        nuevoEliminador.PrioridadBase = prioridadBase;
                        prioridadBaseValida = true;
                    }
                    else
                    {
                        Console.WriteLine("La Prioridad Base debe estar entre 1 y 5.");
                    }
                }
                else
                {
                    Console.WriteLine("El valor ingresado para la Prioridad Base es inválido. Por favor, ingrese un número válido.");
                }
            }

            Console.Write("Objetivo: ");
            nuevoEliminador.Objetivo = Console.ReadLine();

            bool anioDestinoValido = false;
            while (!anioDestinoValido)
            {
                Console.Write("Año de Destino (mayor a 1997 y menor a 3000): ");
                string anioDestinoStr = Console.ReadLine();

                if (int.TryParse(anioDestinoStr, out int anioDestino))
                {
                    if (anioDestino > 1997 && anioDestino < 3000)
                    {
                        nuevoEliminador.AnioDestino = anioDestino;
                        anioDestinoValido = true;
                    }
                    else
                    {
                        Console.WriteLine("El Año de Destino debe ser mayor a 1997 y menor a 3000.");
                    }
                }
                else
                {
                    Console.WriteLine("El valor ingresado para el Año de Destino es inválido. Por favor, ingrese un número válido.");
                }
            }

            dal.AgregarEliminador(nuevoEliminador);
        }

        static void BuscarEliminador()
        {
            Console.WriteLine("===== Búsqueda de Eliminador =====");

            Console.Write("Ingrese el modelo: ");
            string modelo = Console.ReadLine();

            Console.Write("Ingrese el año de destino: ");
            int anioDestino = int.Parse(Console.ReadLine());

            List<Eliminador> eliminadores = dal.ObtenerEliminadores();
            bool encontrado = false;

            foreach (Eliminador eliminador in eliminadores)
            {
                if (eliminador.Tipo == modelo && eliminador.AnioDestino == anioDestino)
                {
                    Console.WriteLine($"{eliminador.NumeroSerie} - {eliminador.Tipo} - {eliminador.Objetivo}");
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontraron Eliminadores con el modelo y año de destino especificados.");
            }
        }

        static void MostrarEliminadores()
        {
            Console.WriteLine("===== Eliminadores Registrados =====");

            List<Eliminador> eliminadores = dal.ObtenerEliminadores();

            foreach (Eliminador eliminador in eliminadores)
            {
                Console.WriteLine($"{eliminador.NumeroSerie} - {eliminador.Tipo} - {eliminador.Objetivo}");
            }
        }

        static void DestruirSkyNet()
        {
            Console.WriteLine("SkyNet ha sido destruido");
            dal = new SkyNetDAL();
        }
    }
}