using AutoMapper;
using IMDB.Application.Mappings;
using Microsoft.Extensions.Logging.Abstractions;

namespace Tests.Application;

public class MappingProfileTests
{
    [Fact]
    public void Profile_configuration_is_valid()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>(), NullLoggerFactory.Instance);

        configuration.AssertConfigurationIsValid();
    }
}
