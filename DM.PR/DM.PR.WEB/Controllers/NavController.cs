﻿using System.Web.Mvc;      
using DM.PR.Common.Entities;   
using System.Collections.Generic;
using DM.PR.WEB.Models;
using DM.PR.Business.Providers;

namespace DM.PR.WEB.Controllers
{
    public class NavController : Controller
    {
        #region Private

        private IDepartmentProvider _departmentProvider;

        #endregion
        
        #region Ctor
        public NavController(IDepartmentProvider departmentProvider)
        {
            _departmentProvider = departmentProvider;
        }

        #endregion

        #region Menu

        public ActionResult Menu()
        {
            var departments = _departmentProvider.GetAll();
            if (departments != null)
            {
                var departsView = MapDepartmentToDepartmentViewModel(departments);
                if (departments != null)
                {
                    return PartialView(departsView);

                }
                else return HttpNotFound(); //Дописать 

            }
            else return HttpNotFound(); //Дописать
            

        }


        #endregion

        #region Helpers

        private IEnumerable<DepartmentNavViewModel> MapDepartmentToDepartmentViewModel(IEnumerable<Department> departments)
        {
            var departmentsViewModel = new List<DepartmentNavViewModel>();
            foreach (var item in departments)
            {
                departmentsViewModel.Add(new DepartmentNavViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    ParentId = item.ParentId
                });
            }
            return departmentsViewModel;
        }

        //private IEnumerable<NavDepartmentViewModel> FindChidrenById(int? id)
        //{
        //    IEnumerable<Department> childrenList = _departmentProvider.GetAll().Where(x => x.ParentId == id);

        //    return childrenList != null ? MapDepartmentToDepartmentViewModel(childrenList) : null;

        //}

        #endregion
    }
}