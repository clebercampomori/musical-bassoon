using System;
using GJJA.RegistraVoce.Domain.Enums;

namespace GJJA.RegistraVoce.Domain
{
    // POCO
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string DocumentNumber { get; set; }
        public string Identification { get; set; }
        public DateTime BirthDate { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}