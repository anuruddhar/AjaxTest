<%@ Page language="c#" Inherits="AjaxDemo.AjaxClient" CodeFile="AjaxClient.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AjaxClient</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="js\AjaxVariables.js"></script>
		<script src="js\AjaxScript.js"></script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:DropDownList id="countryList" style="Z-INDEX: 101; LEFT: 20px; POSITION: absolute; TOP: 28px"
				onchange="return CountryListOnChange()" runat="server" Width="174px" Height="28px"></asp:DropDownList>
			<asp:DropDownList id="stateList" style="Z-INDEX: 102; LEFT: 218px; POSITION: absolute; TOP: 28px"
				runat="server" Width="174px"></asp:DropDownList>
		</form>
	</body>
</HTML>
