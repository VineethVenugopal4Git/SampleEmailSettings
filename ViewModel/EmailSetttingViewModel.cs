using SampleEmailSettings.Extensions;

namespace SampleEmailSettings.ViewModel
{
    public class EmailSetttingViewModel : IQueryObject
    {
        public int Id { get; set; }
        public string Salutation { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Signature { get; set; }
        public int Page { get; set; } = 1;
        public byte PageSize { get; set; } = 10;
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }


    }
}
