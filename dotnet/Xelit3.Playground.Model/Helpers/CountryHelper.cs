using Xelit3.Tests.Model.Models;

namespace Xelit3.Tests.Model
{
    public class CountryHelper
	{
		public static Country<TKey> GetSingle<TKey>()
		{
            return new Country<TKey>() { Id = default, Name = "Kenya" };
        }
	}
}
