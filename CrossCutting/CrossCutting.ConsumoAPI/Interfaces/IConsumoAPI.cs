using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.ConsumoAPI.Interfaces
{
    public interface IConsumoAPI<T>
    {
        Task<T> Get(string url);
    }
}
