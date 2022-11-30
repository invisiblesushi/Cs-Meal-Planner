using System;
using System.Collections.Generic;
using MealPlanner.Database;
using MealPlanner.Model;

namespace MealPlanner
{
    public class Planner
    {
        private static string[] WeekDays = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

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

        // Prints all meals in list
        public static void ViewAllMealList()
        {
            List<Meal> meals = JsonDb.GetMealList();
            meals.ForEach( mealObj => Console.WriteLine($"Name : {mealObj.Name} \t " +
                                                        $"Calories: {mealObj.Calories} \t " +
                                                        $"Protein: {mealObj.Protein} \t " +
                                                        $"Carbohydrate: {mealObj.Carbohydrate} \t " +
                                                        $"Fat: {mealObj.Fat}"));
        }

        // Generate week menu based on the input calories until total calories are met
        public static List<WeekMeals> GenerateMenu(int InputCalories)
        {
            List<Meal> mealsList = JsonDb.GetMealList();
            List<WeekMeals> weekMeals = new List<WeekMeals>();
            
            Random random = new Random();

            foreach (var weekDay in WeekDays)
            {
                int totalCalories = 0;
                WeekMeals dayMeal = new WeekMeals();
                
                while (totalCalories <= InputCalories)
                {
                    dayMeal.Day = weekDay;
                    var dish = mealsList[random.Next(mealsList.Count)];

                    dayMeal.MealForDay.Add(dish);
                    totalCalories += dish.Calories;
                }
                weekMeals.Add(dayMeal);
            }

            return weekMeals;
        }

        // Prints the suggested meals for the week
        public static void ViewAllWeekMealList(List<WeekMeals> weekMeals)
        {
            foreach (var weekMeal in weekMeals)
            {
                Console.WriteLine($"Day: {weekMeal.Day}");
                
                weekMeal.MealForDay.ForEach(meal => 
                    Console.WriteLine($"Meal: {meal.Name} Calories: {meal.Calories}")
                );
            }

        }
        
    }
}