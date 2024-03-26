using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.DTO
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string SupplierDescription { get; set; }
        public string SupplierCNPJ { get; set; }
    }
}
