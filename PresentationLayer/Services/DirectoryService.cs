using BuissnesLayer;
using DataLayer.Entites;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Services
{
    public class DirectoryService
    {
        private DataManager _dataManeger;
        private MaterialService _materialService;
        public DirectoryService(DataManager dataManeger)
        {
            _dataManeger = dataManeger;
            _materialService = new MaterialService(dataManeger);
        }
        public List<DirectoryViewModel> GetDirectoryesList()
        {
            var _dirs = _dataManeger.Derictorys.GetAllDirectories();
            List<DirectoryViewModel> _modelList = new List<DirectoryViewModel>();
            foreach (var item in _dirs)
            {
                _modelList.Add(DirectoryDBToViewModelById(item.Id));
            }
            return _modelList; 
        }

        public DirectoryViewModel DirectoryDBToViewModelById(int directoryId)
        {
            var _directory = _dataManeger.Derictorys.GetDirectoryById(directoryId, true);
            List<MaterialViewModel> _materialsViewModelList = new List<MaterialViewModel>();
            foreach(var item in _directory.Materials)
            {
                _materialsViewModelList.Add(_materialService.MaterialDBModelToView(item.Id));
            }
            return new DirectoryViewModel() { Directory = _directory, Materials = _materialsViewModelList };
        }

        public DirectoryEditModel GetDirectoryEditModel(int directoryId = 0)
        {
            if (directoryId != 0)
            {
                var _dirDB = _dataManeger.Derictorys.GetDirectoryById(directoryId);
                var _dirEditModel = new DirectoryEditModel() { Id = _dirDB.Id, Title = _dirDB.Title, Html = _dirDB.Html };
                return _dirEditModel;
            }
            else
            {
                return new DirectoryEditModel() { };
            }
        }

        public DirectoryViewModel SaveDirectoryEditModelToDB(DirectoryEditModel directoryEditModel)
        {
            Directory _directoryDBModel; 
            if(directoryEditModel.Id != 0)
            {
                _directoryDBModel = _dataManeger.Derictorys.GetDirectoryById(directoryEditModel.Id);
               
            }
            else
            {
                _directoryDBModel = new Directory();
            }
            _directoryDBModel.Title = directoryEditModel.Title;
            _directoryDBModel.Html = directoryEditModel.Html;
            _dataManeger.Derictorys.SaveDirectory(_directoryDBModel);

            return DirectoryDBToViewModelById(_directoryDBModel.Id);   
        }
    }
}
