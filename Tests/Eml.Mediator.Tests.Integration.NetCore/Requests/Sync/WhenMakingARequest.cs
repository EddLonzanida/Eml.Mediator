﻿using System;
using Eml.Mediator.Tests.Common.Requests;
using Eml.Mediator.Tests.Common.Responses;
using Eml.Mediator.Tests.Integration.NetCore.BaseClasses;
using Shouldly;
using Xunit;

namespace Eml.Mediator.Tests.Integration.NetCore.Requests.Sync
{
    public class WhenMakingARequest : IntegrationTestDiBase
    {
        [Fact]
        public void Response_ShouldBeCorrectType()
        {
           var request = new TestRequest(Guid.NewGuid());
            
           var response = mediator.Get(request);

            response.ShouldBeOfType(typeof(TestResponse));
        }

        [Fact]
        public void Response_ShouldBeCorrectValue()
        {
            var request = new TestRequest(Guid.NewGuid());

            var response = mediator.Get(request);

            response.ResponseToRequestId.ShouldBe(request.Id);
        }
    }
}