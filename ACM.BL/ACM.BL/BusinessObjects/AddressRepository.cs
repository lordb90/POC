using System;
using System.Collections.Generic;
using System.Linq;

namespace ACM.BL.BusinessObjects
{
    public class AddressRepository
    {
        /// <summary>
        /// Retrieve one address
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Address Retrieve(int addressId)
        {
            Address address = new Address(addressId);

            // TODO: Add Logic to retrive actually product

            // Temporary create testing product
            if (address.AddressId == 1)
            {
                address.StreetLine1 = "Bag End";
                address.StreetLine2 = "Bagshot row";
                address.City = "Hobbiton";
                address.State = "Shire";
                address.Country = "Middle Earth";
                address.PostalCode = "144";
            }
            return address;
        }

        public IEnumerable<Address> RetrieveByCustomerID(int customerId)
        {
            // TODO: Add Logic to retrive actually product
            var addressList = new List<Address>();

            Address address = new Address(1)
            {
                AddressType = 1,
                StreetLine1 = "Bag End",
                StreetLine2 = "Bagshot row",
                City = "Hobbiton",
                State = "Shire",
                Country = "Middle Earth",
                PostalCode = "144"
            };
            addressList.Add(address);
            address = new Address(2)
            {
                AddressType = 2,
                StreetLine1 = "The Green Dragon Inn",
                City = "Bywater",
                State = "Shire",
                Country = "Middle Earth",
                PostalCode = "146"
            };
            addressList.Add(address);

            return addressList;
        }
        /// <summary>
        /// Saves current Product
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            // Code that saves the defined Product
            return true;
        }
    }
}
