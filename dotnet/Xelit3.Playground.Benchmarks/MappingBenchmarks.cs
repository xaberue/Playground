using AutoMapper;
using BenchmarkDotNet.Attributes;
using Bogus;
using Mapster;
using Xelit3.Benchmarks.Generated;
using Xelit3.Tests.Model.Models;
using IAutoMapper = AutoMapper.IMapper;
using IMapsterMapper = MapsterMapper.IMapper;


namespace Xelit3.Playground.Benchmarks;

public class MappingBenchmarks
{

    private IAutoMapper _automapper;
    private IMapsterMapper _mapster;
    private TypeAdapterConfig _mapsterConfig;
    private IEnumerable<Person<Guid>> _persons;
    private IEnumerable<PersonDefault> _personsDefault;
    private Person<Guid> _person;
    private PersonDefault _personDefault;


    [GlobalSetup]
    public void GlobalSetup()
    {
        _persons = new Faker<Person<Guid>>()
            .RuleFor(x => x.Name, f => f.Person.FirstName)
            .RuleFor(x => x.Surname, f => f.Person.LastName)
            .RuleFor(x => x.BirthDate, f => f.Person.DateOfBirth)
            .Generate(1000);
        _personsDefault = new Faker<PersonDefault>()
            .RuleFor(x => x.Name, f => f.Person.FirstName)
            .RuleFor(x => x.Surname, f => f.Person.LastName)
            .RuleFor(x => x.BirthDate, f => f.Person.DateOfBirth)
            .Generate(1000);

        _person = _persons.First();
        _personDefault = _personsDefault.First();

        SetupAutomapperConfig();
        SetupMapsterConfig();
    }

    private void SetupAutomapperConfig()
    {
        var automapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<Person<Guid>, PersonMappingDto>());

        _automapper = new Mapper(automapperConfig);
    }

    private void SetupMapsterConfig()
    {
        _mapsterConfig = new TypeAdapterConfig();
        _mapsterConfig.NewConfig<Person<Guid>, PersonMappingDto>();

        _mapster = new MapsterMapper.Mapper(_mapsterConfig);
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
        var dto = _automapper.Map<PersonMappingDto>(_person);
    }

    [Benchmark]
    public void MultipleElementAutomapperBenchmark_WithIEnumerableMap()
    {
        var dtos = _automapper.Map<IEnumerable<PersonMappingDto>>(_persons).ToList();
    }

    [Benchmark]
    public void MultipleElementAutomapperBenchmark_WithSelect()
    {
        var dtos = _persons.Select(x => _automapper.Map<PersonMappingDto>(x)).ToList();
    }

    [Benchmark]
    public void SingleElementMapsterBenchmark_WithoutConfig()
    {
        var dto = _person.Adapt<PersonMappingDto>();
    }

    [Benchmark]
    public void SingleElementMapsterBenchmark_WithConfig()
    {
        var dto = _person.Adapt<PersonMappingDto>(_mapsterConfig);
    }

    [Benchmark]
    public void MultipleElementsMapsterBenchmark()
    {
        var dtos = _persons.Adapt<IEnumerable<PersonMappingDto>>().ToList();
    }

    [Benchmark]
    public void SingleElementMapsterBenchmark_UsingType()
    {
        var dto = _mapster.From(_person).AdaptToType<PersonMappingDto>();
    }

    [Benchmark]
    public void MultipleElementsMapsterBenchmark_UsingType()
    {
        var dto = _mapster.From(_persons).AdaptToType<IEnumerable<PersonMappingDto>>().ToList();
    }

    [Benchmark]
    public void SingleElementMapsterBenchmark_UsingCodeGenerator()
    {
        var dto = _personDefault.AdaptToDto();
    }

    [Benchmark]
    public void MultipleElementsMapsterBenchmark_UsingCodeGenerator()
    {
        var dto = _personsDefault.Select(x => x.AdaptToDto()).ToList();
    }

}


public class PersonMappingDto
{
    public Guid OriginId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}


public static class PersonMapper
{
    public static PersonMappingDto Map(this Person<Guid> person)
    {
        return new PersonMappingDto
        {
            Name = person.Name,
            Surname = person.Surname,
            BirthDate = person.BirthDate,
            OriginId = person.OriginId
        };
    }

    public static IEnumerable<PersonMappingDto> Map(this IEnumerable<Person<Guid>> persons)
    {
        return persons.Select(x => x.Map());
    }
}