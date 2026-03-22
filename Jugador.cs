using JuegoRpg;

namespace JuegoRpg
{
    

    public class Jugador
    {
        public string ? Nombre{get;private set;}
        public int Vida{get; set;}
        public int Nivel{get;private set;}
        public int DañoBase{get;private set;}
        public int vidaLimite;
        public Inventario InventarioJugador{get;private set;}
        public Arma ? ArmaEquipada{get;private set;}
    
        public Jugador(string Nombre,int Vida,int Nivel,int DañoBase,Inventario inventarioJugador,Arma ? ArmaEquipada=null)
        {
            this.Nombre=Nombre;
            this.Vida=Vida;
            this.Nivel=Nivel;
            this.InventarioJugador=inventarioJugador ?? new Inventario();
            this.ArmaEquipada=ArmaEquipada;
            this.DañoBase=DañoBase;
            this.vidaLimite=Vida;
        }
        public Jugador() 
        {
            InventarioJugador=new Inventario();
        }
        public void InformacionJugador()
        {
            Console.WriteLine("----INFORMACION JUGADOR----");
            Console.WriteLine($"Arma equipada: {(ArmaEquipada!=null ? ArmaEquipada.Nombre: "Ninguna")}");
            Console.WriteLine($"-Nombre: {Nombre}\n-Vida: {Vida}\n-Nivel: {Nivel}");
            InventarioJugador.MostrarInventario();
        }
        public void AñadirArma(Arma arma)
        {
            InventarioJugador.AñadirArma(arma);
        } 
        public void RecibirDaño(int daño)
        {
            Vida-=daño;
            if(Vida<0)Vida=0;
        }
        public void SubirDeNivel()
        {
            Nivel++;
        }
        public void EquiparArma()
        {
            if(InventarioJugador.ListaArmas.Count==0)
            {
                Console.WriteLine("No tienes ni una arma equipada");
                return;
            }
            for(int i=0;i<=InventarioJugador.ListaArmas.Count-1;i++)
            {
                Console.WriteLine($"{i+1}.{InventarioJugador.ListaArmas[i].Nombre}");
            }
            bool NumeroCorrecto=true;
            Console.WriteLine("¿Que arma desea equipar?");
            int n1=Convert.ToInt32(Console.ReadLine());
            while(NumeroCorrecto)
            {
                if(n1>InventarioJugador.ListaArmas.Count||n1==0)
                {
                    Console.WriteLine("No tienes esa arma");
                    Console.WriteLine("Ingresa Un numero Correcto");
                    n1=Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    ArmaEquipada=InventarioJugador.ListaArmas[n1-1];
                    Console.WriteLine($"Haz equipada el arma: {ArmaEquipada.Nombre}");
                    NumeroCorrecto=false;
                }
            }
        }
        public void Atacar(Enemigo objetivo)
        {
            if(ArmaEquipada==null)
            {
                Console.WriteLine("Sin arma equipada");
                objetivo.RecibirDaño(DañoBase);
                Console.WriteLine($"-{objetivo.Nombre} le queda: {objetivo.Vida} puntos de vida-");
                if(objetivo.Vida<=0)Console.WriteLine($"{objetivo.Nombre} HA MUERTO");
            }
            else
            {
                Console.WriteLine($"--Tu personaje a lanzado un ataque de {ArmaEquipada?.Daño} puntos de daño--");
                objetivo.RecibirDaño(ArmaEquipada!.Daño);
                Console.WriteLine($"--Vida Restante del enemigo: {objetivo.Vida}");
                if(objetivo.Vida<=0)Console.WriteLine($"{objetivo.Nombre} HA MUERTO");
            }
        }
        public void Curarse(Pocion pocion)
        {
            Console.WriteLine("---¡Aplicando Pocion de curacion!--");
            int VidaACurar=Math.Min(vidaLimite-Vida,pocion.Curacion);
            Vida+=VidaACurar;
            Console.WriteLine($"Listo. Te has curado: {VidaACurar} puntos de vida\nVida: {Vida}");
        }
    }
}