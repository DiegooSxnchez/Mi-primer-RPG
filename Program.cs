using System;
using System.Text.Json;
using System.IO;

namespace JuegoRpg
{
    public class Program
    {
        static void Main()
        {
            Inventario inventario= new Inventario();
            Jugador jugador=new Jugador("Diego",100,0,20,inventario);
            jugador.AñadirArma(new Arma("Daga",50));
            jugador.AñadirArma(new Arma("Sable",90));
            jugador.AñadirArma(new Arma("Katana",100));

            Enemigo enemigo=new Enemigo("Voldemort",100);

            Pocion pocion=new Pocion("Pocion de curacion", 20);
            
            bool SalirDelMenu=true;
            Console.WriteLine("----OPCIONES----");

            while(SalirDelMenu)
            {
                Console.WriteLine("1. Ver jugador");
                Console.WriteLine("2. Añadir arma");
                Console.WriteLine("3. Guardar");
                Console.WriteLine("4. Cargar");
                Console.WriteLine("5. Salir y Jugar");
                Console.WriteLine("6. Equipar Armas");

                try
                {
                    int Respuesta=Convert.ToInt32(Console.ReadLine());
                    while(Respuesta>6||Respuesta<1)
                    {
                        Console.WriteLine("Respuesta incorrecta");
                        Respuesta=Convert.ToInt32(Console.ReadLine());
                    }
                    switch(Respuesta)
                    {
                        case 1:
                        jugador.InformacionJugador();
                        break;

                        case 2:
                        Console.WriteLine("Añade el nombre y daño de tu nueva arma:");
                        Console.Write("Nombre: ");
                        string  nuevaArma=Console.ReadLine() ?? "SinNombre";
                        Console.Write("Daño: ");
                        int DañoArma=Convert.ToInt32(Console.ReadLine());
                        jugador.AñadirArma(new Arma(nuevaArma,DañoArma));
                        jugador.InventarioJugador.MostrarInventario();
                        Console.WriteLine("Tu nueva arma se ha guardado correctamente");
                        break;

                        case 3:
                        Console.WriteLine("Guardando Juego...");
                        string GurdarJuego=JsonSerializer.Serialize(jugador);
                        File.WriteAllText("JuegoRPGGuardar.json",GurdarJuego);
                        Console.WriteLine("Juego guardado con exito");
                        break;

                        case 4:
                        Console.WriteLine("Cargando tu partida...");
                        if(File.Exists("JuegoRPGGuardar.json"))
                        {
                            string Jugador1=File.ReadAllText("JuegoRPGGuardar.json");
                            jugador=JsonSerializer.Deserialize<Jugador>(Jugador1)!;
                            Console.WriteLine("Juego Cargado con exito");
                        }
                        else Console.WriteLine("No tienes ningun juego guard6ado guarda primero");
                        break;
                    
                        case 5:
                        Console.WriteLine("Saliendo del apartado de opciones...");
                        Console.WriteLine("Entrando al juego..... ---PREPARATE---");
                        SalirDelMenu=false;
                        break;

                        case 6:
                        jugador.EquiparArma();
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Eso no es un numero");
                }
            }
            bool TerminarJuego=true;
            while(TerminarJuego)
            {
                Random random=new Random();
                Console.WriteLine("Elige una opcion:");
                Console.WriteLine("1.Atacar");
                Console.WriteLine("2.Curarse");
                Console.WriteLine("3.Retirarse");
                int Respuesta1=Convert.ToInt32(Console.ReadLine());

                int RespuestaEnemiga=random.Next(1,3);
                int daño=random.Next(40,61);

                switch(Respuesta1)
                {
                    case 1:
                    Console.WriteLine("Opcion 1 elegida. Comenzando Ataque...");
                    jugador.Atacar(enemigo);
                    if(enemigo.Vida<=0)
                    {
                        return;
                    }
                    break;

                    case 2:
                    jugador.Curarse(pocion);
                    break;

                    case 3:
                    Console.WriteLine("Retirandose...");
                    return;
                }

                switch(RespuestaEnemiga)
                {
                    case 1:
                    Console.WriteLine($"{enemigo.Nombre} eligio la opcion 1...");
                    enemigo.Atacar(jugador,daño);
                    if(jugador.Vida<=0)
                    {   
                        return;
                    }
                    break;

                    case 2:
                    Console.WriteLine($"{enemigo.Nombre} eligio la opcion 2...");
                    enemigo.Curarse(pocion);
                    break;
                }
            } 
        }
    }
}
