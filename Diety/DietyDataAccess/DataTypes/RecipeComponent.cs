using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyCommonTypes.Enums;
using DietyCommonTypes.Interfaces;
using DietyData.Entities;
using DietyDataTransportTypes.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace DietyDataAccess.DataTypes
{
	public class RecipeComponent : ViewModelBase, IRecipeComponent
	{
		#region Private Fields

		/// <summary>
		/// The _recipe component
		/// </summary>
		private readonly IRecipeComponentData _recipeComponent;

		/// <summary>
		/// The _amount text
		/// </summary>
		private string _amountText;

		/// <summary>
		/// The _amount error
		/// </summary>
		private bool _amountError;

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

		/// <summary>
		/// Gets or sets the amount text.
		/// </summary>
		/// <value>
		/// The amount text.
		/// </value>
		public string AmountText
		{
			get
			{
				if (String.IsNullOrEmpty(_amountText))
				{
					_amountText = Amount.ToString(CultureInfo.CurrentCulture);
					RaisePropertyChanged();
				}
				return _amountText;
			}
			set
			{
				double newValue;
				Set(ref _amountText, value);
				if (Double.TryParse(value, out newValue))
				{
					Amount = newValue;
				}								
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether [amount error].
		/// </summary>
		/// <value>
		///   <c>true</c> if [amount error]; otherwise, <c>false</c>.
		/// </value>
		public bool AmountError
		{
			get { return _amountError; }
			set { Set(ref _amountError, value); }
		}

		/// <summary>
		/// Gets the amount got focus.
		/// </summary>
		/// <value>
		/// The amount got focus.
		/// </value>
		public RelayCommand AmountGotFocus
		{
			get { return new RelayCommand(() =>
			{
				AmountError = false;
			});}
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
