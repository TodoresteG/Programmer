namespace Programmer.App.Infrastructure.TagHelpers.Common
{
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System.Collections.Generic;

    public class TagHelperCutPaste
    {
        public const string ItemsStorageKey = "";

        public string CutPasteKey { get; set; }

        public TagHelperContent TagHelperContent { get; set; }

        public List<TagHelperAttribute> Attributes { get; set; }
    }
}
