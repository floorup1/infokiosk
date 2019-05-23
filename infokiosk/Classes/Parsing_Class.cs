using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infokiosk.Classes
{
    public class Parsing_Class
    {
        public string Href_link(HtmlDocument htmlDocument, string str)
        {
            return htmlDocument.DocumentNode.SelectSingleNode(str).GetAttributeValue("href", "");
        }

        public string TextParser(HtmlDocument htmlDocument, string str)
        {
            return htmlDocument.DocumentNode.SelectSingleNode(str).InnerText.Trim();
        }

        public string TextParser(HtmlDocument htmlDocument, int i, int j)
        {
            string istr, jstr, str;
            istr = i.ToString();
            jstr = j.ToString();
            str = "//div[@class='content rightPart']/div/table/tr[" + istr + "]/td[" + jstr + "]/div";
            return htmlDocument.DocumentNode.SelectSingleNode(str).InnerText.Trim();
        }
    }
}
