using System;

namespace ESDE.Custody.Domain.Entities
{
    public class Custody
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int AssetId { get; set; }

        public int Quantity { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

    }
}
