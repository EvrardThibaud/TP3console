using System;
using TP3console.Models.EntityFramework;
using System.Linq;

namespace TP3console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new FilmsDBContext())
            {
                Film titanic = ctx.Films.First(f => f.Nom.Contains("Titanic"));

                titanic.Description = "Un bateau échoué. Date : " + DateTime.Now;

                int nbchanges = ctx.SaveChanges();

                Console.WriteLine("Nombre d'enregistrements modifiés ou ajoutés : " + nbchanges);

            }
            Console.ReadKey();

        }
    }
}