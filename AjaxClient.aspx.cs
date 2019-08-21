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
using System.Text;

namespace AjaxDemo
{

////OM SAI RAM

	/// <summary>
	/// Summary description for AjaxClient.
	/// </summary>
	public partial class AjaxClient : System.Web.UI.Page
	{

		/// <summary>
		/// This function populates data into country and state combo box.
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			CountryStateXml countryStateXml = new CountryStateXml();

			//Getting the list of countries in an ArrayList
			ArrayList countries = countryStateXml.GetCountryList();

			//Populating country combo box
			for(int index = 0; index < countries.Count; index++)
			{
				countryList.Items.Add(countries[index].ToString());
			}
			
			//Getting the list of states for a given in an ArrayList
			ArrayList states = countryStateXml.GetStateList(countries[0].ToString()) ;

			//Populating states combo box
			for(int index = 0; index < states.Count; index++)
			{
				stateList.Items.Add(states[index].ToString());
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
