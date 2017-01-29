<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Requests.aspx.cs" Inherits="PushR.Requests" MasterPageFile="~/Masters/Default.Master" %>


<asp:Content runat="server" ContentPlaceHolderID="contentBody">
    <h3>Requests</h3>
    <div>
        <table id="quotes" class="table table-condensed">
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Amount</th>
                    <th>Originator</th>
                    <th>Team </th>
                    <th>Data</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="6">No data to display</td>
                </tr>
            </tbody>
            <tfoot>
	            <tr>
	                <td colspan="6"><%=FooterText%></td>
	            </tr>
		    </tfoot>
        </table>
    </div>
    <script src="/Scripts/requests.js" ></script>
</asp:Content>