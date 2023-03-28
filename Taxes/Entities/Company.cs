using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Entities
{
    class Company : TaxPayer
    {
        public int Employees { get; set; }

        public Company(string name,double anualincome,int employees):base(name,anualincome)
        {
            Employees = employees;
        }

        public override double Tax()
        {
            if (Employees <= 10)
            {
                return AnualIncome*0.16;
            }
            else
            {
                return AnualIncome * 0.14;
            }
            
        }
    }
}
