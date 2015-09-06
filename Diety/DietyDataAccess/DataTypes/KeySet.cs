using DietyCommonTypes.Interfaces;
using DietyData.Entities;
using DietyDataTransportTypes.Interfaces;
using GalaSoft.MvvmLight;

namespace DietyDataAccess.DataTypes
{
	public class KeySet : ViewModelBase, IKeySet
	{
		#region Private Fields

		private readonly IKeySetData _keySet;

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets the key.
		/// </summary>
		/// <value>
		/// The key.
		/// </value>
		public string Key
		{
			get { return _keySet.Key; }
			set
			{
				_keySet.Key = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the vi.
		/// </summary>
		/// <value>
		/// The vi.
		/// </value>
		public string Vi
		{			
			get { return _keySet.Vi; }
			set
			{
				_keySet.Vi = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the owner.
		/// </summary>
		/// <value>
		/// The owner.
		/// </value>
		public IUserProfile Owner
		{
			get { return _keySet.Owner; }
			set
			{
				_keySet.Owner = value;
				RaisePropertyChanged();
			}
		}

		#endregion


		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="KeySet"/> class.
		/// </summary>
		/// <param name="keySet">The key set.</param>
		internal KeySet(IKeySetData keySet)
		{
			_keySet = keySet;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="KeySet"/> class.
		/// </summary>
		public KeySet()
		{
			_keySet = new KeySetDb();			
		}

		#endregion

		#region Internal Methods

		/// <summary>
		/// Unwraps the data object.
		/// </summary>
		/// <returns></returns>
		internal IKeySetData UnwrapDataObject()
		{
			return _keySet;
		}

		#endregion
		
	}
}