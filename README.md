# [Eml.Mediator](https://preview.nuget.org/packages/Eml.Mediator/)
Capture Business-Use-Cases and convert it into modular and highly testable chunk of codes. A combination of Command, Request-Response, Mediator and Abstract Class Factory pattern. Now supports .NetCore2.0

# A. Usage - ***Command***
    
```javascript
    [Test]
    public async Task Command_ShouldBeCalledOnce()
    {
        var command = new TestCommandAsync();       //<-Data

        await mediator.SetAsync(command);           //<-Execute

        command.EngineInvocationCount.ShouldBe(1);
    }
 ```

### 1. Create a command class.
*TestCommandAsync* contains the needed data for the **CommandEngine**.
```javascript
    public class TestCommandAsync : ICommandAsync
    {
        public int EngineInvocationCount { get; set; }

        public TestCommandAsync()
        {
            EngineInvocationCount = 0;
        }
    }
```

### 2. Create a command engine.
*TestCommandEngine* will be auto-discovered and executed by **await command.SetAsync();**.

```javascript
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestCommandEngine : ICommandAsyncEngine<TestCommandAsync>
    {
        public async Task SetAsync(TestCommandAsync commandAsync)
        {
            await Task.Run(() => commandAsync.EngineInvocationCount++);
        }
    }
```

# B. Usage - ***Request-Response***

```javascript
    [Test]
    public async Task Response_ShouldReturnCorrectValue()
    {
        var request = new TestRequestAsync(Guid.NewGuid());     //<-Data

        var response = await mediator.GetAsync(request);        //<-Execute

        response.ResponseToRequestId.ShouldBe(request.Id);      //<-Return Value
    }
```

### 1. Create a Request class.
*TestRequestAsync* contains the needed data for the **RequestEngine**.
```javascript
    public class TestRequestAsync : IRequestAsync<TestRequestAsync, TestResponse>
    {
        public Guid Id { get; }                                 //<-Data

        public TestRequestAsync(Guid id)
        {
            Id = id;
        }
    }
```

### 2. Create a Response class.
*TestResponse* is the return value of **RequestEngine**.
```javascript
    public class TestResponse : IResponse
    {
        public Guid ResponseToRequestId { get; }                //<-Return Value

        public TestResponse(Guid responseToRequestId)
        {
            ResponseToRequestId = responseToRequestId;
        }
    }
```

### 3. Create a Request engine.
*TestRequestEngine* will be auto-discovered and executed by **await mediator.GetAsync(request);**.

* For NetFramework
```javascript
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestRequestEngine : IRequestAsyncEngine<TestRequestAsync, TestResponse>
    {
        public async Task<TestResponse> GetAsync(TestRequestAsync request)  //<-Execute
        {
            return await Task.Run(() => new TestResponse(request.Id));
        }
    }
```
* For NetCore2.0 *(no need to place CreationPolicy.NonShared attribute)*
```javascript
    public class TestRequestEngine : IRequestAsyncEngine<TestRequestAsync, TestResponse>
    {
        public async Task<TestResponse> GetAsync(TestRequestAsync request)  //<-Execute
        {
            return await Task.Run(() => new TestResponse(request.Id));
        }
    }
```
## That's it.
#### Check out [Eml.Mediator.vsix](https://marketplace.visualstudio.com/items?itemName=eDuDeTification.Mediator) to automate the above process in one go.
![](https://github.com/EddLonzanida/Eml.Mediator.Demo/tree/master/Art/Steps.gif)


