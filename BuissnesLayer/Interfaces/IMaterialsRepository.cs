﻿using DataLayer.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
    public interface IMaterialsRepository
    {
        IEnumerable<Material> GetAllMaterials(bool includeDirectory = false);
        Material GetMaterialById(int materialId, bool includeDirectory = false);
        void SaveDirectory(Material material);
        void DeleteDirectory(Material material);
    }
}
