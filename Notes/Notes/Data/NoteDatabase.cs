using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Notes.Models;

namespace Notes.Data
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public NoteDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User_Access>().Wait();
        }

        public Task<List<User_Access>> GetNotesAsync()
        {
            return _database.Table<User_Access>().ToListAsync();
        }

        public Task<User_Access> GetNoteAsync(int id)
        {
            return _database.Table<User_Access>()
                            .Where(i => i.Access_Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(User_Access note)
        {
            if (note.Access_Id != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(User_Access note)
        {
            return _database.DeleteAsync(note);
        }
    }
}