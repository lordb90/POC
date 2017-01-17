using System.Collections.Generic;
using System.Linq;

namespace ACM.BL.BusinessObjects
{
    public class CustomerRepository
    {
        private AddressRepository addressRepository { get; set; }

        public CustomerRepository()
        {
            addressRepository = new AddressRepository();
        }

        /// <summary>
        /// Retrieve one customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Customer Retrieve(int customerId)
        {
            // Create new temp customer for testing
            Customer customer = new Customer(customerId);
            customer.AddressList = addressRepository.RetrieveByCustomerID(customerId).ToList();

            // TODO: Code that retrieves the define customer

            //Temporary hard coded values
            if (customerId == 1)
            {
                customer.EmailAddress = "fbaggins@bagginn.com";
                customer.FirstName = "Frodo";
                customer.LastName = "Baggins";
            }
            return customer;
        }

        public List<Customer> Retrieve()
        {
            return new List<Customer>();
        }
        /// <summary>
        /// Saves current Customer
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            // Code that saves the defined customer
            return true;
        }
    }
}
