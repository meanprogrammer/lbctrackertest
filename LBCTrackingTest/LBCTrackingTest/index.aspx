<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LBCTrackingTest.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Index</h1>
        <p>
            <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="5">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>
                        TrackingNo
                    </asp:TableHeaderCell>
                     <asp:TableHeaderCell>
                        Status and Location
                    </asp:TableHeaderCell>
                     <asp:TableHeaderCell>
                        Message
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </p>
    </div>
    </form>
</body>
</html>
