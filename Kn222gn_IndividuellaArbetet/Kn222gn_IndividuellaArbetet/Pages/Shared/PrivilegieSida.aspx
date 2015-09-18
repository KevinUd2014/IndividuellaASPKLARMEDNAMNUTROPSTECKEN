<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="PrivilegieSida.aspx.cs" Inherits="Kn222gn_IndividuellaArbetet.Pages.Shared.PrivilegieSida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SuccessMesage" runat="server">

            
    <asp:PlaceHolder ID="confirmholder" 
        runat="server" 
        Visible="false">


        <asp:Label ID="confirmText" 
            runat="server" 
            Text="Label"></asp:Label>

        <asp:Button ID="closeButton" 
            runat="server" 
            Text="Close" 
            CausesValidation="false" />
    
    </asp:PlaceHolder>

    
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="Red" />
    <asp:ListView ID="PrivilegieListView" runat="server"
                  ItemType="Kn222gn_IndividuellaArbetet.BLL.Privilegie"
                  SelectMethod="PrivilegieListView_GetData"
                  InsertMethod="PrivilegieListView_InsertItem"
                  UpdateMethod="PrivilegieListView_UpdateItem"
                  DeleteMethod="PrivilegieListView_DeleteItem"
                  InsertItemPosition="FirstItem"
                  DataKeyNames="PrivilegieID">
        <layouttemplate>
            <table class="PrivilegieTableGrid">
                <tr>
                    
                    <th>PrivilegieID</th>
                    <th>PrivilegieTyp</th>
                    <th>BiljettID</th>
                    <th>Åtgärd</th>
                </tr>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </table>
        </layouttemplate>
        <itemtemplate>
            <tr>
                <td><%# Item.PrivilegieID %></td>
                <td><%# Item.PrivilegieTyp %></td>
                <td> <%#: Item.BiljettID %></td>
                <td>
                    <asp:linkbutton ID="Linkbutton2" runat="server" 
                        commandname="Edit" 
                        text="Ändra" 
                        causesvalidation="false" />
                    <asp:linkbutton ID="Linkbutton3" runat="server" 
                        commandname="Delete" 
                        text="Ta Bort" 
                        causesvalidation="false" 
                        onclientclick='<%# String.Format("return confirm(\"Ta bort biljetten med ID {0} ?\")", Item.PrivilegieID) %>' />
                </td>
            </tr>
        </itemtemplate>
        <emptydatatemplate>
            <tr>
                <td>
                    Privilegiet hittades inte!
                </td>
            </tr>
        </emptydatatemplate>
                    <%-- Lägga till data. --%>
                    <InsertItemTemplate>
                        <tr>
                            <td>
                                <%--<asp:TextBox ID="PrivilegieID" runat="server" 
                                    MaxLength="5" 
                                    Text="<%# BindItem.PrivilegieID %>" />
                                <asp:RequiredFieldValidator ID="PrivilegieIDRequiredFieldValidator" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för BiljettID får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="PrivilegieID" />--%>
                            </td>
                            <td>
                                <asp:TextBox ID="PrivilegieTyp" runat="server" 
                                    MaxLength="20" 
                                    Text="<%# BindItem.PrivilegieTyp %>" />
                                <asp:RequiredFieldValidator ID="PrivilegieTypRequiredFieldValidatorG" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för Pris får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="PrivilegieTyp" />
                                <asp:RegularExpressionValidator ID="PrivilegieTypRegularExpressionValidatorG" runat="server" 
                                    ControlToValidate="PrivilegieTyp" 
                                    ValidationExpression="^[a-zA-Z'.\s]{1,50}"
                                    ErrorMessage="Fältet för PrivilegieTyp får inte innehålla siffror!" 
                                    Text="*" />   
                            </td>
                            <td>

                                Välj Biljett ID
                    <asp:DropDownList ID="BiljettIDDropDownList" runat="server"
                                      ItemType="Kn222gn_IndividuellaArbetet.BLL.Biljett"
                                      SelectMethod="BiljettDropDownList_GetData"
                                      DataTextField="BiljettID"
                                      DataValueField="BiljettID"
                                      SelectedValue='<%# BindItem.BiljettID %>' />
<%--                                <asp:TextBox ID="BiljettID" runat="server" 
                                    MaxLength="20" 
                                    Text="<%# BindItem.BiljettID %>" />
                                <asp:RequiredFieldValidator ID="BiljettIDRequiredFieldValidatorQ" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för Antal får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="BiljettID" />    
                                <asp:RegularExpressionValidator ID="BiljettIDRegularExpressionValidatorQ" runat="server" 
                                    ControlToValidate="BiljettID"
                                    ValidationExpression="^[0-9]+$"
                                    ErrorMessage="Fältet för BiljettID måste bara innehålla siffror" 
                                    Text="*" />          --%>                   
                            </td>
                            <td>
                                <asp:linkbutton ID="Linkbutton1" runat="server" 
                                    commandname="Insert" 
                                    text="Lägg till Privilegie" 
                                    causesvalidation="True" />
                            </td>

                        </tr>
                    </InsertItemTemplate>                
        <edititemtemplate>
            
            <tr>
                <td>
                    <%--<asp:TextBox ID="PrivilegieID" runat="server" 
                                    MaxLength="5" 
                                    Text="<%# BindItem.PrivilegieID %>" />
                                <asp:RequiredFieldValidator ID="PrivilegieIDRequiredFieldValidator" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för BiljettID får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="PrivilegieID" />--%>
                            </td>
                            <td>
                                <asp:TextBox ID="PrivilegieTyp" runat="server" 
                                    MaxLength="50" 
                                    Text="<%# BindItem.PrivilegieTyp %>" />
                                <asp:RequiredFieldValidator ID="PrivilegieTypRequiredFieldValidatorL" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för Pris får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="PrivilegieTyp" />
                                <asp:RegularExpressionValidator ID="PrivilegieTypRegularExpressionValidatorL" runat="server" 
                                    ControlToValidate="PrivilegieTyp" 
                                    ValidationExpression="^[a-zA-Z'.\s]{1,50}"
                                    ErrorMessage="Fältet för PrivilegieTyp får inte innehålla siffror!" 
                                    Text="*" />   
                            </td>
                            <td>

                                Välj Biljett ID
                    <asp:DropDownList ID="BiljettIDDropDownList" runat="server"
                                      ItemType="Kn222gn_IndividuellaArbetet.BLL.Biljett"
                                      SelectMethod="BiljettDropDownList_GetData"
                                      DataTextField="BiljettID"
                                      DataValueField="BiljettID"
                                      SelectedValue='<%# BindItem.BiljettID %>' />
                               <%-- <asp:TextBox ID="BiljettID" runat="server" 
                                    MaxLength="20" 
                                    Text="<%# BindItem.BiljettID %>" />
                                <asp:RequiredFieldValidator ID="BiljettIDRequiredFieldValidatorO" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för Antal får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="BiljettID" />   
                                <asp:RegularExpressionValidator ID="BiljettIDRegularExpressionValidatorO" runat="server" 
                                    ControlToValidate="BiljettID"
                                    ValidationExpression="^[0-9]+$"
                                    ErrorMessage="Fältet för BiljettID måste bara innehålla siffror" 
                                    Text="*" />      --%>                      
                            </td>
                                <td>
                                        <asp:linkbutton ID="Linkbutton1" runat="server" 
                                        commandname="Update"
                                        text="Spara"
                                        causesvalidation="true"
                                        validationgroup="editDate" />
                                    <asp:linkbutton ID="Linkbutton4" 
                                        runat="server" 
                                        commandname="Cancel" 
                                        text="Cancel" 
                                        causesvalidation="false" />
                                </td>

            </tr>
        </edititemtemplate>
    </asp:ListView>

</asp:Content>
