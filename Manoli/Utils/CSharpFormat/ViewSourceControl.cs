// Decompiled with JetBrains decompiler
// Type: Manoli.Utils.CSharpFormat.ViewSourceControl
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Manoli.Utils.CSharpFormat
{
  [ToolboxData("<{0}:ViewSourceControl />")]
  public class ViewSourceControl : WebControl
  {
    private string _CodeFile = "";
    private string _CssLocation = "WebResource";
    private string _Text = "Show Code";
    protected Button btnShowCode;
    protected string Output;
    private const string STR_CSHARP_RESOURCE = "Manoli.Utils.CSharpFormat.csharp.css";
    private DisplayStates _DisplayState;

    [Description("The location of the code file using ~/ url syntax.")]
    [DefaultValue("")]
    public string CodeFile
    {
      get => _CodeFile;
        set => _CodeFile = value;
    }

    [Description("Determines which mode the control displays either as a button or displaying the code")]
    public DisplayStates DisplayState
    {
      get => _DisplayState;
        set => _DisplayState = value;
    }

    [Description("Optional location of the CSS file that formats code. WebResource specifies loading from internal resource.")]
    public string CssLocation
    {
      get => _CssLocation;
        set => _CssLocation = value;
    }

    [Description("The button text.")]
    [DefaultValue("Show Code")]
    public string Text
    {
      get => _Text;
        set
      {
        _Text = value;
        if (btnShowCode == null)
          return;
        btnShowCode.Text = value;
      }
    }

    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);
      btnShowCode = new Button();
      btnShowCode.Text = Text;
      btnShowCode.Click += new EventHandler(btnShowCode_Click);
      Controls.Add(btnShowCode);
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      btnShowCode.Width = Width;
      if (Context.Items["StyleAdded"] != null)
        return;
      HtmlLink htmlLink = new HtmlLink();
      htmlLink.Attributes.Add("type", "text/css");
      htmlLink.Attributes.Add("rel", "stylesheet");
      if (string.IsNullOrEmpty(CssLocation) || CssLocation == "WebResource")
      {
        string webResourceUrl = Page.ClientScript.GetWebResourceUrl(typeof (ViewSourceControl), "Manoli.Utils.CSharpFormat.csharp.css");
        htmlLink.Attributes.Add("href", webResourceUrl);
      }
      else
        htmlLink.Attributes.Add("href", ResolveUrl(CssLocation));
      Page.Header.Controls.Add(htmlLink);
      Context.Items["StyleAdded"] = "1";
    }

    protected void btnShowCode_Click(object sender, EventArgs e)
    {
      DisplayCode();
    }

    protected void DisplayCode()
    {
      string lower = Page.Server.MapPath(ResolveUrl(CodeFile)).ToLower();
      if (!",.cs,.vb,.aspx,.asmx,.js,.ashx,".Contains("," + Path.GetExtension(lower).ToLower() + ","))
      {
        Output = "Invalid Filename specified...";
      }
      else
      {
        if (File.Exists(lower))
        {
          StreamReader streamReader = new StreamReader(lower);
          string end = streamReader.ReadToEnd();
          streamReader.Close();
          Output = lower.ToLower().EndsWith(".cs") || lower.ToLower().EndsWith(".asmx") || lower.ToLower().EndsWith(".ashx") ? "<div class='showcode'>" + new CSharpFormat().FormatCode(end) + "</div>" : (!lower.ToLower().EndsWith(".js") ? "<div class='showcode'>" + new HtmlFormat().FormatCode(end) + "</div>" : "<div class='showcode'>" + new JavaScriptFormat().FormatCode(end) + "</div>");
          Page.ClientScript.RegisterStartupScript(typeof (ViewSourceControl), "scroll", "var codeContainer = document.getElementById('" + btnShowCode.ClientID + "');codeContainer.focus();setTimeout(function() { window.scrollBy(0,200);},100);", true);
        }
        btnShowCode.Visible = true;
      }
    }

    public override void RenderControl(HtmlTextWriter writer)
    {
      base.RenderControl(writer);
      if (string.IsNullOrEmpty(Output))
        return;
      writer.Write(Output);
    }
  }
}
