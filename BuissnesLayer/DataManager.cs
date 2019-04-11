using BuissnesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer
{
    public class DataManager
    {
        private IDerictorysRepository _derictorysRepository;
        private IMaterialsRepository _materialsRepository;

        public DataManager(IDerictorysRepository derictorysRepository, IMaterialsRepository materialsRepository)
        {
            _derictorysRepository = derictorysRepository;
            _materialsRepository = materialsRepository;
        }

        public IDerictorysRepository Derictorys { get { return _derictorysRepository; } }
        public IMaterialsRepository Materials { get { return _materialsRepository; } }
    }
}
