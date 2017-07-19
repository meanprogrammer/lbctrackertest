<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LBCTrackingTest.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js" integrity="sha256-hwg4gsxgFZhOsEEamdOYGBf13FyQuiTwlAQgxVSNgt4=" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Index</h1>
        <asp:TextBox ID="TrackingTextbox" ClientIDMode="Static" ></asp:TextBox>
        <asp:Button ID="AddTrackingButton" ClientIDMode="Static" Text="Add"/>



        <!--
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
        </p>-->
        <asp:HiddenField ID="trackingNos" ClientIDMode="Static" runat="server" />
    </div>
    </form>
</body>
</html>
<script>
    $(document).ready(function () {
        $('#TrackingTextbox').click(function () {
            $.ajax({
                type: "GET",
                url: "TrackingHandler.ashx",
                success: function (data) {
                    console.log(data);
                },
                dataType: 'jsonp',
            });
        });
    });
</script>