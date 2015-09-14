using DietyCommonTypes.Enums;
using DietyCommonTypes.Extensions;
using DietyCommonTypes.Interfaces;
using DietyDataAccess.DataTypes.ComplementaryTypes.Interfaces;
using GalaSoft.MvvmLight;

namespace DietyDataAccess.DataTypes.ComplementaryTypes
{
	public class NutrientsSummary : ViewModelBase ,INutrientsSummary
	{
		/// <summary>
		/// The _calories
		/// </summary>
		private double _calories;

		/// <summary>
		/// The _fats
		/// </summary>
		private double _fats;

		/// <summary>
		/// The _carbohydrates
		/// </summary>
		private double _carbohydrates;

		/// <summary>
		/// The _proteins
		/// </summary>
		private double _proteins;

		#region Public Properties

		/// <summary>
		/// Gets or sets the fats.
		/// </summary>
		/// <value>
		/// The fats.
		/// </value>
		public double Fats
		{
			get { return _fats; }
			set { Set(ref _fats, value); }
		}

		/// <summary>
		/// Gets or sets the carbohydrates.
		/// </summary>
		/// <value>
		/// The carbohydrates.
		/// </value>
		public double Carbohydrates
		{
			get { return _carbohydrates; }
			set { Set(ref _carbohydrates, value); }
		}

		/// <summary>
		/// Gets or sets the proteins.
		/// </summary>
		/// <value>
		/// The proteins.
		/// </value>
		public double Proteins
		{
			get { return _proteins; }
			set { Set(ref _proteins, value); }
		}

		/// <summary>
		/// Gets or sets the calories.
		/// </summary>
		/// <value>
		/// The calories.
		/// </value>
		public double Calories
		{
			get { return _calories; }
			set { Set(ref _calories, value); }
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Adds the ingredient.
		/// </summary>
		/// <param name="ingredient">The ingredient.</param>
		/// <param name="unit">The unit.</param>
		public void AddIngredient(IIngredient ingredient, UnitTypes unit)
		{
			var typeMultiplyer = UnitTypeValueModyfierAttribute.GetMultiplyerValue(unit);
			Carbohydrates += ingredient.Carbohydrates*typeMultiplyer;
			Proteins += ingredient.Proteins*typeMultiplyer;
			Fats += ingredient.Fats*typeMultiplyer;
			Calories += ingredient.Calories*typeMultiplyer;
		}

		#endregion

	}
}
