using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DietyCommonTypes.Interfaces;
using DietyDataTransportTypes.Interfaces;

namespace DietyData.Entities
{
	[Table("WeightHistoryRecords")]
    public class WeightHistoryRecordDb: IWeightHistoryRecordData
    {

        #region Properties
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; } 

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>
		/// The date.
		/// </value>
        public DateTime Date{get; set;}

		/// <summary>
		/// Gets or sets the weight.
		/// </summary>
		/// <value>
		/// The weight.
		/// </value>
        public double Weight{get; set;}

		/// <summary>
		/// Gets or sets the user data.
		/// </summary>
		/// <value>
		/// The user data.
		/// </value>
		[InverseProperty("WeightHistoryData")]
		public virtual UserProfileDb UserData { get; set; }

		/// <summary>
		/// Gets the creator identifier.
		/// </summary>
		/// <value>
		/// The creator identifier.
		/// </value>
		[NotMapped]
		public IUserProfile Owner
		{
			get { return UserData; }
			set { UserData = value as UserProfileDb; }
		}


        #endregion
    }
}
