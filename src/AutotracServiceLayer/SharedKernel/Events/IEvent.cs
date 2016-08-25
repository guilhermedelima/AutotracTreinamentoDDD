using System;

namespace SharedKernel.Events
{
    public interface IEvent
    {
        DateTime OcurredOn { get; }
    }
}
