using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NewsWeb.Core.Entities;
using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "pre-post")]
    public class NewsDetailsTagHelper : TagHelper
    {
        public string Images { get; set; }
        public string Details { get; set; }
        public string PrePost { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder title = new TagBuilder("h1");
            TagBuilder detail = new TagBuilder("p");
            title.InnerHtml.Append(PrePost);
            detail.InnerHtml.Append(Details);


            TagBuilder images = new TagBuilder("img");
            images.Attributes.Add("class", "img-fluid w-100");
            images.Attributes.Add("src" , Images);
            images.Attributes.Add("style", "object-fit: cover;");



            TagBuilder container = new TagBuilder("div");
            container.InnerHtml.AppendHtml(title);
            container.InnerHtml.AppendHtml(detail);
            container.InnerHtml.AppendHtml(images);
            output.PreElement.SetHtmlContent(container);

        }
    }
}
