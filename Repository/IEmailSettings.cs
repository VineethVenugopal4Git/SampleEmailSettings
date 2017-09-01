using SampleEmailSettings.Entities;
using SampleEmailSettings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleEmailSettings.Repository
{
    public interface IEmailSettings
    {
        IEnumerable<EmailTemplate> GetAll();
        EmailTemplate GetEmail(int id);
        void Add(EmailTemplate model);
        void update(EmailTemplate model);
        void commit();
        void Delete(EmailTemplate model);
    }
}
