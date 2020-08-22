<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridviewBinding.aspx.cs" Inherits="LoginSystem.GridviewBinding" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <center>
    <form id="form1" runat="server">
        <div>
            <h1 style="background-color: aqua">Gridview Control Update,Delete&paging </h1>
            
            <asp:GridView ID="GridView4" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="IdProduct" DataSourceID="SqlDataSource3" GridLines="Vertical" PageSize="3">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="IdProduct" HeaderText="IdProduct" InsertVisible="False" ReadOnly="True" SortExpression="IdProduct" />
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ProductDataBaseConnectionString %>" DeleteCommand="DELETE FROM [Product] WHERE [IdProduct] = @original_IdProduct AND (([ProductName] = @original_ProductName) OR ([ProductName] IS NULL AND @original_ProductName IS NULL))" InsertCommand="INSERT INTO [Product] ([ProductName]) VALUES (@ProductName)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Product]" UpdateCommand="UPDATE [Product] SET [ProductName] = @ProductName WHERE [IdProduct] = @original_IdProduct AND (([ProductName] = @original_ProductName) OR ([ProductName] IS NULL AND @original_ProductName IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_IdProduct" Type="Int32" />
                    <asp:Parameter Name="original_ProductName" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="ProductName" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="ProductName" Type="String" />
                    <asp:Parameter Name="original_IdProduct" Type="Int32" />
                    <asp:Parameter Name="original_ProductName" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>

            <br/>
            <br/>
            <br/>
             <h1 style="background-color: aqua"> Creating DataTable Code</h1>
           
            <asp:Button ID="Button1" runat="server" Text="Click to show table" OnClick="Button1_Click"></asp:Button>
            <br/>
            <br/>
            <br/>
            <div style="text-align:center;padding:40px;" >
                <asp:GridView ID="GridView3" runat="server"></asp:GridView>
            </div>
            <br/>
            <br/>
            <br/>
             <h1 style="background-color: aqua">Search data in GridView using dropdownlist control</h1>
            Select Name<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="ProductName" DataValueField="ProductName" AutoPostBack="True"> </asp:DropDownList>
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProductDataBaseConnectionString %>" SelectCommand="SELECT [ProductName] FROM [Product]"></asp:SqlDataSource>
                 <br/>
                 <br/>
                <asp:GridView ID="GridView2" runat="server" CellPadding="4" DataKeyNames="IdProduct" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" Height="196px" Width="348px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="IdProduct" HeaderText="IdProduct" InsertVisible="False" ReadOnly="True" SortExpression="IdProduct" />
                        <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                 </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ProductDataBaseConnectionString %>" SelectCommand="SELECT DISTINCT [IdProduct], [ProductName] FROM [Product] WHERE ([ProductName] = @ProductName)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="ProductName" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                 </asp:SqlDataSource>

            <h1 style="background-color: aqua">Dynamic Gridview Binding without Database with delete button</h1>
            <fieldset style="width: 450px;">
                <legend>Dynamic Gridview Binding without Database with delete functionality
                </legend>
                <table>
                    <tr>
                        <td>enter id
                        </td>
                        <td>
                            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>name
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Contact
                        </td>
                        <td>
                            <asp:TextBox ID="txtContact" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Email
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                        </td>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnResponse" runat="server" Text="GetTime" OnClick="btnResponse_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <asp:GridView ID="GridView1" runat="server" Height="142" Width="433" AutoGenerateDeleteButton="true" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                </asp:GridView>
            </fieldset>
            
                 
            

        </div>

    </form>
    </center>
</body>
</html>
