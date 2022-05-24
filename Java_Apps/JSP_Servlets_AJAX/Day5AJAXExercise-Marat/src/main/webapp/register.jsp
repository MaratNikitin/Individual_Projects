<%--
JSP/Servlets - Day 5 Individual Home Assignment
CPRG-220 - Open Source Web Applications, OOSD program,
SAIT, April 2022
Author: Marat Nikitin
This is the web application side.
The existing project was upgraded, allowing a user a choice of Canadian Provinces or the US States in a dropdown
	list depending on the selected country with selection values retrieved from a MySQL 'travelexperts' database.
I did not enforce customer registration as insert in the DB as it was not requested in the task.
--%>

<%@ page import="java.sql.*, java.io.*" %>
<%!
   public String createCustomer(String [] customerArray)
		{
			String sql = "INSERT INTO customers ("
				+ "CustomerId, CustFirstName, CustLastName, CustAddress, CustCity, CustProv, CustCountry, CustPostal, " +
					"CustHomePhone, CustBusPhone, CustEmail, AgentID"
			    + ") values (0, "
				+ "'" + customerArray[0] + "'," 
				+ " '" + customerArray[1] + "',"
				+ " '" + customerArray[2] + "',"
				+ " '" + customerArray[3] + "',"
				+ " '" + customerArray[4] + "',"
				+ " '" + customerArray[5] + "',"
				+ " '" + customerArray[6] + "',"
				+ " '" + customerArray[7] + "',"
				+ " '" + customerArray[8] + "',"
				+ " '" + customerArray[9] + "',"
				+ " " + customerArray[10] + ")";


		    try
		    {
				Class.forName("org.mariadb.jdbc.Driver");
				Connection dbConn = DriverManager.getConnection("jdbc:mariadb://localhost:3306/travelexperts", "marat", "marat");

		        Statement stmt = dbConn.createStatement();

		        int rows = stmt.executeUpdate(sql);

		        // Cleanup
		        dbConn.close();  // close the connection
		        
				if (rows == 1)
				{
					return "Your registration was a success. Thank you for joining The Travel Experts.";
				}
				else
				{
					return "Insert was NOT successful";
				}
		    }
		    catch (Exception excp)
		    {
		        excp.printStackTrace();
		    }
			return "";
		}
		
		public void displayForm(String [] customerArray, javax.servlet.jsp.JspWriter out) throws IOException
		{
			out.print("<form name='form1' method='get' action=''>");
			out.print("<table width='600' border='0' align='center' cellpadding='0' cellspacing='5'>");
			out.print("<tr>");
			out.print("<caption>Customer Registration</caption>");
			out.print("</tr>");
			out.print("<tr>");
			out.print("<td colspan='2'><h6>Required fields indicated with a *</h6></td>");
			out.print("</tr>");
			out.print("<tr>");
			out.print("<td width='90'><div align='left'>*First Name:</div>");
			out.print("</td>");
			out.print("<td><div align='left'>");
			out.print("<input name='CustFirstName' type='text' id='CustFirstName' value='" + customerArray[0] + "'></div>"); 
			out.print("</td>");
			out.print("<td width='110'><div align='left'>*Last Name:</div></td>");
			out.print("<td><div align='left'>");
			out.print("<input name='CustLastName' type='text' id='CustLastName' value='" + customerArray[1] + "'></div>");
			out.print("</td>");
			out.print("</tr>");
			out.print("<tr>");
			out.print("<td>&nbsp;</td><td>&nbsp;</td>");
			out.print("</tr>");
			out.print("<tr>");
			out.print("<td><div align='left'>Address:</div></td>");
			out.print("<td colspan='2'><div align='left'>");
			out.print("<input name='CustAddress' type='text' id='CustAddress' value='" + customerArray[2] + "' maxlength='75' size='25'></div>");
			out.print("</td>");
			out.print("</tr>");
			out.print("<tr>");
			out.print("<td><div align='left'>*City:</div></td>");
			out.print("<td><div align='left'>");
			out.print("<input name='CustCity' type='text' id='Custcity' value='" + customerArray[3] + "'></div>");
			out.print("</td>");
			out.print("</tr>");

			out.print("<tr>");

			out.print("<td><div align='left'>*Country:</div></td>");

			out.print("<td><div align='left'>");

// in the line below there is a function triggering:
			out.print("<select name='CustCountry' id='CustCountry' onchange='loadStatesOrProvinces(this.value)'>");

			out.print("<option value=''>Select Your Country Here</option>");
			out.print("<option value='Canada'>Canada</option>");
			out.print("<option value='United States'>United States</option>");
			out.print("</select>");
			out.print("</div>");
			out.print("</td>");

			out.print("<td>");
			out.print("<div align='left' id='label'>*Province/State:</div>");
			out.print("</td>");

			out.print("<td>");
			out.print("<div align='left' id='region'>");
			out.print("<select name='CustProv'  id='CustProv'>");
			out.print("<option value=''>Select Your Country First</option>");

// Commenting out hard-coded options as they are replaced by values from the DB:

//			out.print("<option value='AB'>AB</option>");
//			out.print("<option value='BC'>BC</option>");
//			out.print("<option value='MB'>MB</option>");
//			out.print("<option value='NB'>NB</option>");
//			out.print("<option value='NF'>NF</option>");
//			out.print("<option value='NT'>NT</option>");
//			out.print("<option value='NS'>NS</option>");
//			out.print("<option value='NU'>NU</option>");
//			out.print("<option value='ON'>ON</option>");
//			out.print("<option value='PE'>PE</option>");
//			out.print("<option value='QC'>QC</option>");
//			out.print("<option value='SK'>SK</option>");
//			out.print("<option value='YT'>YT</option>");

			out.print("</select>");

			out.print("</div>");
			out.print("</td>");

			out.print("</tr>");

			out.print("<tr>");
			out.print("<td><div align='left' id='zippostal'>*Postal Code:</div></td>");
			out.print("<td><div align='left'>");
			out.print("<input name='CustPostal' type='text' id='CustPostal' value='" + customerArray[6] + "'></div>");
			out.print("</td>");
			out.print("</tr>");
			out.print("<tr>");
			out.print("<td>&nbsp;</td><td>&nbsp;</td>");
			out.print("</tr>");
			out.print("<tr>");
			out.print("<td><div align='left'>*Home Phone:</div></td>");
			out.print("<td><div align='left'>");
			out.print("<input name='CustHomePhone' type='text' id='CustHomePhone' value='" + customerArray[7] + "'></div>");
			out.print("</td>");
			out.print("<td><div align='left'>Business Phone:</div></td>");
			out.print("<td><div align='left'>");
			out.print("<input name='CustBusPhone' type='text' id='CustBusPhone' value='" + customerArray[8] + "'></div>");
			out.print("</td>");
			out.print("</tr>");
			out.print("<tr>");
			out.print("<td><div align='left'>Email:</div></td>");
			out.print("<td><div align='left'>");
			out.print("<input name='CustEmail' type='text' id='CustEmail' value='" + customerArray[9] + "' size='25'></div>");
			out.print("</td>");
			out.print("</tr>");
			out.print("<tr>");
			out.print("<td>&nbsp;</td><td>&nbsp;</td>");
			out.print("</tr>");
			out.print("<tr>");
			out.print("<td><div align='left'>AgentID:</div></td>");
			out.print("<td><div align='left'>");
			out.print("<input name='AgentID' type='text' id='AgentID' value='" + customerArray[10] + "' size='25'></div>");
			out.print("</td>");
			out.print("</tr>");
			out.print("<tr>");
			out.print("<td>&nbsp;</td><td>&nbsp;</td>");
			out.print("</tr>");
			out.print("</table>");
			out.print("<table width='200' border='0' align='center'>");
			out.print("<tr>");
			out.print("<td width='100'>");
			out.print("<input type='submit'  name='submit' value='Register'>");
			out.print("</td>");
			out.print("<td width='100'>");
			out.print("<div align='left'>");
			out.print("<input name='reset' type='reset' id='reset' value='Reset' />");
			out.print("</div>");
			out.print("</td>");
			out.print("</tr>");
			out.print("</table>");
			out.print("</form>");
					
			out.print("<p><b>Privacy statement:</b> Any information entered in the above fields will be used for the purposes of Travel Experts alone. We will not share your information with anyone</p>");
			out.print("<p>&nbsp;</p>");
			out.print("<p>&nbsp;</p>");			
		}
		
		public String validate(String [] customerData)
		{
			for (int i=0; i<customerData.length; i++)
			{
				if (customerData[i].equals(""))
				{
					switch(i)
					{
						case 0:
							return "**First name must have a value!**";
						
						case 1:
							return "**Last name must have a value!**";
						
						case 2:
							break;						
						
						case 3:
							return "**You must include your city name!**";
							
						case 4:
							return "**You must include your province or state name by selecting your country first!**";
							
						case 5:
							return "**You must include your country name!**";
							
						case 6:
							return "**You must include your postal or zip code!**";
							
						case 7:
							return "**Please provide your home phone number!**";
							
						case 8:
							break;
							
						case 9:

							break;
						
						default:
						return "field must have a value.";
					}
				}
			}
			return "";
		}
%>

<%--
This script below is where all of the magic related to 'Province/State' dropdown list happens:
--%>
<script>

	// This function determines which select options should be displayed in the 'Province/State' dropdown list
		// depending on which country was selected.
	function loadStatesOrProvinces(selectedCountry)
	{
		if (selectedCountry == "Canada")
		{
			loadProvinces(); // if Canada was selected, a choice of Canadian Provinces is offered for selection
		}
		else if (selectedCountry == "United States")
		{
			loadStates(); // if US was selected, a choice of US states is offered for selection
		}
		else // it means that the default instruction, not a country, was selected
		{
			document.getElementById("CustProv").length = 0; // this clears the 'Provinces/States' dropdown list
			displayDefaultSelectInstruction(); // the first line with default instructions is displayed always
		}

	};

	// This function ensures that the uppermost line of the 'Provinces/States' dropdown list always contains the
		// instructions to a user. It is used in data validation by enforcing a conscious choice.
	function displayDefaultSelectInstruction()
	{
		var defaultoption = document.createElement("option"); // empty dropdown list option is created
		defaultoption.setAttribute("value", ""); // empty string is assigned as a value to the option
		// this instruction message is inserted into the default uppermost dropdown list option:
		defaultoption.appendChild(document.createTextNode("Select Your Country First")); // instruction for a is set here
		document.getElementById("CustProv").appendChild(defaultoption); // default option is added to the dropdown list
	}

	// This function fills-up 'Provinces/States' dropdown list with US states select options from the 'travelexperts'
		// database using AJAX.
	function loadStates()
	{
		document.getElementById("CustProv").length = 0; // this clears the 'Provinces/States' dropdown list
		displayDefaultSelectInstruction(); // displaying the uppermost select option with instructions for a user
		var req = new XMLHttpRequest(); // creating an AJAX request
		var provinceStateSelect = document.getElementById("CustProv"); // simplifying addressing the 'Provinces/States' dropdown list
		req.onreadystatechange = function (){
			if (req.readyState == 4 && req.status == 200) { // true if ready and no errors
				var states = JSON.parse(req.responseText); // JSON objects' list is created
				for (i=0; i<states.length; i++) // iterating over each JSON object
				{
					var state = states[i]; // retrieving a JSON object representing a single DB table line
					var newoption = document.createElement("option"); // empty dropdown select option is created
					newoption.setAttribute("value", state.id); // posted value is assigned (id = StateCode)
					newoption.appendChild(document.createTextNode(state.stateName)); // meaningful state name is displayed
					provinceStateSelect.appendChild(newoption); // an option is added to the 'Provinces/States' dropdown list
				}
			}
		}
		req.open("GET", "http://localhost:8080/api/table/states");
		req.send(null); // sending AJAX request, null shows explicitly that request does not have a body
	}; // end of loadStates()

	// This function fills-up 'Provinces/States' dropdown list with Canadian provinces select options from the 'travelexperts'
		// database using AJAX.
	function loadProvinces()
	{
		document.getElementById("CustProv").length = 0; // this clears the 'Provinces/States' dropdown list
		displayDefaultSelectInstruction(); // displaying the uppermost select option with instructions for a user
		var req = new XMLHttpRequest(); // creating an AJAX request
		var provinceStateSelect = document.getElementById("CustProv");

		req.onreadystatechange = function (){
			if (req.readyState == 4 && req.status == 200) { // true if ready and no errors
				var provinces = JSON.parse(req.responseText); // JSON objects' list is created
				for (i=0; i<provinces.length; i++) // working with each JSON object coming from the DB
				{
					var province = provinces[i]; // retrieving a JSON object representing a single DB table line
					var newoption = document.createElement("option"); // empty dropdown select option is created
					newoption.setAttribute("value", province.id); // posted value is assigned (id = ProvinceCode)
					newoption.appendChild(document.createTextNode(province.provinceName)); // meaningful province name is displayed
					provinceStateSelect.appendChild(newoption); // an option is added to the 'Provinces/States' dropdown list
				}
			}
		}
		req.open("GET", "http://localhost:8080/api/table/provinces"); // GET request pulls data from this URL
		req.send(null); // sending AJAX request, null shows explicitly that request does not have a body
	}; // end of loadProvinces()
</script>  <%-- End of dropdown lists magic. --%>

<jsp:include page="header.jsp" />
<body>
<div align="center">

	<div id="banner">
	
	
	</div>


	<div id="menu">
		
		<div align="right">
		
			<a href="index.jsp" onmouseover="mouseOver()" onmouseout="mouseOut()"><img src="images/homebut.gif" name="b1" border="0"></a>
			
			<a href="packages.jsp" onmouseover="mouseOver2()" onmouseout="mouseOut2()"><img src="images/packagebut.gif" name="b2" border="0"></a>

			<a href="register.jsp" onmouseover="mouseOver3()" onmouseout="mouseOut3()"><img src="images/registerbut.gif" name="b3" border="0"></a>
			
			<a href="contact.jsp" onmouseover="mouseOver4()" onmouseout="mouseOut4()"><img src="images/contactbut.gif" name="b4" border="0"></a>
			
			<a href="links.jsp" onmouseover="mouseOver5()" onmouseout="mouseOut5()"><img src="images/linksbut.gif" name="b5" border="0"></a>

		</div>
		
	</div>

	<div id="body">
		
		<%
			if (request.getParameter("submit") != null)
			{
				String [] customer = new String[11];
				customer[0] = (String)request.getParameter("CustFirstName");
				customer[1] = (String)request.getParameter("CustLastName");
				customer[2]= (String)request.getParameter("CustAddress");
				customer[3]= (String)request.getParameter("CustCity");
				customer[4] = (String)request.getParameter("CustProv");
				customer[5] = (String)request.getParameter("CustCountry");
				customer[6] = (String)request.getParameter("CustPostal");
				customer[7] = (String)request.getParameter("CustHomePhone");
				customer[8] = (String)request.getParameter("CustBusPhone");
				customer[9] = (String)request.getParameter("CustEmail");
				customer[10] = (String)request.getParameter("AgentID");
		
				//pass data to validation function
				String message = validate(customer);
				if (message.equals(""))
				{
					//if not valid set error message and redisplay form
					out.print("<h4 style='color:crimson'>" + createCustomer(customer) + "</h4>");
					
					//after writing customer data empty the array so form will be empty
					
						customer[0] = "";
						customer[1] = "";
						customer[2] = "";
						customer[3] = "";
						customer[4] = "";
						customer[5] = "";
						customer[6] = "";
						customer[7] = "";
						customer[8] = "";
						customer[9] = "";
						customer[10] = "";
				
					
					displayForm(customer, out);
				} else
				{
				   out.print("<h4 style='color:crimson'>" + message + "</h4>");
				   displayForm(customer, out);
			    }
			}
			else
			{
				//display form
				String [] customer = {"","","","","","","","","","",""};
				displayForm(customer, out);
			}
			%>
		
	</div>
	

	<div id="footer">
	
		<span>[</span>
		
		<a href="index.jsp">Home</a>
		
		<span>||</span>
		
		<a href="packages.jsp">Packages</a>
		
		<span>||</span>
		
		<a href="register.jsp">Registration</a>
		
		<span>||</span>
		
		<a href="contact.jsp">Contact Us</a>
		
		<span>||</span>
		
		<a href="links.jsp">Links</a>
		
		<span>]</span><br />
		
		<span>Copyright &copy; 2008</span>
		
		<br />
	
	</div>

</div>

</body>
</html>