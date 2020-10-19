using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HangmanDataLayer
{
    public interface IRepo <T>
    {
        Task<T> ReadAsync(int id);
        Task WriteAsync(T value);
        Task ModifyAsync(T value);
        Task DeleteAsync(int id);
    }
}
