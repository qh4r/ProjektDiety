using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DietyCommonTypes.Interfaces;

namespace DietyData.Entities
{
	public class Sample : ISample
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
		/// Gets or sets the sample property.
		/// </summary>
		/// <value>
		/// The sample property.
		/// </value>
		public string SampleProperty { get; set; }

		#endregion
	}
}
