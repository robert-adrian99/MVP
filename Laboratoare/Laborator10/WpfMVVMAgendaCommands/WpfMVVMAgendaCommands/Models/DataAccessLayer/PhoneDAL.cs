using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVMAgendaCommands.Models
{
    class PhoneDAL
    {
        internal ObservableCollection<Phone> GetAllPhonesForPerson(Person persoana)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                ObservableCollection<Phone> result = new ObservableCollection<Phone>();
                SqlCommand cmd = new SqlCommand("GetPhonesForPerson", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdPersoana = new SqlParameter("@idPersoana", persoana.PersonID);
                cmd.Parameters.Add(paramIdPersoana);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Phone()
                    {
                        PhoneID = reader.GetInt32(0),
                        PersonID = reader.GetInt32(1),
                        PhoneNumber = reader.GetString(2),
                        Description = reader.GetString(3)
                    });
                }
                return result;
            }
        }

        internal void AddPhone(Phone telefon)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddPhoneForPerson", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdPersoana = new SqlParameter("@idPersoana", telefon.PersonID);
                SqlParameter paramNumarTelefon = new SqlParameter("@numarTelefon", telefon.PhoneNumber);
                SqlParameter paramDescriere = new SqlParameter("@descriere", telefon.Description);
                SqlParameter paramIdTelefon = new SqlParameter("@idTelefon", System.Data.SqlDbType.Int);
                paramIdTelefon.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(paramIdPersoana);
                cmd.Parameters.Add(paramIdTelefon);
                cmd.Parameters.Add(paramNumarTelefon);
                cmd.Parameters.Add(paramDescriere);
                con.Open();
                cmd.ExecuteNonQuery();
                if (!String.IsNullOrEmpty(paramIdTelefon.Value.ToString()))
                    telefon.PhoneID = (int?)paramIdTelefon.Value;
            }
        }

        internal void DeletePhone(Phone telefon)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeletePhone", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdTelefon = new SqlParameter("@idTelefon", telefon.PhoneID);
                cmd.Parameters.Add(paramIdTelefon);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal void ModifyPhone(Phone phone)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyPhone", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdTelefon = new SqlParameter("@idTelefon", phone.PhoneID);
                SqlParameter paramIdPersoana = new SqlParameter("@idPersoana", phone.PersonID);
                SqlParameter paramNumar = new SqlParameter("@numarTelefon", phone.PhoneNumber);
                SqlParameter paramDescriere = new SqlParameter("@descriere", phone.Description);
                cmd.Parameters.Add(paramIdPersoana);
                cmd.Parameters.Add(paramIdTelefon);
                cmd.Parameters.Add(paramNumar);
                cmd.Parameters.Add(paramDescriere);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
