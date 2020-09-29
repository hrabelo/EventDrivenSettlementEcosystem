using System;

namespace ESDE.AssetCheck.Domain.DTOs
{
    public class AssetForDueDateDto
    {
        public int Id { get; set; }

        public string ShortName { get; set; }

        public string FullName { get; set; }

        public DateTime DueDate { get; set; }
    }
}
