﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DietyCommonTypes.Interfaces;
using DietyDataTransportTypes.Interfaces;

namespace DietyData.Entities
{
	[Table("MealHistoryRecords")]
	public class MealHistoryRecordDb : IMealHistoryRecordData
	{
		#region Properties

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		/// <summary>
		/// Gets or sets the date data.
		/// </summary>
		/// <value>
		/// The date data.
		/// </value>
		[Column("Date")]
		public DateTime? DateData { get; set; }

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>
		/// The date.
		/// </value>
		[NotMapped]
		public DateTime Date
		{
			get { return DateData ?? default(DateTime); }
			set { DateData = value; }
		}


		/// <summary>
		/// Gets or sets the recipe data.
		/// </summary>
		/// <value>
		/// The recipe data.
		/// </value>
		[Column("Recipe")]
		public virtual RecipeDb RecipeData { get; set; }

		/// <summary>
		/// Gets or sets the recipe.
		/// </summary>
		/// <value>
		/// The recipe.
		/// </value>
		[NotMapped]
		public IRecipe Recipe
		{
			get
			{
				return RecipeData;
			}
			set { RecipeData = value as RecipeDb; }
		}

		/// <summary>
		/// Gets or sets the user data.
		/// </summary>
		/// <value>
		/// The user data.
		/// </value>
		[InverseProperty("MealRecordsData")]
		public virtual UserProfileDb UserData { get; set; }


		/// <summary>
		/// Gets the creator identifier.
		/// </summary>
		/// <value>
		/// The creator identifier.
		/// </value>
		[NotMapped]
		public IUserProfile Owner
		{
			get { return UserData; }
			set { UserData = value as UserProfileDb; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is past.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is past; otherwise, <c>false</c>.
		/// </value>
		public bool IsPast { get; set; }


		#endregion
	}
}
