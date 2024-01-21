using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.CustomExceptions.AgencyExceptions
{
    public class PortfolioImageFileLengthException:Exception
    {
        public string PropertyName { get; set; }

        public PortfolioImageFileLengthException()
        {
        }
        public PortfolioImageFileLengthException(string? message) : base(message)
        {
        }
        public PortfolioImageFileLengthException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
