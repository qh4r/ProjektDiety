namespace DietyServices
{
	public interface IPasswordProcessingService
	{
		#region Properties

		/// <summary>
		/// Encrypts the string.
		/// </summary>
		/// <param name="plainString">The plain string.</param>
		/// <returns></returns>
		string EncryptString(string plainString);

		/// <summary>
		/// Decrypts the password.
		/// </summary>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		string DecryptPassword(string password);

		#endregion

	}
}