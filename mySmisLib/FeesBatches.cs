using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySmisLib
{
    public class FeesBatches
    {
        public int ID { get; set; }
        public int FeeCateId { get; set; }
        public int BatchId { get; set; }
        public double Feevalue { get; set; }
        public DateTime DateCreted { get; set; }
        public DateTime LastModified { get; set; }
        public string Bgroup { get; set; }

        public int xFeeId { get; set; }
        public string xTitle { get; set; }
        public string xDescription { get; set; }
        public string xApplyto { get; set; }
        public string xBatchTitle { get; set; }
        
        public FeesBatches(){}
    }

    public class FeesBatchesService
    {
        public bool AddFeesBatches(FeesBatches fp, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "INSERT INTO `feesbatches`(`feecateid`, `batchid`, `feevalue`, `createdate`, `modifydate`,bgroup) VALUES (@feecateid,@batchid,@feevalue,@createdate,@modifydate,@bgroup)";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@feecateid", fp.FeeCateId);
            cmd.Parameters.AddWithValue("@batchid", fp.BatchId);
            cmd.Parameters.AddWithValue("@feevalue", fp.Feevalue);
            cmd.Parameters.AddWithValue("@createdate", fp.DateCreted);
            cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
            cmd.Parameters.AddWithValue("@bgroup", fp.Bgroup);
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool AddFeesBatchesList(string fpList, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = string.Format("INSERT INTO `feesbatches`(`feecateid`, `batchid`, `feevalue`, `createdate`, `modifydate`,bgroup) VALUES {0} ", fpList);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            //cmd.Parameters.AddWithValue("@feecateid", fp.FeeCateId);
            //cmd.Parameters.AddWithValue("@batchid", fp.BatchId);
            //cmd.Parameters.AddWithValue("@feevalue", fp.Feevalue);
            //cmd.Parameters.AddWithValue("@createdate", fp.DateCreted);
            //cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool UpdateFeesBatches(FeesBatches fp, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "UPDATE `feesbatches` SET `feecateid`=@feecateid,`batchid`=@batchid,`feevalue`=@feevalue,`modifydate`=@modifydate bgroup =@bgroup WHERE id = @id";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@feecateid", fp.FeeCateId);
            cmd.Parameters.AddWithValue("@batchid", fp.BatchId);
            cmd.Parameters.AddWithValue("@feevalue", fp.Feevalue);
            cmd.Parameters.AddWithValue("@modifydate", fp.LastModified);
            cmd.Parameters.AddWithValue("@id", fp.ID);
            cmd.Parameters.AddWithValue("@bgroup", fp.Bgroup);

            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public bool DeleteFeesBatches(int fp, string userID)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "DELETE FROM `feesbatches` WHERE id = @id";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@id", fp);
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
        public List<FeesBatches> GetAllFeesBatches(string applyto, string userID)
        {
            List<FeesBatches> retVal = new List<FeesBatches>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT feescategory.title,feescategory.description,feescategory.applyto,feescategory.id,IFNULL(feesbatches.batchid,0),IFNULL(feesbatches.feevalue, 0),IFNULL(feesbatches.createdate, '0001-01-01 00:00:00'),IFNULL(feesbatches.modifydate, '0001-01-01 00:00:00'),IFNULL(feesbatches.bgroup,''),IFNULL(feesbatches.id, 0) AS feesbid,IFNULL(feesbatches.feecateid,0) AS feecateid,IFNULL(studentcoursesschedule.schdTitle,'') AS schdTitle FROM feescategory LEFT OUTER JOIN feesbatches ON feescategory.id = feesbatches.feecateid LEFT OUTER JOIN studentcoursesschedule ON feesbatches.batchid = studentcoursesschedule.id WHERE feescategory.active = 1 AND feescategory.applyto = @applyto";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@applyto", applyto);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                FeesBatches Mod = new FeesBatches();
                Mod.xTitle = dr.GetString(0);
                Mod.xDescription = dr.GetString(1);
                Mod.xApplyto = dr.GetString(2);
                Mod.xFeeId = dr.GetInt32(3);
                Mod.BatchId = dr.GetInt32(4);
                Mod.Feevalue = dr.GetDouble(5);
                Mod.DateCreted = dr.GetDateTime(6);
                Mod.LastModified = dr.GetDateTime(7);
                Mod.Bgroup = dr.GetString(8);
                Mod.FeeCateId = dr.GetInt32(9);
                Mod.ID = dr.GetInt32(10);
                Mod.xBatchTitle = dr.GetString(11);
                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
        public List<FeesBatches> GetAllFeesBatchesByBatchid(int batchId, string userID)
        {
            List<FeesBatches> retVal = new List<FeesBatches>();
            MySqlConnection con = new MySqlConnection(DbCon.connectionString);
            string sqlInsert = "SELECT feesbatches.id,feesbatches.feecateid,feesbatches.batchid,feesbatches.feevalue,feesbatches.createdate,feesbatches.modifydate,feesbatches.bgroup,feescategory.title,feescategory.applyto,studentcoursesschedule.schdTitle FROM feesbatches INNER JOIN feescategory ON feesbatches.feecateid = feescategory.id INNER JOIN studentcoursesschedule ON feesbatches.batchid = studentcoursesschedule.id WHERE feesbatches.batchid = @batchId";
            MySqlDataReader dr = null;
            MySqlCommand cmd;
            con.Open();
            cmd = new MySqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("@batchid", batchId);
            dr = cmd.ExecuteReader();

            while (dr.Read()) //iterate through the records in the result dataset
            {
                FeesBatches Mod = new FeesBatches();
                Mod.ID = dr.GetInt32(0);
                Mod.FeeCateId = dr.GetInt32(1);
                Mod.BatchId = dr.GetInt32(2);
                Mod.Feevalue = dr.GetDouble(3);
                Mod.DateCreted = dr.GetDateTime(4);
                Mod.LastModified = dr.GetDateTime(5);
                Mod.Bgroup = dr.GetString(6);
                Mod.xTitle = dr.GetString(7);
                Mod.xApplyto = dr.GetString(8);
                Mod.xBatchTitle = dr.GetString(9);
                retVal.Add(Mod);
            }


            con.Close();

            return retVal;
        }
    }
}
