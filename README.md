# [Eml.Mediator](https://www.nuget.org/packages/Eml.Mediator/)

* Has own [Visual Studio Addin](https://marketplace.visualstudio.com/items?itemName=eDuDeTification.Mediator) for easier use.

* Small size.

* Capture Business-use-cases and convert it into a modular, highly testable chunk of codes. One step closer to dissecting & migrating monolithic apps. A combination of Command, Request-Response, Mediator and Abstract Class Factory pattern.

* Provides a common ground for projects with large number of developers.

* .Net5 is now supported.

##### Limitations
* ExecuteAsync will always create a new instance of the engine.
* The lifetime of the engine ends as soon as ExecuteAsync is completed.
* If this behavior does not suit your needs, just use dependency injection via the constructor.



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

# C. DI Registration
Requires [Scrutor](https://github.com/khellang/Scrutor) for the automated registration.

See **[IntegrationTestDiFixture.cs](https://github.com/EddLonzanida/Eml.Mediator.Demo/blob/master/Tests/Eml.Mediator.Tests.Integration.NetCore/BaseClasses/IntegrationTestDiFixture.cs)** for more details.
```javascript
    private static void ConfigureServices(IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyDependencies(typeof(IntegrationTestDiFixture).Assembly)

                // Register IMediator
                .AddClasses(classes => classes.AssignableTo<IMediator>())
                .AsSelfWithInterfaces()
                .WithSingletonLifetime()

                // Register RequestEngines, CommandEngines - Async
                .AddClasses(classes => classes.AssignableTo(typeof(IRequestAsyncEngine<,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
                
                // Register RequestEngines, CommandEngines
                .AddClasses(classes => classes.AssignableTo(typeof(IRequestEngine<,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime()

                // Register CommandEngines - Async
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandAsyncEngine<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
                
                // Register CommandEngines
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandEngine<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime()

                // IDiDiscoverableTransient
                .AddClasses(classes => classes.AssignableTo(typeof(IDiDiscoverableTransient)))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
        );
    }
```

# D. Sample Class

* Simply inject IMediator in the constructor.
See **[ConsumerClassWithMediator.cs](https://github.com/EddLonzanida/Eml.Mediator.Demo/blob/master/Tests/Eml.Mediator.Tests.Integration.NetCore/Requests/Async/ConsumerClassWithMediator.cs)** for more details.

```
    public class ConsumerClassWithMediator : IConsumerClassWithMediator
    {
        private readonly IMediator mediator;

        public ConsumerClassWithMediator(IMediator mediator)        //<-Inject IMediator
        {
            this.mediator = mediator;
        }

        public async Task<TestResponse> DoSomething()
        {
            var request = new TestAsyncRequest(Guid.NewGuid());     //<-Request

            var response = await mediator.ExecuteAsync(request);    //<-Execute

            return response;                                        //<-Return Value
        }
    }
```

* This is the equivalent class without leveraging IMediator.
See **[ConsumerClassWithoutMediator.cs](https://github.com/EddLonzanida/Eml.Mediator.Demo/blob/master/Tests/Eml.Mediator.Tests.Integration.NetCore/Requests/Async/ConsumerClassWithMediator.cs)** for more details.
```
    public class ConsumerClassWithoutMediator : IConsumerClassWithoutMediator
    {
        private readonly IRequestAsyncEngine<TestAsyncRequest, TestResponse> engine;

        public ConsumerClassWithoutMediator(IRequestAsyncEngine<TestAsyncRequest, TestResponse> engine)     //<-Normal dependency injection. Inject engine
        {
            this.engine = engine;
        }

        public async Task<TestResponse> DoSomething()
        {
            var request = new TestAsyncRequest(Guid.NewGuid());     //<-Request

            var response = await engine.ExecuteAsync(request);      //<-Execute

            return response;                                        //<-Return Value
        }
    }
```

## That's it.
##### Check out [Eml.Mediator.vsix](https://marketplace.visualstudio.com/items?itemName=eDuDeTification.Mediator) to automate the steps above.
![](https://github.com/EddLonzanida/Eml.Mediator.Demo/blob/master/Art/Steps.gif)

