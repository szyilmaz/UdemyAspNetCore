using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAspNetCore.Models
{
    public class CustomerContext
    {
        public static List<Customer> Customers = new()
        {
            new Customer {Id = 1, FirstName = "Abuzer", LastName = "YILMAZ", Age = 39 },
            new Customer {Id = 2, FirstName = "Hüsam", LastName = "YILMAZ", Age = 39 },
            new Customer {Id = 3, FirstName = "Murtaza", LastName = "YILMAZ", Age = 4 }
        };
    }
}
