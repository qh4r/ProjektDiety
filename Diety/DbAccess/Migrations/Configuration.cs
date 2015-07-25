using DietyCommonTypes.Enums;
using DietyData.Entities;

namespace DbAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DbAccess.DietyDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DbAccess.DietyDb context)
        {
			////TUTAJ PRZYKLAD JAK DODAWAC POCZATKOWE DANE
			////NIGDY NIE USTAWIAMY ID -> TYM ZAJMUJE SIE BAZA
			//context.Ingredients.AddOrUpdate(i => i.Name, new Ingredient
			//{
			//	Calories = 100.0,
			//	Carbohydrates = 4252.0,
			//	Fats = 14124.23,
			//	Name = "S³onina",
			//	Proteins = 3523
			//}, new Ingredient
			//{
			//	Calories = 32523,
			//	Carbohydrates = 12421421,
			//	Fats = 1242141,
			//	Name = "Ciecie¿yca",
			//	Proteins = 2215124.4124
			//});
			////JESLI ELEMENTA WYSTEPUJE JAKO WLASCIWOSC INNEJ KLASY TO DODAJEMY GO PODCZAS TWORZENIA KLASY MATKI
			////ZOSTANIE DODANY DO BAZY IMPLICITLY 
			//context.TrainingHistoryRecords.Add(new TrainingHistoryRecord
			//{
			//	Date = DateTime.Now.AddMonths(-1),
			//	Training = new Training
			//	{
			//		CaloriesBurned = 432523,
			//		Duration = TimeSpan.FromMinutes(45),
			//		Sport = SportTypes.Cycling
			//	}
			//});
			////BY DODAC WIELE NARAZ MOZNA UZYC AddRange() JESLI KTOS NIE CHCE UZYWAC AddOrUpdate
            }
    }
}
