using Anserem_Task.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Anserem_Task.Repository
{
    public class SellingRepository : ISellingRepository
    {
        private SaleContext context;
        public SellingRepository(SaleContext context)
        {
            this.context = context;
        }
        public IEnumerable<SellingViewModel> GetSellings()
        {
            List<SellingViewModel> SellingList = context.Sellings.Where(x => x.IsDeleted == false).Select(x => new SellingViewModel
            {
                SellingId = x.id,
                Name = x.Name,
                SellingContact = x.SellingContact.ContactPerson,
                ContractorName = x.Contractor.Name,
                ContractorContactPerson = x.Contractor.ContactPerson,
                ContractorCity = x.Contractor.City.Name
            }).ToList();
            return SellingList;
        }
        public SellingViewModel GetSellingByID(int id)
        {
            SellingViewModel selling = context.Sellings.Where(x => x.id == id && x.IsDeleted == false).Select(x => new SellingViewModel
            {
                SellingId = x.id,
                Name = x.Name,
                SellingContact = x.SellingContact.ContactPerson,
                ContractorName = x.Contractor.Name,
                ContractorContactPerson = x.Contractor.ContactPerson,
                ContractorCity = x.Contractor.City.Name
            }).FirstOrDefault();
            return selling;
        }
        public void CreateSelling(SellingViewModel selling)
        {
            Selling entry = new Selling
            {
                Name = selling.Name,
                IsDeleted = false
            };
            if (selling.ContractorName != null || selling.ContractorContactPerson != null)
            {
                Contractor contractor = new Contractor { Name = selling.ContractorName, ContactPerson = selling.ContractorContactPerson };
                if (selling.ContractorCity != null)
                {
                    City city = new City { Name = selling.ContractorCity };
                    context.Cities.Add(city);
                    contractor.City = city;
                }
                context.Contractors.Add(contractor);
                entry.Contractor = contractor;
            };
            if (selling.SellingContact != null)
            {
                SellingContact sellingContact = new SellingContact { ContactPerson = selling.SellingContact };
                entry.SellingContact = sellingContact;
            };
            context.Sellings.Add(entry);
        }
        public void DeleteSelling(int id)
        {
            Selling selling = context.Sellings.Where(x => x.id == id && x.IsDeleted == false).FirstOrDefault();
            selling.IsDeleted = true;
            context.Entry(selling).State = EntityState.Modified;
        }
        
        public void UpdateSelling(SellingViewModel selling)
        {
            Selling entry = context.Sellings.Where(x => x.id == selling.SellingId && x.IsDeleted == false).FirstOrDefault();

            if ( ((selling.ContractorName != null)&&(selling.ContractorName != entry.Contractor.Name)) || ((selling.ContractorContactPerson != null)&&(selling.ContractorContactPerson != entry.Contractor.ContactPerson)) )
            {
                Contractor contractor = new Contractor { Name = selling.ContractorName, ContactPerson = selling.ContractorContactPerson };
                if (selling.ContractorCity != null)
                {
                    City city = new City { Name = selling.ContractorCity };
                    context.Cities.Add(city);
                    contractor.City = city;
                }
                context.Contractors.Add(contractor);
                entry.Contractor = contractor;
            };
            if (selling.SellingContact != null && selling.SellingContact != entry.SellingContact.ContactPerson)
            {
                SellingContact sellingContact = new SellingContact { ContactPerson = selling.SellingContact };
                entry.SellingContact = sellingContact;
            };
            context.Entry(entry).State = EntityState.Modified;
        }

        public void CopySelling(int id)
        {
            SellingViewModel selling = context.Sellings.Where(x => x.id == id && x.IsDeleted == false).Select(x => new SellingViewModel
            {
                Name = x.Name,
                SellingContact = x.SellingContact.ContactPerson,
                ContractorName = x.Contractor.Name,
                ContractorContactPerson = x.Contractor.ContactPerson,
                ContractorCity = x.Contractor.City.Name
            }).FirstOrDefault();
            CreateSelling(selling);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}