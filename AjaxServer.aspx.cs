using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace AjaxDemo
{
	/// <summary>
	/// Summary description for AjaxServer.
	/// </summary>
	public partial class AjaxServer : System.Web.UI.Page
	{
		//Sends the response back, with XML data.
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack )
			{
				string selectedCountry = Request["SelectedCountry"];
				if(selectedCountry.Length > 0)
				{
					Response.Clear();
					CountryStateXml countryStateXml = new CountryStateXml();

					//For a given country, getting country and states under that country in XML format.
					string statesString = countryStateXml.GetStatesXMLString(selectedCountry);
					Response.Clear();
					Response.ContentType ="text/xml";
					
					Response.Write(statesString);
					//end the response
					Response.End();
				}
				else
				{
					//clears the response written into the buffer and end the response.
					Response.Clear();
					Response.End();
				}

			
			}
			else
			{
				//clears the response written into the buffer and end the response.
				Response.Clear();
				Response.End();
			}

		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
		}
		#endregion
	}
}
