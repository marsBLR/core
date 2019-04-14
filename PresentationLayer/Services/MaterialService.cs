using BuissnesLayer;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.Services
{
    public class MaterialService
    {
        private DataManager _dataManager;
        public MaterialService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public MaterialViewModel MaterialDBModelToView(int materialId)
        {
            var _model = new MaterialViewModel()
            {
                Material = _dataManager.Materials.GetMaterialById(materialId, true)
            };
            var _dir = _dataManager.Derictorys.GetDirectoryById(_model.Material.DirectoryId);
            if (_dir.Materials.IndexOf(_model.Material) != _dir.Materials.Count())
            {
                _model.NextMaterial = _dir.Materials.ElementAt(_dir.Materials.IndexOf(_model.Material) + 1);
            }
            return _model;
        }

    }
}
