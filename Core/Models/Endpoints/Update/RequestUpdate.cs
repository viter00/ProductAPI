using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Endpoints.Update
{
    public class RequestUpdate
    {
        public int ProductId { get; set; }
        public string? Description { get; set; }
        public bool? Activated { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? SupplierCode { get; set; }
        public string? SupplierName { get; set; }
        public string? SupplierDescription { get; set; }
        public string? SupplierCNPJ { get; set; }


        public void Validate()
        {
            if (ProductId <= 0 ||
                ManufactureDate > ExpiryDate)
                throw new Exception("Id do Produto inválido");
        }
    }
}
