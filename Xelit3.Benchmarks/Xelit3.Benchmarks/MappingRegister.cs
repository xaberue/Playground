using Mapster;
using Xelit3.Tests.Model;

namespace Xelit3.Benchmarks;

public class MappingRegister : ICodeGenerationRegister
{
    public void Register(CodeGenerationConfig config)
    {
        config.AdaptTo("[name]Dto").ForType<PersonDefault>();
        config.AdaptTo("[name]Dto").ForType<AddressDefault>();
        config.AdaptTo("[name]Dto").ForType<CityDefault>();
        config.AdaptTo("[name]Dto").ForType<CountryDefault>();
        config.AdaptTo("[name]Dto").ForType<PostDefault>();

        config.GenerateMapper("[name]Mapper")
            .ForType<PersonDefault>()
            .ForType<AddressDefault>()
            .ForType<CityDefault>()
            .ForType<CountryDefault>()
            .ForType<PostDefault>();
    }
}