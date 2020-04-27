namespace Programmer.App.ViewModels.Administration
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class ManageAccountsViewModel
    {
        public IEnumerable<SelectListItem> Users { get; set; }
    }
}
