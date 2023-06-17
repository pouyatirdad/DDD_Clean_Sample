using Microsoft.EntityFrameworkCore;
using Project.Application.DTO;
using Project.Application.Queries;
using Project.Infrastructure.Ef.Contexts;
using Project.Infrastructure.Ef.Models;
using Project.Infrastructure.Ef.Queries;
using Project.Shared.Abstraction.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Ef.Queries.Handlers
{
    internal class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDTO>
    {

        private readonly DbSet<PackingListReadModel> _packingLists;

        public GetPackingListHandler(ReadDbContext context)
        {
            _packingLists = context.PackingLists;
        }

        public Task<PackingListDTO> HandleAsync(GetPackingList query)
        {
            return _packingLists.Include(x => x.items).Where(x => x.Id == query.Id)
                .Select(x => x.AsDTO())
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
    }
}
