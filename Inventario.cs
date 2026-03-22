using System;

namespace JuegoRpg
{
    public class Inventario
    {
        public List<Arma> ListaArmas{get; set;}
        

        public Inventario(List<Arma> ListaArmas)
        {
            this.ListaArmas=ListaArmas;
        
        }
        public Inventario()
        {
            ListaArmas=new List<Arma>();
        }

        public void MostrarInventario()
        {
            foreach(Arma n in ListaArmas)
            {
                Console.WriteLine("--------------------");
                n.InformacionArma();
                Console.WriteLine("--------------------");
            }
        }
        public void AñadirArma(Arma arma)
        {
            ListaArmas.Add(arma);
        }
        public void EliminarArma(Arma arma)
        {
            if(ListaArmas.Count==0)Console.WriteLine("¡¡iNVENTARIO VACIO!!");
            ListaArmas.Remove(arma);
        }
    }
}