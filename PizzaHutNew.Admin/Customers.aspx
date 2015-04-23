<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="PizzaHutNew.Admin.Customers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div class="content-wrapper main-content clear-fix">
        <h2>Customers</h2>
        <asp:EntityDataSource ID="CustomersEntityDataSource1" runat="server" ConnectionString="name=PizzaHutDbEntities" DefaultContainerName="PizzaHutDbEntities"
            EnableDelete="True" EnableFlattening="False" EnableUpdate="True" EntitySetName="customers">
        </asp:EntityDataSource>
        <asp:GridView ID="CustomersGridView1" runat="server" DataSourceID="CustomersEntityDataSource1" AutoGenerateColumns="False" DataKeyNames="id" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <Columns>
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ShowSelectButton="True"></asp:CommandField>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"></asp:BoundField>
                <asp:BoundField DataField="name" HeaderText="Customer's name" SortExpression="name"></asp:BoundField>
                <asp:BoundField DataField="phone" HeaderText="Customer's phone" SortExpression="phone"></asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"></HeaderStyle>

            <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

            <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

            <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

            <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

            <SortedDescendingHeaderStyle BackColor="#242121"></SortedDescendingHeaderStyle>
        </asp:GridView>


        <h2>Orders of current customer</h2>

        <asp:EntityDataSource ID="OrdersEntityDataSource1" runat="server" ConnectionString="name=PizzaHutDbEntities" 
            DefaultContainerName="PizzaHutDbEntities" EnableFlattening="False" EntitySetName="orders" Where="it.[customerId]=@id">
            <WhereParameters>
                <asp:ControlParameter ControlID="CustomersGridView1"
                    Name="id" PropertyName="SelectedValue"
                    Type="Int32" />
            </WhereParameters>
        </asp:EntityDataSource>

        <asp:GridView ID="GridView1" runat="server" DataSourceID="OrdersEntityDataSource1" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Order id" ReadOnly="True" SortExpression="id"></asp:BoundField>
                <asp:CheckBoxField DataField="processing" HeaderText="Order completed" SortExpression="processing"></asp:CheckBoxField>
                <asp:BoundField DataField="fullprice" HeaderText="Order price" SortExpression="fullprice"></asp:BoundField>
                <asp:BoundField DataField="deliveryAddress" HeaderText="Delivery address" SortExpression="deliveryAddress"></asp:BoundField>
                <asp:BoundField DataField="orderTime" HeaderText="Order time" SortExpression="orderTime"></asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"></HeaderStyle>

            <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

            <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

            <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

            <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

            <SortedDescendingHeaderStyle BackColor="#242121"></SortedDescendingHeaderStyle>
        </asp:GridView>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
