using System;

namespace Ascentic.Sample.Entities
{
    public abstract class AuditableEntity<T> : Identity<T>
    {
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Editor { get; set; }
        public DateTime Edited { get; set; }
    }
}
