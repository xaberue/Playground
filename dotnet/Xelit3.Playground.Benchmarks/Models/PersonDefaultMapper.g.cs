using System;
using System.Collections.Generic;
using Mapster;
using Xelit3.Benchmarks.Generated;
using Xelit3.Tests.Model.Models;

namespace Xelit3.Benchmarks.Generated
{
    public static partial class PersonDefaultMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static PersonDefaultDto AdaptToDto(this PersonDefault p1)
        {
            return p1 == null ? null : new PersonDefaultDto()
            {
                OriginId = p1.OriginId,
                Name = p1.Name,
                Surname = p1.Surname,
                Email = p1.Email,
                PhoneNumber = p1.PhoneNumber,
                Bio = p1.Bio,
                BirthDate = p1.BirthDate,
                Origin = funcMain1(p1.Origin),
                Addresses = funcMain12(p1.Addresses),
                Posts = funcMain25(p1.Posts),
                Id = p1.Id
            };
        }
        public static PersonDefaultDto AdaptTo(this PersonDefault p40, PersonDefaultDto p41)
        {
            if (p40 == null)
            {
                return null;
            }
            PersonDefaultDto result = p41 ?? new PersonDefaultDto();
            
            result.OriginId = p40.OriginId;
            result.Name = p40.Name;
            result.Surname = p40.Surname;
            result.Email = p40.Email;
            result.PhoneNumber = p40.PhoneNumber;
            result.Bio = p40.Bio;
            result.BirthDate = p40.BirthDate;
            result.Origin = funcMain39(p40.Origin, result.Origin);
            result.Addresses = funcMain50(p40.Addresses, result.Addresses);
            result.Posts = funcMain63(p40.Posts, result.Posts);
            result.Id = p40.Id;
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
                result.Add(funcMain26(item));
            }
            return result;
            
        }
        
        private static Country<Guid> funcMain39(Country<Guid> p42, Country<Guid> p43)
        {
            if (p42 == null)
            {
                return null;
            }
            Country<Guid> result = p43 ?? new Country<Guid>();
            
            result.Name = p42.Name;
            result.Cities = funcMain40(p42.Cities, result.Cities);
            result.Citizens = funcMain46(p42.Citizens, result.Citizens);
            result.Id = p42.Id;
            return result;
            
        }
        
        private static ICollection<Address<Guid>> funcMain50(ICollection<Address<Guid>> p56, ICollection<Address<Guid>> p57)
        {
            if (p56 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p56.Count);
            
            IEnumerator<Address<Guid>> enumerator = p56.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address<Guid> item = enumerator.Current;
                result.Add(funcMain51(item));
            }
            return result;
            
        }
        
        private static ICollection<Post<Guid>> funcMain63(ICollection<Post<Guid>> p70, ICollection<Post<Guid>> p71)
        {
            if (p70 == null)
            {
                return null;
            }
            ICollection<Post<Guid>> result = new List<Post<Guid>>(p70.Count);
            
            IEnumerator<Post<Guid>> enumerator = p70.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Post<Guid> item = enumerator.Current;
                result.Add(funcMain64(item));
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
        
        private static Post<Guid> funcMain26(Post<Guid> p27)
        {
            return p27 == null ? null : new Post<Guid>()
            {
                AuthorId = p27.AuthorId,
                Title = p27.Title,
                Text = p27.Text,
                Author = funcMain27(p27.Author),
                Id = p27.Id
            };
        }
        
        private static ICollection<City<Guid>> funcMain40(ICollection<City<Guid>> p44, ICollection<City<Guid>> p45)
        {
            if (p44 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p44.Count);
            
            IEnumerator<City<Guid>> enumerator = p44.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(funcMain41(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain46(ICollection<Person<Guid>> p51, ICollection<Person<Guid>> p52)
        {
            if (p51 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p51.Count);
            
            IEnumerator<Person<Guid>> enumerator = p51.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(funcMain47(item));
            }
            return result;
            
        }
        
        private static Address<Guid> funcMain51(Address<Guid> p58)
        {
            return p58 == null ? null : new Address<Guid>()
            {
                PersonId = p58.PersonId,
                CityId = p58.CityId,
                Line = p58.Line,
                Sequence = p58.Sequence,
                City = funcMain52(p58.City),
                Person = funcMain58(p58.Person),
                Id = p58.Id
            };
        }
        
        private static Post<Guid> funcMain64(Post<Guid> p72)
        {
            return p72 == null ? null : new Post<Guid>()
            {
                AuthorId = p72.AuthorId,
                Title = p72.Title,
                Text = p72.Text,
                Author = funcMain65(p72.Author),
                Id = p72.Id
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
        
        private static Person<Guid> funcMain27(Person<Guid> p28)
        {
            return p28 == null ? null : new Person<Guid>()
            {
                OriginId = p28.OriginId,
                Name = p28.Name,
                Surname = p28.Surname,
                Email = p28.Email,
                PhoneNumber = p28.PhoneNumber,
                Bio = p28.Bio,
                BirthDate = p28.BirthDate,
                Origin = funcMain28(p28.Origin),
                Addresses = funcMain33(p28.Addresses),
                Posts = TypeAdapterConfig1.GetMapFunction<ICollection<Post<Guid>>, ICollection<Post<Guid>>>().Invoke(p28.Posts),
                Id = p28.Id
            };
        }
        
        private static City<Guid> funcMain41(City<Guid> p46)
        {
            return p46 == null ? null : new City<Guid>()
            {
                CountryId = p46.CountryId,
                Name = p46.Name,
                Population = p46.Population,
                Country = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p46.Country),
                Addresses = funcMain42(p46.Addresses),
                Id = p46.Id
            };
        }
        
        private static Person<Guid> funcMain47(Person<Guid> p53)
        {
            return p53 == null ? null : new Person<Guid>()
            {
                OriginId = p53.OriginId,
                Name = p53.Name,
                Surname = p53.Surname,
                Email = p53.Email,
                PhoneNumber = p53.PhoneNumber,
                Bio = p53.Bio,
                BirthDate = p53.BirthDate,
                Origin = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p53.Origin),
                Addresses = funcMain48(p53.Addresses),
                Posts = funcMain49(p53.Posts),
                Id = p53.Id
            };
        }
        
        private static City<Guid> funcMain52(City<Guid> p59)
        {
            return p59 == null ? null : new City<Guid>()
            {
                CountryId = p59.CountryId,
                Name = p59.Name,
                Population = p59.Population,
                Country = funcMain53(p59.Country),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p59.Addresses),
                Id = p59.Id
            };
        }
        
        private static Person<Guid> funcMain58(Person<Guid> p65)
        {
            return p65 == null ? null : new Person<Guid>()
            {
                OriginId = p65.OriginId,
                Name = p65.Name,
                Surname = p65.Surname,
                Email = p65.Email,
                PhoneNumber = p65.PhoneNumber,
                Bio = p65.Bio,
                BirthDate = p65.BirthDate,
                Origin = funcMain59(p65.Origin),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p65.Addresses),
                Posts = funcMain62(p65.Posts),
                Id = p65.Id
            };
        }
        
        private static Person<Guid> funcMain65(Person<Guid> p73)
        {
            return p73 == null ? null : new Person<Guid>()
            {
                OriginId = p73.OriginId,
                Name = p73.Name,
                Surname = p73.Surname,
                Email = p73.Email,
                PhoneNumber = p73.PhoneNumber,
                Bio = p73.Bio,
                BirthDate = p73.BirthDate,
                Origin = funcMain66(p73.Origin),
                Addresses = funcMain71(p73.Addresses),
                Posts = TypeAdapterConfig1.GetMapFunction<ICollection<Post<Guid>>, ICollection<Post<Guid>>>().Invoke(p73.Posts),
                Id = p73.Id
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
        
        private static Country<Guid> funcMain28(Country<Guid> p29)
        {
            return p29 == null ? null : new Country<Guid>()
            {
                Name = p29.Name,
                Cities = funcMain29(p29.Cities),
                Citizens = funcMain32(p29.Citizens),
                Id = p29.Id
            };
        }
        
        private static ICollection<Address<Guid>> funcMain33(ICollection<Address<Guid>> p34)
        {
            if (p34 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p34.Count);
            
            IEnumerator<Address<Guid>> enumerator = p34.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address<Guid> item = enumerator.Current;
                result.Add(funcMain34(item));
            }
            return result;
            
        }
        
        private static ICollection<Address<Guid>> funcMain42(ICollection<Address<Guid>> p47)
        {
            if (p47 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p47.Count);
            
            IEnumerator<Address<Guid>> enumerator = p47.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address<Guid> item = enumerator.Current;
                result.Add(funcMain43(item));
            }
            return result;
            
        }
        
        private static ICollection<Address<Guid>> funcMain48(ICollection<Address<Guid>> p54)
        {
            if (p54 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p54.Count);
            
            IEnumerator<Address<Guid>> enumerator = p54.GetEnumerator();
            
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
        
        private static ICollection<Post<Guid>> funcMain49(ICollection<Post<Guid>> p55)
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
        
        private static Country<Guid> funcMain53(Country<Guid> p60)
        {
            return p60 == null ? null : new Country<Guid>()
            {
                Name = p60.Name,
                Cities = funcMain54(p60.Cities),
                Citizens = funcMain55(p60.Citizens),
                Id = p60.Id
            };
        }
        
        private static Country<Guid> funcMain59(Country<Guid> p66)
        {
            return p66 == null ? null : new Country<Guid>()
            {
                Name = p66.Name,
                Cities = funcMain60(p66.Cities),
                Citizens = funcMain61(p66.Citizens),
                Id = p66.Id
            };
        }
        
        private static ICollection<Post<Guid>> funcMain62(ICollection<Post<Guid>> p69)
        {
            if (p69 == null)
            {
                return null;
            }
            ICollection<Post<Guid>> result = new List<Post<Guid>>(p69.Count);
            
            IEnumerator<Post<Guid>> enumerator = p69.GetEnumerator();
            
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
        
        private static Country<Guid> funcMain66(Country<Guid> p74)
        {
            return p74 == null ? null : new Country<Guid>()
            {
                Name = p74.Name,
                Cities = funcMain67(p74.Cities),
                Citizens = funcMain70(p74.Citizens),
                Id = p74.Id
            };
        }
        
        private static ICollection<Address<Guid>> funcMain71(ICollection<Address<Guid>> p79)
        {
            if (p79 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p79.Count);
            
            IEnumerator<Address<Guid>> enumerator = p79.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address<Guid> item = enumerator.Current;
                result.Add(funcMain72(item));
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
        
        private static ICollection<City<Guid>> funcMain29(ICollection<City<Guid>> p30)
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
                result.Add(funcMain30(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain32(ICollection<Person<Guid>> p33)
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
        
        private static Address<Guid> funcMain34(Address<Guid> p35)
        {
            return p35 == null ? null : new Address<Guid>()
            {
                PersonId = p35.PersonId,
                CityId = p35.CityId,
                Line = p35.Line,
                Sequence = p35.Sequence,
                City = funcMain35(p35.City),
                Person = TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(p35.Person),
                Id = p35.Id
            };
        }
        
        private static Address<Guid> funcMain43(Address<Guid> p48)
        {
            return p48 == null ? null : new Address<Guid>()
            {
                PersonId = p48.PersonId,
                CityId = p48.CityId,
                Line = p48.Line,
                Sequence = p48.Sequence,
                City = TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(p48.City),
                Person = funcMain44(p48.Person),
                Id = p48.Id
            };
        }
        
        private static ICollection<City<Guid>> funcMain54(ICollection<City<Guid>> p61)
        {
            if (p61 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p61.Count);
            
            IEnumerator<City<Guid>> enumerator = p61.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain55(ICollection<Person<Guid>> p62)
        {
            if (p62 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p62.Count);
            
            IEnumerator<Person<Guid>> enumerator = p62.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(funcMain56(item));
            }
            return result;
            
        }
        
        private static ICollection<City<Guid>> funcMain60(ICollection<City<Guid>> p67)
        {
            if (p67 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p67.Count);
            
            IEnumerator<City<Guid>> enumerator = p67.GetEnumerator();
            
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
        
        private static ICollection<Person<Guid>> funcMain61(ICollection<Person<Guid>> p68)
        {
            if (p68 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p68.Count);
            
            IEnumerator<Person<Guid>> enumerator = p68.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<City<Guid>> funcMain67(ICollection<City<Guid>> p75)
        {
            if (p75 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p75.Count);
            
            IEnumerator<City<Guid>> enumerator = p75.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(funcMain68(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain70(ICollection<Person<Guid>> p78)
        {
            if (p78 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p78.Count);
            
            IEnumerator<Person<Guid>> enumerator = p78.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static Address<Guid> funcMain72(Address<Guid> p80)
        {
            return p80 == null ? null : new Address<Guid>()
            {
                PersonId = p80.PersonId,
                CityId = p80.CityId,
                Line = p80.Line,
                Sequence = p80.Sequence,
                City = funcMain73(p80.City),
                Person = TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(p80.Person),
                Id = p80.Id
            };
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
        
        private static City<Guid> funcMain30(City<Guid> p31)
        {
            return p31 == null ? null : new City<Guid>()
            {
                CountryId = p31.CountryId,
                Name = p31.Name,
                Population = p31.Population,
                Country = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p31.Country),
                Addresses = funcMain31(p31.Addresses),
                Id = p31.Id
            };
        }
        
        private static City<Guid> funcMain35(City<Guid> p36)
        {
            return p36 == null ? null : new City<Guid>()
            {
                CountryId = p36.CountryId,
                Name = p36.Name,
                Population = p36.Population,
                Country = funcMain36(p36.Country),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p36.Addresses),
                Id = p36.Id
            };
        }
        
        private static Person<Guid> funcMain44(Person<Guid> p49)
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
                Posts = funcMain45(p49.Posts),
                Id = p49.Id
            };
        }
        
        private static Person<Guid> funcMain56(Person<Guid> p63)
        {
            return p63 == null ? null : new Person<Guid>()
            {
                OriginId = p63.OriginId,
                Name = p63.Name,
                Surname = p63.Surname,
                Email = p63.Email,
                PhoneNumber = p63.PhoneNumber,
                Bio = p63.Bio,
                BirthDate = p63.BirthDate,
                Origin = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p63.Origin),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p63.Addresses),
                Posts = funcMain57(p63.Posts),
                Id = p63.Id
            };
        }
        
        private static City<Guid> funcMain68(City<Guid> p76)
        {
            return p76 == null ? null : new City<Guid>()
            {
                CountryId = p76.CountryId,
                Name = p76.Name,
                Population = p76.Population,
                Country = TypeAdapterConfig1.GetMapFunction<Country<Guid>, Country<Guid>>().Invoke(p76.Country),
                Addresses = funcMain69(p76.Addresses),
                Id = p76.Id
            };
        }
        
        private static City<Guid> funcMain73(City<Guid> p81)
        {
            return p81 == null ? null : new City<Guid>()
            {
                CountryId = p81.CountryId,
                Name = p81.Name,
                Population = p81.Population,
                Country = funcMain74(p81.Country),
                Addresses = TypeAdapterConfig1.GetMapFunction<ICollection<Address<Guid>>, ICollection<Address<Guid>>>().Invoke(p81.Addresses),
                Id = p81.Id
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
        
        private static ICollection<Address<Guid>> funcMain31(ICollection<Address<Guid>> p32)
        {
            if (p32 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p32.Count);
            
            IEnumerator<Address<Guid>> enumerator = p32.GetEnumerator();
            
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
        
        private static Country<Guid> funcMain36(Country<Guid> p37)
        {
            return p37 == null ? null : new Country<Guid>()
            {
                Name = p37.Name,
                Cities = funcMain37(p37.Cities),
                Citizens = funcMain38(p37.Citizens),
                Id = p37.Id
            };
        }
        
        private static ICollection<Post<Guid>> funcMain45(ICollection<Post<Guid>> p50)
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
        
        private static ICollection<Post<Guid>> funcMain57(ICollection<Post<Guid>> p64)
        {
            if (p64 == null)
            {
                return null;
            }
            ICollection<Post<Guid>> result = new List<Post<Guid>>(p64.Count);
            
            IEnumerator<Post<Guid>> enumerator = p64.GetEnumerator();
            
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
        
        private static ICollection<Address<Guid>> funcMain69(ICollection<Address<Guid>> p77)
        {
            if (p77 == null)
            {
                return null;
            }
            ICollection<Address<Guid>> result = new List<Address<Guid>>(p77.Count);
            
            IEnumerator<Address<Guid>> enumerator = p77.GetEnumerator();
            
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
        
        private static Country<Guid> funcMain74(Country<Guid> p82)
        {
            return p82 == null ? null : new Country<Guid>()
            {
                Name = p82.Name,
                Cities = funcMain75(p82.Cities),
                Citizens = funcMain76(p82.Citizens),
                Id = p82.Id
            };
        }
        
        private static ICollection<City<Guid>> funcMain37(ICollection<City<Guid>> p38)
        {
            if (p38 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p38.Count);
            
            IEnumerator<City<Guid>> enumerator = p38.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain38(ICollection<Person<Guid>> p39)
        {
            if (p39 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p39.Count);
            
            IEnumerator<Person<Guid>> enumerator = p39.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<City<Guid>> funcMain75(ICollection<City<Guid>> p83)
        {
            if (p83 == null)
            {
                return null;
            }
            ICollection<City<Guid>> result = new List<City<Guid>>(p83.Count);
            
            IEnumerator<City<Guid>> enumerator = p83.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                City<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<City<Guid>, City<Guid>>().Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<Person<Guid>> funcMain76(ICollection<Person<Guid>> p84)
        {
            if (p84 == null)
            {
                return null;
            }
            ICollection<Person<Guid>> result = new List<Person<Guid>>(p84.Count);
            
            IEnumerator<Person<Guid>> enumerator = p84.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Person<Guid> item = enumerator.Current;
                result.Add(TypeAdapterConfig1.GetMapFunction<Person<Guid>, Person<Guid>>().Invoke(item));
            }
            return result;
            
        }
    }
}