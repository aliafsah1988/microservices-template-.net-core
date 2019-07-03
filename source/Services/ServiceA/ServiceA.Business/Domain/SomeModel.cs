using System;

namespace ServiceA.Business.Domain
{
    public class SomeModel
    {
        public long Id { get; set; }
        public Guid AppId { get; set; }

        public string FirstName { get; set; }

        public int MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Message { get; set; }

        public string IP { get; set; }

        public string Output { get; set; }
    }
}
