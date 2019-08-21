using System;
using System.Web;
using System.Text; 
using System.IO;
using System.Collections;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace AjaxDemo
{
	/// <summary>
	///This class acts as a data source for countries and states data. Following are the list of uses. 
	///		Retuning list of countries present in CountriesAndStates.xml file as ArrayList
	///		Retuning list of states for a given country as ArrayList or XML Document in a string
	/// </summary>
	/// 

	public class CountryStateXml
	{
		private XPathDocument xPathDoc;

		public CountryStateXml()
		{
			try
			{
				//Loads the CountriesAndStates.xml file into XPathDocument
				xPathDoc = new XPathDocument(HttpContext.Current.Server.MapPath("~/xmlxsl/CountriesAndStates.xml"));
			}
			catch(Exception Ex)
			{
				throw(Ex);
			}
		}

		/// <summary>
		/// This function retuns list of states for a given country as XML Document in a string 
		/// and this value is used in client side java script to populate state combo box.
		/// Functionality: Transform the CountriesAndStates xml string into another XML string having the single country 
		/// and states under that country. 
		/// </summary>
		public string GetStatesXMLString(string countryName)
		{
			//Creates a XslTransform object and load the CountriesAndStates.xsl file
			XslTransform transformToCountryNode = new XslTransform();
			transformToCountryNode.Load(new XPathDocument(HttpContext.Current.Server.MapPath("~/xmlxsl/CountriesAndStates.xsl")).CreateNavigator(), new XmlUrlResolver());
			//TransformToCountryNode.Load(new XPathDocument(HttpContext.Current.Server.MapPath("~/xmlxsl/CountriesAndStates.xsl")).CreateNavigator(), new XmlUrlResolver(), this.GetType().Assembly.Evidence);

			//Creating the XSLT parameter country-name and setting the value
			XsltArgumentList xslArgs = new XsltArgumentList();
			xslArgs.AddParam("country-name", "", countryName);
				
			// Memory stream to store the result of XSL transform 
			MemoryStream countryNodeMemoryStream = new MemoryStream(); 
			XmlTextWriter countryNodeXmlTextWriter = new XmlTextWriter(countryNodeMemoryStream, Encoding.UTF8); 
			countryNodeXmlTextWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");

			//transforming the current XML string to get the state XML string
			transformToCountryNode.Transform(xPathDoc, xslArgs,  countryNodeXmlTextWriter);
			//TransformToCountryNode.Transform(XPathDoc, XslArgs,  CountryNodeXmlTextWriter, null);

			//reading the XML string using StreamReader and return the same
			countryNodeXmlTextWriter.Flush(); 
			countryNodeMemoryStream.Position = 0; 
			StreamReader countryNodeStreamReader = new StreamReader(countryNodeMemoryStream); 
			return  countryNodeStreamReader.ReadToEnd(); 
		}

		/// <summary>
		/// This function retuns list of states for a given country ( present in CountriesAndStates.xml file) in an ArrayList 
		/// </summary>
		public ArrayList GetStateList(string CountryName)
		{
			//creating a XPathNodeIterator object for the state nodes under a perticular country with the help of XPath
			XPathNavigator xPathNav = xPathDoc.CreateNavigator();
			XPathNodeIterator xPathNodeIter = xPathNav.Select("/countries/country[@name='" + CountryName + "']");
						
			ArrayList stateArrayList = new ArrayList(); 

			//iterating through the state nodes and creating the state Arraylist
			if(xPathNodeIter.Current.HasChildren && xPathNodeIter.MoveNext())
			{
				xPathNodeIter = xPathNodeIter.Current.SelectChildren("state","");
				while(xPathNodeIter.MoveNext())
				{
					stateArrayList.Add (xPathNodeIter.Current.Value);
				}
			}
			return stateArrayList;
		}

		/// <summary>
		/// This function retuns list of countries ( present in CountriesAndStates.xml file) in an ArrayList 
		/// </summary>
		public ArrayList GetCountryList()
		{
			//creating a XPathNodeIterator object for all the country nodes with the help of XPath
			XPathNavigator xPathNav = xPathDoc.CreateNavigator();
			XPathNodeIterator xPathNodeIter = xPathNav.Select("/countries/country");
		
			ArrayList countryArrayList = new ArrayList(); 

			//iterating through the county nodes and creating the country arraylist
			while(xPathNodeIter.MoveNext())
			{
				countryArrayList.Add(xPathNodeIter.Current.GetAttribute("name",""));
			}
			return countryArrayList;
		}

	}
	
}
