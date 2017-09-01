using SampleEmailSettings.Data;
using SampleEmailSettings.Entities;
using SampleEmailSettings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleEmailSettings.Repository
{
    public class EmailSettingsRepository:IEmailSettings
    {
        private readonly EmailDbContext _context;
        public EmailSettingsRepository(EmailDbContext context)
        {
            _context = context;
        }
        public void Add(EmailTemplate model)
        {
            _context.Add(model);
        }
        public void update(EmailTemplate model)
        {
            _context.Update(model);
        }
        public void Delete(EmailTemplate model)
        {
            _context.Remove(model);
        }
        public EmailTemplate GetEmail(int id)
        {
            return _context.EmailTemplates.SingleOrDefault(p => p.Id == id);
        }
        public IEnumerable<EmailTemplate> GetAll()
        {
            return _context.EmailTemplates;
        }
        public void commit()
        {
            _context.SaveChanges();
        }
    }
}

