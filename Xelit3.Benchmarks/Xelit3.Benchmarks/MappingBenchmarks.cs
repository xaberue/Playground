using AutoMapper;
using BenchmarkDotNet.Attributes;
using Bogus;
using Mapster;
using Xelit3.Tests.Model;
using IAutoMapper = AutoMapper.IMapper;


namespace Xelit3.Benchmarks;

public class MappingBenchmarks
{

    private IAutoMapper _automapper;
    private IEnumerable<Person<Guid>> _persons;
    private Person<Guid> _person;


    [GlobalSetup]
    public void GlobalSetup()
    {
        _persons = new Faker<Person<Guid>>()
            .RuleFor(x => x.Name, f => f.Person.FirstName)
            .RuleFor(x => x.Surname, f => f.Person.LastName)
            .RuleFor(x => x.BirthDate, f => f.Person.DateOfBirth)
            .Generate(1000);

        _person = _persons.First();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<Person<Guid>, PersonDto>());

        _automapper = new Mapper(config);
    }


    [Benchmark]
    public void SingleElementManualMappingBenchmark()
    {
        var dto = _person.Map();
    }

    [Benchmark]
    public void MultipleElementsManualMappingBenchmark()
    {
        var dtos = _persons.Map().ToList();
    }

    [Benchmark]
    public void SingleElementAutomapperBenchmark()
    {
        var dto = _automapper.Map<PersonDto>(_person);
    }

    [Benchmark]
    public void MultipleElementAutomapperBenchmark_WithIEnumerableMap()
    {
        var dtos = _automapper.Map<IEnumerable<PersonDto>>(_persons).ToList();
    }

    [Benchmark]
    public void MultipleElementAutomapperBenchmark_WithSelect()
    {
        var dtos = _persons.Select(x => _automapper.Map<PersonDto>(x)).ToList();
    }

    [Benchmark]
    public void SingleElementMapsterBenchmark()
    {
        var dto = _person.Adapt<PersonDto>();
    }

    [Benchmark]
    public void MultipleElementsMapsterBenchmark()
    {
        var dtos = _persons.Adapt<IEnumerable<PersonDto>>().ToList();
    }

}


public class PersonDto
{
    public Guid OriginId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}


public static class PersonMapper
{
    public static PersonDto Map(this Person<Guid> person)
    {
        return new PersonDto
        {
            Name = person.Name,
            Surname = person.Surname,
            BirthDate = person.BirthDate,
            OriginId = person.OriginId
        };
    }

    public static IEnumerable<PersonDto> Map(this IEnumerable<Person<Guid>> persons)
    {
        return persons.Select(x => x.Map());
    }
}