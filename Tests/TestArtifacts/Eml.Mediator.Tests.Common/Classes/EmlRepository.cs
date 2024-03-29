﻿using System.Threading.Tasks;

namespace Eml.Mediator.Tests.Common.Classes;

public class EmlRepository<T> : IEmlRepository<T>
{
    public async Task<IUser<T>> FindAsync(string nameIdentifier)
    {
        return await Task.FromResult(new User<T>());
    }

    public async Task<IUser<T>> FindAsync(T piiUserId)
    {
        return await Task.FromResult(new User<T>());
    }
}
