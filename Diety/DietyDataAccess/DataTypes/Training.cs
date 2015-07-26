using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using DietyCommonTypes.Enums;
using DietyCommonTypes.Interfaces;
using DietyData.Entities;
using DietyDataTransportTypes.Interfaces;
using GalaSoft.MvvmLight;

namespace DietyDataAccess.DataTypes
{
	class Training : ViewModelBase, ITraining
	{
		#region Private Fields

		/// <summary>
		/// The _training
		/// </summary>
		private readonly ITrainingData _training;

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
			get { return _training.Id; }
		}

		/// <summary>
		/// Gets or sets the sport.
		/// </summary>
		/// <value>
		/// The sport.
		/// </value>
		public SportTypes Sport
		{
			get { return _training.Sport; }
			set
			{
				_training.Sport = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the duration.
		/// </summary>
		/// <value>
		/// The duration.
		/// </value>
		public TimeSpan Duration
		{
			get { return _training.Duration; }
			set
			{
				_training.Duration = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the calories burned.
		/// </summary>
		/// <value>
		/// The calories burned.
		/// </value>
		public double CaloriesBurned
		{
			get { return _training.CaloriesBurned; }
			set
			{
				_training.CaloriesBurned = value;
				RaisePropertyChanged();
			}
		}

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="Training"/> class.
		/// </summary>
		/// <param name="training">The training.</param>
		internal Training(ITrainingData training)
		{
			_training = training;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Training"/> class.
		/// </summary>
		public Training()
		{
			_training = new TrainingDb();
		}

		#endregion

		#region Internal Methods

		/// <summary>
		/// Unwraps the data object.
		/// </summary>
		/// <returns></returns>
		internal ITrainingData UnwrapDataObject()
		{
			return _training;
		}

		#endregion
	}
}
