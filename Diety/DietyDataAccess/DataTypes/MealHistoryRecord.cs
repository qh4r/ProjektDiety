﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyCommonTypes.Interfaces;
using DietyData.Entities;
using DietyDataTransportTypes.Interfaces;
using GalaSoft.MvvmLight;

namespace DietyDataAccess.DataTypes
{
	public class MealHistoryRecord : ViewModelBase, IMealHistoryRecord
	{
		#region Private Properties

		/// <summary>
		/// The _meal history record
		/// </summary>
		private readonly IMealHistoryRecordData _mealHistoryRecord;

		/// <summary>
		/// The _owner
		/// </summary>
		private IUserProfile _owner;

		/// <summary>
		/// The _recipe
		/// </summary>
		private IRecipe _recipe;

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public long Id
		{
			get { return _mealHistoryRecord.Id; }
		}

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>
		/// The date.
		/// </value>
		public DateTime Date
		{
			get { return _mealHistoryRecord.Date; }
			set
			{
				_mealHistoryRecord.Date = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the recipe.
		/// </summary>
		/// <value>
		/// The recipe.
		/// </value>
		public IRecipe Recipe
		{
			get { return _recipe; }
			set
			{
				Set(ref _recipe, value);
				//_mealHistoryRecord.Recipe = value as RecipeDb ?? (value as Recipe).UnwrapDataObject();
				//RaisePropertyChanged();
			}
		}


		/// <summary>
		/// Gets the creator identifier.
		/// </summary>
		/// <value>
		/// The creator identifier.
		/// </value>
		public IUserProfile Owner
		{
			get { return _owner; }
			set
			{
				Set(ref _owner, value);
				//_mealHistoryRecord.Owner = value as UserProfileDb ?? (value as UserProfile).UnwrapDataObject();
				//RaisePropertyChanged();
			}
		}


		/// <summary>
		/// Gets or sets a value indicating whether this instance is past.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is past; otherwise, <c>false</c>.
		/// </value>
		public bool IsPast
		{
			get { return _mealHistoryRecord.IsPast; }
			set
			{
				_mealHistoryRecord.IsPast = value;
				RaisePropertyChanged();
			}
		}

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="MealHistoryRecord"/> class.
		/// </summary>
		/// <param name="mealHistoryRecord">The meal history record.</param>
		internal MealHistoryRecord(IMealHistoryRecord mealHistoryRecord)
		{
			_mealHistoryRecord = mealHistoryRecord as IMealHistoryRecordData;
			Owner = mealHistoryRecord.Owner;
			foreach (var component in mealHistoryRecord.Recipe.ComponentsList)
			{
				component.Ingredient = component.Ingredient;
			}
			Recipe = new Recipe(mealHistoryRecord.Recipe);

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MealHistoryRecord"/> class.
		/// </summary>
		public MealHistoryRecord()
		{
			_mealHistoryRecord = new MealHistoryRecordDb();
		}

		#endregion

		#region Internal Methods

		/// <summary>
		/// Unwraps the data object.
		/// </summary>
		/// <returns></returns>
		internal IMealHistoryRecordData UnwrapDataObject()
		{
			var owner = Owner as UserProfile;
			if (owner != null)
			{
				_mealHistoryRecord.Owner = owner.UnwrapDataObject();
			}
			var recipe = Recipe as Recipe;
			if (recipe != null)
			{
				_mealHistoryRecord.Recipe = recipe.UnwrapDataObject();
			}
			return _mealHistoryRecord;
		}

		#endregion

	}
}
