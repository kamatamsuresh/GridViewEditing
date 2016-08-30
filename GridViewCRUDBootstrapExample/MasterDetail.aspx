<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="MasterDetail.aspx.cs" Inherits="GridViewCRUDBootstrapExample.MasterDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master Details Grid</title>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "images/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "images/plus.png");
            $(this).closest("tr").next().remove();
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="false" CssClass="Grid"
                DataKeyNames="CustomerID" OnRowDataBound="OnRowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <img alt="" style="cursor: pointer" src="images/plus.png" />
                            <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="false" CssClass="ChildGrid">
                                    <Columns>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="OrderId" HeaderText="Order Id" />
                                        <asp:BoundField ItemStyle-Width="150px" DataField="OrderDate" HeaderText="Date" />
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="ContactName" HeaderText="Contact Name" />
                    <asp:BoundField ItemStyle-Width="150px" DataField="City" HeaderText="City" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
