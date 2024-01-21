using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.CustomExceptions.AgencyExceptions
{
    public class EntityNullException : Exception
    {
        public string PropertyName { get; set; }

        public EntityNullException()
        {
        }
        public EntityNullException(string? message) : base(message)
        {
        }
        public EntityNullException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }

       
    }
}
