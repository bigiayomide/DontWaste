using DontWaste.Api.Core.Common;
using DontWaste.Api.Entities;
using System;
using System.Collections.Generic;

namespace Dontwaste.Api.Data
{
    public abstract class RepositoryService<T> : RepositoryService<T, DontWasteContext>
       where T : class, new()
    { }
}
