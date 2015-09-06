namespace DietyCommonTypes.Interfaces
{
	public interface IKeySet
	{
		#region Properties

		/// <summary>
		/// Gets or sets the key.
		/// </summary>
		/// <value>
		/// The key.
		/// </value>
		string Key { get; set; }

		/// <summary>
		/// Gets or sets the vi.
		/// </summary>
		/// <value>
		/// The vi.
		/// </value>
		string Vi { get; set; }

		/// <summary>
		/// Gets or sets the owner.
		/// </summary>
		/// <value>
		/// The owner.
		/// </value>
		IUserProfile Owner { get; set; }

		#endregion
	}
}