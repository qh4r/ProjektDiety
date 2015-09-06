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
	class WeightHistoryRecord : ViewModelBase, IWeightHistoryRecord
	{
		#region Private Fields

		/// <summary>
		/// The _weight history record
		/// </summary>
		private readonly IWeightHistoryRecordData _weightHistoryRecord;

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
			get { return _weightHistoryRecord.Id; }
		}

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>
		/// The date.
		/// </value>
		public DateTime Date
		{
			get { return _weightHistoryRecord.Date; }
			set
			{
				_weightHistoryRecord.Date = value;
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
			get { return _weightHistoryRecord.Weight; }
			set
			{
				_weightHistoryRecord.Weight = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Gets the creator identifier.
		/// </summary>
		/// <value>
		/// The creator identifier.
		/// </value>
		public long CreatorId
		{
			get
			{
				return _weightHistoryRecord.Id;
			}
		}

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="WeightHistoryRecord"/> class.
		/// </summary>
		/// <param name="weightHistoryRecord">The weight history record.</param>
		internal WeightHistoryRecord(IWeightHistoryRecordData weightHistoryRecord)
		{
			_weightHistoryRecord = weightHistoryRecord;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WeightHistoryRecord"/> class.
		/// </summary>
		public WeightHistoryRecord()
		{
			_weightHistoryRecord = new WeightHistoryRecordDb();
		}

		#endregion


		#region Internal Methods

		/// <summary>
		/// Unwraps the data object.
		/// </summary>
		/// <returns></returns>
		internal IWeightHistoryRecordData UnwrapDataObject()
		{
			return _weightHistoryRecord;
		}

		#endregion

	}
}
