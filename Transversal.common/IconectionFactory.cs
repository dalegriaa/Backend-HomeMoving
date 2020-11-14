
using System.Data;

namespace Transversal.common
{
    public interface IconectionFactory 
    {
        IDbConnection GetInstance { get; }
    }
}
