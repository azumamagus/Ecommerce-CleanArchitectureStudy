namespace Ecommerce.Infrastructure.Data.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly IDocumentStore _documentStore;
    public CustomerRepository(IDocumentStore documentStore)
    {
        _documentStore = documentStore;
    }

    public void Delete(string id)
    {
        using IDocumentSession documenSession = _documentStore.OpenSession();
        var customer = documenSession.Load<Customer>(id);

        if (customer is not null)
        {
            documenSession.Delete(customer);
            documenSession.SaveChanges();
        }
    }

    public IEnumerable<Customer> Get()
    {
        using IDocumentSession documenSession = _documentStore.OpenSession();
        return documenSession.Query<Customer>().ToList();
    }

    public Customer Get(string id)
    {
        using IDocumentSession documenSession = _documentStore.OpenSession();
        return documenSession.Load<Customer>(id);
    }

    public void Insert(Customer customer)
    {
        using IDocumentSession documenSession = _documentStore.OpenSession();
        documenSession.Store(customer);
        documenSession.SaveChanges();
    }

    public void Update(Customer customer)
    {
        using IDocumentSession documenSession = _documentStore.OpenSession();
        var customerEntity = documenSession.Query<Customer>()
                                     .FirstOrDefault(c => c.Name == customer.Name);
        if (customerEntity is not null)
        {
            customerEntity.Name = customer.Name;
            customerEntity.Address = customer.Address;
            customerEntity.Email = customer.Email;
            customerEntity.LastName = customer.LastName;
            customerEntity.BirthDate = customer.BirthDate;
            customerEntity.Cpf = customer.Cpf;
            customerEntity.IsActive = true;
        }

        documenSession.SaveChanges();
    }

    public Customer? GetByEmail(string email)
    {
        using IDocumentSession documenSession = _documentStore.OpenSession();
        var customerEntity = documenSession.Query<Customer>().FirstOrDefault(c => c.Email == email);

        if (customerEntity is not null)
            return customerEntity;

        return null;
    }
}
