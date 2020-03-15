using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Business
{
    public class Base
    {
        public int IdBase { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Se excedio la longitud")]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Se excedio la longitud")]
        public string Region { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Se excedio la longitud")]
        public string Ciudad { get; set; }

        [Required]
        public string Direccion { get; set; }
        
        [Required]
        [MaxLength(20, ErrorMessage = "Se excedio la longitud")]
        public string NumeroTelefono { get; set; }


        public void getInfo()
        {
            Console.WriteLine("idBase: " + this.IdBase);
            Console.WriteLine("Nombre: " + this.Nombre);
            Console.WriteLine("Region: " + this.Region);
            Console.WriteLine("Ciudad: " + this.Ciudad);
            Console.WriteLine("Direccion: " + this.Direccion);
            Console.WriteLine("NumeroTelefono: " + this.NumeroTelefono);
        }

        public Base SolicitarData()
        {
            Console.WriteLine("Nombre: ");
            var n = Console.ReadLine();
            this.Nombre = n;
            return this;
        }


    }
}
