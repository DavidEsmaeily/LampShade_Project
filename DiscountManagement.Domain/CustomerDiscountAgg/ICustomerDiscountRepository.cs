﻿using _0_Framework.Domain;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using System.Collections.Generic;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{

        public interface ICustomerDiscountRepository : IRepository<long , CustomerDiscount>
        {
            EditCustomerDiscount GetDetails(long id);
            List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
        }

    

    
}
