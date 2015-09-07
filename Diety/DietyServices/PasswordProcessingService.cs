using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Effortless.Net.Encryption;


namespace DietyServices
{
	class PasswordProcessingService : IPasswordProcessingService
	{
		#region Private Static Fields

		/// <summary>
		/// The salt
		/// </summary>
		private const string Salt = "zuafK6XXRsZJDQJKaAk+I3QfJz2H2yU3910USeqHWu17ZZ0ZooS3214vrw3HbZTml8y8zo2I0LVWiy+9QWpvCbJ5jzp8ymotx9HtAg+0LRm7Rj1p74pzJliGxarlueXIlEUDNg+Qg++Eoqu0Rxf6ktoLb5f4ltolPWiHK/FxPmONv/9alIWp+6omRr07c1RrjO+/rrl560H+x22wVcB1ZfUWG7/brQxRwQY79h5dgTy13xbvwpeTfJxpT+q4t8ulY65OJyBGGmdj1YXL+LjrRiZu7vOazrKQJbNiHvuPfcqkPqxtPfX1zUklMczBkRQFqfzlYfmPrcT85PttJE6oUG+tKhqd0hFKzXCI7bqhdecomUb3OXske1btJ0lmHe9DjhqnoL7Yc1jQjNXVIbRvUNJ63yjCZ4luaxFP6M4DULmUcKLmi1e00tF+svD+ktoLrUpjvccBPjrwYmbT1NfuGERoLCvmAQJB+UyYlepNAo1A/j/w9c3NY6k4MdNnKPjno5Cwd3pOZaUtGXGseIPFO8PySZ9xILG7Z3E3XK+vvpcoRgumA2B5CccSKDHjrQtqUJEpQYhl6vzi44O1RSIYrAImakFZNd4q8WlaQvDG2d/gt1Jpq5TduTqLgaxiJAxvI/Xk/SRDqZ1UinFjxodKQLBA18QZ6Lt+FcD60ZJ0/JN3cPH3dbLWgyUdQYXHHKVii24RhjFP4xpCaLOlg83BrCgg2zPZn/YSUoIZS+rHAR+nD/XeXWHcJov4HIk7gkSv6TKbh9UJ5HdgcYjKIwojPOmO1Extpxk4wMERvX+U3JR4vl8+EXN+dKy4NSnaE0+AM8/x0G3DtNR37APPB5crNOLy8mvH20vXa3p2Vbuy9zw3FfcM3X0vFhSqaay7EBtVhnxr+2qRzDNyZHu+TKojHkR4GmrmjJ6ojiVxypviTpmRR+L6FPTRF1t/n+L/8KjdJOTcxIQ64ciLHWst5dwD+dJLcdlpCM48xx4c2MUus7JxvK9DCBTKoFWGcoD9LVU4gb9YGASZWXn5eKAtgPEsDFZqXH0Ff2G4hBivbfih0Gx50+h647Y5VGR03r2LRXyJe7lCOaVS7Hj9zQtD5lxYmF9WM/jZXv3gwCqf1xUejFvqVIz6qcpBUEL6wB6fQo5GzN2hK5y6HL2g0tRe62hHgSl7mhJM2jtq6auK24wW6pWhCKxg5cPjINrdwG2E6GQpFv1oRwXaVPRPhufOnmsSukOzDIo8ro/tZlPA8xyudCodFI6MqzBwNfTnfGNgbbvrg7vJ9CkDuMRjhT6xR34xDAux17URvF/87P+/oPtaYZs3F/SVXfhnSo9UXA+juNi2mg4YLAySP+Gg96q0XkmALg==";

		/// <summary>
		/// The key
		/// </summary>
		private const string Key = "PpcaOdE7Vkl68iM4QsWsEdkGmUfAD8D55jz0M9Ucc1PcK2MI5GpvZYI5JjmPlrdT8tRRv91h5TIfrfKdblGwY0Npr2pbhKvBMsyReRC3PbocHY7Ovu5OcBwQ3S5KBo8d0ruVp3WszBFvsP9NR1ks9fS5Wawd8qOyBtqr+xhiWcxfnSynys0R+zLS/HbpjRtVb5vXLGTSUdvWXPJ3EhZXWPVY6Gz3vXh3EGT/C7S6XfeMRTUcWWtGTqWew/y7NOe3UfXPOFaYKeMZOeO3oNR7IcMHaYoZwIXEwYq+QfUuzUwob15/EGFlOO0tMk/EO3fED3sKjDaRrd3D0/s5JK1Bhw==";

		#endregion

		#region Public Methods

		/// <summary>
		/// Encrypts the string.
		/// </summary>
		/// <param name="plainString">The plain string.</param>
		/// <returns></returns>
		public string EncryptString(string plainString)
		{
			var encrypted = Strings.Encrypt(plainString, GenerateKey(), GenerateKey());
			return encrypted;
		}

		/// <summary>
		/// Decrypts the password.
		/// </summary>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		public string DecryptPassword(string password)
		{
			var decrypted = Strings.Decrypt(password, GenerateKey(), GenerateKey());
			return decrypted;
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Generates the key.
		/// </summary>
		/// <returns></returns>
		private byte[] GenerateKey()
		{
			return Bytes.GenerateKey(Key, Salt, Bytes.KeySize.Size256);
		}

		#endregion

	}
}
