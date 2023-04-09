using System;
using System.Collections.Generic;
using Mapster;
using Xelit3.Benchmarks.Generated;
using Xelit3.Tests.Model.Models;

namespace Xelit3.Benchmarks.Generated
{
    public static partial class AddressDefaultMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static AddressDefaultDto AdaptToDto(this AddressDefault p1)
        {
            return p1 == null ? null : new AddressDefaultDto()
            {
                PersonId = p1.PersonId,
                CityId = p1.CityId,
                Line = p1.Line,
                Sequence = p1.Sequence,
                City = funcMain1(p1.City),
                Person = funcMain15(p1.Person),
                Id = p1.Id
            };
        }
        public static AddressDefaultDto AdaptTo(this AddressDefault p29, AddressDefaultDto p30)
        {
            if (p29 == null)
            {
                return null;
            }
            AddressDefaultDto result = p30 ?? new AddressDefaultDto();
            
            result.PersonId = p29.PersonId;
            result.CityId = p29.CityId;
            result.Line = p29.Line;
            result.Sequence = p29.Sequence;
            result.City = funcMain28(p29.City, result.City);
            result.Person = funcMain42(p29.Person, result.Person);
            result.Id = p29.Id;
            return result;
            
        }
        
        private static City<Guid> funcMain1(City<Guid> p2)
        {
            return p2 == null ? null : new City<Guid>()
            {
                CountryId = p2.CountryId,
                Name = p2.Name,
                Population = p2.Population,
                Country = funcMain2(p2.Country),
                Addresses = funcMain8(p2.Addresses),
                Id = p2.Id
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
                Addresses = funcMain21(p16.Addresses),
                Posts = funcMain27(p16.Posts),
                Id = p16.Id
            };
        }
        
        private static City<Guid> funcMain28(City<Guid> p31, City<Guid> p32)
        {
            if (p31 == null)
            {
                return null;
            }
            City<Guid> result = p32 ?? new City<Guid>();
            
            result.CountryId = p31.CountryId;
            result.Name = p31.Name;
            result.Population = p31.Population;
            result.Country = funcMain29(p31.Country, result.Country);
            result.Addresses = funcMain35(p31.Addresses, result.Addresses);
            result.Id = p31.Id;
            return result;
            
        }
        
        private static Person<Guid> funcMain42(Person<Guid> p50, Person<Guid> p51)
        {
            if (p50 == null)
            {
                return null;
            }
            Person<Guid> result = p51 ?? new Person<Guid>();
            
            result.OriginId = p50.OriginId;
            result.Name = p50.Name;
            result.Surname = p50.Surname;
            result.BirthDate = p50.BirthDate;
            result.Origin = funcMain43(p50.Origin, result.Origin);
            result.Addresses = funcMain48(p50.Addresses, result.Addresses);
            result.Posts = funcMain54(p50.Posts, result.Posts);
            result.Id = p50.Id;
            return result;
            
        }
        
        private static Country<Guid> funcMain2(Country<Guid> p3)
        {
            return p3 == null ? null : new Country<Guid>()
            {
                Name = p3.Name,
                Cities = funcMain3(p3.Cities),
                Citizens = funcMain4(p3.Citizens),
                Id = p3.Id
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
                Citizens = funcMain20(p17.Citizens),
                Id = p17.Id
            };
        }
        
        private static ICollection<Address<Guid>> funcMain21(ICollection<Address<Guid>> p22)
        {
            if (p22 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p22.Count);
            
            IEnumerator<Address<Guid>> enumerator = p22.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address<Guid> item = enumerator.Current;
                result.Add(funcMain22(item));
            }
            return result;
            
        }
        
        private static ICollection<Post<Guid>> funcMain27(ICollection<Post<Guid>> p28)
        {
            if (p28 == null)
            {
                return null;
            }
            ICollection<Post<Guid>> result = new List<Post<Guid>>(p28.Count);
            
            IEnumerator<Post<Guid>> enumerator = p28.GetEnumerator();
            
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
        
        private static Country<Guid> funcMain29(Country<Guid> p33, Country<Guid> p34)
        {
            if (p33 == null)
            {
                return null;
            }
            Country<Guid> result = p34 ?? new Country<Guid>();
            
            result.Name = p33.Name;
            result.Cities = funcMain30(p33.Cities, result.Cities);
            result.Citizens = funcMain31(p33.Citizens, result.Citizens);
            result.Id = p33.Id;
            return result;
            
        }
        
        private static ICollection<Address<Guid>> funcMain35(ICollection<Address<Guid>> p42, ICollection<Address<Guid>> p43)
        {
            if (p42 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p42.Count);
            
            IEnumerator<Address<Guid>> enumerator = p42.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address<Guid> item = enumerator.Current;
                result.Add(funcMain36(item));
            }
            return result;
            
        }
        
        private static Country<Guid> funcMain43(Country<Guid> p52, Country<Guid> p53)
        {
            if (p52 == null)
            {
                return null;
            }
            Country<Guid> result = p53 ?? new Country<Guid>();
            
            result.Name = p52.Name;
            result.Cities = funcMain44(p52.Cities, result.Cities);
            result.Citizens = funcMain47(p52.Citizens, result.Citizens);
            result.Id = p52.Id;
            return result;
            
        }
        
        private static ICollection<Address<Guid>> funcMain48(ICollection<Address<Guid>> p60, ICollection<Address<Guid>> p61)
        {
            if (p60 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p60.Count);
            
            IEnumerator<Address<Guid>> enumerator = p60.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address<Guid> item = enumerator.Current;
                result.Add(funcMain49(item));
            }
            return result;
            
        }
        
        private static ICollection<Post<Guid>> funcMain54(ICollection<Post<Guid>> p67, ICollection<Post<Guid>> p68)
        {
            if (p67 == null)
            {
                return null;
            }
            ICollection<Post<Guid>> result = new List<Post<Guid>>(p67.Count);
            
            IEnumerator<Post<Guid>> enumerator = p67.GetEnumerator();
            
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
                result.Add(TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(item));
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
        
        private static ICollection<Person<Guid>> funcMain20(ICollection<Person<Guid>> p21)
        {
            if (p21 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p21.Count);
            
            IEnumerator<Person<Guid>> enumerator = p21.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static Address<Guid> funcMain22(Address<Guid> p23)
        {
            return p23 == null ? null : new Address<Guid>()
            {
                PersonId = p23.PersonId,
                CityId = p23.CityId,
                Line = p23.Line,
                Sequence = p23.Sequence,
                City = funcMain23(p23.City),
                Person = TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(p23.Person),
                Id = p23.Id
            };
        }
        
        private static ICollection<City<Guid>> funcMain30(ICollection<City<Guid>> p35, ICollection<City<Guid>> p36)
        {
            if (p35 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p35.Count);
            
            IEnumerator<City<Guid>> enumerator = p35.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain31(ICollection<Person<Guid>> p37, ICollection<Person<Guid>> p38)
        {
            if (p37 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p37.Count);
            
            IEnumerator<Person<Guid>> enumerator = p37.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(funcMain32(item));
            }
            return result;
            
        }
        
        private static Address<Guid> funcMain36(Address<Guid> p44)
        {
            return p44 == null ? null : new Address<Guid>()
            {
                PersonId = p44.PersonId,
                CityId = p44.CityId,
                Line = p44.Line,
                Sequence = p44.Sequence,
                City = TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(p44.City),
                Person = funcMain37(p44.Person),
                Id = p44.Id
            };
        }
        
        private static ICollection<City<Guid>> funcMain44(ICollection<City<Guid>> p54, ICollection<City<Guid>> p55)
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
                result.Add(funcMain45(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain47(ICollection<Person<Guid>> p58, ICollection<Person<Guid>> p59)
        {
            if (p58 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p58.Count);
            
            IEnumerator<Person<Guid>> enumerator = p58.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static Address<Guid> funcMain49(Address<Guid> p62)
        {
            return p62 == null ? null : new Address<Guid>()
            {
                PersonId = p62.PersonId,
                CityId = p62.CityId,
                Line = p62.Line,
                Sequence = p62.Sequence,
                City = funcMain50(p62.City),
                Person = TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(p62.Person),
                Id = p62.Id
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
                Posts = funcMain14(p11.Posts),
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
        
        private static City<Guid> funcMain23(City<Guid> p24)
        {
            return p24 == null ? null : new City<Guid>()
            {
                CountryId = p24.CountryId,
                Name = p24.Name,
                Population = p24.Population,
                Country = funcMain24(p24.Country),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p24.Addresses),
                Id = p24.Id
            };
        }
        
        private static Person<Guid> funcMain32(Person<Guid> p39)
        {
            return p39 == null ? null : new Person<Guid>()
            {
                OriginId = p39.OriginId,
                Name = p39.Name,
                Surname = p39.Surname,
                BirthDate = p39.BirthDate,
                Origin = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p39.Origin),
                Addresses = funcMain33(p39.Addresses),
                Posts = funcMain34(p39.Posts),
                Id = p39.Id
            };
        }
        
        private static Person<Guid> funcMain37(Person<Guid> p45)
        {
            return p45 == null ? null : new Person<Guid>()
            {
                OriginId = p45.OriginId,
                Name = p45.Name,
                Surname = p45.Surname,
                BirthDate = p45.BirthDate,
                Origin = funcMain38(p45.Origin),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p45.Addresses),
                Posts = funcMain41(p45.Posts),
                Id = p45.Id
            };
        }
        
        private static City<Guid> funcMain45(City<Guid> p56)
        {
            return p56 == null ? null : new City<Guid>()
            {
                CountryId = p56.CountryId,
                Name = p56.Name,
                Population = p56.Population,
                Country = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p56.Country),
                Addresses = funcMain46(p56.Addresses),
                Id = p56.Id
            };
        }
        
        private static City<Guid> funcMain50(City<Guid> p63)
        {
            return p63 == null ? null : new City<Guid>()
            {
                CountryId = p63.CountryId,
                Name = p63.Name,
                Population = p63.Population,
                Country = funcMain51(p63.Country),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p63.Addresses),
                Id = p63.Id
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
                Cities = funcMain12(p12.Cities),
                Citizens = funcMain13(p12.Citizens),
                Id = p12.Id
            };
        }
        
        private static ICollection<Post<Guid>> funcMain14(ICollection<Post<Guid>> p15)
        {
            if (p15 == null)
            {
                return null;
            }
            ICollection<Post<Guid>> result = new List<Post<Guid>>(p15.Count);
            
            IEnumerator<Post<Guid>> enumerator = p15.GetEnumerator();
            
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
        
        private static Country<Guid> funcMain24(Country<Guid> p25)
        {
            return p25 == null ? null : new Country<Guid>()
            {
                Name = p25.Name,
                Cities = funcMain25(p25.Cities),
                Citizens = funcMain26(p25.Citizens),
                Id = p25.Id
            };
        }
        
        private static ICollection<Address<Guid>> funcMain33(ICollection<Address<Guid>> p40)
        {
            if (p40 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p40.Count);
            
            IEnumerator<Address<Guid>> enumerator = p40.GetEnumerator();
            
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
        
        private static ICollection<Post<Guid>> funcMain34(ICollection<Post<Guid>> p41)
        {
            if (p41 == null)
            {
                return null;
            }
            ICollection<Post<Guid>> result = new List<Post<Guid>>(p41.Count);
            
            IEnumerator<Post<Guid>> enumerator = p41.GetEnumerator();
            
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
        
        private static Country<Guid> funcMain38(Country<Guid> p46)
        {
            return p46 == null ? null : new Country<Guid>()
            {
                Name = p46.Name,
                Cities = funcMain39(p46.Cities),
                Citizens = funcMain40(p46.Citizens),
                Id = p46.Id
            };
        }
        
        private static ICollection<Post<Guid>> funcMain41(ICollection<Post<Guid>> p49)
        {
            if (p49 == null)
            {
                return null;
            }
            ICollection<Post<Guid>> result = new List<Post<Guid>>(p49.Count);
            
            IEnumerator<Post<Guid>> enumerator = p49.GetEnumerator();
            
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
        
        private static ICollection<Address<Guid>> funcMain46(ICollection<Address<Guid>> p57)
        {
            if (p57 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p57.Count);
            
            IEnumerator<Address<Guid>> enumerator = p57.GetEnumerator();
            
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
        
        private static Country<Guid> funcMain51(Country<Guid> p64)
        {
            return p64 == null ? null : new Country<Guid>()
            {
                Name = p64.Name,
                Cities = funcMain52(p64.Cities),
                Citizens = funcMain53(p64.Citizens),
                Id = p64.Id
            };
        }
        
        private static ICollection<City<Guid>> funcMain12(ICollection<City<Guid>> p13)
        {
            if (p13 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p13.Count);
            
            IEnumerator<City<Guid>> enumerator = p13.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain13(ICollection<Person<Guid>> p14)
        {
            if (p14 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p14.Count);
            
            IEnumerator<Person<Guid>> enumerator = p14.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<City<Guid>> funcMain25(ICollection<City<Guid>> p26)
        {
            if (p26 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p26.Count);
            
            IEnumerator<City<Guid>> enumerator = p26.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain26(ICollection<Person<Guid>> p27)
        {
            if (p27 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p27.Count);
            
            IEnumerator<Person<Guid>> enumerator = p27.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<City<Guid>> funcMain39(ICollection<City<Guid>> p47)
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
                result.Add(TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain40(ICollection<Person<Guid>> p48)
        {
            if (p48 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p48.Count);
            
            IEnumerator<Person<Guid>> enumerator = p48.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<City<Guid>> funcMain52(ICollection<City<Guid>> p65)
        {
            if (p65 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p65.Count);
            
            IEnumerator<City<Guid>> enumerator = p65.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain53(ICollection<Person<Guid>> p66)
        {
            if (p66 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p66.Count);
            
            IEnumerator<Person<Guid>> enumerator = p66.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item));
            }
            return result;
            
        }
    }
}