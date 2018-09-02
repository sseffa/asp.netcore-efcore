using LearningEFCore.Models;
using System.Collections.Generic;

namespace LearningEFCore.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
    }
}
