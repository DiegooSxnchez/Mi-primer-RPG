using System;

namespace JuegoRpg
{
    public class Pocion
    {
        public string Nombre{get; private set;}
        public int Curacion{get;private set;}

        public Pocion(string Nombre,int Curacion)
        {
            this.Nombre=Nombre;
            this.Curacion=Curacion;
        }
    }
}