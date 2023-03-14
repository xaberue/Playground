using System;
using System.Collections.Generic;
using Mapster;
using Xelit3.Benchmarks.Generated;
using Xelit3.Tests.Model;

namespace Xelit3.Benchmarks.Generated
{
    public static partial class PostDefaultMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static PostDefaultDto AdaptToDto(this PostDefault p1)
        {
            return p1 == null ? null : new PostDefaultDto()
            {
                AuthorId = p1.AuthorId,
                Title = p1.Title,
                Text = p1.Text,
                Author = funcMain1(p1.Author),
                Id = p1.Id
            };
        }
        public static PostDefaultDto AdaptTo(this PostDefault p15, PostDefaultDto p16)
        {
            if (p15 == null)
            {
                return null;
            }
            PostDefaultDto result = p16 ?? new PostDefaultDto();
            
            result.AuthorId = p15.AuthorId;
            result.Title = p15.Title;
            result.Text = p15.Text;
            result.Author = funcMain14(p15.Author, result.Author);
            result.Id = p15.Id;
            return result;
            
        }
        
        private static Person<Guid> funcMain1(Person<Guid> p2)
        {
            return p2 == null ? null : new Person<Guid>()
            {
                OriginId = p2.OriginId,
                Name = p2.Name,
                Surname = p2.Surname,
                BirthDate = p2.BirthDate,
                Origin = funcMain2(p2.Origin),
                Addresses = funcMain7(p2.Addresses),
                Posts = funcMain13(p2.Posts),
                Id = p2.Id
            };
        }
        
        private static Person<Guid> funcMain14(Person<Guid> p17, Person<Guid> p18)
        {
            if (p17 == null)
            {
                return null;
            }
            Person<Guid> result = p18 ?? new Person<Guid>();
            
            result.OriginId = p17.OriginId;
            result.Name = p17.Name;
            result.Surname = p17.Surname;
            result.BirthDate = p17.BirthDate;
            result.Origin = funcMain15(p17.Origin, result.Origin);
            result.Addresses = funcMain20(p17.Addresses, result.Addresses);
            result.Posts = funcMain26(p17.Posts, result.Posts);
            result.Id = p17.Id;
            return result;
            
        }
        
        private static Country<Guid> funcMain2(Country<Guid> p3)
        {
            return p3 == null ? null : new Country<Guid>()
            {
                Name = p3.Name,
                Cities = funcMain3(p3.Cities),
                Citizens = funcMain6(p3.Citizens),
                Id = p3.Id
            };
        }
        
        private static ICollection<Address<Guid>> funcMain7(ICollection<Address<Guid>> p8)
        {
            if (p8 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p8.Count);
            
            IEnumerator<Address<Guid>> enumerator = p8.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address<Guid> item = enumerator.Current;
                result.Add(funcMain8(item));
            }
            return result;
            
        }
        
        private static ICollection<Post<Guid>> funcMain13(ICollection<Post<Guid>> p14)
        {
            if (p14 == null)
            {
                return null;
            }
            ICollection<Post<Guid>> result = new List<Post<Guid>>(p14.Count);
            
            IEnumerator<Post<Guid>> enumerator = p14.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Post<Guid> item = enumerator.Current;
                result.Add(item == null ? null : new Post<Guid>()
                {
                    AuthorId = item.AuthorId,
                    Title = item.Title,
                    Text = item.Text,
                    Author = TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item.Author),
                    Id = item.Id
                });
            }
            return result;
            
        }
        
        private static Country<Guid> funcMain15(Country<Guid> p19, Country<Guid> p20)
        {
            if (p19 == null)
            {
                return null;
            }
            Country<Guid> result = p20 ?? new Country<Guid>();
            
            result.Name = p19.Name;
            result.Cities = funcMain16(p19.Cities, result.Cities);
            result.Citizens = funcMain19(p19.Citizens, result.Citizens);
            result.Id = p19.Id;
            return result;
            
        }
        
        private static ICollection<Address<Guid>> funcMain20(ICollection<Address<Guid>> p27, ICollection<Address<Guid>> p28)
        {
            if (p27 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p27.Count);
            
            IEnumerator<Address<Guid>> enumerator = p27.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address<Guid> item = enumerator.Current;
                result.Add(funcMain21(item));
            }
            return result;
            
        }
        
        private static ICollection<Post<Guid>> funcMain26(ICollection<Post<Guid>> p34, ICollection<Post<Guid>> p35)
        {
            if (p34 == null)
            {
                return null;
            }
            ICollection<Post<Guid>> result = new List<Post<Guid>>(p34.Count);
            
            IEnumerator<Post<Guid>> enumerator = p34.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Post<Guid> item = enumerator.Current;
                result.Add(item == null ? null : new Post<Guid>()
                {
                    AuthorId = item.AuthorId,
                    Title = item.Title,
                    Text = item.Text,
                    Author = TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item.Author),
                    Id = item.Id
                });
            }
            return result;
            
        }
        
        private static ICollection<City<Guid>> funcMain3(ICollection<City<Guid>> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p4.Count);
            
            IEnumerator<City<Guid>> enumerator = p4.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(funcMain4(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain6(ICollection<Person<Guid>> p7)
        {
            if (p7 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p7.Count);
            
            IEnumerator<Person<Guid>> enumerator = p7.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static Address<Guid> funcMain8(Address<Guid> p9)
        {
            return p9 == null ? null : new Address<Guid>()
            {
                PersonId = p9.PersonId,
                CityId = p9.CityId,
                Line = p9.Line,
                Sequence = p9.Sequence,
                City = funcMain9(p9.City),
                Person = TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(p9.Person),
                Id = p9.Id
            };
        }
        
        private static ICollection<City<Guid>> funcMain16(ICollection<City<Guid>> p21, ICollection<City<Guid>> p22)
        {
            if (p21 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p21.Count);
            
            IEnumerator<City<Guid>> enumerator = p21.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(funcMain17(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain19(ICollection<Person<Guid>> p25, ICollection<Person<Guid>> p26)
        {
            if (p25 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p25.Count);
            
            IEnumerator<Person<Guid>> enumerator = p25.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static Address<Guid> funcMain21(Address<Guid> p29)
        {
            return p29 == null ? null : new Address<Guid>()
            {
                PersonId = p29.PersonId,
                CityId = p29.CityId,
                Line = p29.Line,
                Sequence = p29.Sequence,
                City = funcMain22(p29.City),
                Person = TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(p29.Person),
                Id = p29.Id
            };
        }
        
        private static City<Guid> funcMain4(City<Guid> p5)
        {
            return p5 == null ? null : new City<Guid>()
            {
                CountryId = p5.CountryId,
                Name = p5.Name,
                Population = p5.Population,
                Country = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p5.Country),
                Addresses = funcMain5(p5.Addresses),
                Id = p5.Id
            };
        }
        
        private static City<Guid> funcMain9(City<Guid> p10)
        {
            return p10 == null ? null : new City<Guid>()
            {
                CountryId = p10.CountryId,
                Name = p10.Name,
                Population = p10.Population,
                Country = funcMain10(p10.Country),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p10.Addresses),
                Id = p10.Id
            };
        }
        
        private static City<Guid> funcMain17(City<Guid> p23)
        {
            return p23 == null ? null : new City<Guid>()
            {
                CountryId = p23.CountryId,
                Name = p23.Name,
                Population = p23.Population,
                Country = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p23.Country),
                Addresses = funcMain18(p23.Addresses),
                Id = p23.Id
            };
        }
        
        private static City<Guid> funcMain22(City<Guid> p30)
        {
            return p30 == null ? null : new City<Guid>()
            {
                CountryId = p30.CountryId,
                Name = p30.Name,
                Population = p30.Population,
                Country = funcMain23(p30.Country),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p30.Addresses),
                Id = p30.Id
            };
        }
        
        private static ICollection<Address<Guid>> funcMain5(ICollection<Address<Guid>> p6)
        {
            if (p6 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p6.Count);
            
            IEnumerator<Address<Guid>> enumerator = p6.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address<Guid> item = enumerator.Current;
                result.Add(item == null ? null : new Address<Guid>()
                {
                    PersonId = item.PersonId,
                    CityId = item.CityId,
                    Line = item.Line,
                    Sequence = item.Sequence,
                    City = TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(item.City),
                    Person = TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item.Person),
                    Id = item.Id
                });
            }
            return result;
            
        }
        
        private static Country<Guid> funcMain10(Country<Guid> p11)
        {
            return p11 == null ? null : new Country<Guid>()
            {
                Name = p11.Name,
                Cities = funcMain11(p11.Cities),
                Citizens = funcMain12(p11.Citizens),
                Id = p11.Id
            };
        }
        
        private static ICollection<Address<Guid>> funcMain18(ICollection<Address<Guid>> p24)
        {
            if (p24 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p24.Count);
            
            IEnumerator<Address<Guid>> enumerator = p24.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address<Guid> item = enumerator.Current;
                result.Add(item == null ? null : new Address<Guid>()
                {
                    PersonId = item.PersonId,
                    CityId = item.CityId,
                    Line = item.Line,
                    Sequence = item.Sequence,
                    City = TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(item.City),
                    Person = TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item.Person),
                    Id = item.Id
                });
            }
            return result;
            
        }
        
        private static Country<Guid> funcMain23(Country<Guid> p31)
        {
            return p31 == null ? null : new Country<Guid>()
            {
                Name = p31.Name,
                Cities = funcMain24(p31.Cities),
                Citizens = funcMain25(p31.Citizens),
                Id = p31.Id
            };
        }
        
        private static ICollection<City<Guid>> funcMain11(ICollection<City<Guid>> p12)
        {
            if (p12 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p12.Count);
            
            IEnumerator<City<Guid>> enumerator = p12.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain12(ICollection<Person<Guid>> p13)
        {
            if (p13 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p13.Count);
            
            IEnumerator<Person<Guid>> enumerator = p13.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<City<Guid>> funcMain24(ICollection<City<Guid>> p32)
        {
            if (p32 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p32.Count);
            
            IEnumerator<City<Guid>> enumerator = p32.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain25(ICollection<Person<Guid>> p33)
        {
            if (p33 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p33.Count);
            
            IEnumerator<Person<Guid>> enumerator = p33.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item));
            }
            return result;
            
        }
    }
}