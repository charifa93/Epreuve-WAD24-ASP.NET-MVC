using Common.Repositories;
using DAL.Entities;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class JeuxService : BaseService, IJeuxRepository<DAL.Entities.Jeux>
    {

        public JeuxService(IConfiguration config) : base(config, "Main-DB") { }


        public IEnumerable<Jeux> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Jeux_GetAll";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToJeux();
                        }
                    }
                }
            }
        }

        public IEnumerable<Jeux> GetFromUser(Guid userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Jeux_GetByUserId_WithTags";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(userId), userId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToJeux();
                        }
                    }
                }
            }
        }

        public IEnumerable<Jeux> GetWithNom(string Nom)
        {
            List<Jeux> jeuxList = new List<Jeux>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Jeux_GetByNom";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Nom), Nom);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Jeux jeu = reader.ToJeux();

                            jeuxList.Add(jeu);
                        }
                    }
                }
            }

            return jeuxList;
        }





        public IEnumerable<Jeux> GetWithTag(Guid tagId)
        {
            List<Jeux> jeuxList = new List<Jeux>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Jeux_GetByTag";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(tagId), tagId);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Jeux jeu = reader.ToJeux();

                            jeuxList.Add(jeu);
                        }
                    }
                }
            }

            return jeuxList;
        }

        public Guid Insert(Jeux jeux)
        {
            if (JeuExiste(jeux.Nom))
            {
                throw new Exception("Le jeu existe déjà dans la base de données.");
            }
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Jeux_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Jeux.Nom), jeux.Nom);
                    command.Parameters.AddWithValue(nameof(Jeux.Description), jeux.Description);
                    command.Parameters.AddWithValue(nameof(Jeux.AgeMin), jeux.AgeMin);
                    command.Parameters.AddWithValue(nameof(Jeux.AgeMax), jeux.AgeMax);
                    command.Parameters.AddWithValue(nameof(Jeux.NbJoueourMin), jeux.NbJoueourMin);
                    command.Parameters.AddWithValue(nameof(Jeux.NbJoueourMax), jeux.NbJoueourMax);
                    command.Parameters.AddWithValue(nameof(Jeux.DureeMinute), jeux.DureeMinute);
                    connection.Open();
                    return (Guid)command.ExecuteScalar();
                }
            }
        }
        private bool JeuExiste(string nom)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT COUNT(1) FROM Jeux WHERE Nom = @Nom";
                    command.Parameters.AddWithValue("@Nom", nom);

                    connection.Open();
                    return (int)command.ExecuteScalar() > 0;
                }
            }
        }


        public void Delete(Guid jeuId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Jeux_Delete";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(jeuId), jeuId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }

        public Jeux Get(Guid jeuId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Jeux_GetById_WithTags";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@JeuId", jeuId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToJeux();
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(jeuId));
                        }
                    }
                }
            }
        }
        

        
    }
}
