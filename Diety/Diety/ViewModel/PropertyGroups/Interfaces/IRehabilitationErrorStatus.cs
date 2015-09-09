namespace Diety.ViewModel.PropertyGroups.Interfaces
{
	public interface IRehabilitationErrorStatus
	{
		#region Properties

		/// <summary>
		/// Gets or sets a value indicating whether [username error].
		/// </summary>
		/// <value>
		///   <c>true</c> if [username error]; otherwise, <c>false</c>.
		/// </value>
		bool UsernameError { get; }

		/// <summary>
		/// Gets or sets a value indicating whether [password error].
		/// </summary>
		/// <value>
		///   <c>true</c> if [password error]; otherwise, <c>false</c>.
		/// </value>
		bool PasswordError { get; }

		/// <summary>
		/// Gets or sets a value indicating whether [weight error].
		/// </summary>
		/// <value>
		///   <c>true</c> if [weight error]; otherwise, <c>false</c>.
		/// </value>
		bool WeightError { get; }

		/// <summary>
		/// Gets or sets a value indicating whether [height error].
		/// </summary>
		/// <value>
		///   <c>true</c> if [height error]; otherwise, <c>false</c>.
		/// </value>
		bool HeightError { get; }

		/// <summary>
		/// Gets or sets a value indicating whether [no errors].
		/// </summary>
		/// <value>
		///   <c>true</c> if [no errors]; otherwise, <c>false</c>.
		/// </value>
		bool NoErrors { get;}

		/// <summary>
		/// Gets or sets the username error message.
		/// </summary>
		/// <value>
		/// The username error message.
		/// </value>
		string UsernameErrorMessage { get; set; }

		/// <summary>
		/// Gets or sets the password error message.
		/// </summary>
		/// <value>
		/// The password error message.
		/// </value>
		string PasswordErrorMessage { get; set; }

		/// <summary>
		/// Gets or sets the height error message.
		/// </summary>
		/// <value>
		/// The height error message.
		/// </value>
		string HeightErrorMessage { get; set; }

		/// <summary>
		/// Gets or sets the weight error message.
		/// </summary>
		/// <value>
		/// The weight error message.
		/// </value>
		string WeightErrorMessage { get; set; }

		#endregion

	}
}