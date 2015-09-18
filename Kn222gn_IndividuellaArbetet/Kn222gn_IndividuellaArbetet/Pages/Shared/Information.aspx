<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Information.aspx.cs" Inherits="Kn222gn_IndividuellaArbetet.Pages.Shared.Information" %>
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
    <asp:ListView ID="BiljettListView" runat="server"
                  ItemType="Kn222gn_IndividuellaArbetet.BLL.Biljett"
                  SelectMethod="BiljettListView_GetData"
                  InsertMethod="BiljettListView_InsertItem"
                  UpdateMethod="BiljettListView_UpdateItem"
                  DeleteMethod="BiljettListView_DeleteItem"
                  InsertItemPosition="FirstItem"
                  DataKeyNames="BiljettID">
        <layouttemplate>
            <table class="BiljettTableGrid">
                <tr>
                    <th>BiljettID</th>
                    <th>Pris</th>
                    <th>Antal</th>
                    <th>Rabatt</th>
                    <th>BiljettTyp</th>
                    <th>BesokarID</th>
                    <th>Åtgärd</th>
                </tr>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </table>
        </layouttemplate>
        <itemtemplate>
            <tr>
                <td> <%#: Item.BiljettID %></td>
                <td><%# Item.Pris %></td>
                <td><%# Item.Antal %></td>
                <td><%# Item.Rabatt %></td>
                <td><%# Item.BiljettTyp %></td>
                <td><%# Item.Besokare.Fornamn %></td>
                <td>
                    <asp:linkbutton runat="server" 
                        commandname="Edit" 
                        text="Ändra" 
                        causesvalidation="false" />
                    <asp:linkbutton runat="server" 
                        commandname="Delete" 
                        text="Ta Bort" 
                        causesvalidation="false" 
                        onclientclick='<%# String.Format("return confirm(\"Ta bort biljetten med ID {0} ?\")", Item.BiljettID) %>' />
                </td>
<%--                <td>
                    <asp:LinkButton ID="AddContactLinkButton" runat="server" CommandName="Insert" Text="Add Contact"></asp:LinkButton>
                </td>--%>
            </tr>
        </itemtemplate>
        <emptydatatemplate>
            <tr>
                <td>
                    Biljetten hittades inte!
                </td>
            </tr>
        </emptydatatemplate>

                    <%-- Lägga till data. --%>
                    <InsertItemTemplate>
                        <tr>
                            <td>
                               <%-- <asp:TextBox ID="BiljettID" runat="server" 
                                    MaxLength="5" 
                                    Text="<%# BindItem.BiljettID %>" />
                                <asp:RequiredFieldValidator ID="BiljettIDRequiredFieldValidator" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för BiljettID får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="BiljettID" />--%>
                            </td>
                            <td>
                                <asp:TextBox ID="Pris" runat="server" 
                                    MaxLength="5" 
                                    Text="<%# BindItem.Pris %>" />
                                <asp:RequiredFieldValidator ID="PrisRequiredFieldValidatorT" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för Pris får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="Pris" />
                                <asp:RegularExpressionValidator ID="PrisRegularExpressionValidatorT" runat="server" 
                                    ControlToValidate="Pris"
                                    ValidationExpression="^[0-9]+$"
                                    ErrorMessage="Fältet för Pris måste bara innehålla siffror" 
                                    Text="*" /> 
                            </td>
                            <td>
                                <asp:TextBox ID="Antal" runat="server" 
                                    MaxLength="5" 
                                    Text="<%# BindItem.Antal %>" />
                                <asp:RequiredFieldValidator ID="AntalRequiredFieldValidatorU" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för Antal får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="Antal" /> 
                                <asp:RegularExpressionValidator ID="AntalRegularExpressionValidatorU" runat="server" 
                                    ControlToValidate="Antal"
                                    ValidationExpression="^[0-9]+$"
                                    ErrorMessage="Fältet för Antal måste bara innehålla siffror" 
                                    Text="*" />                            
                            </td>
                                                            <%--(^\d{3,5}\,\d{2}$)|(^\d{3,5}$)--%>
                            <td>
                                <asp:TextBox ID="Rabatt" runat="server" 
                                    MaxLength="4" 
                                    Text="<%# BindItem.Rabatt %>" />
                                <asp:RequiredFieldValidator ID="RabattRequiredFieldValidatorB" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för Rabatt får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="Rabatt" />
                                <%--<asp:RegularExpressionValidator ID="RabattRegularExpressionValidatorB" runat="server" 
                                    ControlToValidate="Rabatt"
                                    ValidationExpression="(^\d{3,5}\,\d{2}$)|(^\d{3,5}$)"
                                    ErrorMessage="Fältet för Rabatt måste bara innehålla siffror" 
                                    Text="*" />     --%>     
                            </td>

                            <td>
                                <asp:TextBox ID="BiljettTyp" runat="server" 
                                    MaxLength="10" 
                                    Text="<%# BindItem.BiljettTyp %>" />
                                <asp:RequiredFieldValidator ID="BiljettTypRequiredFieldValidatorM" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för BiljettTyp får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="BiljettTyp" />
                                <asp:RegularExpressionValidator ID="BiljettTypRegularExpressionValidatorM" runat="server" 
                                    ControlToValidate="BiljettTyp" 
                                    ValidationExpression="^[a-zA-Z'.\s]{1,50}"
                                    ErrorMessage="Fältet för BiljettTyp får inte innehålla siffror!" 
                                    Text="*" />    
                            </td>       
                                                     
                            <td>
                                Välj Besökar ID
                    <asp:DropDownList ID="BesökareDropDownList" runat="server"
                                      ItemType="Kn222gn_IndividuellaArbetet.BLL.Besokare"
                                      SelectMethod="BesokarDropDownList_GetData"
                                      DataTextField="Fornamn"
                                      DataValueField="BesokarID"
                                      SelectedValue='<%# BindItem.BesokarID %>' />

                                                    
                
                      <%--          <asp:TextBox ID="BesokarID" runat="server" 
                                    MaxLength="4" 
                                    Text="<%# BindItem.BesokarID %>" />
                                <asp:RequiredFieldValidator ID="BesokarIDRequiredFieldValidatorJ" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för BesokarID får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="BesokarID" />
                                <asp:RegularExpressionValidator ID="BesokarIDRegularExpressionValidatorJ" runat="server" 
                                    ControlToValidate="BesokarID"
                                    ValidationExpression="^[0-9]+$"
                                    ErrorMessage="Fältet för BesokarID måste bara innehålla siffror" 
                                    Text="*" />     --%>
                            </td>
           <%--                     <asp:RegularExpressionValidator ID="EmailAddressRegularExpressionValidator" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Ogiltig epostadress." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="EmailAddress" 
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />--%>
                            <td>
                                <asp:linkbutton runat="server" 
                                    commandname="Insert" 
                                    text="Lägg till Biljett" 
                                    causesvalidation="True" />
                            </td>

                        </tr>
                    </InsertItemTemplate>                
        <edititemtemplate>
            
            <tr>
                            <td>

                                <%-- Denna är tom då jag ska visa att det finns ett ID men man ska inte kunna ändra detta id! --%>
                            </td>
                            <td>
                                <asp:TextBox ID="Pris" runat="server" 
                                    MaxLength="10" 
                                    Text="<%# BindItem.Pris %>" />
                                <asp:RequiredFieldValidator ID="PrisRequiredFieldValidator12" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för Pris får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="Pris" />
                                <asp:RegularExpressionValidator ID="PrisRegularExpressionValidator12" runat="server" 
                                    ControlToValidate="Pris"
                                    ValidationExpression="^[0-9]+$"
                                    ErrorMessage="Fältet för Pris måste bara innehålla siffror" 
                                    Text="*" /> 
                            </td>
                            <td>
                                <asp:TextBox ID="Antal" runat="server" 
                                    MaxLength="10" 
                                    Text="<%# BindItem.Antal %>" />
                                <asp:RequiredFieldValidator ID="AntalRequiredFieldValidator13" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för Antal får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="Antal" />  
                                <asp:RegularExpressionValidator ID="AntalRegularExpressionValidator13" runat="server" 
                                    ControlToValidate="Antal"
                                    ValidationExpression="^[0-9]+$"
                                    ErrorMessage="Fältet för Antal måste bara innehålla siffror" 
                                    Text="*" />                                 
                            </td>
                                                            
                            <td>
                                <asp:TextBox ID="Rabatt" runat="server" 
                                    MaxLength="10" 
                                    Text="<%# BindItem.Rabatt %>" />
                                <asp:RequiredFieldValidator ID="RabattRequiredFieldValidator14" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för Rabatt får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="Rabatt" />
                            </td>
                                                            
                            <td>
                                <asp:TextBox ID="BiljettTyp" runat="server" 
                                    MaxLength="10" 
                                    Text="<%# BindItem.BiljettTyp %>" />
                                <asp:RequiredFieldValidator ID="BiljettTypRequiredFieldValidator15" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för BiljettTyp får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="BiljettTyp" />
                                <asp:RegularExpressionValidator ID="BiljettTypRegularExpressionValidator15" runat="server" 
                                    ControlToValidate="BiljettTyp" 
                                    ValidationExpression="^[a-zA-Z'.\s]{1,50}"
                                    ErrorMessage="Fältet för BiljettTyp får inte innehålla siffror!" 
                                    Text="*" />    
                            </td>       
                              
                            <td>

                                Välj Besökar ID
                    <asp:DropDownList ID="BesökareDropDownList" runat="server"
                                      ItemType="Kn222gn_IndividuellaArbetet.BLL.Besokare"
                                      SelectMethod="BesokarDropDownList_GetData"
                                      DataTextField="Fornamn"
                                      DataValueField="BesokarID"
                                      SelectedValue='<%# BindItem.BesokarID %>' />
<%--                                <asp:TextBox ID="BesokarID" runat="server" 
                                    MaxLength="5" 
                                    Text="<%# BindItem.BesokarID %>" />
                                <asp:RequiredFieldValidator ID="BesokarIDRequiredFieldValidator16" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för BesokarID får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="BesokarID" />
                                <asp:RegularExpressionValidator ID="BesokarIDRegularExpressionValidator16" runat="server" 
                                    ControlToValidate="BesokarID"
                                    ValidationExpression="^[0-9]+$"
                                    ErrorMessage="Fältet för BesokarID måste bara innehålla siffror" 
                                    Text="*" />   --%>  
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