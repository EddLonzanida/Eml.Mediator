# [Eml.Mediator](https://preview.nuget.org/packages/Eml.Mediator/)
Capture Business-Use-Cases and convert it into modular and highly testable chunk of codes. A combination of Command, Request-Response, Mediator and Abstract Class Factory pattern. Now supports .Net5

# A. Usage - ***Command***
    
```javascript
    [Fact]
    public async Task Command_ShouldBeCalledOnce()
    {
        var command = new TestAsyncCommand();   //<-Data

        await mediator.ExecuteAsync(command);   //<-Execute

        command.EngineInvocationCount.ShouldBe(1);
    }
 ```

### 1. Create a command class.
*TestAsyncCommand* contains the needed data for  **await mediator.ExecuteAsync(command);**.
```javascript
    public class TestAsyncCommand : ICommandAsync
    {
        public int EngineInvocationCount { get; set; }

        /// <summary>
        /// This request will be processed by <see cref="TestAsyncCommandEngine"/>.
        /// </summary>
        public TestAsyncCommand()
        {
            EngineInvocationCount = 0;
        }
    }
```

### 2. Create a command engine.
*TestAsyncCommandEngine* will be auto-discovered and executed by **await mediator.ExecuteAsync(command);**.

```javascript
    /// <summary>
    /// DI signature: ICommandAsyncEngine&lt;TestAsyncCommand&gt;.
    /// <inheritdoc cref="ICommandAsyncEngine{TestAsyncCommand}"/>
    /// </summary>
    public class TestAsyncCommandEngine : ICommandAsyncEngine<TestAsyncCommand>
    {
        public async Task ExecuteAsync(TestAsyncCommand commandAsync)
        {
            await Task.Run(() => commandAsync.EngineInvocationCount++);
        }
    }
```

# B. Usage - ***Request-Response***

```javascript
    [Fact]
    public async Task Response_ShouldReturnCorrectValue()
    {
        var request = new TestAsyncRequest(Guid.NewGuid());     //<-Request

        var response = await mediator.ExecuteAsync(request);    //<-Execute

        response.ResponseToRequestId.ShouldBe(request.Id);      //<-Return Value
    }
```

### 1. Create a Request class.
*TestAsyncRequest* contains the needed data for **TestRequestAsyncEngine**.
```javascript
    public class TestAsyncRequest : IRequestAsync<TestAsyncRequest, TestResponse>
    {
        public Guid Id { get; private set; }

        /// <summary>
        /// This request will be processed by <see cref="TestRequestAsyncEngine"/>.
        /// </summary>
        public TestAsyncRequest(Guid id)
        {
            Id = id;
        }
    }
```

### 2. Create a Response class.
*TestResponse* is the return value of **await mediator.ExecuteAsync(request);**.
```javascript
    /// <summary>
    /// TestRequestAsyncEngine return value.
    /// </summary>
    public class TestResponse : IResponse
    {
        public Guid ResponseToRequestId { get; }        //<-Return Value

        public TestResponse(Guid responseToRequestId)
        {
            ResponseToRequestId = responseToRequestId;
        }
    }
```

### 3. Create a Request engine.
*TestRequestAsyncEngine* will be auto-discovered and executed by **var response = await mediator.ExecuteAsync(request);**.

```javascript
    /// <summary>
    /// DI signature: IRequestAsyncEngine&lt;TestAsyncRequest, TestResponse&gt;.
    /// <inheritdoc cref="IRequestAsyncEngine{TestAsyncRequest, TestResponse}"/>
    /// </summary>
    public class TestRequestAsyncEngine : IRequestAsyncEngine<TestAsyncRequest, TestResponse>
    {
        public async Task<TestResponse> ExecuteAsync(TestAsyncRequest request)
        {
            return await Task.Run(() => new TestResponse(request.Id));
        }
    }
```
## That's it.
#### Check out [EmlExtensions.vsix](https://marketplace.visualstudio.com/items?itemName=eDuDeTification.EmlExtensions) to automate the above process in one go.
![](Art/Steps.gif)


