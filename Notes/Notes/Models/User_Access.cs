using System;
using SQLite;

namespace Notes.Models
{
    public class User_Access
    {
        [PrimaryKey, AutoIncrement]
        public int Access_Id { get; set; }
        public string User_Name { get; set; }
        public string Role { get; set; }
        public int Active { get; set; }
        public string User_unid { get; set; }
        public string Comments { get; set; }

    }
}
