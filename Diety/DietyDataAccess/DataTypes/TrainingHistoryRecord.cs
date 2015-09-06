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
	class TrainingHistoryRecord : ViewModelBase, ITrainingHistoryRecord
	{
		#region Private Fields

		/// <summary>
		/// The _training history record
		/// </summary>
		private readonly ITrainingHistoryRecordData _trainingHistoryRecord;

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
			get { return _trainingHistoryRecord.Id; }
		}

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>
		/// The date.
		/// </value>
		public DateTime Date
		{
			get { return _trainingHistoryRecord.Date; }
			set
			{
				_trainingHistoryRecord.Date = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the training.
		/// </summary>
		/// <value>
		/// The training.
		/// </value>
		public ITraining Training
		{
			get { return _trainingHistoryRecord.Training; }
			set
			{
				_trainingHistoryRecord.Training = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets the creator identifier.
		/// </summary>
		/// <value>
		/// The creator identifier.
		/// </value>
		public IUserProfile Owner
		{
			get { return _trainingHistoryRecord.Owner; }
			set
			{
				_trainingHistoryRecord.Owner = value;
				RaisePropertyChanged();
			}
		}

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="TrainingHistoryRecord"/> class.
		/// </summary>
		/// <param name="trainingHistoryRecord">The training history record.</param>
		internal TrainingHistoryRecord(ITrainingHistoryRecordData trainingHistoryRecord)
		{
			_trainingHistoryRecord = trainingHistoryRecord;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TrainingHistoryRecord"/> class.
		/// </summary>
		public TrainingHistoryRecord()
		{
			_trainingHistoryRecord = new TrainingHistoryRecordDb();
		}

		#endregion

		#region Internal Methods

		/// <summary>
		/// Unwraps the data object.
		/// </summary>
		/// <returns></returns>
		internal ITrainingHistoryRecordData UnwrapDataObject()
		{
			return _trainingHistoryRecord;
		}

		#endregion
	}
}
