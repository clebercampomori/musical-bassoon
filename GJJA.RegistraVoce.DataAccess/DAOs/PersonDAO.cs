using System.Data;
using System;
using System.Data.Common;
using System.Collections.Generic;
using GJJA.RegistraVoce.Domain;
using GJJA.RegistraVoce.DataAccess.Utils;
using GJJA.RegistraVoce.Domain.Enums;
using GJJA.RegistraVoce.DataAccess.Extensions;

namespace GJJA.RegistraVoce.DataAccess.DAOs
{
    public class PersonDAO
    {
        public List<Person> Select()
        {
            List<Person> people = new List<Person>();
            using (DbConnection conn = DbUtils.CreateConnection())
            using (DbCommand command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM pes_pessoas";
                command.CommandType = System.Data.CommandType.Text;
                DbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    people.Add(new Person
                    {
                        Id = Convert.ToInt32(reader["pes_id"]),
                        Name = reader["pes_nome"].ToString(),
                        Gender = (Gender)Convert.ToInt32(reader["pes_sexo"]),
                        DocumentNumber = reader["pes_cpf"].ToString(),
                        Identification = reader["pes_rg"].ToString(),
                        BirthDate = Convert.ToDateTime(reader["pes_data_nascimento"]),
                        MaritalStatus = (MaritalStatus)Convert.ToInt32(reader["pes_estado_civil"]),
                        Address = reader["pes_endereco"].ToString(),
                        Phone = reader["pes_telefone"].ToString(),
                        // 1' OR '1' = '1
                    });
                }
                return people;
            }
        }
        
        public void Insert(Person person)
        {
            using (DbConnection conn = DbUtils.CreateConnection())
            using (DbCommand command = conn.CreateCommand())
            {
                command.CommandText = 
                    "INSERT INTO pes_pessoas (pes_nome, pes_sexo, pes_cpf, pes_rg, pes_data_nascimento, pes_estado_civil, pes_endereco, pes_telefone) " + 
                    " VALUES (@pes_nome, @pes_sexo, @pes_cpf, @pes_rg, @pes_data_nascimento, @pes_estado_civil, @pes_endereco, @pes_telefone)";
                command.SetParameter("@pes_nome", person.Name);
                command.SetParameter("@pes_sexo", person.Gender);
                command.SetParameter("@pes_cpf", person.DocumentNumber);
                command.SetParameter("@pes_rg", person.Identification);
                command.SetParameter("@pes_data_nascimento", person.BirthDate);
                command.SetParameter("@pes_estado_civil", person.MaritalStatus);
                command.SetParameter("@pes_endereco", person.Address);
                command.SetParameter("@pes_telefone", person.Phone);
                command.ExecuteNonQuery();
            }
        }
    }
}