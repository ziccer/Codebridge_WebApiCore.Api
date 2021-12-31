using Codebridge_WebApiCore.Data.Context;
using Codebridge_WebApiCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebridge_WebApiCore.Data.Repository
{
    public class DogRepository : IRepository<Dog>
    {
        private readonly CodebridgeContext context;

        public DogRepository(CodebridgeContext context) => this.context = context;
        public async Task<IEnumerable<Dog>> AllAsync()
        {
            return await context.Dogs.ToListAsync();
        }

        public async Task Add(Dog entity)
        {
            context.Dogs.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Dog entity)
        {
            context.Dogs.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Dog> FindById(string name) => await context.Dogs.FirstOrDefaultAsync(x => x.Name == name);

        public async Task Update(Dog entity)
        {
            var inst = context.Dogs.FirstOrDefault(k => k.Name == entity.Name);
            if (inst != null)
            {
                inst.Tail_Length = entity.Tail_Length;
                inst.Weight = entity.Weight;
                inst.Color = entity.Color;
                await context.SaveChangesAsync();
            }
        }
    }
}
