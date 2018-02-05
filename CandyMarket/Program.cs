using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyMarket
{
	class Program
	{
		static void Main(string[] args)
		{
			// wanna be a l33t h@x0r? skip all this console menu nonsense and go with straight command line arguments. something like `candy-market add taffy "blueberry cheesecake" yesterday`
			var db = SetupNewApp();

			var run = true;
			while (run)
			{
				ConsoleKeyInfo userInput = MainMenu();
                ConsoleKeyInfo selectedCandyType;
				switch (userInput.KeyChar)
				{
					case '0':
						run = false;
						break;
					case '1': // add candy to your bag

						// select a candy type
						selectedCandyType = DisplayCandyMenu(db, "What type of candy did you get?");

						/** MORE DIFFICULT DATA MODEL
						 * show a new menu to enter candy details
						 * it would be convenient to show the menu in stages e.g. press enter to go to next detail stage, but write the whole screen again with responses populated so far.
						 */

						// if(moreDifficultDataModel) bug - this is passing candy type right now (which just increments in our DatabaseContext), but should also be passing candy details
						db.SaveNewCandy(selectedCandyType.KeyChar);
						break;
					case '2':
                        selectedCandyType = DisplayCandyMenu(db, "What kind of candy did you eat?");
                        ShowCandy(db);
                        Console.ReadKey();
                        db.RemoveCandy(selectedCandyType.KeyChar);
						/** eat candy
						 * select a candy type
						 
						 * select specific candy details to eat from list filtered to selected candy type
						 * 
						 * enjoy candy
						 */
						break;
					case '3':
                        selectedCandyType = DisplayCandyMenu(db, "What kind of candy did you throw away?");
                        db.RemoveCandy(selectedCandyType.KeyChar);
						/** throw away candy
						 * select a candy type
						 * if(moreDifficultDataModel) enhancement - give user the option to throw away old candy in one action. this would require capturing the detail of when the candy was new.
						 * 
						 * select specific candy details to throw away from list filtered to selected candy type
						 * 
						 * cry for lost candy
						 */
						break;
					case '4':

                        selectedCandyType = DisplayCandyMenu(db, "What kind of candy did you give away?");
                        db.RemoveCandy(selectedCandyType.KeyChar);
						/** give candy
						 * feel free to hardcode your users. no need to create a whole UI to register users.
						 * no one is impressed by user registration unless it's just amazingly fast & simple
						 * 
						 * select candy in any manner you prefer.
						 * it may be easiest to reuse some code for throwing away candy since that's basically what you're doing. except instead of throwing it away, you're giving it away to another user.
						 * you'll need a way to select what user you're giving candy to.
						 * one design suggestion would be to put candy "on the table" and then "give the candy on the table" to another user once you've selected all the candy to give away
						 */
						break;
					case '5':
                        selectedCandyType = DisplayCandyMenu(db, "What kind of candy did you give away?");
                        db.RemoveCandy(selectedCandyType.KeyChar);
                        /** trade candy
						 * this is the next logical step. who wants to just give away candy forever?
						 */
                        break;
                    case '6':
                        // show all available candy for above options
                        //selectedCandyType = DisplayCandyMenu(db, "What kind of candy did you throw away?");
                        ShowCandy(db);
                        break;
					default: // what about requesting candy? like a wishlist. that would be cool.
						break;
				}
			}
		}

		static DatabaseContext SetupNewApp()
		{
			Console.Title = "Cross Confectioneries Incorporated";

			var cSharp = 554;
			var db = new DatabaseContext(tone: cSharp);

			Console.SetWindowSize(60, 30);
			Console.SetBufferSize(60, 30);
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;
			return db;
		}

		static ConsoleKeyInfo MainMenu()
		{
			View mainMenu = new View()
					.AddMenuOption("Did you just get some new candy? Add it here.")
					.AddMenuOption("Do you want to eat some candy? Take it here.")
                    .AddMenuOption("Did you throw away some candy? Remove it here.")
                    .AddMenuOption("Do you want to give away some of your candy? Do it here.")
                    .AddMenuOption("Do you want to trade some of your candy? Trade it here.")
                    .AddMenuOption("Show all of your available candy.")
					.AddMenuText("Press 0 to exit.");

			Console.Write(mainMenu.GetFullMenu());
			ConsoleKeyInfo userOption = Console.ReadKey();
			return userOption;
		}

		static ConsoleKeyInfo DisplayCandyMenu(DatabaseContext db, string MenuText)
		{
			var candyTypes = db.GetCandyTypes();

            var newCandyMenu = new View()
                    .AddMenuText(MenuText)
					.AddMenuOptions(candyTypes);

			Console.Write(newCandyMenu.GetFullMenu());

			ConsoleKeyInfo selectedCandyType = Console.ReadKey();
			return selectedCandyType;
		}

        static void ShowCandy(DatabaseContext db)
        {
            var currentCandy = db.GetCurrentCandy();
            var currentCandyMenu = new View();
            

            foreach (var typeOfCandy in currentCandy)
            {
                if (currentCandy.Count > 0)
                {
                    currentCandyMenu.AddMenuText($"You have {typeOfCandy.Value} of {typeOfCandy.Key}.");
                }

                if(currentCandy.Count < 1)
                {
                    var noCandyMenu = new View()
                    .AddMenuOption("You have no candy right now! Go add some!")
                    .AddMenuText("Press 0 to exit.");

                }             
            }

            Console.Write(currentCandyMenu.GetFullMenu());
        }
	}
}
