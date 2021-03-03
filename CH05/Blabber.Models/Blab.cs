using System;

namespace Blabber
{
    public class Blab
    {
        public const int MaxContentLength = 560;

        public string Content { get; private set; }
        public DateTimeOffset CreatedOn { get; private set; }

        public Blab(string content, DateTimeOffset createdOn)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException(nameof(content));
            }
            Content = content;
            CreatedOn = createdOn;
        }
    }
}