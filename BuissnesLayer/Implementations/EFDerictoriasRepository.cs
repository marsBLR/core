using BuissnesLayer.Interfaces;
using DataLayer;
using DataLayer.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implementations
{
    public class EFDerictoriasRepository : IDerictorysRepository
    {
        private EFDBContext context;
        public EFDerictoriasRepository(EFDBContext context)
        {
            this.context = context;
        }
        public void DeleteDirectory(Directory achieve)
        {
            context.Directories.Remove(achieve);
            context.SaveChanges(); 
        }

        public IEnumerable<Directory> GetAllDirectories(bool includeMaterials = false)
        {
            if (includeMaterials)
                return context.Set<Directory>().Include(x => x.Materials).AsNoTracking().ToList();
            else
                return context.Directories.ToList();
        }

        public Directory GetDirectoryById(int directoryId, bool includeMaterials = false)
        {
            if (includeMaterials)
                return context.Set<Directory>().Include(x => x.Materials).AsNoTracking().FirstOrDefault(x => x.Id == directoryId);
            else
                return context.Directories.FirstOrDefault(x => x.Id == directoryId);
        }

        public void SaveDirectory(Directory achieve)
        {
            if (achieve.Id == 0)
                context.Directories.Add(achieve);
            else
                context.Entry(achieve).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
