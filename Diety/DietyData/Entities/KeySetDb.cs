using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DietyCommonTypes.Interfaces;
using DietyDataTransportTypes.Interfaces;

namespace DietyData.Entities
{
	public class KeySetDb : IKeySetData
	{
		#region Public Properties

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
		/// Gets or sets the key.
		/// </summary>
		/// <value>
		/// The key.
		/// </value>
		public string Key { get; set; }

		/// <summary>
		/// Gets or sets the vi.
		/// </summary>
		/// <value>
		/// The vi.
		/// </value>
		public string Vi { get; set; }

		/// <summary>
		/// Gets or sets the owner.
		/// </summary>
		/// <value>
		/// The owner.
		/// </value>
		[Column("Owner")]
		public UserProfileDb UserData { get; set; }

		/// <summary>
		/// Gets or sets the owner.
		/// </summary>
		/// <value>
		/// The owner.
		/// </value>
		[NotMapped]
		public IUserProfile Owner
		{
			get { return UserData;}
			set { UserData = value as UserProfileDb; }
		}
		#endregion
	}
}