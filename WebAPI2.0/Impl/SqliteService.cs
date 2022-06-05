using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI2._0.DatabaseContext;
using WebAPI2._0.Model;

namespace WebAPI2._0.Impl
{
    public class SqliteService
    {
        private KinderGartenContext KinderGartenContext = new KinderGartenContext();

        public SqliteService(KinderGartenContext kinderGartenContext)
        {
            this.KinderGartenContext = kinderGartenContext;
        }

        public async Task<Child> addChild(Child child)
        {
            EntityEntry<Child> newChild = await KinderGartenContext.Children.AddAsync(child);
            await KinderGartenContext.SaveChangesAsync();
            return newChild.Entity;
        }

        public async Task<Toy> addToy(Toy toy)
        {
            EntityEntry<Toy> newToy = await KinderGartenContext.Toys.AddAsync(toy);
            await KinderGartenContext.SaveChangesAsync();
            return newToy.Entity;
        }

        public async Task<IList<Child>> GetChildren()
        {
            return await KinderGartenContext.Children.ToListAsync();
        }

        public async Task<IList<Toy>> GetToy()
        {
            return await KinderGartenContext.Toys.ToListAsync();
        }

        public async Task RemoveToy(int Id)
        {
            try
            {
                Toy toy = await KinderGartenContext.Toys.FirstAsync(toy1 => toy1.Id == Id);
                KinderGartenContext.Toys.Remove(toy);
                await KinderGartenContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}