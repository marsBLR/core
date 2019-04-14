﻿using DataLayer.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
    public interface IDirectorysRepository
    {
        IEnumerable<Directory> GetAllDirectories(bool includeMaterials = false);
        Directory GetDirectoryById(int directoryId, bool includeMaterials = false);
        void SaveDirectory(Directory achieve);
        void DeleteDirectory(Directory achieve);
    }
}
