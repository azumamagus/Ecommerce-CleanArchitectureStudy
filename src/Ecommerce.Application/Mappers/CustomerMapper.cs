using Ecommerce.Application.Dtos;
using Ecommerce.Application.Mappers.Interfaces;
using Ecommerce.Domain.Model;

namespace Ecommerce.Application.Mappers;

public class CustomerMapper : IMapper<Customer, CustomerDto>, IMapper<CustomerDto, Customer>
{
    public CustomerDto Map(Customer source)
    {
        return new CustomerDto
        {
            Cpf = source.Cpf,
            Email = source.Email,
            Name = source.Name,
            LastName = source.LastName,
            BirthDate = source.BirthDate,
            Address = new AddressDto
            {
                Street = source.Address.Street,
                Number = source.Address.Number,
                City = source.Address.City,
                State = source.Address.State,
                Complement = source.Address.Complement,
                PostalCode = source.Address.PostalCode,
            }
        };
    }

    public Customer Map(CustomerDto source)
    {
        return new Customer
        {
            Cpf = source.Cpf,
            Email = source.Email,
            Name = source.Name,
            LastName = source.LastName,
            BirthDate = source.BirthDate,
            Address = new Address
            {
                Street = source.Address.Street,
                Number = source.Address.Number,
                City = source.Address.City,
                State = source.Address.State,
                Complement = source.Address.Complement,
                PostalCode = source.Address.PostalCode,
            }
        };
    }

    public IEnumerable<CustomerDto> Map(IEnumerable<Customer> source)
    {
        foreach (var item in source)
            yield return Map(item);
    }

    public IEnumerable<Customer> Map(IEnumerable<CustomerDto> source)
    {
        foreach (var item in source)
            yield return Map(item);
    }
}
