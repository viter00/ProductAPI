using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Endpoints.Insert
{
    public class RequestInsert
    {
        public string Description { get; set; }
        public bool Activated { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string SupplierDescription { get; set; }
        public string SupplierCNPJ { get; set; }


        public void Validate()
        {
            if (String.IsNullOrEmpty(Description) ||
                String.IsNullOrEmpty(SupplierName) ||
                String.IsNullOrEmpty(SupplierDescription) ||
                String.IsNullOrEmpty(SupplierCNPJ) ||
                SupplierCode <= 0 ||
                ManufactureDate > ExpiryDate ||
                SupplierCNPJ.Length != 14
                )
                throw new Exception("Requisição inválida");
        }

    }
}
