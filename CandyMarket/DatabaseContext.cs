using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyMarket
{
	internal class DatabaseContext
	{
        Dictionary<string, int> _taffy = new Dictionary<string, int>();
        Dictionary<string, int> _candyCoated = new Dictionary<string, int>();
        Dictionary<string, int> _compressedSugar = new Dictionary<string, int>();
        Dictionary<string, int> _zagnut = new Dictionary<string, int>();


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

        //internal Dictionary<string, int> GetCurrentCandy()
        //{
        //    var contents = new Dictionary<string, int>();
        //    if(_countOfTaffy > 0)
        //    {
        //        contents.Add("Taffy", _countOfTaffy);
        //    }
        //    if(_countOfCandyCoated > 0)
        //    {
        //        contents.Add("Candy Coated", _countOfCandyCoated);
        //    }
        //    if(_countOfCompressedSugar > 0)
        //    {
        //        contents.Add("Compressed Sugar", _countOfCompressedSugar);
        //    }
        //    if(_countOfZagnut > 0)
        //    {
        //        contents.Add("Zagnut", _countOfZagnut);
        //    }
        //    return contents;
        //}

		internal void SaveNewCandy(string userName, CandyType candyType, int howMany)
		{
            if (!_taffy.ContainsKey(userName))
            {
                _taffy.Add(userName, 0);
                _candyCoated.Add(userName, 0);
                _compressedSugar.Add(userName, 0);
                _zagnut.Add(userName, 0);
            }

			switch (candyType)
			{
				case CandyType.TaffyNotLaffy:
					_taffy[userName] += howMany;
					break;
				case CandyType.CandyCoated:
					_candyCoated[userName] += howMany;
					break;
				case CandyType.CompressedSugar:
					_compressedSugar[userName] += howMany;
					break;
				case CandyType.ZagnutStyle:
					_zagnut[userName] += howMany;
					break;
				default:
					break;
			}
		}

        internal void RemoveCandy(string name, CandyType type)
        {


            switch (type)
            {
                case CandyType.TaffyNotLaffy:
                    if (_taffy[name] > 0)
                    {
                        _taffy[name]--;
                    }
                    break;
                case CandyType.CandyCoated:
                    if (_candyCoated[name] > 0)
                    {
                        _candyCoated[name]--;
                    }
                    break;
                case CandyType.CompressedSugar:
                    if (_compressedSugar[name]-- > 0)
                    {
                        _compressedSugar[name]--;
                    }
                    break;
                case CandyType.ZagnutStyle:
                    if (_zagnut[name] > 0)
                    {
                        _zagnut[name]--;
                    }
                    break;
                default:
                    break;
            }

        }


    }
}