using System;
using WebAPI01.Domain.Model;

namespace WebAPI01.Domain.Repositories
{
    public interface IFileRepository : IFileTypeRepository<File>, IFileInfoUpdate<File>
    {
    }
}