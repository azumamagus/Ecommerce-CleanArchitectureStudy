namespace Ecommerce.Application.Interfaces;

public interface ICustomerApplicationService
{
    void SaveCustomer(CustomerDto customerDto);
    void UpdateCustomer(CustomerDto customerDto);
    void DeleteCustomer(string id);
    CustomerDto GetCustomerById(string id);
    IEnumerable<CustomerDto> GetCustomers();
}
