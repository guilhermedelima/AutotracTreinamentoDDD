using System;

namespace PassOn
{
    public sealed class Notification
    {
        public string Id { get; private set; }
        public string Message { get; private set; }

        public Notification(string message)
        {
            Id = Guid.NewGuid().ToString("N");
            Message = message;
        }

        public Notification(string id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
