using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HangmanDataLayer
{
    public interface IUniqueIdGen
    {
        Task<int> GetUniqueIdAsync(int length);
    }
}
