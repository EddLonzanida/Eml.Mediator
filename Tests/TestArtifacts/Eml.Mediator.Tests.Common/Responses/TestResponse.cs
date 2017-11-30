﻿using System;
{
    public class TestResponse : IResponse
    {
        public Guid ResponseToRequestId { get; }

        public TestResponse(Guid responseToRequestId)
        {
            ResponseToRequestId = responseToRequestId;
        }
    }
}