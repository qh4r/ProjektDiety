using DietyCommonTypes.Interfaces;

namespace DietyDataTransportTypes.Interfaces
{
	public interface IRecipeComponentData : IRecipeComponent
	{
		#region Properties

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		new long Id { get; set; }

		#endregion
	}
}