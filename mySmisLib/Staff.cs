using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySmisLib
{
   public class Staff
    {
       public int ID { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string OtherNames { get; set; }
       public DateTime DateOfBirth { get; set; }
       public string UserID { get; set; }
       public string Tel { get; set; }
       public string Mobile { get; set; }
       public string Email { get; set; }
       public string Gender { get; set; }
       public string PostalAddress { get; set; }
       public string ResAddress { get; set; }
       public int Position { get; set; }
       public int Active { get; set; }
       public DateTime DateCreated { get; set; }
       public DateTime LastModify { get; set; }
       public string Role { get; set; }
       public string xFullName { get; set; }

       public string xPosition { get; set; }
       public string xActive { get; set; }

       public Staff(){}
    }

   public class StaffService
   {
       public bool AddStaff(Staff mem, string userId)
       {
           Boolean retVal = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           MySqlCommand cmd;

           string query = "INSERT INTO `staff`( `userid`, `fname`, `sname`, `oname`, `gender`, `dob`, `tel`, `mobile`, `email`, `postaladd`, `resadd`, `position`, `dateCreated`, `lastModify`,role) VALUES (@userid,@fname,@sname,@oname,@gender,@dob,@tel,@mobile,@email,@postaladd,@resadd,@position,@dateCreated,@lastModify,@role)";

           try
           {
               con.Open();//opens connection to database

               cmd = new MySqlCommand(query, con);//insert data if connection is open
               cmd.Parameters.AddWithValue("@userid", mem.UserID);
               cmd.Parameters.AddWithValue("@fname", mem.FirstName);
               cmd.Parameters.AddWithValue("@sname", mem.LastName);
               cmd.Parameters.AddWithValue("@oname", mem.OtherNames);
               cmd.Parameters.AddWithValue("@dob", mem.DateOfBirth);
               cmd.Parameters.AddWithValue("@resadd", mem.ResAddress);
               cmd.Parameters.AddWithValue("@tel", mem.Tel);
               cmd.Parameters.AddWithValue("@email", mem.Email);
               cmd.Parameters.AddWithValue("@mobile", mem.Mobile);
               cmd.Parameters.AddWithValue("@gender", mem.Gender);
               cmd.Parameters.AddWithValue("@position",mem.Position);
               cmd.Parameters.AddWithValue("@postaladd", mem.PostalAddress);
               cmd.Parameters.AddWithValue("@dateCreated", mem.DateCreated);
               cmd.Parameters.AddWithValue("@lastModify", mem.LastModify);
               cmd.Parameters.AddWithValue("@role",mem.Role);

               int rowsAffec = cmd.ExecuteNonQuery();
               new AuditLogService().AddAuditLog("ADDING STAFF", userId, new UserService().GetUserName(userId), "A new staff has been added/created", DateTime.Now);
               if (rowsAffec > 0)
               {
                   retVal = true;
               }
           }

           catch (MySqlException ex) //first catch a specific exception
           {
               //new AuditLogService().AddAuditLog("ERROR ADD STAFF", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
               String errorString = ex.Message;
           }
           catch (Exception ex) //also catch any general kind of error, since all Exception classes derive from 'Exception'
           {
              // new AuditLogService().AddAuditLog("ERROR ADD STAFF", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
               String errorString = ex.Message;
           }
           finally
           {
               con.Close();
           }

           return retVal;
       }
       public List<Staff> GetAllStaff(string userId)
       {
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           MySqlDataReader dr = null;
           MySqlCommand cmd;

           string query = "SELECT `id`, `userid`, `fname`, `sname`, `oname`, `gender`, `dob`, `tel`, `mobile`, `email`, `postaladd`, `resadd`, `position`, `active`, `dateCreated`, `lastModify`,role,jobposition.lValue FROM `staff` INNER JOIN jobposition ON staff.position = jobposition.lKey ORDER BY active DESC";

           Staff member;
           List<Staff> memberList = new List<Staff>();

           try
           {
               con.Open();
               cmd = new MySqlCommand(query, con);
               dr = cmd.ExecuteReader();
              // new AuditLogService().AddAuditLog("GETTING ALL MEMBER", userId, new UserService().GetUserName(userId), query, DateTime.Now);
               if (dr.HasRows) //if the executed query returns any records
               {
                   while (dr.Read()) //iterate through the records in the result dataset
                   {
                       member = new Staff();

                       member.ID = dr.GetInt32(0);
                       member.UserID = dr.GetString(1);
                       member.FirstName = dr.GetString(2);
                       member.LastName = dr.GetString(3);
                       member.OtherNames = dr.GetString(4);
                       member.Gender = dr.GetString(5);
                       member.DateOfBirth = dr.GetDateTime(6);
                       member.Tel = dr.GetString(7);
                       member.Mobile = dr.GetString(8);
                       member.Email = dr.GetString(9);
                       member.PostalAddress = dr.GetString(10);
                       member.ResAddress = dr.GetString(11);
                       member.Position = dr.GetInt32(12);
                       member.Active = dr.GetInt32(13);
                       member.DateCreated = dr.GetDateTime(14);
                       member.LastModify = dr.GetDateTime(15);
                       member.Role = dr.GetString(16);
                       member.xPosition = dr.GetString(17);
                       member.xFullName = dr.GetString(2) + " " + dr.GetString(4) + " " + dr.GetString(3);
                       if (dr.GetInt32(13) == 1) { member.xActive = "Activated"; } else if (dr.GetInt32(13) == 0) { member.xActive = "Deactivated"; }
                       memberList.Add(member);
                   }
               }
           }
           catch (MySqlException ex)
           {
               //new AuditLogService().AddAuditLog("ERROR GETTING ALL MEMBER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
               String errorString = ex.Message;
           }
           catch (Exception ex)
           {
               //new AuditLogService().AddAuditLog("ERROR GETTING ALL MEMBER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
               String errorString = ex.Message;
           }
           finally
           {
               dr.Close();
               con.Close();
           }

           return memberList;
       }
       public Staff GetStaffByID(int staffID, string userId)
       {
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           MySqlDataReader dr = null;
           MySqlCommand cmd;

           string query = "SELECT `id`, `userid`, `fname`, `sname`, `oname`, `gender`, `dob`, `tel`, `mobile`, `email`, `postaladd`, `resadd`, `position`, `active`, `dateCreated`, `lastModify`,role,jobposition.lValue FROM `staff` INNER JOIN jobposition ON staff.position = jobposition.lKey WHERE id=@staffID";

           Staff member = new Staff();
           //List<Staff> memberList = new List<Staff>();

           try
           {
               con.Open();
               cmd = new MySqlCommand(query, con);
               cmd.Parameters.AddWithValue("@staffID", staffID);
               dr = cmd.ExecuteReader();
             //  new AuditLogService().AddAuditLog("GETTING ALL MEMBER", userId, new UserService().GetUserName(userId), query, DateTime.Now);
               if (dr.HasRows) //if the executed query returns any records
               {
                   while (dr.Read()) //iterate through the records in the result dataset
                   {
                       member = new Staff();

                       member.ID = dr.GetInt32(0);
                       member.UserID = dr.GetString(1);
                       member.FirstName = dr.GetString(2);
                       member.LastName = dr.GetString(3);
                       member.OtherNames = dr.GetString(4);
                       member.Gender = dr.GetString(5);
                       member.DateOfBirth = dr.GetDateTime(6);
                       member.Tel = dr.GetString(7);
                       member.Mobile = dr.GetString(8);
                       member.Email = dr.GetString(9);
                       member.PostalAddress = dr.GetString(10);
                       member.ResAddress = dr.GetString(11);
                       member.Position = dr.GetInt32(12);
                       member.Active = dr.GetInt32(13);
                       member.DateCreated = dr.GetDateTime(14);
                       member.LastModify = dr.GetDateTime(15);
                       member.Role = dr.GetString(16);
                       member.xPosition = dr.GetString(17);
                       member.xFullName = dr.GetString(2) + " " + dr.GetString(3);

                       //memberList.Add(member);
                   }
               }
           }
           catch (MySqlException ex)
           {
              // new AuditLogService().AddAuditLog("ERROR GETTING ALL MEMBER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
               String errorString = ex.Message;
           }
           catch (Exception ex)
           {
              // new AuditLogService().AddAuditLog("ERROR GETTING ALL MEMBER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
               String errorString = ex.Message;
           }
           finally
           {
               dr.Close();
               con.Close();
           }

           return member;
       }
       public Staff GetStaffByUserID(string ID,string userId)
       {
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           MySqlDataReader dr = null;
           MySqlCommand cmd;

           string query = "SELECT `id`, `userid`, `fname`, `sname`, `oname`, `gender`, `dob`, `tel`, `mobile`, `email`, `postaladd`, `resadd`, `position`, `active`, `dateCreated`, `lastModify`,role,jobposition.lValue FROM `staff` INNER JOIN jobposition ON staff.position = jobposition.lKey WHERE userid=@userid";

           Staff member = new Staff();
           //List<Staff> memberList = new List<Staff>();

           try
           {
               con.Open();
               cmd = new MySqlCommand(query, con);
               cmd.Parameters.AddWithValue("@userid", ID);
               dr = cmd.ExecuteReader();
              // new AuditLogService().AddAuditLog("GETTING ALL MEMBER", userId, new UserService().GetUserName(userId), query, DateTime.Now);
               if (dr.HasRows) //if the executed query returns any records
               {
                   while (dr.Read()) //iterate through the records in the result dataset
                   {
                       member = new Staff();

                       member.ID = dr.GetInt32(0);
                       member.UserID = dr.GetString(1);
                       member.FirstName = dr.GetString(2);
                       member.LastName = dr.GetString(3);
                       member.OtherNames = dr.GetString(4);
                       member.Gender = dr.GetString(5);
                       member.DateOfBirth = dr.GetDateTime(6);
                       member.Tel = dr.GetString(7);
                       member.Mobile = dr.GetString(8);
                       member.Email = dr.GetString(9);
                       member.PostalAddress = dr.GetString(10);
                       member.ResAddress = dr.GetString(11);
                       member.Position = dr.GetInt32(12);
                       member.Active = dr.GetInt32(13);
                       member.DateCreated = dr.GetDateTime(14);
                       member.LastModify = dr.GetDateTime(15);
                       member.Role = dr.GetString(16);
                       member.xPosition = dr.GetString(17);
                       member.xFullName = dr.GetString(2) + " " + dr.GetString(3);

                       //memberList.Add(member);
                   }
               }
           }
           catch (MySqlException ex)
           {
              // new AuditLogService().AddAuditLog("ERROR GETTING ALL MEMBER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
               String errorString = ex.Message;
           }
           catch (Exception ex)
           {
              // new AuditLogService().AddAuditLog("ERROR GETTING ALL MEMBER", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
               String errorString = ex.Message;
           }
           finally
           {
               dr.Close();
               con.Close();
           }

           return member;
       }
       public bool UpdateStaff(Staff mem, string userId)
       {
           Boolean retVal = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           MySqlCommand cmd;

           string query = "UPDATE `staff` SET `userid`=@userid,`fname`=@fname,`sname`=@sname,`oname`=@oname,`gender`=@gender,`dob`=@dob,`tel`=@tel,`mobile`=@mobile,`email`=@email,`postaladd`=@postaladd,`resadd`=@resadd,`position`=@position,`lastModify`=@lastModify,role=@role WHERE `id`=@id,";

           try
           {
               con.Open();//opens connection to database

               cmd = new MySqlCommand(query, con);//insert data if connection is open
               cmd.Parameters.AddWithValue("@userid", mem.UserID);
               cmd.Parameters.AddWithValue("@fname", mem.FirstName);
               cmd.Parameters.AddWithValue("@sname", mem.LastName);
               cmd.Parameters.AddWithValue("@oname", mem.OtherNames);
               cmd.Parameters.AddWithValue("@dob", mem.DateOfBirth);
               cmd.Parameters.AddWithValue("@resadd", mem.ResAddress);
               cmd.Parameters.AddWithValue("@tel", mem.Tel);
               cmd.Parameters.AddWithValue("@email", mem.Email);
               cmd.Parameters.AddWithValue("@mobile", mem.Mobile);
               cmd.Parameters.AddWithValue("@gender", mem.Gender);
               cmd.Parameters.AddWithValue("@position", mem.Position);
               cmd.Parameters.AddWithValue("@postaladd", mem.PostalAddress);
               cmd.Parameters.AddWithValue("@id", mem.ID);
               cmd.Parameters.AddWithValue("@lastModified", mem.LastModify);
               cmd.Parameters.AddWithValue("@role",mem.Role);

               int rowsAffec = cmd.ExecuteNonQuery();
               new AuditLogService().AddAuditLog("UPDATING STAFF", userId, new UserService().GetUserName(userId), "Staff with ID:{"+mem.ID+"}'s details was updated", DateTime.Now);
               if (rowsAffec > 0)
               {
                   retVal = true;
               }
           }

           catch (MySqlException ex) //first catch a specific exception
           {
              // new AuditLogService().AddAuditLog("ERROR ADD STAFF", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
               String errorString = ex.Message;
           }
           catch (Exception ex) //also catch any general kind of error, since all Exception classes derive from 'Exception'
           {
               //new AuditLogService().AddAuditLog("ERROR ADD STAFF", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
               String errorString = ex.Message;
           }
           finally
           {
               con.Close();
           }

           return retVal;
       }
       public bool DeactivateStaff(int mem, string userId)
       {
           Boolean retVal = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           MySqlCommand cmd;

           string query = "UPDATE `staff` SET active = 0 WHERE `userid`=@id";

           try
           {
               con.Open();//opens connection to database

               cmd = new MySqlCommand(query, con);//insert data if connection is open
               cmd.Parameters.AddWithValue("@id", mem);
              

               int rowsAffec = cmd.ExecuteNonQuery();
               new AuditLogService().AddAuditLog("DEACTiVATE STAFF", userId, new UserService().GetUserName(userId), "Staff with ID:{" + mem + "}'s details was updated", DateTime.Now);
               if (rowsAffec > 0)
               {
                   retVal = true;
               }
           }

           catch (MySqlException ex) //first catch a specific exception
           {
               // new AuditLogService().AddAuditLog("ERROR ADD STAFF", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
               String errorString = ex.Message;
           }
           catch (Exception ex) //also catch any general kind of error, since all Exception classes derive from 'Exception'
           {
               //new AuditLogService().AddAuditLog("ERROR ADD STAFF", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
               String errorString = ex.Message;
           }
           finally
           {
               con.Close();
           }

           return retVal;
       }
       public bool ActivateStaff(int mem, string userId)
       {
           Boolean retVal = false;
           MySqlConnection con = new MySqlConnection(DbCon.connectionString);
           MySqlCommand cmd;

           string query = "UPDATE `staff` SET active = 1 WHERE `userid`=@id";

           try
           {
               con.Open();//opens connection to database

               cmd = new MySqlCommand(query, con);//insert data if connection is open
               cmd.Parameters.AddWithValue("@id", mem);


               int rowsAffec = cmd.ExecuteNonQuery();
               new AuditLogService().AddAuditLog("ACTiVATE STAFF", userId, new UserService().GetUserName(userId), "Staff with ID:{" + mem + "}'s details was updated", DateTime.Now);
               if (rowsAffec > 0)
               {
                   retVal = true;
               }
           }

           catch (MySqlException ex) //first catch a specific exception
           {
               // new AuditLogService().AddAuditLog("ERROR ADD STAFF", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
               String errorString = ex.Message;
           }
           catch (Exception ex) //also catch any general kind of error, since all Exception classes derive from 'Exception'
           {
               //new AuditLogService().AddAuditLog("ERROR ADD STAFF", userId, new UserService().GetUserName(userId), ex.Message, DateTime.Now);
               String errorString = ex.Message;
           }
           finally
           {
               con.Close();
           }

           return retVal;
       }
   }
}
