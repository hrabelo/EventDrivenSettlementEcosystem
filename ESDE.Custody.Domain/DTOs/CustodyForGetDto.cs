using System;
using System.Collections.Generic;
using System.Text;

namespace ESDE.Custody.Domain.DTOs
{
    public class CustodyForGetDto
    {
        public int ClientId { get; set; }

        public string AssetName { get; set; }

        public int Quantity { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
