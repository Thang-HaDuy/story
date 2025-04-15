using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace App.Models.ViewModels
{
    public class Paginated
    {
        public static object RenderObject<T>(IPagedList<T> page)
        {
            return new
            {
                PageNumber = page.PageNumber,
                PageSize = page.PageSize,
                TotalItemCount = page.TotalItemCount,
                PageCount = page.PageCount,
                Data = page.ToList()
            };
        }
    }
}

