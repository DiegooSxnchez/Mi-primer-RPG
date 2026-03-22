using System;

namespace JuegoRpg
{
    public class Arma
    {
        public string ? Nombre{get; set;}
        public int Daño{get; set;}
        public Arma(string Nombre,int Daño)
        {
            this.Nombre=Nombre;
            this.Daño=Daño;
        }
        public Arma(){}
        public void InformacionArma()
        {
            Console.WriteLine("----INFORMACION ARMA----");
            Console.WriteLine($"Arma: {Nombre}\nDaño: {Daño}");
        }
    }
}