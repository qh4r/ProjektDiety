using DietyCommonTypes.Interfaces;
using DietyDataAccess.DataTypes.ComplementaryTypes.Interfaces;

namespace DietyDataAccess.DataTypes.WrapperInterfaces
{
	public interface IRecipeWrapper : IRecipe
	{
		#region Public Properties

		/// <summary>
		/// Gets or sets a value indicating whether this instance is selected.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is selected; otherwise, <c>false</c>.
		/// </value>
		bool IsSelectedInverted { get; set; }

		/// <summary>
		/// Gets or sets the recipe nutrients summary.
		/// </summary>
		/// <value>
		/// The recipe nutrients summary.
		/// </value>
		INutrientsSummary RecipeNutrientsSummary { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [name error].
		/// </summary>
		/// <value>
		///   <c>true</c> if [name error]; otherwise, <c>false</c>.
		/// </value>
		bool NameError { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [components error].
		/// </summary>
		/// <value>
		///   <c>true</c> if [components error]; otherwise, <c>false</c>.
		/// </value>
		bool ComponentsError { get; set; }

		#endregion

	}
}