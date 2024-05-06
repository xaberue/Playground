using Xelit3.Tests.Model.Models;

namespace Xelit3.Tests.Model
{
    public class CityHelper 
    {
        public static City<TKey> GetSingle<TKey>()
        {
            return new City<TKey>() { Name = "Barcelona", Population = 3600000 };
        }
    }
}
