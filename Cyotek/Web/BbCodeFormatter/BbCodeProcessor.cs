// Decompiled with JetBrains decompiler
// Type: Cyotek.Web.BbCodeFormatter.BbCodeProcessor
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using Manoli.Utils.CSharpFormat;
using System.Collections.Generic;

namespace Cyotek.Web.BbCodeFormatter
{
    public class BbCodeProcessor
    {
        private static readonly List<IHtmlFormatter> _formatters = new List<IHtmlFormatter>();

        static BbCodeProcessor()
        {
            _formatters.Add(new RegexFormatter("<(.|\\n)*?>", string.Empty));
            _formatters.Add(new LineBreaksFormatter(new string[7]
            {
          "html",
          "csharp",
          "code",
          "jscript",
          "sql",
          "vb",
          "php"
            }));
            _formatters.Add(new RegexFormatter("\\[b(?:\\s*)\\]((.|\\n)*?)\\[/b(?:\\s*)\\]", "<strong>$1</strong>"));
            _formatters.Add(new RegexFormatter("\\[chart(?:\\s*)\\]((.|\\n)*?)\\[/chart(?:\\s*)\\]", "<iframe src=\"/ShowChart/Charts/$1\"  border=\"0\" class=\"chartFrame\" > </iframe>"));
 
            _formatters.Add(new RegexFormatter("\\[tr(?:\\s*)\\]((.|\\n)*?)\\[/tr(?:\\s*)\\]", "<tr>$1</tr>"));
            _formatters.Add(new RegexFormatter("\\[td(?:\\s*)\\]((.|\\n)*?)\\[/td(?:\\s*)\\]", "<td>$1</td>"));
            _formatters.Add(new RegexFormatter("\\[table(?:\\s*)\\]((.|\\n)*?)\\[/table(?:\\s*)\\]", "<table>$1</table>"));
            _formatters.Add(new RegexFormatter("\\[chart(?:\\s*)\\]((.|\\n)*?)\\[/chart(?:\\s*)\\]", "<iframe src=\"/ShowChart/Charts/$1\" style=\"border:0 none;\" class=\"chartFrame\" > </iframe>")); 

            _formatters.Add(new RegexFormatter("\\[i(?:\\s*)\\]((.|\\n)*?)\\[/i(?:\\s*)\\]", "<em>$1</em>"));
            _formatters.Add(new RegexFormatter("\\[s(?:\\s*)\\]((.|\\n)*?)\\[/s(?:\\s*)\\]", "<strike>$1</strike>"));
            _formatters.Add(new RegexFormatter("\\[u(?:\\s*)\\]((.|\\n)*?)\\[/u(?:\\s*)\\]", "<u>$1</u>"));
            _formatters.Add(new RegexFormatter("\\[left(?:\\s*)\\]((.|\\n)*?)\\[/left(?:\\s*)]", "<div style=\"text-align:left\">$1</div>"));
            _formatters.Add(new RegexFormatter("\\[center(?:\\s*)\\]((.|\\n)*?)\\[/center(?:\\s*)]", "<div style=\"text-align:center\">$1</div>"));
            _formatters.Add(new RegexFormatter("\\[right(?:\\s*)\\]((.|\\n)*?)\\[/right(?:\\s*)]", "<div style=\"text-align:right\">$1</div>"));
            _formatters.Add(new RegexFormatter("\\[rtl(?:\\s*)\\]((.|\\n)*?)\\[/rtl(?:\\s*)]", "<div style=\"text-align:right;direction:rtl\">$1</div>"));
            _formatters.Add(new RegexFormatter("\\[ltr(?:\\s*)\\]((.|\\n)*?)\\[/ltr(?:\\s*)]", "<div style=\"text-align:left;direction:ltr\">$1</div>"));
            _formatters.Add(new RegexFormatter("\\[code(?:\\s*)\\]((.|\\n)*?)\\[/code(?:\\s*)]", "<div class=\"bbc-codetitle\">Code:</div><div class=\"bbc-codecontent\"><pre>$1</pre></div>"));
            _formatters.Add(new RegexFormatter("\\[php(?:\\s*)\\]((.|\\n)*?)\\[/php(?:\\s*)]", "<div class=\"bbc-codetitle\">PHP Code:</div><div class=\"bbc-codecontent\"><pre>$1</pre></div>"));
            List<IHtmlFormatter> formatters1 = _formatters;
            HtmlFormat htmlFormat = new HtmlFormat();
            int num1 = 1;
            htmlFormat.EmbedStyleSheet = num1 != 0;
            string pattern1 = "\\[html(?:\\s*)\\]((.|\\n)*?)\\[/html(?:\\s*)]";
            string replace1 = "<div class=\"bbc-codetitle\">HTML Code:</div><div class=\"bbc-codecontent\">{0}</div>";
            SyntaxFormatter syntaxFormatter1 = new SyntaxFormatter(htmlFormat, pattern1, replace1);
            formatters1.Add(syntaxFormatter1);
            List<IHtmlFormatter> formatters2 = _formatters;
            CSharpFormat csharpFormat = new CSharpFormat();
            int num2 = 1;
            csharpFormat.EmbedStyleSheet = num2 != 0;
            string pattern2 = "\\[csharp(?:\\s*)\\]((.|\\n)*?)\\[/csharp(?:\\s*)]";
            string replace2 = "<div class=\"bbc-codetitle\">C# Code:</div><div class=\"bbc-codecontent\">{0}</div>";
            SyntaxFormatter syntaxFormatter2 = new SyntaxFormatter(csharpFormat, pattern2, replace2);
            formatters2.Add(syntaxFormatter2);
            List<IHtmlFormatter> formatters3 = _formatters;
            JavaScriptFormat javaScriptFormat = new JavaScriptFormat();
            int num3 = 1;
            javaScriptFormat.EmbedStyleSheet = num3 != 0;
            string pattern3 = "\\[jscript(?:\\s*)\\]((.|\\n)*?)\\[/jscript(?:\\s*)]";
            string replace3 = "<div class=\"bbc-codetitle\">JavaScript Code:</div><div class=\"bbc-codecontent\">{0}</div>";
            SyntaxFormatter syntaxFormatter3 = new SyntaxFormatter(javaScriptFormat, pattern3, replace3);
            formatters3.Add(syntaxFormatter3);
            List<IHtmlFormatter> formatters4 = _formatters;
            TsqlFormat tsqlFormat = new TsqlFormat();
            int num4 = 1;
            tsqlFormat.EmbedStyleSheet = num4 != 0;
            string pattern4 = "\\[sql(?:\\s*)\\]((.|\\n)*?)\\[/sql(?:\\s*)]";
            string replace4 = "<div class=\"bbc-codetitle\">SQL Code:</div><div class=\"bbc-codecontent\">{0}</div>";
            SyntaxFormatter syntaxFormatter4 = new SyntaxFormatter(tsqlFormat, pattern4, replace4);
            formatters4.Add(syntaxFormatter4);
            List<IHtmlFormatter> formatters5 = _formatters;
            VisualBasicFormat visualBasicFormat = new VisualBasicFormat();
            int num5 = 1;
            visualBasicFormat.EmbedStyleSheet = num5 != 0;
            string pattern5 = "\\[vb(?:\\s*)\\]((.|\\n)*?)\\[/vb(?:\\s*)]";
            string replace5 = "<div class=\"bbc-codetitle\">Visual Basic Code:</div><div class=\"bbc-codecontent\">{0}</div>";
            SyntaxFormatter syntaxFormatter5 = new SyntaxFormatter(visualBasicFormat, pattern5, replace5);
            formatters5.Add(syntaxFormatter5);
            _formatters.Add(new RegexFormatter("\\[quote=((.|\\n)*?)(?:\\s*)\\]", "<div class=\"bbc-quotetitle\">$1 said:</div><div class=\"bbc-quotecontent\"><p>"));
            _formatters.Add(new RegexFormatter("\\[quote(?:\\s*)\\]", "<div class=\"bbc-quotecontent\"><p>"));
            _formatters.Add(new RegexFormatter("\\[/quote(?:\\s*)\\]", "</p></div>"));

            _formatters.Add(new RegexFormatter("\\[url(?:\\s*)\\]www\\.(.*?)\\[/url(?:\\s*)\\]", "<a href=\"http://www.$1\" target=\"_blank\" title=\"$1\">$1</a>"));

            _formatters.Add(new RegexFormatter("\\[url(?:\\s*)\\]((.|\\n)*?)\\[/url(?:\\s*)\\]", "<a href=\"$1\" target=\"_blank\" title=\"$1\">$1</a>"));
            _formatters.Add(new RegexFormatter("\\[url=\"((.|\\n)*?)(?:\\s*)\"\\]((.|\\n)*?)\\[/url(?:\\s*)\\]", "<a href=\"$1\" target=\"_blank\" title=\"$1\">$3</a>"));
            _formatters.Add(new RegexFormatter("\\[url=((.|\\n)*?)(?:\\s*)\\]((.|\\n)*?)\\[/url(?:\\s*)\\]", "<a href=\"$1\" target=\"_blank\" title=\"$1\">$3</a>"));
            _formatters.Add(new RegexFormatter("\\[link(?:\\s*)\\]((.|\\n)*?)\\[/link(?:\\s*)\\]", "<a href=\"$1\" target=\"_blank\" title=\"$1\">$1</a>"));
            _formatters.Add(new RegexFormatter("\\[link=((.|\\n)*?)(?:\\s*)\\]((.|\\n)*?)\\[/link(?:\\s*)\\]", "<a href=\"$1\" target=\"_blank\" title=\"$1\">$3</a>"));
            _formatters.Add(new RegexFormatter("\\[img(?:\\s*)\\]((.|\\n)*?)\\[/img(?:\\s*)\\]", "<img src=\"$1\" border=\"0\" alt=\"\" />"));
            _formatters.Add(new RegexFormatter("\\[img align=((.|\\n)*?)(?:\\s*)\\]((.|\\n)*?)\\[/img(?:\\s*)\\]", "<img src=\"$3\" border=\"0\" align=\"$1\" alt=\"\" />"));
            _formatters.Add(new RegexFormatter("\\[img width=((.|\\n)*?),height=((.|\\n)*?)(?:\\s*)\\]((.|\\n)*?)\\[/img(?:\\s*)\\]", "<img width=\"$1\" height=\"$3\" src=\"$5\" border=\"0\" alt=\"\" />"));
            _formatters.Add(new RegexFormatter("\\[img=((.|\\n)*?)x((.|\\n)*?)(?:\\s*)\\]((.|\\n)*?)\\[/img(?:\\s*)\\]", "<img width=\"$1\" height=\"$3\" src=\"$5\" border=\"0\" alt=\"\" />"));
            _formatters.Add(new RegexFormatter("\\[color=((.|\\n)*?)(?:\\s*)\\]((.|\\n)*?)\\[/color(?:\\s*)\\]", "<span style=\"color:$1;\">$3</span>"));
            _formatters.Add(new RegexFormatter("\\[highlight(?:\\s*)\\]((.|\\n)*?)\\[/highlight(?:\\s*)]", "<span class=\"bbc-highlight\">$1</span>"));
            _formatters.Add(new RegexFormatter("\\[spoiler(?:\\s*)\\]((.|\\n)*?)\\[/spoiler(?:\\s*)]", "<span class=\"bbc-spoiler\">$1</span>"));
            _formatters.Add(new RegexFormatter("\\[indent(?:\\s*)\\]((.|\\n)*?)\\[/indent(?:\\s*)]", "<div class=\"bbc-indent\">$1</div>"));
            _formatters.Add(new RegexFormatter("\\[hr(?:\\s*)\\]", "<hr />"));
            _formatters.Add(new RegexFormatter("\\[rule=((.|\\n)*?)(?:\\s*)\\]((.|\\n)*?)\\[/rule(?:\\s*)\\]", "<div style=\"height: 0pt; border-top: 1px solid $3; margin: auto; width: $1;\"></div>"));
            _formatters.Add(new RegexFormatter("\\[email(?:\\s*)\\]((.|\\n)*?)\\[/email(?:\\s*)\\]", "<a href=\"mailto:$1\">$1</a>"));
            _formatters.Add(new RegexFormatter("\\[email=\"((.|\\n)*?)(?:\\s*)\"\\]((.|\\n)*?)\\[/email(?:\\s*)\\]", "<a href=\"mailto:$1\" title=\"$3\">$3</a>"));
            _formatters.Add(new RegexFormatter("\\[email=((.|\\n)*?)(?:\\s*)\\]((.|\\n)*?)\\[/email(?:\\s*)\\]", "<a href=\"mailto:$1\" title=\"$3\">$3</a>"));
            _formatters.Add(new RegexFormatter("\\[small(?:\\s*)\\]((.|\\n)*?)\\[/small(?:\\s*)]", "<small>$1</small>"));
            _formatters.Add(new RegexFormatter("\\[size=+((.|\\n)*?)(?:\\s*)\\]((.|\\n)*?)\\[/size(?:\\s*)\\]", "<span style=\"font-size:$1em\">$3</span>"));
            _formatters.Add(new RegexFormatter("\\[size=((.|\\n)*?)(?:\\s*)\\]((.|\\n)*?)\\[/size(?:\\s*)\\]", "<span style=\"font-size:$1\">$3</span>"));
            _formatters.Add(new RegexFormatter("\\[font=((.|\\n)*?)(?:\\s*)\\]((.|\\n)*?)\\[/font(?:\\s*)\\]", "<span style=\"font-family:$1;\">$3</span>"));
            _formatters.Add(new RegexFormatter("\\[align=((.|\\n)*?)(?:\\s*)\\]((.|\\n)*?)\\[/align(?:\\s*)\\]", "<span style=\"text-align:$1;\">$3</span>"));
            _formatters.Add(new RegexFormatter("\\[float=((.|\\n)*?)(?:\\s*)\\]((.|\\n)*?)\\[/float(?:\\s*)\\]", "<span style=\"float:$1;\">$3</div>"));
            string format = "<ol class=\"bbc-list\" style=\"list-style:{0};\">$1</ol>";
            _formatters.Add(new RegexFormatter("\\[\\*(?:\\s*)]\\s*([^\\[]*)", "<li>$1</li>"));
            _formatters.Add(new RegexFormatter("\\[list(?:\\s*)\\]((.|\\n)*?)\\[/list(?:\\s*)\\]", "<ul class=\"bbc-list\">$1</ul>"));
            _formatters.Add(new RegexFormatter("\\[list=1(?:\\s*)\\]((.|\\n)*?)\\[/list(?:\\s*)\\]", string.Format(format, "decimal"), false));
            _formatters.Add(new RegexFormatter("\\[list=i(?:\\s*)\\]((.|\\n)*?)\\[/list(?:\\s*)\\]", string.Format(format, "lower-roman"), false));
            _formatters.Add(new RegexFormatter("\\[list=I(?:\\s*)\\]((.|\\n)*?)\\[/list(?:\\s*)\\]", string.Format(format, "upper-roman"), false));
            _formatters.Add(new RegexFormatter("\\[list=a(?:\\s*)\\]((.|\\n)*?)\\[/list(?:\\s*)\\]", string.Format(format, "lower-alpha"), false));
            _formatters.Add(new RegexFormatter("\\[list=A(?:\\s*)\\]((.|\\n)*?)\\[/list(?:\\s*)\\]", string.Format(format, "upper-alpha"), false));
        }

        public static string Format(string data)
        {
            foreach (IHtmlFormatter formatter in _formatters)
                data = formatter.Format(data);
            return "<p>" + data + "</p>";
        }
    }
}
