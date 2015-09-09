using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diety.Helpers.Constatnts
{
	public static class Messages
	{
		#region Private Fields

		/// <summary>
		/// The wrong username or password
		/// </summary>
		private const string _wrongUsernameOrPassword = "Błędna nazwa użytkownika lub hasło";

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets the wrong username or password.
		/// </summary>
		/// <value>
		/// The wrong username or password.
		/// </value>
		public static string WrongUsernameOrPassword
		{
			get { return _wrongUsernameOrPassword;}
		}

		#endregion

	}
}
