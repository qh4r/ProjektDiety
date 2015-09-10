using System.Threading.Tasks;
using DietyCommonTypes.Interfaces;

namespace Diety.ViewModel.Modules.Interfaces
{
	public interface ICurrentUserModule
	{
		#region Properties

		/// <summary>
		/// Gets the current user.
		/// </summary>
		/// <value>
		/// The current user.
		/// </value>
		IUserProfile CurrentUser { get; }

		#endregion

		#region Methods

		/// <summary>
		/// Processes the passowrd.
		/// </summary>
		/// <param name="login">The login.</param>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		Task<bool> AttemptLogin(string login, string password);		

		#endregion

		/// <summary>
		/// Logs the out.
		/// </summary>
		void LogOut();
	}
}