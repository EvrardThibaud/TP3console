using System;
using TP3console.Models.EntityFramework;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TP3console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new FilmsDBContext())
            {
                /*ctx.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;*/


                Film titanic = ctx.Films.AsNoTracking().First(f => f.Nom.Contains("Titanic"));

                /*Film titanic = (from f in ctx.Films
                                where f.Nom == "Titanic"
                                select f).First();*/


                titanic.Description = "Un bateau échoué. Date : " + DateTime.Now;

                int nbchanges = ctx.SaveChanges();

                Console.WriteLine("Nombre d'enregistrements modifiés ou ajoutés : " + nbchanges);

            }
            Console.ReadKey();

        }
    }
}