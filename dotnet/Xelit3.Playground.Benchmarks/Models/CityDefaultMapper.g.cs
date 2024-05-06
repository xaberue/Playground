using System;
using System.Collections.Generic;
using Mapster;
using Xelit3.Benchmarks.Generated;
using Xelit3.Tests.Model.Models;

namespace Xelit3.Benchmarks.Generated
{
    public static partial class CityDefaultMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static CityDefaultDto AdaptToDto(this CityDefault p1)
        {
            return p1 == null ? null : new CityDefaultDto()
            {
                CountryId = p1.CountryId,
                Name = p1.Name,
                Population = p1.Population,
                Country = funcMain1(p1.Country),
                Addresses = funcMain12(p1.Addresses),
                Id = p1.Id
            };
        }
        public static CityDefaultDto AdaptTo(this CityDefault p26, CityDefaultDto p27)
        {
            if (p26 == null)
            {
                return null;
            }
            CityDefaultDto result = p27 ?? new CityDefaultDto();
            
            result.CountryId = p26.CountryId;
            result.Name = p26.Name;
            result.Population = p26.Population;
            result.Country = funcMain25(p26.Country, result.Country);
            result.Addresses = funcMain36(p26.Addresses, result.Addresses);
            result.Id = p26.Id;
            return result;
            
        }
        
        private static Country<Guid> funcMain1(Country<Guid> p2)
        {
            return p2 == null ? null : new Country<Guid>()
            {
                Name = p2.Name,
                Cities = funcMain2(p2.Cities),
                Citizens = funcMain8(p2.Citizens),
                Id = p2.Id
            };
        }
        
        private static ICollection<Address<Guid>> funcMain12(ICollection<Address<Guid>> p13)
        {
            if (p13 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p13.Count);
            
            IEnumerator<Address<Guid>> enumerator = p13.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address<Guid> item = enumerator.Current;
                result.Add(funcMain13(item));
            }
            return result;
            
        }
        
        private static Country<Guid> funcMain25(Country<Guid> p28, Country<Guid> p29)
        {
            if (p28 == null)
            {
                return null;
            }
            Country<Guid> result = p29 ?? new Country<Guid>();
            
            result.Name = p28.Name;
            result.Cities = funcMain26(p28.Cities, result.Cities);
            result.Citizens = funcMain32(p28.Citizens, result.Citizens);
            result.Id = p28.Id;
            return result;
            
        }
        
        private static ICollection<Address<Guid>> funcMain36(ICollection<Address<Guid>> p42, ICollection<Address<Guid>> p43)
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
                result.Add(funcMain37(item));
            }
            return result;
            
        }
        
        private static ICollection<City<Guid>> funcMain2(ICollection<City<Guid>> p3)
        {
            if (p3 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p3.Count);
            
            IEnumerator<City<Guid>> enumerator = p3.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(funcMain3(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain8(ICollection<Person<Guid>> p9)
        {
            if (p9 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p9.Count);
            
            IEnumerator<Person<Guid>> enumerator = p9.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(funcMain9(item));
            }
            return result;
            
        }
        
        private static Address<Guid> funcMain13(Address<Guid> p14)
        {
            return p14 == null ? null : new Address<Guid>()
            {
                PersonId = p14.PersonId,
                CityId = p14.CityId,
                Line = p14.Line,
                Sequence = p14.Sequence,
                City = funcMain14(p14.City),
                Person = funcMain20(p14.Person),
                Id = p14.Id
            };
        }
        
        private static ICollection<City<Guid>> funcMain26(ICollection<City<Guid>> p30, ICollection<City<Guid>> p31)
        {
            if (p30 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p30.Count);
            
            IEnumerator<City<Guid>> enumerator = p30.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(funcMain27(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain32(ICollection<Person<Guid>> p37, ICollection<Person<Guid>> p38)
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
                result.Add(funcMain33(item));
            }
            return result;
            
        }
        
        private static Address<Guid> funcMain37(Address<Guid> p44)
        {
            return p44 == null ? null : new Address<Guid>()
            {
                PersonId = p44.PersonId,
                CityId = p44.CityId,
                Line = p44.Line,
                Sequence = p44.Sequence,
                City = funcMain38(p44.City),
                Person = funcMain44(p44.Person),
                Id = p44.Id
            };
        }
        
        private static City<Guid> funcMain3(City<Guid> p4)
        {
            return p4 == null ? null : new City<Guid>()
            {
                CountryId = p4.CountryId,
                Name = p4.Name,
                Population = p4.Population,
                Country = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p4.Country),
                Addresses = funcMain4(p4.Addresses),
                Id = p4.Id
            };
        }
        
        private static Person<Guid> funcMain9(Person<Guid> p10)
        {
            return p10 == null ? null : new Person<Guid>()
            {
                OriginId = p10.OriginId,
                Name = p10.Name,
                Surname = p10.Surname,
                Email = p10.Email,
                PhoneNumber = p10.PhoneNumber,
                Bio = p10.Bio,
                BirthDate = p10.BirthDate,
                Origin = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p10.Origin),
                Addresses = funcMain10(p10.Addresses),
                Posts = funcMain11(p10.Posts),
                Id = p10.Id
            };
        }
        
        private static City<Guid> funcMain14(City<Guid> p15)
        {
            return p15 == null ? null : new City<Guid>()
            {
                CountryId = p15.CountryId,
                Name = p15.Name,
                Population = p15.Population,
                Country = funcMain15(p15.Country),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p15.Addresses),
                Id = p15.Id
            };
        }
        
        private static Person<Guid> funcMain20(Person<Guid> p21)
        {
            return p21 == null ? null : new Person<Guid>()
            {
                OriginId = p21.OriginId,
                Name = p21.Name,
                Surname = p21.Surname,
                Email = p21.Email,
                PhoneNumber = p21.PhoneNumber,
                Bio = p21.Bio,
                BirthDate = p21.BirthDate,
                Origin = funcMain21(p21.Origin),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p21.Addresses),
                Posts = funcMain24(p21.Posts),
                Id = p21.Id
            };
        }
        
        private static City<Guid> funcMain27(City<Guid> p32)
        {
            return p32 == null ? null : new City<Guid>()
            {
                CountryId = p32.CountryId,
                Name = p32.Name,
                Population = p32.Population,
                Country = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p32.Country),
                Addresses = funcMain28(p32.Addresses),
                Id = p32.Id
            };
        }
        
        private static Person<Guid> funcMain33(Person<Guid> p39)
        {
            return p39 == null ? null : new Person<Guid>()
            {
                OriginId = p39.OriginId,
                Name = p39.Name,
                Surname = p39.Surname,
                Email = p39.Email,
                PhoneNumber = p39.PhoneNumber,
                Bio = p39.Bio,
                BirthDate = p39.BirthDate,
                Origin = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p39.Origin),
                Addresses = funcMain34(p39.Addresses),
                Posts = funcMain35(p39.Posts),
                Id = p39.Id
            };
        }
        
        private static City<Guid> funcMain38(City<Guid> p45)
        {
            return p45 == null ? null : new City<Guid>()
            {
                CountryId = p45.CountryId,
                Name = p45.Name,
                Population = p45.Population,
                Country = funcMain39(p45.Country),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p45.Addresses),
                Id = p45.Id
            };
        }
        
        private static Person<Guid> funcMain44(Person<Guid> p51)
        {
            return p51 == null ? null : new Person<Guid>()
            {
                OriginId = p51.OriginId,
                Name = p51.Name,
                Surname = p51.Surname,
                Email = p51.Email,
                PhoneNumber = p51.PhoneNumber,
                Bio = p51.Bio,
                BirthDate = p51.BirthDate,
                Origin = funcMain45(p51.Origin),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p51.Addresses),
                Posts = funcMain48(p51.Posts),
                Id = p51.Id
            };
        }
        
        private static ICollection<Address<Guid>> funcMain4(ICollection<Address<Guid>> p5)
        {
            if (p5 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p5.Count);
            
            IEnumerator<Address<Guid>> enumerator = p5.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address<Guid> item = enumerator.Current;
                result.Add(funcMain5(item));
            }
            return result;
            
        }
        
        private static ICollection<Address<Guid>> funcMain10(ICollection<Address<Guid>> p11)
        {
            if (p11 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p11.Count);
            
            IEnumerator<Address<Guid>> enumerator = p11.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address<Guid> item = enumerator.Current;
                result.Add(item == null ? null : new Address<Guid>()
                {
                    PersonId = item.PersonId,
                    CityId = item.CityId,
                    Line = item.Line,
                    Sequence = item.Sequence,
                    City = item.City == null ? null : new City<Guid>()
                    {
                        CountryId = item.City.CountryId,
                        Name = item.City.Name,
                        Population = item.City.Population,
                        Country = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(item.City.Country),
                        Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(item.City.Addresses),
                        Id = item.City.Id
                    },
                    Person = TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item.Person),
                    Id = item.Id
                });
            }
            return result;
            
        }
        
        private static ICollection<Post<Guid>> funcMain11(ICollection<Post<Guid>> p12)
        {
            if (p12 == null)
            {
                return null;
            }
            ICollection<Post<Guid>> result = new List<Post<Guid>>(p12.Count);
            
            IEnumerator<Post<Guid>> enumerator = p12.GetEnumerator();
            
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
        
        private static Country<Guid> funcMain15(Country<Guid> p16)
        {
            return p16 == null ? null : new Country<Guid>()
            {
                Name = p16.Name,
                Cities = funcMain16(p16.Cities),
                Citizens = funcMain17(p16.Citizens),
                Id = p16.Id
            };
        }
        
        private static Country<Guid> funcMain21(Country<Guid> p22)
        {
            return p22 == null ? null : new Country<Guid>()
            {
                Name = p22.Name,
                Cities = funcMain22(p22.Cities),
                Citizens = funcMain23(p22.Citizens),
                Id = p22.Id
            };
        }
        
        private static ICollection<Post<Guid>> funcMain24(ICollection<Post<Guid>> p25)
        {
            if (p25 == null)
            {
                return null;
            }
            ICollection<Post<Guid>> result = new List<Post<Guid>>(p25.Count);
            
            IEnumerator<Post<Guid>> enumerator = p25.GetEnumerator();
            
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
        
        private static ICollection<Address<Guid>> funcMain28(ICollection<Address<Guid>> p33)
        {
            if (p33 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p33.Count);
            
            IEnumerator<Address<Guid>> enumerator = p33.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address<Guid> item = enumerator.Current;
                result.Add(funcMain29(item));
            }
            return result;
            
        }
        
        private static ICollection<Address<Guid>> funcMain34(ICollection<Address<Guid>> p40)
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
                    City = item.City == null ? null : new City<Guid>()
                    {
                        CountryId = item.City.CountryId,
                        Name = item.City.Name,
                        Population = item.City.Population,
                        Country = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(item.City.Country),
                        Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(item.City.Addresses),
                        Id = item.City.Id
                    },
                    Person = TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item.Person),
                    Id = item.Id
                });
            }
            return result;
            
        }
        
        private static ICollection<Post<Guid>> funcMain35(ICollection<Post<Guid>> p41)
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
        
        private static Country<Guid> funcMain39(Country<Guid> p46)
        {
            return p46 == null ? null : new Country<Guid>()
            {
                Name = p46.Name,
                Cities = funcMain40(p46.Cities),
                Citizens = funcMain41(p46.Citizens),
                Id = p46.Id
            };
        }
        
        private static Country<Guid> funcMain45(Country<Guid> p52)
        {
            return p52 == null ? null : new Country<Guid>()
            {
                Name = p52.Name,
                Cities = funcMain46(p52.Cities),
                Citizens = funcMain47(p52.Citizens),
                Id = p52.Id
            };
        }
        
        private static ICollection<Post<Guid>> funcMain48(ICollection<Post<Guid>> p55)
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
        
        private static Address<Guid> funcMain5(Address<Guid> p6)
        {
            return p6 == null ? null : new Address<Guid>()
            {
                PersonId = p6.PersonId,
                CityId = p6.CityId,
                Line = p6.Line,
                Sequence = p6.Sequence,
                City = TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(p6.City),
                Person = funcMain6(p6.Person),
                Id = p6.Id
            };
        }
        
        private static ICollection<City<Guid>> funcMain16(ICollection<City<Guid>> p17)
        {
            if (p17 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p17.Count);
            
            IEnumerator<City<Guid>> enumerator = p17.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain17(ICollection<Person<Guid>> p18)
        {
            if (p18 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p18.Count);
            
            IEnumerator<Person<Guid>> enumerator = p18.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(funcMain18(item));
            }
            return result;
            
        }
        
        private static ICollection<City<Guid>> funcMain22(ICollection<City<Guid>> p23)
        {
            if (p23 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p23.Count);
            
            IEnumerator<City<Guid>> enumerator = p23.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(item == null ? null : new City<Guid>()
                {
                    CountryId = item.CountryId,
                    Name = item.Name,
                    Population = item.Population,
                    Country = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(item.Country),
                    Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(item.Addresses),
                    Id = item.Id
                });
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain23(ICollection<Person<Guid>> p24)
        {
            if (p24 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p24.Count);
            
            IEnumerator<Person<Guid>> enumerator = p24.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static Address<Guid> funcMain29(Address<Guid> p34)
        {
            return p34 == null ? null : new Address<Guid>()
            {
                PersonId = p34.PersonId,
                CityId = p34.CityId,
                Line = p34.Line,
                Sequence = p34.Sequence,
                City = TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(p34.City),
                Person = funcMain30(p34.Person),
                Id = p34.Id
            };
        }
        
        private static ICollection<City<Guid>> funcMain40(ICollection<City<Guid>> p47)
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
        
        private static ICollection<Person<Guid>> funcMain41(ICollection<Person<Guid>> p48)
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
                result.Add(funcMain42(item));
            }
            return result;
            
        }
        
        private static ICollection<City<Guid>> funcMain46(ICollection<City<Guid>> p53)
        {
            if (p53 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p53.Count);
            
            IEnumerator<City<Guid>> enumerator = p53.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(item == null ? null : new City<Guid>()
                {
                    CountryId = item.CountryId,
                    Name = item.Name,
                    Population = item.Population,
                    Country = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(item.Country),
                    Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(item.Addresses),
                    Id = item.Id
                });
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain47(ICollection<Person<Guid>> p54)
        {
            if (p54 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p54.Count);
            
            IEnumerator<Person<Guid>> enumerator = p54.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static Person<Guid> funcMain6(Person<Guid> p7)
        {
            return p7 == null ? null : new Person<Guid>()
            {
                OriginId = p7.OriginId,
                Name = p7.Name,
                Surname = p7.Surname,
                Email = p7.Email,
                PhoneNumber = p7.PhoneNumber,
                Bio = p7.Bio,
                BirthDate = p7.BirthDate,
                Origin = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p7.Origin),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p7.Addresses),
                Posts = funcMain7(p7.Posts),
                Id = p7.Id
            };
        }
        
        private static Person<Guid> funcMain18(Person<Guid> p19)
        {
            return p19 == null ? null : new Person<Guid>()
            {
                OriginId = p19.OriginId,
                Name = p19.Name,
                Surname = p19.Surname,
                Email = p19.Email,
                PhoneNumber = p19.PhoneNumber,
                Bio = p19.Bio,
                BirthDate = p19.BirthDate,
                Origin = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p19.Origin),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p19.Addresses),
                Posts = funcMain19(p19.Posts),
                Id = p19.Id
            };
        }
        
        private static Person<Guid> funcMain30(Person<Guid> p35)
        {
            return p35 == null ? null : new Person<Guid>()
            {
                OriginId = p35.OriginId,
                Name = p35.Name,
                Surname = p35.Surname,
                Email = p35.Email,
                PhoneNumber = p35.PhoneNumber,
                Bio = p35.Bio,
                BirthDate = p35.BirthDate,
                Origin = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p35.Origin),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p35.Addresses),
                Posts = funcMain31(p35.Posts),
                Id = p35.Id
            };
        }
        
        private static Person<Guid> funcMain42(Person<Guid> p49)
        {
            return p49 == null ? null : new Person<Guid>()
            {
                OriginId = p49.OriginId,
                Name = p49.Name,
                Surname = p49.Surname,
                Email = p49.Email,
                PhoneNumber = p49.PhoneNumber,
                Bio = p49.Bio,
                BirthDate = p49.BirthDate,
                Origin = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p49.Origin),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p49.Addresses),
                Posts = funcMain43(p49.Posts),
                Id = p49.Id
            };
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
        
        private static ICollection<Post<Guid>> funcMain19(ICollection<Post<Guid>> p20)
        {
            if (p20 == null)
            {
                return null;
            }
            ICollection<Post<Guid>> result = new List<Post<Guid>>(p20.Count);
            
            IEnumerator<Post<Guid>> enumerator = p20.GetEnumerator();
            
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
        
        private static ICollection<Post<Guid>> funcMain31(ICollection<Post<Guid>> p36)
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
        
        private static ICollection<Post<Guid>> funcMain43(ICollection<Post<Guid>> p50)
        {
            if (p50 == null)
            {
                return null;
            }
            ICollection<Post<Guid>> result = new List<Post<Guid>>(p50.Count);
            
            IEnumerator<Post<Guid>> enumerator = p50.GetEnumerator();
            
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
    }
}