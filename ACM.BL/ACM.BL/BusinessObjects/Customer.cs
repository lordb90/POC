using ACM.Common;
using System.Collections.Generic;

namespace ACM.BL.BusinessObjects
{
    public class Customer : EntityBase, ILoggable
    {
        public Customer()
            : this(0)
        {

        }

        public Customer(int customerId)
        {
            this.CustomerId = customerId;
            AddressList = new List<Address>();
        }

        public int CustomerType { get; set; }
        public static int InstanceCount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        //public Address WorkAddress { get; set; }
        //public Address HomeAddress { get; set; }
        public List<Address> AddressList { get; set; }
        public int CustomerId { get; private set; }
        //public bool Equals(object x, object y)
        //{
        //    // TODO: Implement this method
        //    throw new NotImplementedException();
        //}

        public string FullName
        {
            get 
            {
                string fullName = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(fullName))
                    {
                        fullName += ", ";
                    }
                    fullName += FirstName;
                }
                return fullName;
            }
        }

        public override bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;

            return isValid;
        }

        public string Log()
        {
            var logString = this.CustomerId + ": " +
                            this.FirstName + " " +
                            "Email: " + this.EmailAddress + " " +
                            "Status: " + this.EntityState.ToString();
            return logString;
        }
    }
}
