using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.CustomExceptions.AgencyExceptions
{
    public class PortfolioImageFileContentTypeException:Exception
    {
        public string PropertyName { get; set; }

        public PortfolioImageFileContentTypeException()
        {
        }
        public PortfolioImageFileContentTypeException(string? message) : base(message)
        {
        }
        public PortfolioImageFileContentTypeException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }

    }
}
