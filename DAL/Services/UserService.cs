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
    public class UserService : BaseService , IUserRepository<DAL.Entities.Utilisateur>
    {
        public UserService(IConfiguration config) : base(config, "Main-DB") { }

        
        public Utilisateur Get(Guid userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "User_GetById";
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue("UtilisateurId", userId);
                    command.Parameters.AddWithValue(nameof(Utilisateur.UtilisateurId), userId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToUser();
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(userId));
                        }
                    }
                }
            }
        }

        public Guid Insert(Utilisateur user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "User_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Utilisateur.Pseudo), user.Pseudo);
                    command.Parameters.AddWithValue(nameof(Utilisateur.Email), user.Email);
                    command.Parameters.AddWithValue(nameof(Utilisateur.Motdepasse), user.Motdepasse);
                    connection.Open();
                    return (Guid)command.ExecuteScalar();
                }
            }
        }

        public void Update(Guid userId, Utilisateur user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "User_UpdatePseudo";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(user.UtilisateurId), userId);
                    command.Parameters.AddWithValue(nameof(Utilisateur.Pseudo), user.Pseudo);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(Guid userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "User_Delete";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Utilisateur.UtilisateurId), userId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }

    }
}
