using DietyCommonTypes.Enums;
using DietyData.Entities;
using System;

namespace DbAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DbAccess.DietyDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DbAccess.DietyDb context)
        {
        //    //TUTAJ PRZYKLAD JAK DODAWAC POCZATKOWE DANE
        //    //NIGDY NIE USTAWIAMY ID -> TYM ZAJMUJE SIE BAZA
            //context.Ingredients.AddOrUpdate(i => i.Name, new IngredientDb
            //{
            //    Calories = 100.0,
            //    Carbohydrates = 4252.0,
            //    Fats = 14124.23,
            //    Name = "lolol",
            //    Proteins = 3523
            //}, new IngredientDb
            //{
            //    Calories = 32523,
            //    Carbohydrates = 12421421,
            //    Fats = 1242141,
            //    Name = "lolkh",
            //    Proteins = 2215124.4124
            //});
            //JESLI ELEMENTA WYSTEPUJE JAKO WLASCIWOSC INNEJ KLASY TO DODAJEMY GO PODCZAS TWORZENIA KLASY MATKI
            //ZOSTANIE DODANY DO BAZY IMPLICITLY 
            //context.TrainingHistoryRecords.Add(new TrainingHistoryRecordDb
            //{
            //    Date = DateTime.Now.AddMonths(-1),
            //    TrainingDb = new TrainingDb
            //    {
            //        CaloriesBurned = 432523,
            //        Duration = TimeSpan.FromMinutes(45),
            //        Sport = SportTypes.Cycling
            //    }
            //});
            //BY DODAC WIELE NARAZ MOZNA UZYC AddRange() JESLI KTOS NIE CHCE UZYWAC AddOrUpdate

            string[] ingredients = System.IO.File.ReadAllLines(@"C:\Users\PPH\Desktop\aga\semestr 6\ProjektDiety\Diety\kalorieITD.csv");
            char[] delimiterChars = { ';'};
            int counter;
            counter = 0;

            foreach (string ingredient in ingredients)
            {
                if (counter == 0)
                {
                    counter++;
                }
                else if (counter < (System.IO.File.ReadAllLines(@"C:\Users\PPH\Desktop\aga\semestr 6\ProjektDiety\Diety\kalorieITD.csv").Length-1))
                {


                    counter++;
                    string[] Characteristic = ingredient.Split(delimiterChars);
                    

                    context.Ingredients.AddOrUpdate(i => i.Name, new IngredientDb
                    {

                        Calories = double.Parse(Characteristic[1].Trim(), System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture),
                        Carbohydrates = double.Parse(Characteristic[2].Trim(), System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture),
                        Fats = double.Parse(Characteristic[4].Trim(), System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture),
                        Name = Characteristic[0].Trim(),
                        Proteins = double.Parse(Characteristic[3].Trim(), System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture)
                        
                    });
                    

                }



            }

            

         }
    }
}
