using DietyCommonTypes.Interfaces;

namespace DietyDataTransportTypes.Interfaces
{
	public interface IKeySetData : IKeySet
	{
		#region Properties

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		long Id { get; set; }

		#endregion
	}
}