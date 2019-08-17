using System.Data;
using System;
using System.Data.Common;
using System.Collections.Generic;
using GJJA.RegistraVoce.Domain;
using GJJA.RegistraVoce.DataAccess.Utils;
using GJJA.RegistraVoce.Domain.Enums;

namespace GJJA.RegistraVoce.DataAccess.DAOs
{
    public class PersonDAO
    {
        public List<Person> Select()
        {
            List<Person> people = new List<Person>();
            DbConnection conn = null;
            try
            {
                conn = DbUtils.CreateConnection();
                DbCommand command = conn.CreateCommand();
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
                    });
                }
                return people;
            }
            finally
            {
                DbUtils.CloseConnection(conn);
            }
        }
    }
}