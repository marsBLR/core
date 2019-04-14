using BuissnesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer
{
    public class DataManager
    {
        private IDirectorysRepository _derictorysRepository;
        private IMaterialsRepository _materialsRepository;

        public DataManager(IDirectorysRepository derictorysRepository, IMaterialsRepository materialsRepository)
        {
            _derictorysRepository = derictorysRepository;
            _materialsRepository = materialsRepository;
        }

        public IDirectorysRepository Derictorys { get { return _derictorysRepository; } }
        public IMaterialsRepository Materials { get { return _materialsRepository; } }
    }
}
