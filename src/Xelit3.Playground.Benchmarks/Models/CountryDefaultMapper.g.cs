using System;
using System.Collections.Generic;
using Mapster;
using Xelit3.Benchmarks.Generated;
using Xelit3.Tests.Model.Models;

namespace Xelit3.Benchmarks.Generated
{
    public static partial class CountryDefaultMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static CountryDefaultDto AdaptToDto(this CountryDefault p1)
        {
            return p1 == null ? null : new CountryDefaultDto()
            {
                Name = p1.Name,
                Cities = funcMain1(p1.Cities),
                Citizens = funcMain14(p1.Citizens),
                Id = p1.Id
            };
        }
        public static CountryDefaultDto AdaptTo(this CountryDefault p27, CountryDefaultDto p28)
        {
            if (p27 == null)
            {
                return null;
            }
            CountryDefaultDto result = p28 ?? new CountryDefaultDto();
            
            result.Name = p27.Name;
            result.Cities = funcMain26(p27.Cities, result.Cities);
            result.Citizens = funcMain39(p27.Citizens, result.Citizens);
            result.Id = p27.Id;
            return result;
            
        }
        
        private static ICollection<City<Guid>> funcMain1(ICollection<City<Guid>> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p2.Count);
            
            IEnumerator<City<Guid>> enumerator = p2.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(funcMain2(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain14(ICollection<Person<Guid>> p15)
        {
            if (p15 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p15.Count);
            
            IEnumerator<Person<Guid>> enumerator = p15.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(funcMain15(item));
            }
            return result;
            
        }
        
        private static ICollection<City<Guid>> funcMain26(ICollection<City<Guid>> p29, ICollection<City<Guid>> p30)
        {
            if (p29 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p29.Count);
            
            IEnumerator<City<Guid>> enumerator = p29.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(funcMain27(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain39(ICollection<Person<Guid>> p43, ICollection<Person<Guid>> p44)
        {
            if (p43 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p43.Count);
            
            IEnumerator<Person<Guid>> enumerator = p43.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(funcMain40(item));
            }
            return result;
            
        }
        
        private static City<Guid> funcMain2(City<Guid> p3)
        {
            return p3 == null ? null : new City<Guid>()
            {
                CountryId = p3.CountryId,
                Name = p3.Name,
                Population = p3.Population,
                Country = funcMain3(p3.Country),
                Addresses = funcMain8(p3.Addresses),
                Id = p3.Id
            };
        }
        
        private static Person<Guid> funcMain15(Person<Guid> p16)
        {
            return p16 == null ? null : new Person<Guid>()
            {
                OriginId = p16.OriginId,
                Name = p16.Name,
                Surname = p16.Surname,
                BirthDate = p16.BirthDate,
                Origin = funcMain16(p16.Origin),
                Addresses = funcMain20(p16.Addresses),
                Posts = funcMain25(p16.Posts),
                Id = p16.Id
            };
        }
        
        private static City<Guid> funcMain27(City<Guid> p31)
        {
            return p31 == null ? null : new City<Guid>()
            {
                CountryId = p31.CountryId,
                Name = p31.Name,
                Population = p31.Population,
                Country = funcMain28(p31.Country),
                Addresses = funcMain33(p31.Addresses),
                Id = p31.Id
            };
        }
        
        private static Person<Guid> funcMain40(Person<Guid> p45)
        {
            return p45 == null ? null : new Person<Guid>()
            {
                OriginId = p45.OriginId,
                Name = p45.Name,
                Surname = p45.Surname,
                BirthDate = p45.BirthDate,
                Origin = funcMain41(p45.Origin),
                Addresses = funcMain45(p45.Addresses),
                Posts = funcMain50(p45.Posts),
                Id = p45.Id
            };
        }
        
        private static Country<Guid> funcMain3(Country<Guid> p4)
        {
            return p4 == null ? null : new Country<Guid>()
            {
                Name = p4.Name,
                Cities = TypeAdapterConfig1.GetMapFunction<ICollection<City<Guid>>, ICollection<City<Guid>>>().Invoke(p4.Cities),
                Citizens = funcMain4(p4.Citizens),
                Id = p4.Id
            };
        }
        
        private static ICollection<Address<Guid>> funcMain8(ICollection<Address<Guid>> p9)
        {
            if (p9 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p9.Count);
            
            IEnumerator<Address<Guid>> enumerator = p9.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address<Guid> item = enumerator.Current;
                result.Add(funcMain9(item));
            }
            return result;
            
        }
        
        private static Country<Guid> funcMain16(Country<Guid> p17)
        {
            return p17 == null ? null : new Country<Guid>()
            {
                Name = p17.Name,
                Cities = funcMain17(p17.Cities),
                Citizens = TypeAdapterConfig1.GetMapFunction<ICollection<Person<Guid>>, ICollection<Person<Guid>>>().Invoke(p17.Citizens),
                Id = p17.Id
            };
        }
        
        private static ICollection<Address<Guid>> funcMain20(ICollection<Address<Guid>> p21)
        {
            if (p21 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p21.Count);
            
            IEnumerator<Address<Guid>> enumerator = p21.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address<Guid> item = enumerator.Current;
                result.Add(funcMain21(item));
            }
            return result;
            
        }
        
        private static ICollection<Post<Guid>> funcMain25(ICollection<Post<Guid>> p26)
        {
            if (p26 == null)
            {
                return null;
            }
            ICollection<Post<Guid>> result = new List<Post<Guid>>(p26.Count);
            
            IEnumerator<Post<Guid>> enumerator = p26.GetEnumerator();
            
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
        
        private static Country<Guid> funcMain28(Country<Guid> p32)
        {
            return p32 == null ? null : new Country<Guid>()
            {
                Name = p32.Name,
                Cities = TypeAdapterConfig1.GetMapFunction<ICollection<City<Guid>>, ICollection<City<Guid>>>().Invoke(p32.Cities),
                Citizens = funcMain29(p32.Citizens),
                Id = p32.Id
            };
        }
        
        private static ICollection<Address<Guid>> funcMain33(ICollection<Address<Guid>> p37)
        {
            if (p37 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p37.Count);
            
            IEnumerator<Address<Guid>> enumerator = p37.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address<Guid> item = enumerator.Current;
                result.Add(funcMain34(item));
            }
            return result;
            
        }
        
        private static Country<Guid> funcMain41(Country<Guid> p46)
        {
            return p46 == null ? null : new Country<Guid>()
            {
                Name = p46.Name,
                Cities = funcMain42(p46.Cities),
                Citizens = TypeAdapterConfig1.GetMapFunction<ICollection<Person<Guid>>, ICollection<Person<Guid>>>().Invoke(p46.Citizens),
                Id = p46.Id
            };
        }
        
        private static ICollection<Address<Guid>> funcMain45(ICollection<Address<Guid>> p50)
        {
            if (p50 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p50.Count);
            
            IEnumerator<Address<Guid>> enumerator = p50.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address<Guid> item = enumerator.Current;
                result.Add(funcMain46(item));
            }
            return result;
            
        }
        
        private static ICollection<Post<Guid>> funcMain50(ICollection<Post<Guid>> p55)
        {
            if (p55 == null)
            {
                return null;
            }
            ICollection<Post<Guid>> result = new List<Post<Guid>>(p55.Count);
            
            IEnumerator<Post<Guid>> enumerator = p55.GetEnumerator();
            
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
        
        private static ICollection<Person<Guid>> funcMain4(ICollection<Person<Guid>> p5)
        {
            if (p5 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p5.Count);
            
            IEnumerator<Person<Guid>> enumerator = p5.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(funcMain5(item));
            }
            return result;
            
        }
        
        private static Address<Guid> funcMain9(Address<Guid> p10)
        {
            return p10 == null ? null : new Address<Guid>()
            {
                PersonId = p10.PersonId,
                CityId = p10.CityId,
                Line = p10.Line,
                Sequence = p10.Sequence,
                City = TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(p10.City),
                Person = funcMain10(p10.Person),
                Id = p10.Id
            };
        }
        
        private static ICollection<City<Guid>> funcMain17(ICollection<City<Guid>> p18)
        {
            if (p18 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p18.Count);
            
            IEnumerator<City<Guid>> enumerator = p18.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(funcMain18(item));
            }
            return result;
            
        }
        
        private static Address<Guid> funcMain21(Address<Guid> p22)
        {
            return p22 == null ? null : new Address<Guid>()
            {
                PersonId = p22.PersonId,
                CityId = p22.CityId,
                Line = p22.Line,
                Sequence = p22.Sequence,
                City = funcMain22(p22.City),
                Person = TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(p22.Person),
                Id = p22.Id
            };
        }
        
        private static ICollection<Person<Guid>> funcMain29(ICollection<Person<Guid>> p33)
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
                result.Add(funcMain30(item));
            }
            return result;
            
        }
        
        private static Address<Guid> funcMain34(Address<Guid> p38)
        {
            return p38 == null ? null : new Address<Guid>()
            {
                PersonId = p38.PersonId,
                CityId = p38.CityId,
                Line = p38.Line,
                Sequence = p38.Sequence,
                City = TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(p38.City),
                Person = funcMain35(p38.Person),
                Id = p38.Id
            };
        }
        
        private static ICollection<City<Guid>> funcMain42(ICollection<City<Guid>> p47)
        {
            if (p47 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p47.Count);
            
            IEnumerator<City<Guid>> enumerator = p47.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(funcMain43(item));
            }
            return result;
            
        }
        
        private static Address<Guid> funcMain46(Address<Guid> p51)
        {
            return p51 == null ? null : new Address<Guid>()
            {
                PersonId = p51.PersonId,
                CityId = p51.CityId,
                Line = p51.Line,
                Sequence = p51.Sequence,
                City = funcMain47(p51.City),
                Person = TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(p51.Person),
                Id = p51.Id
            };
        }
        
        private static Person<Guid> funcMain5(Person<Guid> p6)
        {
            return p6 == null ? null : new Person<Guid>()
            {
                OriginId = p6.OriginId,
                Name = p6.Name,
                Surname = p6.Surname,
                BirthDate = p6.BirthDate,
                Origin = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p6.Origin),
                Addresses = funcMain6(p6.Addresses),
                Posts = funcMain7(p6.Posts),
                Id = p6.Id
            };
        }
        
        private static Person<Guid> funcMain10(Person<Guid> p11)
        {
            return p11 == null ? null : new Person<Guid>()
            {
                OriginId = p11.OriginId,
                Name = p11.Name,
                Surname = p11.Surname,
                BirthDate = p11.BirthDate,
                Origin = funcMain11(p11.Origin),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p11.Addresses),
                Posts = funcMain13(p11.Posts),
                Id = p11.Id
            };
        }
        
        private static City<Guid> funcMain18(City<Guid> p19)
        {
            return p19 == null ? null : new City<Guid>()
            {
                CountryId = p19.CountryId,
                Name = p19.Name,
                Population = p19.Population,
                Country = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p19.Country),
                Addresses = funcMain19(p19.Addresses),
                Id = p19.Id
            };
        }
        
        private static City<Guid> funcMain22(City<Guid> p23)
        {
            return p23 == null ? null : new City<Guid>()
            {
                CountryId = p23.CountryId,
                Name = p23.Name,
                Population = p23.Population,
                Country = funcMain23(p23.Country),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p23.Addresses),
                Id = p23.Id
            };
        }
        
        private static Person<Guid> funcMain30(Person<Guid> p34)
        {
            return p34 == null ? null : new Person<Guid>()
            {
                OriginId = p34.OriginId,
                Name = p34.Name,
                Surname = p34.Surname,
                BirthDate = p34.BirthDate,
                Origin = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p34.Origin),
                Addresses = funcMain31(p34.Addresses),
                Posts = funcMain32(p34.Posts),
                Id = p34.Id
            };
        }
        
        private static Person<Guid> funcMain35(Person<Guid> p39)
        {
            return p39 == null ? null : new Person<Guid>()
            {
                OriginId = p39.OriginId,
                Name = p39.Name,
                Surname = p39.Surname,
                BirthDate = p39.BirthDate,
                Origin = funcMain36(p39.Origin),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p39.Addresses),
                Posts = funcMain38(p39.Posts),
                Id = p39.Id
            };
        }
        
        private static City<Guid> funcMain43(City<Guid> p48)
        {
            return p48 == null ? null : new City<Guid>()
            {
                CountryId = p48.CountryId,
                Name = p48.Name,
                Population = p48.Population,
                Country = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p48.Country),
                Addresses = funcMain44(p48.Addresses),
                Id = p48.Id
            };
        }
        
        private static City<Guid> funcMain47(City<Guid> p52)
        {
            return p52 == null ? null : new City<Guid>()
            {
                CountryId = p52.CountryId,
                Name = p52.Name,
                Population = p52.Population,
                Country = funcMain48(p52.Country),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p52.Addresses),
                Id = p52.Id
            };
        }
        
        private static ICollection<Address<Guid>> funcMain6(ICollection<Address<Guid>> p7)
        {
            if (p7 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p7.Count);
            
            IEnumerator<Address<Guid>> enumerator = p7.GetEnumerator();
            
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
        
        private static ICollection<Post<Guid>> funcMain7(ICollection<Post<Guid>> p8)
        {
            if (p8 == null)
            {
                return null;
            }
            ICollection<Post<Guid>> result = new List<Post<Guid>>(p8.Count);
            
            IEnumerator<Post<Guid>> enumerator = p8.GetEnumerator();
            
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
        
        private static Country<Guid> funcMain11(Country<Guid> p12)
        {
            return p12 == null ? null : new Country<Guid>()
            {
                Name = p12.Name,
                Cities = TypeAdapterConfig1.GetMapFunction<ICollection<City<Guid>>, ICollection<City<Guid>>>().Invoke(p12.Cities),
                Citizens = funcMain12(p12.Citizens),
                Id = p12.Id
            };
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
        
        private static ICollection<Address<Guid>> funcMain19(ICollection<Address<Guid>> p20)
        {
            if (p20 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p20.Count);
            
            IEnumerator<Address<Guid>> enumerator = p20.GetEnumerator();
            
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
        
        private static Country<Guid> funcMain23(Country<Guid> p24)
        {
            return p24 == null ? null : new Country<Guid>()
            {
                Name = p24.Name,
                Cities = funcMain24(p24.Cities),
                Citizens = TypeAdapterConfig1.GetMapFunction<ICollection<Person<Guid>>, ICollection<Person<Guid>>>().Invoke(p24.Citizens),
                Id = p24.Id
            };
        }
        
        private static ICollection<Address<Guid>> funcMain31(ICollection<Address<Guid>> p35)
        {
            if (p35 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p35.Count);
            
            IEnumerator<Address<Guid>> enumerator = p35.GetEnumerator();
            
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
        
        private static ICollection<Post<Guid>> funcMain32(ICollection<Post<Guid>> p36)
        {
            if (p36 == null)
            {
                return null;
            }
            ICollection<Post<Guid>> result = new List<Post<Guid>>(p36.Count);
            
            IEnumerator<Post<Guid>> enumerator = p36.GetEnumerator();
            
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
        
        private static Country<Guid> funcMain36(Country<Guid> p40)
        {
            return p40 == null ? null : new Country<Guid>()
            {
                Name = p40.Name,
                Cities = TypeAdapterConfig1.GetMapFunction<ICollection<City<Guid>>, ICollection<City<Guid>>>().Invoke(p40.Cities),
                Citizens = funcMain37(p40.Citizens),
                Id = p40.Id
            };
        }
        
        private static ICollection<Post<Guid>> funcMain38(ICollection<Post<Guid>> p42)
        {
            if (p42 == null)
            {
                return null;
            }
            ICollection<Post<Guid>> result = new List<Post<Guid>>(p42.Count);
            
            IEnumerator<Post<Guid>> enumerator = p42.GetEnumerator();
            
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
        
        private static ICollection<Address<Guid>> funcMain44(ICollection<Address<Guid>> p49)
        {
            if (p49 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p49.Count);
            
            IEnumerator<Address<Guid>> enumerator = p49.GetEnumerator();
            
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
        
        private static Country<Guid> funcMain48(Country<Guid> p53)
        {
            return p53 == null ? null : new Country<Guid>()
            {
                Name = p53.Name,
                Cities = funcMain49(p53.Cities),
                Citizens = TypeAdapterConfig1.GetMapFunction<ICollection<Person<Guid>>, ICollection<Person<Guid>>>().Invoke(p53.Citizens),
                Id = p53.Id
            };
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
        
        private static ICollection<City<Guid>> funcMain24(ICollection<City<Guid>> p25)
        {
            if (p25 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p25.Count);
            
            IEnumerator<City<Guid>> enumerator = p25.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain37(ICollection<Person<Guid>> p41)
        {
            if (p41 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p41.Count);
            
            IEnumerator<Person<Guid>> enumerator = p41.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<City<Guid>> funcMain49(ICollection<City<Guid>> p54)
        {
            if (p54 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p54.Count);
            
            IEnumerator<City<Guid>> enumerator = p54.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(item));
            }
            return result;
            
        }
    }
}