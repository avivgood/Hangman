using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using HangmanAPI.WordsMatching;
using HangmanAPI.Wrappers;
using HangmanDataLayer.Exceptions;

namespace HangmanDataLayer
{
    public class GameRepo : IRepo<GameWrapperClass>
    {
        private const int triesno = 10;
        public async Task<GameWrapperClass> ReadAsync(int id)
        {
            string sql = "SELECT * FROM Game WHERE gid = @Id";

            using (var conn = new SqlConnection())
            {
                var game = (await conn.QueryAsync<GameWrapperClass>(sql, new {Id = id})).FirstOrDefault();
                if(game is null)
                    throw new PKDosentExistException();
                return game;
            }
        }

        public async Task WriteAsync(GameWrapperClass value)
        {
            string sql = "INSERT INTO Game VALUES (@gid, @word, @MaxTries, @HasStarted, @HasEnded);";

            using (var conn = new SqlConnection())
            {
                var row_affected = (await conn.ExecuteAsync(sql,
                    new {gid = value.gid, word = value.word, MaxTries = value.MaxTries, HasStarted = value.HasStarted, HasEnded = value.HasEnded}));
                if (row_affected == 0)
                    throw new Exception("could not add game to the system");
            }
        }

        public async Task ModifyAsync( GameWrapperClass value)
        {
            string sql = "UPDATE Game SET word = @word, MaxTries = @MaxTries, HasStarted = @HasStarted, HasEnded = @HasEnded WHERE gid = @gid";

            using (var conn = new SqlConnection())
            {
                var row_affected = (await conn.ExecuteAsync(sql,
                    new { gid = value.gid, word = value.word, MaxTries = value.MaxTries, HasStarted = value.HasStarted, HasEnded = value.HasEnded }));
                if (row_affected == 0)
                    throw new Exception("Game could bot be found; update could not be preformed");
            }
        }

        public async Task DeleteAsync(int id)
        {
            string sql = "DELETE FROM Game WHERE gid = @gid";

            using (var conn = new SqlConnection())
            {
                var row_affected = (await conn.ExecuteAsync(sql,
                    new { gid = id }));
                if (row_affected == 0)
                    throw new Exception("Game could bot be found; delete could not be preformed");
            }
        }
        public async Task AddPlayerAsync(GameWrapperClass gameWrapper, int pid)
        {
            string sql = "INSERT INTO Participation VALUES (@gid, @pid, @emptystr);";

            using (var conn = new SqlConnection())
            {
                var row_affected = (await conn.ExecuteAsync(sql,
                    new { gid = gameWrapper.gid, pid = pid, emptystr = new WordTemplate(gameWrapper.word).ToString()}));
                if (row_affected == 0)
                    throw new Exception("could not add player to game");
            }
        }

        public async Task<IEnumerable<PlayerWrapperClass>> GetCurrentPlayersAsync(int gid)
        {
            string sql = "SELECT pid, pname, win_amt " +
                         "FROM Participation NATURAL JOIN Player " +
                         "WHERE gid = @Id";
            using (var conn = new SqlConnection())
            {
                var game = (await conn.QueryAsync<PlayerWrapperClass>(sql, new { Id = gid }));
                if (game is null)
                    throw new PKDosentExistException();
                return game;
            }
        }


    }
}
