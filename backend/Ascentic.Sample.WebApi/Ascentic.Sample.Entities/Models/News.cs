using System;
using System.Collections.Generic;
using System.Text;

namespace Ascentic.Sample.Entities
{
    public class News : AuditableEntity<int>, IEntity
    {
        public string Message { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
