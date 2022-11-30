using System.Collections.Generic;

namespace MealPlanner.Model
{
    public class WeekMeals
    {
        public string Day { get; set; }
        public List<Meal> MealForDay { get; set; } = new List<Meal>();
    }
}