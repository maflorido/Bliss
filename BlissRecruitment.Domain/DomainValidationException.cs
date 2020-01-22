using System;

namespace BlissRecruitment.Domain
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string message) : base(message)
        {

        }
    }
}
