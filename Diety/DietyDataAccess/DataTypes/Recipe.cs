using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DietyCommonTypes.Enums;
using DietyCommonTypes.Interfaces;
using DietyData.Entities;
using DietyDataAccess.DataTypes.ComplementaryTypes;
using DietyDataAccess.DataTypes.ComplementaryTypes.Interfaces;
using DietyDataAccess.DataTypes.WrapperInterfaces;
using DietyDataTransportTypes.Interfaces;
using GalaSoft.MvvmLight;

namespace DietyDataAccess.DataTypes
{
	public class Recipe : ViewModelBase, IRecipeWrapper
	{
		#region Private Fields

		/// <summary>
		/// The _recipe
		/// </summary>
		private readonly IRecipeData _recipe;

		private IEnumerable<IRecipeComponent> _componentsList;
		/// <summary>
		/// The _name error
		/// </summary>
		private bool _nameError;

		/// <summary>
		/// The _components error
		/// </summary>
		private bool _componentsError;

		/// <summary>
		/// The _is selected
		/// </summary>
		private bool _isSelected;

		/// <summary>
		/// The _recipe nutrients summary
		/// </summary>
		private INutrientsSummary _recipeNutrientsSummary;

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
			get { return _recipe.Id; }
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name
		{
			get { return _recipe.Name; }
			set
			{
				_recipe.Name = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is selected.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is selected; otherwise, <c>false</c>.
		/// </value>
		public bool IsSelectedInverted
		{
			get { return !_isSelected; }
			set { Set(ref _isSelected, value); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether [name error].
		/// </summary>
		/// <value>
		///   <c>true</c> if [name error]; otherwise, <c>false</c>.
		/// </value>
		public bool NameError
		{
			get { return _nameError; }
			set { Set(ref _nameError, value); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether [components error].
		/// </summary>
		/// <value>
		///   <c>true</c> if [components error]; otherwise, <c>false</c>.
		/// </value>
		public bool ComponentsError
		{
			get { return _componentsError; }
			set { Set(ref _componentsError, value); }
		}

		/// <summary>
		/// Gets or sets the components list.
		/// </summary>
		/// <value>
		/// The components list.
		/// </value>
		public IEnumerable<IRecipeComponent> ComponentsList
		{
			get { return _componentsList; }
			set
			{
				Set(ref _componentsList, value);
				RaisePropertyChanged(() => ComponentsListEmpty);
				ComponentsError = false;
			}
		}

		/// <summary>
		/// Gets a value indicating whether [components list empty].
		/// </summary>
		/// <value>
		///   <c>true</c> if [components list empty]; otherwise, <c>false</c>.
		/// </value>
		public bool ComponentsListEmpty
		{
			get { return ComponentsList == null || !ComponentsList.Any(); }
		}

		/// <summary>
		/// Gets or sets the type of the meal.
		/// </summary>
		/// <value>
		/// The type of the meal.
		/// </value>
		public MealTypes MealType
		{
			get { return _recipe.MealType; }
			set
			{
				_recipe.MealType = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
		public string Description
		{
			get { return _recipe.Description; }
			set
			{
				_recipe.Description = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the image.
		/// </summary>
		/// <value>
		/// The image.
		/// </value>
		public byte[] Image
		{
			get { return _recipe.Image; }
			set
			{
				_recipe.Image = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the recipe nutrients summary.
		/// </summary>
		/// <value>
		/// The recipe nutrients summary.
		/// </value>
		public INutrientsSummary RecipeNutrientsSummary
		{
			get { return _recipeNutrientsSummary; }
			set { Set(ref _recipeNutrientsSummary, value); }
		}

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="Recipe"/> class.
		/// </summary>
		/// <param name="recipe">The recipe.</param>
		internal Recipe(IRecipe recipe)
		{			
			ComponentsList = recipe.ComponentsList.Select(x => new RecipeComponent(x));
			CalculateNutrientsSummary();
			_recipe = recipe as IRecipeData;
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Recipe"/> class.
		/// </summary>
		public Recipe()
		{
			ComponentsList = new List<IRecipeComponent>();
			_recipe = new RecipeDb();
		}

		#endregion

		#region Internal Methods

		/// <summary>
		/// Unwraps the data object.
		/// </summary>
		/// <returns></returns>
		internal IRecipeData UnwrapDataObject()
		{
			ICollection<IRecipeComponent> newList = new List<IRecipeComponent>();
			foreach (var recipeComponent in ComponentsList)
			{
				if (recipeComponent is RecipeComponent)
				{
					var component = recipeComponent as RecipeComponent;
					newList.Add(component.UnwrapDataObject());
				}
				else
				{
					newList.Add(recipeComponent);
				}
			}
			_recipe.ComponentsList = newList;
			return _recipe;
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Calculates the nutrients summary.
		/// </summary>
		private void CalculateNutrientsSummary()
		{
			if (!ComponentsListEmpty)
			{
				var nutrientsSummary = new NutrientsSummary();
				foreach (var recipeComponent in ComponentsList)
				{
					nutrientsSummary.AddIngredient(recipeComponent.Ingredient, recipeComponent.Unit);
				}
				RecipeNutrientsSummary = nutrientsSummary;
			}
		}

		

		#endregion

		
	}
}
