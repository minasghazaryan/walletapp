using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletApp.WalletAppServices
{
    public interface IBaseService:IDisposable
    {
        Task SaveChangesAsync();

    }
}
