using System;
using System.CodeDom;
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
	public class Ingredient : ViewModelBase, IIngredient
	{

		#region Ingredient

		/// <summary>
		/// The _ingredient
		/// </summary>
		private readonly IIngredientData _ingredient;

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
			get { return _ingredient.Id; }
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name
		{
			get { return _ingredient.Name; }
			set
			{
				_ingredient.Name = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the fats.
		/// </summary>
		/// <value>
		/// The fats.
		/// </value>
		/// <exception cref="System.NotImplementedException"></exception>
		public double Fats
		{
			get { return _ingredient.Fats; }
			set
			{
				_ingredient.Fats = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the carbohydrates.
		/// </summary>
		/// <value>
		/// The carbohydrates.
		/// </value>
		public double Carbohydrates
		{
			get { return _ingredient.Carbohydrates; }
			set
			{
				_ingredient.Carbohydrates = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the proteins.
		/// </summary>
		/// <value>
		/// The proteins.
		/// </value>
		public double Proteins
		{
			get { return _ingredient.Proteins; }
			set
			{
				_ingredient.Proteins = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the calories.
		/// </summary>
		/// <value>
		/// The calories.
		/// </value>
		public double Calories
		{
			get { return _ingredient.Calories; }
			set
			{
				_ingredient.Calories = value;
				RaisePropertyChanged();
			}
		}

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="Ingredient"/> class.
		/// </summary>
		/// <param name="ingredient">The ingredient.</param>
		internal Ingredient(IIngredientData ingredient)
		{
			_ingredient = ingredient;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Ingredient"/> class.
		/// </summary>
		public Ingredient()
		{
			_ingredient = new IngredientDb();			
		}

		#endregion

		#region Internal Methods

		/// <summary>
		/// Unwraps the data object.
		/// </summary>
		/// <returns></returns>
		internal IIngredientData UnwrapDataObject()
		{
			return _ingredient;
		}

		#endregion

	}
}
