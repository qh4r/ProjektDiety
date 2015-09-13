using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DietyCommonTypes.Enums;
using DietyCommonTypes.Interfaces;
using DietyData.Entities;
using DietyDataTransportTypes.Interfaces;
using GalaSoft.MvvmLight;

namespace DietyDataAccess.DataTypes
{
	class Recipe : ViewModelBase ,IRecipe
	{
		#region Private Fields

		/// <summary>
		/// The _recipe
		/// </summary>
		private readonly IRecipeData _recipe;

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
		/// Gets or sets the components list.
		/// </summary>
		/// <value>
		/// The components list.
		/// </value>
		public IEnumerable<IRecipeComponent> ComponentsList
		{
			get { return _recipe.ComponentsList; }
			set
			{
				_recipe.ComponentsList = value;
				RaisePropertyChanged();
			}
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

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="Recipe"/> class.
		/// </summary>
		/// <param name="recipe">The recipe.</param>
		internal Recipe(IRecipe recipe)
		{
			_recipe = recipe as IRecipeData;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Recipe"/> class.
		/// </summary>
		public Recipe()
		{
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
			foreach (var recipeComponent in _recipe.ComponentsList)
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
	}
}
