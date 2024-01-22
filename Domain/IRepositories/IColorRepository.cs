using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IColorRepository : IRepository<Color>
    {
        Task<Color> GetByIdAsync(int id, params string[] includes);
    }
}
