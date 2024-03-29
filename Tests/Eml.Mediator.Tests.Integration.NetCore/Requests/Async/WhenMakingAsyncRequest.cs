﻿using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;
using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;
//using JetBrains.dotMemoryUnit;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests.Async;

public class WhenMakingAsyncRequest : IntegrationTestDiBase
{
    [Fact]
    //[DotMemoryUnit(FailIfRunWithoutSupport = false)]
    public async Task Response_ShouldBeCorrectType()
    {
        var request = new TestAsyncRequest(Guid.NewGuid());

        var response = await mediator.ExecuteAsync(request);

        response.ShouldBeOfType(typeof(TestResponse));

        //dotMemory.Check(memory =>
        //{
        //    memory.GetObjects(where => where.Type.Is<TestRequestAsyncEngine>()).ObjectsCount.ShouldBe(0);
        //});
    }

    [Fact]
    public async Task Response_ShouldReturnCorrectValue()
    {
        var request = new TestAsyncRequest(Guid.NewGuid()); //<-Request

        var response = await mediator.ExecuteAsync(request); //<-Execute

        response.ResponseToRequestId.ShouldBe(request.Id); //<-Return Value
    }
}
