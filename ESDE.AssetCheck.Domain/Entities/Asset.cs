using System;

namespace ESDE.AssetCheck.Domain.Entities
{
    public class Asset
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string ShortName { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsDailySettlement { get; set; }

    }
}
