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
    public class EFMaterialsRepository : IMaterialsRepository
    {
        private EFDBContext context;

        public EFMaterialsRepository(EFDBContext context)
        {
            this.context = context;
        }

        public void DeleteDirectory(Material material)
        {
            context.Materials.Remove(material);
            context.SaveChanges();

        }

        public IEnumerable<Material> GetAllMaterials(bool includeDirectory = false)
        {
            if (includeDirectory)
                return context.Set<Material>().Include(x => x.Directory).AsNoTracking().ToList();
            else
                return context.Materials.ToList();
        }

        public Material GetMaterialById(int materialId, bool includeDirectory = false)
        {
            if (includeDirectory)
                return context.Set<Material>().Include(x => x.Directory).AsNoTracking().FirstOrDefault(x => x.Id == materialId);
            else
                return context.Materials.FirstOrDefault(x => x.Id == materialId);
        }

        public void SaveDirectory(Material material)
        {
            if (material.Id == 0)
                context.Materials.Add(material);
            else
                context.Entry(material).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
