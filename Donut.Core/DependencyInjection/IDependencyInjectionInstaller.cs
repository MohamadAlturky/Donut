using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Donut.Core.DependencyInjection;

public interface IDependencyInjectionInstaller
{
    void Install(IServiceCollection services, IConfiguration configuration);
}