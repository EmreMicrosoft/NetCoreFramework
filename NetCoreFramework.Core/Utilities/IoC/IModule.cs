using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreFramework.Core.Utilities.IoC
{
  public interface IModule
  {
    void Load(IServiceCollection service);
  }
}
