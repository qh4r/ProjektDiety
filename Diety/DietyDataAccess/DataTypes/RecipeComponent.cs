using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyCommonTypes.Enums;
using DietyCommonTypes.Interfaces;
using DietyData.Entities;
using DietyDataTransportTypes.Interfaces;
using GalaSoft.MvvmLight;

namespace DietyDataAccess.DataTypes
{
	public class RecipeComponent : ViewModelBase, IRecipeComponent
	{
		#region Private Fields

		/// <summary>
		/// The _recipe component
		/// </summary>
		private readonly IRecipeComponentData _recipeComponent;

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
			get { return _recipeComponent.Id; }
		}

		/// <summary>
		/// Gets or sets the ingredient.
		/// </summary>
		/// <value>
		/// The ingredient.
		/// </value>
		public IIngredient Ingredient
		{
			get { return _recipeComponent.Ingredient; }
			set
			{
				_recipeComponent.Ingredient = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the unit.
		/// </summary>
		/// <value>
		/// The unit.
		/// </value>
		public UnitTypes Unit
		{
			get { return _recipeComponent.Unit; }
			set
			{
				_recipeComponent.Unit = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the amount.
		/// </summary>
		/// <value>
		/// The amount.
		/// </value>
		public double Amount
		{
			get { return _recipeComponent.Amount; }
			set
			{
				_recipeComponent.Amount = value;
				RaisePropertyChanged();
			}
		}

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="RecipeComponent"/> class.
		/// </summary>
		/// <param name="recipeComponent">The recipe component.</param>
		internal RecipeComponent(IRecipeComponent recipeComponent)
		{
			_recipeComponent = recipeComponent as IRecipeComponentData;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RecipeComponent"/> class.
		/// </summary>
		public RecipeComponent(IIngredient ingredient)
		{
			_recipeComponent = new RecipeComponentDb
			{
				Ingredient = (ingredient as Ingredient).UnwrapDataObject(),
				Amount = 0,
				Unit = default(UnitTypes)
			};
		}

		#endregion

		#region Internal Methods

		/// <summary>
		/// Unwraps the data object.
		/// </summary>
		/// <returns></returns>
		internal IRecipeComponentData UnwrapDataObject()
		{
			var ingredient = _recipeComponent.Ingredient as Ingredient;
			if (ingredient != null)
			{
				_recipeComponent.Ingredient = ingredient.UnwrapDataObject();
			}
			return _recipeComponent;
		}

		#endregion
	}
}
