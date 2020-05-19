using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVMAgendaCommands.Models
{
    class PersonDAL
    {
        internal ObservableCollection<Person> GetAllPersons()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllPersons", con);
                ObservableCollection<Person> result = new ObservableCollection<Person>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Person p = new Person();
                    p.PersonID = (int)(reader[0]);//reader.GetInt(0);
                    p.Name = reader.GetString(1);//reader[1].ToString();
                    p.Address = reader.IsDBNull(2) ? null : reader[2].ToString();
                    result.Add(p);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        internal ObservableCollection<Person> GetAllPersonsWithNoPhone()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllPersonsWithNoPhone", con);
                ObservableCollection<Person> result = new ObservableCollection<Person>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new Person()
                        {
                            PersonID = reader["idPersoana"] as int?,
                            Address = reader["adresa"].ToString(),
                            Name = reader["nume"].ToString()
                        }
                    );
                }
                reader.Close();
                return result;
            }
        }

        internal void AddPerson(Person persoana)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddPerson", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@nume", persoana.Name);
                SqlParameter paramAdresa;
                if (String.IsNullOrEmpty(persoana.Address))
                {
                    paramAdresa = new SqlParameter("@adresa", DBNull.Value);
                }
                else
                {
                    paramAdresa = new SqlParameter("@adresa", persoana.Address);
                }
                SqlParameter paramIdPersoana = new SqlParameter("@idPersoana", SqlDbType.Int);
                paramIdPersoana.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramAdresa);
                cmd.Parameters.Add(paramIdPersoana);
                con.Open();
                cmd.ExecuteNonQuery();
                persoana.PersonID = paramIdPersoana.Value as int?;
            }
        }

        internal void DeletePerson(Person persoana)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeletePerson", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdPersoana = new SqlParameter("@idPersoana", persoana.PersonID);
                cmd.Parameters.Add(paramIdPersoana);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal void ModifyPerson(Person persoana)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyPerson", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdPersoana = new SqlParameter("@idPersoana", persoana.PersonID);
                SqlParameter paramNume = new SqlParameter("@nume", persoana.Name);
                SqlParameter paramAdresa = new SqlParameter();
                paramAdresa.ParameterName = "@adresa";
                if (String.IsNullOrEmpty(persoana.Address))
                {
                    paramAdresa.Value = DBNull.Value;
                }
                else
                {
                    paramAdresa.Value = persoana.Address;
                }
                cmd.Parameters.Add(paramIdPersoana);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramAdresa);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
