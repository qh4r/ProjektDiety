using DietyCommonTypes.Interfaces;
using DietyData.Entities;

namespace DbAccess
{
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class DietyDb : DbContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DietyDb"/> class.
		/// </summary>
		public DietyDb()
			: base("name=DietyDb")
		{
		}

		/// <summary>
		/// Gets or sets the ingredients.
		/// </summary>
		/// <value>
		/// The ingredients.
		/// </value>
		public DbSet<IngredientDb> Ingredients { get; set; }

		/// <summary>
		/// Gets or sets the meal history records.
		/// </summary>
		/// <value>
		/// The meal history records.
		/// </value>
		public DbSet<MealHistoryRecordDb> MealHistoryRecords { get; set; }

		/// <summary>
		/// Gets or sets the recipes.
		/// </summary>
		/// <value>
		/// The recipes.
		/// </value>
		public DbSet<RecipeDb> Recipes { get; set; }

		/// <summary>
		/// Gets or sets the recipe components.
		/// </summary>
		/// <value>
		/// The recipe components.
		/// </value>
		public DbSet<RecipeComponentDb> RecipeComponents { get; set; }

		/// <summary>
		/// Gets or sets the trainings.
		/// </summary>
		/// <value>
		/// The trainings.
		/// </value>
		public DbSet<TrainingDb> Trainings { get; set; }

		/// <summary>
		/// Gets or sets the training history records.
		/// </summary>
		/// <value>
		/// The training history records.
		/// </value>
		public DbSet<TrainingHistoryRecordDb> TrainingHistoryRecords { get; set; }

		/// <summary>
		/// Gets or sets the user profiles.
		/// </summary>
		/// <value>
		/// The user profiles.
		/// </value>
		public DbSet<UserProfileDb> UserProfiles { get; set; }

		/// <summary>
		/// Gets or sets the weight history records.
		/// </summary>
		/// <value>
		/// The weight history records.
		/// </value>
		public DbSet<WeightHistoryRecordDb> WeightHistoryRecords { get; set; } 
	}
}