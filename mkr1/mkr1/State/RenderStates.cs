using mkr1.LightHTML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkr1.State
{
    class VisibleState : IRenderState
    {
        public string GetOuterHTML(LightElementNode element) => element.GenerateFullHTML();
    }

    class HiddenState : IRenderState
    {
        public string GetOuterHTML(LightElementNode element) => "";
    }

    class MinifiedState : IRenderState
    {
        public string GetOuterHTML(LightElementNode element)
        {
            string classAttribute = element.CssClasses.Count > 0
                ? $" class=\"{string.Join(" ", element.CssClasses)}\"" : "";

            return $"<{element.TagName}{classAttribute}/>";
        }
    }
}
