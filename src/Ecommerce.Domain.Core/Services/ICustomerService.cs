﻿namespace Ecommerce.Domain.Core.Services;

public interface ICustomerService
{
    void SaveCustomer(Customer customer);
    void UpdateCustomer(Customer customer);
    void DeleteCustomer(string id);
    IEnumerable<Customer> GetCustomers();
    Customer GetCustomerById(string id);
}
