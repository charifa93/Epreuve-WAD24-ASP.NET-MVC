using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories;
using DAL.Entities;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL.Services
{
    public class EmpruntService  : BaseService , IEmpruntRepository<DAL.Entities.Emprunt>
    {
        public EmpruntService(IConfiguration config) : base(config, "Main-DB") { }

        public void AjouterEvaluationAsync(Guid empruntId, int? evaluationPreteur, int? evaluationEmprunteur)
        {
            throw new NotImplementedException();
        }

        public void CloturerEmprunt(int empruntId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Cloturer_Emprunt";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Emprunt.EmpruntId), empruntId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Emprunt> GetTop10Emprunts()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Top10JeuxEmpruntes";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    
                    {
                            var empruntsList = reader.Cast<IDataRecord>()
                                          .Select(record => record.ToEmprunt()) // Conversion en objets Emprunt
                                          .ToList(); // Convertir en une liste

                            return empruntsList;
                        
                    }
                }
            }
        }

        public Guid Insert(Emprunt emprunt)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Emprunt_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                   
                    command.Parameters.AddWithValue(nameof(Emprunt.DateRetour), emprunt.DateRetour);
                    command.Parameters.AddWithValue("JeuId", emprunt.JeuId);
                    command.Parameters.AddWithValue("PreteurId", (object?)emprunt.PreteurId ?? DBNull.Value);
                    command.Parameters.AddWithValue("EmprunteurId", (object?)emprunt.EmprunteurId ?? DBNull.Value);
                    

                    connection.Open();
                    return (Guid)command.ExecuteScalar();
                }
            }
        }
    }
}
