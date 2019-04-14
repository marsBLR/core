using BuissnesLayer;
using DataLayer.Entites;
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
        public MaterialEditModel GetMaterialEditModel(int materialId)
        {
            var _dbModel = _dataManager.Materials.GetMaterialById(materialId);
            var _editMidel = new MaterialEditModel()
            {
                Id = _dbModel.Id,
                DerictoryId = _dbModel.DirectoryId,
                Title = _dbModel.Title,
                Html = _dbModel.Html
            };
            return _editMidel;
        }

        public MaterialViewModel SaveMaterialEditModelToDb(MaterialEditModel editModel)
        {
            Material material;
            if (editModel.Id != 0)
            {
                material = _dataManager.Materials.GetMaterialById(editModel.Id);
            }
            else
            {
                material = new Material();
            }
            material.Title = editModel.Title;
            material.Html = editModel.Html;
            material.DirectoryId = editModel.DerictoryId;
            _dataManager.Materials.SaveMaterial(material);
            return MaterialDBModelToView(material.Id);
        }
    }
}
