using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Connect;
using System.Data;
using System.Data.SqlClient;
using TanmiahDatabase.Models;
namespace TanmiahDatabase.Services
{
    public class CardServices
    {
        public DataTable GetCard(int id)
        {
            DataTable dtblCard = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spCard", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Select");
                cmd.Parameters.AddWithValue("@prodID", 1);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtblCard.Load(sqlread);
                sqlConn.Close();
            }
            return dtblCard;
        }
    }

    public class CreateCard
    {
        public SqlDataReader GenerateCard(cardModel card)
        {
            using (SqlConnection sqlCon = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("spCard", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@cardImg", card.CardImage);
                sqlCmd.Parameters.AddWithValue("@cardTitle", card.ShortDescription);
                sqlCmd.Parameters.AddWithValue("@cardText", card.ShortText);
                sqlCmd.Parameters.AddWithValue("@prodID", card.ProductID);
                sqlCmd.Parameters.AddWithValue("@StatementType","Insert");
                sqlCon.Open();
                SqlDataReader sqlread = sqlCmd.ExecuteReader();
                sqlCon.Close();
                return sqlread;
            }
        }
    }

    class ReadCard
    {
        public cardModel ReadCardData(int id)
        {
            cardModel card = new cardModel();
            DataTable dtblCard = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spCard", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "select");
                cmd.Parameters.AddWithValue("@prodID", id);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtblCard.Load(sqlread);
                sqlConn.Close();
            }
            if (dtblCard.Rows.Count == 1)
            {
                card.CardId = Convert.ToInt32(dtblCard.Rows[0][0].ToString());
                card.CardImage = dtblCard.Rows[0][1].ToString();
                card.ShortDescription = dtblCard.Rows[0][2].ToString();
                card.ShortText = dtblCard.Rows[0][3].ToString();
                card.ProductID = Convert.ToInt32(dtblCard.Rows[0][4].ToString());
            }
            return card;
        }
    }


    class EditCard
    {
        public SqlDataReader EditCardData(cardModel card)
        {
            using (SqlConnection sqlCon = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("spCard", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@cardID", card.CardId);
                sqlCmd.Parameters.AddWithValue("@cardImg", card.CardImage);
                sqlCmd.Parameters.AddWithValue("@cardTitle", card.ShortDescription);
                sqlCmd.Parameters.AddWithValue("@cardText", card.ShortText);
                sqlCmd.Parameters.AddWithValue("@prodID", card.ProductID);
                sqlCmd.Parameters.AddWithValue("@StatementType", "Update");
                sqlCon.Open();
                SqlDataReader sqlread = sqlCmd.ExecuteReader();
                sqlCon.Close();
                return sqlread;
            }
        }
    }
    class DeleteCard
    {
        public SqlDataReader DeleteCardData(cardModel card, int id)
        {
            DataTable dtblcard = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spCard", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Delete");
                cmd.Parameters.AddWithValue("@prodID", id);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                sqlConn.Close();
                return sqlread;
            }
        }
    }

}