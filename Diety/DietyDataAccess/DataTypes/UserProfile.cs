using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietyCommonTypes.Interfaces;
using DietyData.Entities;
using DietyDataTransportTypes.Interfaces;
using GalaSoft.MvvmLight;

namespace DietyDataAccess.DataTypes
{
	class UserProfile : ViewModelBase, IUserProfile
	{
		#region Private Fields

		/// <summary>
		/// The _user profile
		/// </summary>
		private readonly IUserProfileData _userProfile;

		#endregion


		#region Public Properties

		/// <summary>
		/// Gets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public long Id
		{
			get { return _userProfile.Id; }
		}

		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>
		/// The name of the user.
		/// </value>
		public string UserName
		{
			get { return _userProfile.UserName; }
			set
			{
				_userProfile.UserName = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		/// <value>
		/// The height.
		/// </value>
		public double Height
		{
			get { return _userProfile.Height; }
			set
			{
				_userProfile.Height = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the weight.
		/// </summary>
		/// <value>
		/// The weight.
		/// </value>
		public double Weight
		{
			get { return _userProfile.Weight; }
			set
			{
				_userProfile.Weight = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the bmi.
		/// </summary>
		/// <value>
		/// The bmi.
		/// </value>
		public double Bmi
		{
			get { return _userProfile.Bmi; }
			set
			{
				_userProfile.Bmi = value;
				RaisePropertyChanged();
			}
		}

		///// <summary>
		///// Gets or sets the planned meals.
		///// </summary>
		///// <value>
		///// The planned meals.
		///// </value>
		//public IEnumerable<IMealHistoryRecord> MealRecords
		//{
		//	get { return _userProfile.MealRecords; }
		//	set
		//	{
		//		_userProfile.MealRecords = value;
		//		RaisePropertyChanged();
		//	}
		//}

		///// <summary>
		///// Gets or sets the weight history.
		///// </summary>
		///// <value>
		///// The weight history.
		///// </value>
		//public IEnumerable<IWeightHistoryRecord> WeightHistory
		//{
		//	get { return _userProfile.WeightHistory; }
		//	set
		//	{
		//		_userProfile.WeightHistory = value;
		//		RaisePropertyChanged();
		//	}
		//}

		///// <summary>
		///// Gets or sets the trainings history.
		///// </summary>
		///// <value>
		///// The trainings history.
		///// </value>
		//public IEnumerable<ITrainingHistoryRecord> TrainingsHistory
		//{
		//	get { return _userProfile.TrainingsHistory; }
		//	set
		//	{
		//		_userProfile.TrainingsHistory = value;
		//		RaisePropertyChanged();
		//	}
		//}

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="UserProfile"/> class.
		/// </summary>
		/// <param name="userProfile">The user profile.</param>
		internal UserProfile(IUserProfileData userProfile)
		{
			_userProfile = userProfile;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UserProfile"/> class.
		/// </summary>
		public UserProfile()
		{
			_userProfile = new UserProfileDb();
		}

		#endregion

		#region Internal Methods

		/// <summary>
		/// Unwraps the data object.
		/// </summary>
		/// <returns></returns>
		internal IUserProfileData UnwrapDataObject()
		{
			return _userProfile;
		}

		#endregion
	}
}
