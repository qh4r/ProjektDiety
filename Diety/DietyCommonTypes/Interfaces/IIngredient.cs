namespace DietyCommonTypes.Interfaces
{
    public interface IIngredient
    {
        #region Properties

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
        string Name { get; set; }

		/// <summary>
		/// Gets or sets the fats.
		/// </summary>
		/// <value>
		/// The fats.
		/// </value>
        double Fats { get; set; }

		/// <summary>
		/// Gets or sets the carbohydrates.
		/// </summary>
		/// <value>
		/// The carbohydrates.
		/// </value>
        double Carbohydrates { get; set; }

		/// <summary>
		/// Gets or sets the proteins.
		/// </summary>
		/// <value>
		/// The proteins.
		/// </value>
        double Proteins { get; set; }

		/// <summary>
		/// Gets or sets the calories.
		/// </summary>
		/// <value>
		/// The calories.
		/// </value>
        double Calories { get; set; }

        #endregion
    }
}
