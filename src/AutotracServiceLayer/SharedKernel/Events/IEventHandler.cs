using System;

namespace SharedKernel.Events
{
    public interface IEventHandler<T> where T: IEvent
    {
        void Handle(T @event);
    }
}
