using LearningEFCore.Data;
using LearningEFCore.Interfaces;
using LearningEFCore.Models;
using System.Collections.Generic;

namespace LearningEFCore.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private DataContext context;

        public CustomerRepository(DataContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return context.Customers;
        }
    }
}
