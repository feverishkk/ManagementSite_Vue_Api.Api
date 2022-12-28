using Application.ViewModels.Chart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IChartRepository
    {
        public IList<GetCustomerGenderViewModel> GetCustomerGender();
        public IList<GetGuildPropertyViewModel> GetGuildProperty();
        public IList<GetMemberSinceViewModel> GetMemberSince();
        public IList<GetPreferPaymentViewModel> GetPreferPayment();
    }
}
