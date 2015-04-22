<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>

<script runat="server">
  void Login_Click(object sender, EventArgs e)
  {
    if ((UserName.Text == "admin") && 
            (UserPass.Text == "secret"))
      {
          FormsAuthentication.RedirectFromLoginPage 
             (UserName.Text, Persist.Checked);
      }
      else
      {
          Msg.Text = "Invalid name or password. Please try again.";
      }
  }
</script>
<html>
<head id="Head1" runat="server">
  <title>PizzaHut</title>
</head>
<body style="margin-left:45% auto">
  <form id="form1" runat="server">
    <h3>
      Login Page</h3>
    <table>
      <tr>
        <td>
          Name:</td>
        <td>
          <asp:TextBox ID="UserName" runat="server" /></td>
        <td>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
            ControlToValidate="UserName"
            Display="Dynamic" 
            ErrorMessage="Cannot be empty." 
            runat="server" />
        </td>
      </tr>
      <tr>
        <td>
          Password:</td>
        <td>
          <asp:TextBox ID="UserPass" TextMode="Password" 
             runat="server" />
        </td>
        <td>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
            ControlToValidate="UserPass"
            ErrorMessage="Cannot be empty." 
            runat="server" />
        </td>
      </tr>
      <tr>
        <td>
          Remember me?</td>
        <td>
          <asp:CheckBox ID="Persist" runat="server" /></td>
      </tr>
    </table>
    <asp:Button ID="Submit1" OnClick="Login_Click" Text="Log In" 
       runat="server" />
    <p>
      <asp:Label ID="Msg" ForeColor="red" runat="server" />
    </p>
  </form>
</body>
</html>
