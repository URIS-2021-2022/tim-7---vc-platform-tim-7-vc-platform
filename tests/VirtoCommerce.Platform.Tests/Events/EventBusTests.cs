using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core;
using VirtoCommerce.Platform.Core.Bus;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Events;
using VirtoCommerce.Platform.Core.Messages;
using Xunit;

namespace VirtoCommerce.Platform.Tests.Events
{
    public class EventBusTests
    {
        [Fact]
        public async Task RegisterHandler_RegisterFakeHandler()
        {
            //Arrange
            var changedHandler = new FakeChangedEventHandler();
            var changingHangler = new FakeChangingEventHandler();
            var eventBus = GetEventBus();
            eventBus.RegisterHandler<ChangedIntegratrionEvent<IEntity>>((message, token) =>
            {
                return changedHandler.Handle(message);
                }
            );
            eventBus.RegisterHandler<ChangedIntegratrionEvent<FakeEntity>>((message, token) =>
            {
                return changedHandler.Handle(message);
            }
            );
            //eventBus.RegisterHandler<ChangingIntegrationEvent<IEntity>>((message, token) => changingHangler.Handle(message));
            var entity = new FakeEntity { Id = Guid.NewGuid().ToString() };

            //Act
            await eventBus.PublishAsync(new FakeEntityChangedIntegratrionEvent(entity, (EventMetaInfoType.ModuleId, "SomeModuleId")));
            //await eventBus.PublishAsync(new ChangingIntegrationEvent<IEntity>(entity, (EventMetaInfoType.ModuleId, "SomeModuleId2")));

            //Assert
            Assert.True(changedHandler.Messages.Any());
            Assert.Contains(entity, changedHandler.Messages.Select(m => m.Entity));
            Assert.Equal("SomeModuleId", changedHandler.Messages.OfType<IntegrationEventBase<IEntity>>().First().ModuleId);

            //Assert.True(changingHangler.Messages.Any());
            //Assert.Contains(entity, changingHangler.Messages.Select(m => m.Entity));
            //Assert.Equal("SomeModuleId2", changingHangler.Messages.OfType<IntegrationEventBase<IEntity>>().First().ModuleId);
        }

        public AzureEventGridEventBase GetEventBus()
        {
            return new AzureEventGridEventBase();
        }
    }
        
    class FakeChangedEventHandler : IEventHandler<ChangedIntegratrionEvent<IEntity>>, IEventHandler<ChangedIntegratrionEvent<FakeEntity>>, IEventHandler<IEvent>
    {
        public List<IIntegrationEvent<IEntity>> Messages = new List<IIntegrationEvent<IEntity>>();
        public Task Handle(IIntegrationEvent<IEntity> message)
        {
            Messages.Add(message);
            return Task.CompletedTask;
        }

        public Task Handle(ChangedIntegratrionEvent<FakeEntity> message)
        {
            throw new NotImplementedException();
        }

        public Task Handle(ChangedIntegratrionEvent<IEntity> message)
        {
            Messages.Add(message);
            return Task.CompletedTask;
        }

        public Task Handle(IEvent message)
        {
            throw new NotImplementedException();
        }
    }

    class FakeChangingEventHandler : IEventHandler<ChangingIntegrationEvent<IEntity>>
    {
        public List<IIntegrationEvent<IEntity>> Messages = new List<IIntegrationEvent<IEntity>>();
        public Task Handle(ChangingIntegrationEvent<IEntity> message)
        {
            Messages.Add(message);
            return Task.CompletedTask;
        }
    }

    class FakeEntity : Entity { }

    class FakeEntityChangedIntegratrionEvent : ChangedIntegratrionEvent<IEntity>
    {
        public FakeEntityChangedIntegratrionEvent(IEntity fakeEntity, params (string Key, object Value)[] keyValuePairs) : base(fakeEntity, keyValuePairs)
        {

        }
    }
}
