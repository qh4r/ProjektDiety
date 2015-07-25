using System;
using System.Collections.Generic;
using DietyCommonTypes.Enums;
using DietyCommonTypes.Interfaces;

namespace DietyServices.Interfaces
{
    internal interface IDataService
    {
        IUserProfile GetUser(long id);

        IUserProfile GetUser(string userName);

        IEnumerable<IRecipe> GetRecipies(DateTime date);

        IEnumerable<IRecipe> GetRecipies(DateTime startDay, DateTime endDay);

        IEnumerable<IRecipe> GetRecipies(MealTypes mealType);

        IEnumerable<double> GetUserWeightHistory(long id, DateTime startDate, DateTime? endDay = null);

        IEnumerable<IRecipe> GetUserMealsHistory(long id, DateTime startDate, DateTime? endDay = null);

        IEnumerable<ITraining> GetUserTrainingsHistory(long id, DateTime startDate, DateTime? endDay = null);

        IEnumerable<IRecipe> GetUserPlannedMeals(long id, DateTime startDate, DateTime? endDay = null);

        void AddRecipe(IRecipe recipe);

        void AddPlannedMeal(IRecipe recipe, DateTime plannedDate);
    }
}