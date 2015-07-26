using DietyCommonTypes.Interfaces;

namespace DietyDataTransportTypes.Interfaces
{
	public interface IUserProfileData : IUserProfile
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