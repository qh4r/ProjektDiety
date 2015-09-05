using DbAccess;

namespace DietyDataAccess
{
	public abstract class DataAccessBase
	{
		#region Static Fields

		/// <summary>
		/// The _diety database context
		/// </summary>
		private static DietyDb _dietyDbContext;

		#endregion

		#region Static Properties

		/// <summary>
		/// Gets the diety database context.
		/// </summary>
		/// <value>
		/// The diety database context.
		/// </value>
		protected static DietyDb DietyDbContext
		{
			get
			{
				if (_dietyDbContext == null)
				{
					_dietyDbContext = new DietyDb();
				}
				return _dietyDbContext;
			}
		}

		#endregion

	}
}