using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DietyCommonTypes.Enums;
using DietyCommonTypes.Interfaces;
using DietyDataTransportTypes.Interfaces;

namespace DietyData.Entities
{
	[Table("Recipes")]
	public class RecipeDb : IRecipeData
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
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }
		[Column("ComponentsList")]
		virtual public List<RecipeComponentDb> ComponentsListData { get; set; }

		/// <summary>
		/// Gets or sets the components list.
		/// </summary>
		/// <value>
		/// The components list.
		/// </value>
		[NotMapped]
		public IEnumerable<IRecipeComponent> ComponentsList
		{
			get
			{
				return ComponentsListData;
			}
			set
			{
				var list = value.Select(recipeComponent => recipeComponent as RecipeComponentDb).ToList();
				ComponentsListData = list;
			}
		}		

		/// <summary>
		/// Gets or sets the type of the meal.
		/// </summary>
		/// <value>
		/// The type of the meal.
		/// </value>
		public MealTypes MealType { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the image.
		/// </summary>
		/// <value>
		/// The image.
		/// </value>
		public byte[] Image { get; set; }

		#endregion

		#region C-tors	

		/// <summary>
		/// Prevents a default instance of the <see cref="RecipeDb"/> class from being created.
		/// </summary>
		public RecipeDb()
		{
			ComponentsListData = new List<RecipeComponentDb>(); 
		}

		#endregion
	}
}
