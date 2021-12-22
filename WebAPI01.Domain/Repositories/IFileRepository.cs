using System;
using WebAPI01.Domain.Model;

namespace WebAPI01.Domain.Repositories
{
    public interface IFileRepository : IFileTypeRepository<File>
    {
        public bool Has(Guid id);

        public bool BelongsToUser(Guid userId, Guid fileId);
    }
}