using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuissnesLayer;
using PresentationLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using static DataLayer.Enums.PageEnums;

namespace asp_net_core.Controllers
{
    public class PageController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _serviceManager;

        public PageController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _serviceManager = new ServicesManager(dataManager);
        }

        public IActionResult Index(int pageId, PageType pageType)
        {
            PageViewModel _pageViewModel;
            switch (pageType)
            {
                case PageType.Directory: _pageViewModel = _serviceManager.Directorys.DirectoryDBToViewModelById(pageId); break;
                case PageType.Material: _pageViewModel = _serviceManager.Materials.MaterialDBModelToView(pageId); break;
                default: _pageViewModel = null; break;
            }
            ViewBag.PageType = pageType;
            return View(_pageViewModel);
        }

        public IActionResult PageEditor(int pageId, PageType pageType)
        {
            PageEditModel _editModel;
            switch(pageType)
            {
                case PageType.Directory: _editModel = _serviceManager.Directorys.GetDirectoryEditModel(pageId); break;
                case PageType.Material: _editModel = _serviceManager.Materials.GetMaterialEditModel(pageId); break;
                default: _editModel = null; break;
            }
            ViewBag.PageType = pageType;
            return View(_editModel);
        }
    }
}