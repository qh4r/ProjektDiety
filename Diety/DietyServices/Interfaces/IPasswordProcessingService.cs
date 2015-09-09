namespace DietyServices.Interfaces
{
	public interface IPasswordProcessingService
	{
		#region Properties

		/// <summary>
		/// Encrypts the string.
		/// </summary>
		/// <param name="userName">Name of the user.</param>
		/// <param name="plainString">The plain string.</param>
		/// <returns></returns>
		string EncryptString(string userName, string plainString);

		/// <summary>
		/// Decrypts the password.
		/// </summary>
		/// <param name="userName">Name of the user.</param>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		string DecryptPassword(string userName, string password);

		#endregion

	}
}