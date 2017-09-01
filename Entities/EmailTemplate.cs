using System.ComponentModel.DataAnnotations;

namespace SampleEmailSettings.Entities
{
    public class EmailTemplate
    {
        public int Id { get; set; }
        public string Salutation { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Signature { get; set; }   

    }
}
