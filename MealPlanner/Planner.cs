using System;
using System.Collections.Generic;
using MealPlanner.Database;
using MealPlanner.Model;

namespace MealPlanner
{
    public class Planner
    {

        public static void AddDish()
        {
            var meal = new Meal();

            Console.WriteLine("Dish name:");
            meal.Name = Console.ReadLine();
            Console.WriteLine("Calories:");
            meal.Calories = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Protein:");
            meal.Protein = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Carbohydrate:");
            meal.Carbohydrate = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Fat:");
            meal.Fat = Int32.Parse(Console.ReadLine());
            
            JsonDb.AddMeal(meal);
        }

        public static void ViewAllMealList()
        {
            List<Meal> meals = JsonDb.GetMealList();
            meals.ForEach( mealObj => Console.WriteLine($"Name : {mealObj.Name} \t " +
                                                        $"Calories: {mealObj.Calories} \t " +
                                                        $"Protein: {mealObj.Protein} \t " +
                                                        $"Carbohydrate: {mealObj.Carbohydrate} \t " +
                                                        $"Fat: {mealObj.Fat}"));
            
        }
        
    }
}