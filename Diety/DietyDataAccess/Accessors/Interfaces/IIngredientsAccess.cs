using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DietyCommonTypes.Interfaces;
using DietyData.Entities;

namespace DietyDataAccess.Accessors.Interfaces
{
	public interface IIngredientsAccess
	{
		#region Public Properties

		/// <summary>
		/// Adds the meal record.
		/// </summary>
		/// <param name="item">The ingredient.</param>
		/// <returns></returns>
		Task<IIngredient> AddMealRecord(IIngredient item);

		/// <summary>
		/// Gets the ingredients list.
		/// </summary>
		/// <param name="searchCondition">The search condition.</param>
		/// <param name="orderRule">The order rule.</param>
		/// <param name="skipCount">The skip count.</param>
		/// <param name="takeCount">The take count.</param>
		/// <returns></returns>
		Task<IEnumerable<IIngredient>> GetIngredientsList(
			Func<IngredientDb, bool> searchCondition = null,
			Func<IngredientDb, object> orderRule = null,
			int skipCount = 0, int takeCount = Int32.MaxValue);

		/// <summary>
		/// Gets the ingredient.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		Task<IIngredient> GetIngredient(long id);

		#endregion

	}
}