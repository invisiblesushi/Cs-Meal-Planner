using System;
using System.Collections.Generic;
using MealPlanner.Database;
using MealPlanner.Model;

namespace MealPlanner
{
    internal class Program
    {
        /*
        * A simple console application that generates meal suggestions for a week.
        * The suggestions are saved in the SuggestedMeals.json file.
        * The functions of the program are "AddDish" "ViewAllMealList" and "GenerateMenu".
        * AddDish - adds a custom dish to the whole list of meals.
        * ViewAllMealList - shows the full list of meals including nutritional values.
        * GenerateMenu - generates menu for a week and saves it in JSON format.
        */
        
        public static void Main(string[] args)
        {
            JsonDb.LoadMeals();
            //Planner.ViewAllMealList();

            List<WeekMeals> weekMeals = Planner.GenerateMenu(1000);
            Planner.ViewAllWeekMealList(weekMeals);
            JsonDb.SaveWeekMeals(weekMeals);

            //Planner.AddDish();
            //JsonDb.SaveMeals();

        }
    }
}