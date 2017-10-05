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
      get
      {
        return this._CodeFile;
      }
      set
      {
        this._CodeFile = value;
      }
    }

    [Description("Determines which mode the control displays either as a button or displaying the code")]
    public DisplayStates DisplayState
    {
      get
      {
        return this._DisplayState;
      }
      set
      {
        this._DisplayState = value;
      }
    }

    [Description("Optional location of the CSS file that formats code. WebResource specifies loading from internal resource.")]
    public string CssLocation
    {
      get
      {
        return this._CssLocation;
      }
      set
      {
        this._CssLocation = value;
      }
    }

    [Description("The button text.")]
    [DefaultValue("Show Code")]
    public string Text
    {
      get
      {
        return this._Text;
      }
      set
      {
        this._Text = value;
        if (this.btnShowCode == null)
          return;
        this.btnShowCode.Text = value;
      }
    }

    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);
      this.btnShowCode = new Button();
      this.btnShowCode.Text = this.Text;
      this.btnShowCode.Click += new EventHandler(this.btnShowCode_Click);
      this.Controls.Add(this.btnShowCode);
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      this.btnShowCode.Width = this.Width;
      if (this.Context.Items["StyleAdded"] != null)
        return;
      HtmlLink htmlLink = new HtmlLink();
      htmlLink.Attributes.Add("type", "text/css");
      htmlLink.Attributes.Add("rel", "stylesheet");
      if (string.IsNullOrEmpty(this.CssLocation) || this.CssLocation == "WebResource")
      {
        string webResourceUrl = this.Page.ClientScript.GetWebResourceUrl(typeof (ViewSourceControl), "Manoli.Utils.CSharpFormat.csharp.css");
        htmlLink.Attributes.Add("href", webResourceUrl);
      }
      else
        htmlLink.Attributes.Add("href", this.ResolveUrl(this.CssLocation));
      this.Page.Header.Controls.Add(htmlLink);
      this.Context.Items["StyleAdded"] = "1";
    }

    protected void btnShowCode_Click(object sender, EventArgs e)
    {
      this.DisplayCode();
    }

    protected void DisplayCode()
    {
      string lower = this.Page.Server.MapPath(this.ResolveUrl(this.CodeFile)).ToLower();
      if (!",.cs,.vb,.aspx,.asmx,.js,.ashx,".Contains("," + Path.GetExtension(lower).ToLower() + ","))
      {
        this.Output = "Invalid Filename specified...";
      }
      else
      {
        if (File.Exists(lower))
        {
          StreamReader streamReader = new StreamReader(lower);
          string end = streamReader.ReadToEnd();
          streamReader.Close();
          this.Output = lower.ToLower().EndsWith(".cs") || lower.ToLower().EndsWith(".asmx") || lower.ToLower().EndsWith(".ashx") ? "<div class='showcode'>" + new Manoli.Utils.CSharpFormat.CSharpFormat().FormatCode(end) + "</div>" : (!lower.ToLower().EndsWith(".js") ? "<div class='showcode'>" + new HtmlFormat().FormatCode(end) + "</div>" : "<div class='showcode'>" + new JavaScriptFormat().FormatCode(end) + "</div>");
          this.Page.ClientScript.RegisterStartupScript(typeof (ViewSourceControl), "scroll", "var codeContainer = document.getElementById('" + this.btnShowCode.ClientID + "');codeContainer.focus();setTimeout(function() { window.scrollBy(0,200);},100);", true);
        }
        this.btnShowCode.Visible = true;
      }
    }

    public override void RenderControl(HtmlTextWriter writer)
    {
      base.RenderControl(writer);
      if (string.IsNullOrEmpty(this.Output))
        return;
      writer.Write(this.Output);
    }
  }
}
