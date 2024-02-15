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
                Exo3Q4();
                Console.ReadKey();
            }

        }

        public static void Exo3Q4()
        {
            var ctx = new FilmsDBContext();

            Avi monAvi = new Avi();

            monAvi.Film = 3;
            monAvi.Utilisateur = 1;
            monAvi.Avis = "Jamais vu";
            monAvi.Note = (decimal)0.2;

            ctx.Add(monAvi);²

            ctx.SaveChanges();
        }

        public static void Exo3Q3()
        {
            /*Supprimer un film*/

            var ctx = new FilmsDBContext();


            var filmAModif = ctx.Films.Where(f => f.Nom == "L'armee des douze singes").First();

            foreach (var avi in ctx.Avis.Where(a => a.Film == filmAModif.Id))
            {
                ctx.Avis.Remove(avi);
            }

            ctx.Films.Remove(filmAModif);

            ctx.SaveChanges();


        }

        public static void Exo3Q2()
        {
            /*Modifier un film*/

            var ctx = new FilmsDBContext();

            int idDrame = ctx.Categories.Where(c => c.Nom == "Drame").First().Id;

            var filmAModif = ctx.Films.Where(f => f.Nom == "L'armee des douze singes").First();

            filmAModif.Categorie = idDrame;
            filmAModif.Description = "Il y avait douze singes ...";

            ctx.SaveChanges();

            Console.WriteLine( filmAModif.ToString());

        }

        public static void Exo3Q1()
        {
            /*Ajoutez-vous en tant qu’utilisateur*/

            Utilisateur moi = new Utilisateur();

            moi.Login = "evrardt";
            moi.Email = "thibaud.evrard@etu.univ-smb.fr";
            moi.Pwd = "password";

            var ctx = new FilmsDBContext();

            ctx.Add(moi);

            ctx.SaveChanges();

        }

        public static void Exo2Q9()
        {
            var ctx = new FilmsDBContext();


            foreach (var utilisateur in ctx.Utilisateurs.Where(u => (int)u.Id == ctx.Avis.Where(a => (double)a.Note == (double)ctx.Avis.Max(a => a.Note)).First().Utilisateur))

            {
                Console.WriteLine(utilisateur.ToString());

            }

        }
            

        public static void Exo2Q8()
        {
            var ctx = new FilmsDBContext();

            double noteMoyenne = (double)ctx.Avis.Where(a => a.Film == ctx.Films.First(f => f.Nom.ToLower() == "pulp fiction").Id).Average(a => (double?)a.Note);


            Console.WriteLine(noteMoyenne);


        }

        public static void Exo2Q7()
        {
            var ctx = new FilmsDBContext();

            foreach (var film in ctx.Films.Where(f => f.Nom.ToLower().StartsWith("le")))

            {
                Console.WriteLine(film.ToString());
            }

        }


        public static void Exo2Q6()
        {
            var ctx = new FilmsDBContext();

            double noteMin = (double)ctx.Avis.Min(a => a.Note);

            Console.WriteLine(noteMin);


        }


        public static void Exo2Q5()
        {
            var ctx = new FilmsDBContext();

            int nbCategorie = ctx.Categories.Count();

            Console.WriteLine(nbCategorie);
        }

        public static void Exo2Q4()
        {
            var ctx = new FilmsDBContext();


            foreach (var film in ctx.Films.Where(f => f.Categorie == ctx.Categories.First(c => c.Nom == "Action").Id))
                                            
            {
                Console.WriteLine(film.ToString());
            }
        }

        public static void Exo2Q3()
        {
            var ctx = new FilmsDBContext();
            foreach (var utilisateur in ctx.Utilisateurs.OrderBy(u => u.Login))
            {
                Console.WriteLine(utilisateur.ToString());
            }
        }


        public static void Exo2Q2()
        {
            var ctx = new FilmsDBContext();
            foreach (var utilisateur in ctx.Utilisateurs)
            {
                Console.WriteLine(utilisateur.Email);
            }
        }

        public static void Exo2Q1()
        {
            var ctx = new FilmsDBContext();
            foreach (var film in ctx.Films)
            {
                Console.WriteLine(film.ToString());
            }
        }
    }
}

            /*Hatif*/
            /*using (var ctx = new FilmsDBContext())
            {
                //Chargement de la catégorie Action et des films de cette catégorie
                Categorie categorieAction = ctx.Categories
                .Include(c => c.Films)
                .First(c => c.Nom == "Action");
                Console.WriteLine("Categorie : " + categorieAction.Nom);
                Console.WriteLine("Films : ");
                foreach (var film in categorieAction.Films)
                {
                    Console.WriteLine(film.Nom);
                }
            }*/

            /*using (var ctx = new FilmsDBContext())
            {
                //Chargement de la catégorie Action, des films de cette catégorie et des avis
                Categorie categorieAction = ctx.Categories
                .Include(c => c.Films)
                .ThenInclude(f => f.Avis)
                .First(c => c.Nom == "Action");
            }*/

            /*différé*/
            /*using (var ctx = new FilmsDBContext())
            {
                //Chargement de la catégorie Action
                Categorie categorieAction = ctx.Categories.First(c => c.Nom == "Action");
                Console.WriteLine("Categorie : " + categorieAction.Nom);
                Console.WriteLine("Films : ");
                //Chargement des films de la catégorie Action.
                foreach (var film in categorieAction.Films) // lazy loading initiated
                {
                    Console.WriteLine(film.Nom);
                }
            }*/