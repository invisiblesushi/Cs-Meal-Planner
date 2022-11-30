using System;
using System.Collections.Generic;
using System.IO;
using MealPlanner.Model;
using Newtonsoft.Json;

namespace MealPlanner.Database
{
    public class JsonDb
    {
        public static List<Meal> MealList = new List<Meal>();

        private static string _mealsFile = @"meals.json";
        private static string _suggestedMealsFile = @"SuggestedMeals.json";

        public static void LoadMeals()
        {
            string data = File.ReadAllText(_mealsFile);
            var objData = JsonConvert.DeserializeObject<List<Meal>>(data);

            MealList = objData;
        }

        public static void SaveMeals()
        {
            var data = JsonConvert.SerializeObject(MealList);
            File.WriteAllText(_mealsFile, data);
        }

        public static List<Meal> GetMealList()
        {
            return MealList;
        }
        
        public static void AddMeal(Meal meal)
        {
            MealList.Add(meal);
            Console.WriteLine($"{meal.Name} added.");
        }
        
        
    }
}