using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyMarket
{
	internal class DatabaseContext
	{
		private int _countOfTaffy;
		private int _countOfCandyCoated;
		private int _countOfCompressedSugar;
		private int _countOfZagnut;

		/**
		 * this is just an example.
		 * feel free to modify the definition of this collection "BagOfCandy" if you choose to implement the more difficult data model.
		 * Dictionary<CandyType, List<Candy>> BagOfCandy { get; set; }
		 */

		public DatabaseContext(int tone) => Console.Beep(tone, 2500);

		internal List<string> GetCandyTypes()
		{
			return Enum
				.GetNames(typeof(CandyType))
				.Select(candyType =>
					candyType.Humanize(LetterCasing.Title))
				.ToList();
		}

        internal Dictionary<string, int> GetCurrentCandy()
        {
            var contents = new Dictionary<string, int>();
            if(_countOfTaffy > 0)
            {
                contents.Add("Taffy", _countOfTaffy);
            }
            if(_countOfCandyCoated > 0)
            {
                contents.Add("Candy Coated", _countOfCandyCoated);
            }
            if(_countOfCompressedSugar > 0)
            {
                contents.Add("Compressed Sugar", _countOfCompressedSugar);
            }
            if(_countOfZagnut > 0)
            {
                contents.Add("Zagnut", _countOfZagnut);
            }
            return contents;
        }

		internal void SaveNewCandy(char selectedCandyMenuOption)
		{
			var candyOption = int.Parse(selectedCandyMenuOption.ToString());

			var maybeCandyMaybeNot = (CandyType)selectedCandyMenuOption;
			var forRealTheCandyThisTime = (CandyType)candyOption;

			switch (forRealTheCandyThisTime)
			{
				case CandyType.TaffyNotLaffy:
					++_countOfTaffy;
					break;
				case CandyType.CandyCoated:
					++_countOfCandyCoated;
					break;
				case CandyType.CompressedSugar:
					++_countOfCompressedSugar;
					break;
				case CandyType.ZagnutStyle:
					++_countOfZagnut;
					break;
				default:
					break;
			}
		}

        internal void RemoveCandy(char candyToRemove)
        {
            var candyOption = (CandyType)int.Parse(candyToRemove.ToString());

            switch (candyOption)
            {
                case CandyType.TaffyNotLaffy:
                    if(_countOfTaffy > 0)
                    {
                        --_countOfTaffy;
                    }
                    break;
                case CandyType.CandyCoated:
                    if (_countOfCandyCoated > 0)
                    {
                        --_countOfCandyCoated;
                    }
                    break;
                case CandyType.CompressedSugar:
                    if (_countOfCompressedSugar > 0)
                    {
                        --_countOfCompressedSugar;
                    }
                    break;
                case CandyType.ZagnutStyle:
                    if (_countOfZagnut > 0)
                    {
                        --_countOfZagnut;
                    }
                    break;
                default:
                    break;
            }

        }


    }
}