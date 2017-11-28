﻿#if NETFULL
using System.ComponentModel.Composition;
#endif
using System;
using System.Threading.Tasks;
using Eml.Mediator.Contracts;

namespace Eml.Mediator.Tests.Common.Commands.Engines
{
#if NETFULL
    [PartCreationPolicy(CreationPolicy.NonShared)]
#endif
    public class TestAsyncCommandWithExceptionEngine : ICommandAsyncEngine<TestAsyncCommandWithException>
    {
        public Task SetAsync(TestAsyncCommandWithException commandAsync)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
