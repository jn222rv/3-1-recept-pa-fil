using FiledRecipes.Domain;
using FiledRecipes.App.Mvp;
using FiledRecipes.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FiledRecipes.Views
{
    /// <summary>
    /// 
    /// </summary>
    public class RecipeView : ViewBase, IRecipeView
    {
        public void Show(IRecipe recipe)
        {
            Console.Clear();
            Header = recipe.Name;
            ShowHeaderPanel();
            
            Console.WriteLine();
            Console.WriteLine("Ingredienser");
            Console.WriteLine("============");
            for (int i = 0; i < recipe.Ingredients.Count(); i++)
            {
                Console.WriteLine(recipe.Ingredients.ElementAt(i));
            }

            Console.WriteLine();
            Console.WriteLine("Gör så här");
            Console.WriteLine("==========");
            for (int i = 0; i < recipe.Instructions.Count(); i++)
            {
                Console.Write("({0}) ", i + 1);
                Console.WriteLine(recipe.Instructions.ElementAt(i));
            }
        }
        public void Show(IEnumerable<IRecipe> recipes)
        {
            recipes = recipes.OrderBy(c => c.Name).ToList();

            ConsoleKeyInfo cki = new ConsoleKeyInfo();

            int index = 0;

            do
            {
                Console.Clear();
                Header = recipes.ElementAt(index).Name;
                ShowHeaderPanel();

                Show(recipes.ElementAt(index));
                
                ShowPanel("Använd piltangenterna + Backspace", App.Controls.MessagePanelOptions.Info);

                cki = Console.ReadKey(true);

                if (cki.Key == ConsoleKey.LeftArrow)
                {
                    if (index == 0)
                    {
                        index = recipes.Count() - 1;
                    }
                    else
                    {
                        index--;
                    }
                }
                else if (cki.Key == ConsoleKey.RightArrow)
                {
                    if (index == recipes.Count() - 1)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                }
            } while (cki.Key != ConsoleKey.Backspace);
        }		
    }
}
