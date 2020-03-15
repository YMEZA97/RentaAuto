using System;
using Data.Repositories;
using Domain.Business;

namespace Data
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            BaseRepository b = new BaseRepository();

            var lista = b.GetAll();

            foreach (var item in lista)
            {
                item.getInfo();
            }

            Base ba = new Base();

            ba.SolicitarData();

            var existe = b.Exist("San Pedro Sula");

            if (existe)
            {
                Console.WriteLine("No se puede registrar la base, ya ha sido registrada");
            }
            else
            {
                b.Save(new Base { Nombre = "San Pedro Sula", Direccion = "SPS", Ciudad = "SPS", NumeroTelefono = "789456", Region = "Cortes" });
            }

            var infoagente = b.obtenerInfoAgente(5);
            Console.WriteLine(infoagente.NombreAgente);
            Console.WriteLine(infoagente.Ciudad);
            Console.WriteLine(infoagente.Salario);

        }
    }
}
