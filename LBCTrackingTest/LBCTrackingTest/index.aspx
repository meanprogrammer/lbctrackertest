<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LBCTrackingTest.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js" integrity="sha256-hwg4gsxgFZhOsEEamdOYGBf13FyQuiTwlAQgxVSNgt4=" crossorigin="anonymous"></script>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Index</h1>
         
        <input type="text" id="TrackingTextbox" name="TrackingTextbox" />
        <input type="button" id="AddTrackingButton" name="AddTrackingButton" value="Add" />
        <!--<asp:TextBox ID="TrackingTextbox" ClientIDMode="Static"></asp:TextBox>
        <asp:Button ID="AddTrackingButton" ClientIDMode="Static" Text="Add"/>-->



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

        <table id="result-table" class="table table-bordered">
            <tr><th>Date</th><th>To</th><th>To Address</th><th>Latest Status</th></tr>
        </table>

        <asp:HiddenField ID="trackingNos" ClientIDMode="Static" runat="server" />
    </div>
    </form>
</body>
</html>
<script>
    $(document).ready(function () {
        $('#AddTrackingButton').click(function () {
            $.ajax({
                type: "POST",
                url: "TrackingHandler.ashx?tno=311216816471",
                success: function (data) {
                    console.log(data.DatePosted);
                    console.log(data.To);
                    console.log(data.ToAddress);
                    console.log(data.StatusandLocation);

                    $('#result-table > tr:last').append('<tr>' + '<td>' + data.DatePosted + '</td>' + '<td>' + data.To + '</td>' + '<td>' + data.ToAddress + '</td>' + '<td>' + data.StatusandLocation + '</td></tr>');
                }
            });
        });
    });
</script>