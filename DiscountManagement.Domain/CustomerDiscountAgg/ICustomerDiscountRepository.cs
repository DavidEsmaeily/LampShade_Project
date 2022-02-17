using _0_Framework.Domain;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public partial class CustomerDiscount
    {
        public interface ICustomerDiscountRepository : IRepository<long , CustomerDiscount>
        {

        }

    }

    
}
