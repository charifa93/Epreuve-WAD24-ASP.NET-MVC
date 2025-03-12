using Common.Repositories;
using DAL.Entities;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class EtatService : BaseService, IEtatRepository<DAL.Entities.Etat, Guid>
    {
        public EtatService(IConfiguration config) : base(config, "Main-DB") { }

        public IEnumerable<Etat> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Etat_GetAll";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToEtat();
                        }
                    }
                }
            }
        }

        public Etat GetByJeuxId(Guid jeuxId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Etat_GetByJeuxId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@JeuId", SqlDbType.UniqueIdentifier) { Value = jeuId });
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToEtat();
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(jeuxId));
                        }
                    }
                }
            }
        }

    }
}
