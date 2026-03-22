using System;

namespace JuegoRpg
{
    public class Enemigo
    {
        public string ? Nombre{get; private set;}
        public int Vida{get; set;}
        public Enemigo(string Nombre,int Vida)
        {
            this.Nombre=Nombre;
            this.Vida=Vida;
            
        }
        public void RecibirDaño(int daño)
        {
            Vida-=daño;
            if(Vida<=0)
            {
                Vida=0;
            }
        }
        public void Atacar(Jugador jugador, int Ataque)
        {
            Console.WriteLine($"{Nombre} Lanza un ataque con daño de {Ataque}");
            jugador.RecibirDaño(Ataque);
            Console.WriteLine($"Vida Restante de {jugador.Nombre}: {jugador.Vida}");
            if(jugador.Vida<=0)Console.WriteLine($"{jugador.Nombre} HA MUERTO");
        }
        public void Curarse (Pocion pocion)
        {
            Vida+=pocion.Curacion;
            Console.WriteLine($"{Nombre} ha usado una pocion de curacion\nVida de {Nombre}: {Vida}");
        }
    }
}