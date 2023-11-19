using StudentFeePayment.Entities.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPayment.Contracts
{
    public interface IFeePaymentRepository
    {
        Task<IEnumerable<FeePayment>> GetAllFeePaymentsAsync();
        Task<FeePayment> GetFeePaymentByIdAsync(int id);
        void CreateFeePayment(FeePayment feePayment);
        void UpdateFeePaymentById(int id, string remarks);
    }
}
