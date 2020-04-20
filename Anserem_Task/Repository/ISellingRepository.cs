using Anserem_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anserem_Task.Repository
{
    public interface ISellingRepository
    {
        IEnumerable<SellingViewModel> GetSellings();
        SellingViewModel GetSellingByID(int id);
        void CreateSelling(SellingViewModel selling);
        void DeleteSelling(int id);
        void UpdateSelling(SellingViewModel selling);
        void Save();
    }
}
