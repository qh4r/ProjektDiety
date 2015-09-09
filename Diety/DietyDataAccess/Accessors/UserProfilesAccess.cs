using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DietyCommonTypes.Interfaces;
using DietyData.Entities;
using DietyDataAccess.Accessors.Interfaces;
using DietyDataAccess.DataTypes;
using DietyDataTransportTypes.Interfaces;

namespace DietyDataAccess.Accessors
{
	public class UserProfilesAccess : DataAccessBase, IUserProfilesAccess
	{		
		#region Public Methods

		/// <summary>
		/// Adds the meal record.
		/// </summary>
		/// <param name="item">The meal history record.</param>
		/// <returns></returns>
		public async Task<IUserProfile> AddUser(IUserProfile item)
		{
			var wrappedRecord = item as UserProfile;
			var newMealRecord = wrappedRecord != null ? wrappedRecord.UnwrapDataObject() : item;

			if (newMealRecord != null)
			{
				using (var dietyContext = DietyDbContext)
				{
					DietyDbContext.Database.Log = s => Debug.WriteLine(s);
					var user = newMealRecord as UserProfileDb;					
					DietyDbContext.UserProfiles.AddOrUpdate(new UserProfileDb
					{
						UserName = user.UserName,
						Height = user.Height,
						HashedPassword = user.HashedPassword,
						Weight = user.Weight
					});					
					try
					{
						var liczba = DietyDbContext.SaveChanges();
					}
					catch (Exception e)
					{
						Debug.WriteLine(e.Message);
					}
				}
				await Task.Yield();
			}
			return item;
		}

		/// <summary>
		/// Gets the meal history records list.
		/// </summary>
		/// <param name="searchCondition">The search condition.</param>
		/// <param name="orderRule">The order rule.</param>
		/// <param name="skipCount">The skip count.</param>
		/// <param name="takeCount">The take count.</param>
		/// <returns></returns>
		public async Task<IEnumerable<IUserProfile>> GetUserProfilesList(
			Func<IUserProfile, bool> searchCondition = null,
			Func<IUserProfile, object> orderRule = null,
			int skipCount = 0, int takeCount = Int32.MaxValue)
		{
			using (var dietyContext = DataAccessBase.DietyDbContext)
			{
				IEnumerable<IUserProfile> outputList;
				if (orderRule != null)
				{
					outputList =
						DietyDbContext.UserProfiles.Where(searchCondition ?? (x => true))
							.OrderBy(orderRule)
							.Skip(skipCount);
				}
				else
				{
					outputList =
						DietyDbContext.UserProfiles.Where(searchCondition ?? (x => true))							
							.Skip(skipCount)
							.Take(takeCount);
				}
				await Task.Yield();
				return outputList.Select(x => new UserProfile(x));
			}
		}

		/// <summary>
		/// Gets the meal history record.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public async Task<IUserProfile> GetUserProfile(long id)
		{
			using (var dietyContext = DietyDbContext)
			{
				var record = await DietyDbContext.UserProfiles.FirstOrDefaultAsync(x => x.Id == id);
				return record != null ? new UserProfile(record) : null;
			}
		}

		/// <summary>
		/// Gets the name of the user profile by.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public async Task<IUserProfile> GetUserProfileByName(string name)
		{
			using (var dietyContext = DietyDbContext)
			{
				var record = await DietyDbContext.UserProfiles.FirstOrDefaultAsync(x => x.UserName == name);
				return record != null ? new UserProfile(record) : null;
			}
		}
		#endregion
	}
}
