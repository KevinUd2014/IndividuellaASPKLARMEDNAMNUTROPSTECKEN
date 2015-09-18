<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Kn222gn_IndividuellaArbetet.Pages.Shared.BesokareSida" %>
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
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="Red"/>

                <asp:ListView ID="BesokarListView" runat="server"
                                    ItemType="Kn222gn_IndividuellaArbetet.BLL.Besokare"
                                    SelectMethod="BesokarListView_GetData"
                                    InsertMethod="BesokarListView_InsertItem"
                                    UpdateMethod="BesokarListView_UpdateItem"
                                    InsertItemPosition="FirstItem"
                                    DataKeyNames="BesokarId">

                    <LayoutTemplate>

                        <%--                                    
                                    InsertItemPosition="FirstItem"
                                    OnPagePropertiesChanging="BesokarListView_PagePropertiesChanging"
                                    InsertMethod="BesokarListView_InsertItem"
                                    UpdateMethod="BesokarListView_UpdateItem"
                                    DeleteMethod="BesokarListView_DeleteItem"--%>
                        <table>
                            <thead>
                                <tr>
                                    <th>BesöksID</th>
                                    <th>Förnamn</th>
                                    <th>Efternamn</th>
                                    <th>Telefon</th>
                                    <th>Köp</th>
                                    <th>Bokning</th>
                                    <th>Bokning Upphör</th>
                                    <th>Åtgärd</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                            </tbody>
                        </table>
                    </LayoutTemplate>

                    <%-- Presentera data. --%>
                    <ItemTemplate>

                        <tr>
                            <td><%# Item.BesokarID %></td>
                            <td><%# Item.Fornamn %></td>
                            <td><%# Item.Efternamn %></td>
                            <td><%# Item.TelefonNR %></td>
                            <td><%# Item.Kop %></td>
                            <td><%# Item.Bokning %></td>
                            <td><%# Item.BokningUpphor %></td>
       
                        </tr>

                    </ItemTemplate>

                    <EmptyDataTemplate>
                        <p>Uppgifter saknas.</p>
                    </EmptyDataTemplate>

                    <InsertItemTemplate>
                        <tr>
                            <td>
                                <%--<asp:TextBox ID="BesokarID" runat="server" 
                                    MaxLength="5" 
                                    Text="<%# BindItem.BesokarID %>" />
                                <asp:RequiredFieldValidator ID="BiljettIDRequiredFieldValidator" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för efternamn får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="BesokarID" />--%>
                            </td>
                            <td>
                                <asp:TextBox ID="Fornamn" runat="server" 
                                    MaxLength="15" 
                                    Text="<%# BindItem.Fornamn %>" />
                                <asp:RequiredFieldValidator ID="FornamnRequiredFieldValidatorY" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för Förnamn får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="Fornamn" />
                                <asp:CompareValidator ID="FornamnCompareValidatorY" 
                                    runat="server" 
                                    ErrorMessage="Välj ett oredentligt Förnamn!" 
                                    ControlToValidate="Fornamn" 
                                    Text="*"
                                    Display="Dynamic" 
                                    Operator="DataTypeCheck"></asp:CompareValidator>
                                <asp:RegularExpressionValidator ID="regNamn" runat="server" 
                                    ControlToValidate="Fornamn" 
                                    ValidationExpression="^[a-zA-Z'.\s]{1,50}"
                                    ErrorMessage="Fältet för Förnamn får inte innehålla siffror!" 
                                    Text="*" /> 
                            </td>
                            <td>
                                <asp:TextBox ID="Efternamn" runat="server" 
                                    MaxLength="15" 
                                    Text="<%# BindItem.Efternamn %>" />
                                <asp:RequiredFieldValidator ID="EfternamnRequiredFieldValidatorR" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för Efternamn får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="Efternamn" />  
                                <asp:RegularExpressionValidator ID="EfternamnRegularExpressionValidatorR" runat="server" 
                                    ControlToValidate="Efternamn" 
                                    ValidationExpression="^[a-zA-Z'.\s]{1,50}"
                                    ErrorMessage="Fältet för Efternamn får inte innehålla siffror!" 
                                    Text="*" />                           
                            </td>
                                                            
                            <td>
                                <asp:TextBox ID="TelefonNR" runat="server" 
                                    MaxLength="10" 
                                    Text="<%# BindItem.TelefonNR %>" />
                                <asp:RequiredFieldValidator ID="TelefonNRRequiredFieldValidatorE" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för TelefonNR får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="TelefonNR" />
                                <asp:RegularExpressionValidator ID="TelefonNRRegularExpressionValidatorE" runat="server" 
                                    ControlToValidate="TelefonNR" 
                                    ValidationExpression="^[0-9]+$"
                                    ErrorMessage="Fältet för TelefonNR får inte innehålla något annat än siffror" 
                                    Text="*" /> 
                            </td>

                            <td>
                                <asp:TextBox ID="Kop" runat="server" 
                                    MaxLength="8" 
                                    Text="<%# BindItem.Kop %>" />
                                <asp:RequiredFieldValidator ID="KopTypRequiredFieldValidatorD" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för Köp får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="Kop" />
                                <asp:RegularExpressionValidator ID="KopRegularExpressionValidatorD" runat="server" 
                                    ControlToValidate="Kop" 
                                    ValidationExpression="^[a-zA-Z'.\s]{1,50}"
                                    ErrorMessage="Fältet för Köp får inte innehålla siffror!" 
                                    Text="*" />     
                            </td>

                            <td>
                                <asp:TextBox ID="Bokning" runat="server" 
                                    Type="Date"
                                    Text="<%# BindItem.Bokning %>" />
                                <asp:RequiredFieldValidator ID="BokningRequiredFieldValidatorV" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för Bokning får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="Bokning" />
                                <asp:CompareValidator ID="BokningCompareValidatorV" 
                                    runat="server" 
                                    ErrorMessage="Fel! Ange ett giltigt datum!" 
                                    ControlToValidate="Bokning" 
                                    Text="*"
                                    Display="Dynamic" 
                                    Operator="DataTypeCheck" 
                                    Type="Date">*</asp:CompareValidator>
                            </td>

                              <td>
                                <asp:TextBox ID="BokningUpphor" runat="server" 
                                    Type="Date"
                                    Text="<%# BindItem.BokningUpphor %>" />
                                <asp:RequiredFieldValidator ID="BokningUpphorRequiredFieldValidatorH" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för BokningUpphör får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="BokningUpphor" />
                                <asp:CompareValidator ID="BokningUpphorCompareValidatorH" 
                                    runat="server" 
                                    ErrorMessage="Fel! Ange ett giltigt datum!" 
                                    ControlToValidate="BokningUpphor" 
                                    Text="*"
                                    Display="Dynamic" 
                                    Operator="DataTypeCheck" 
                                    Type="Date">*</asp:CompareValidator>
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
                                <asp:linkbutton ID="Linkbutton1" runat="server" 
                                    commandname="Insert" 
                                    text="Lägg till Besökare" 
                                    causesvalidation="True" />
                            </td>

                        </tr>
                    </InsertItemTemplate>     
                            <edititemtemplate>
                                <tr>
                            <td>
                                <%--<asp:TextBox ID="BesokarID" runat="server" 
                                    MaxLength="5" 
                                    Text="<%# BindItem.BesokarID %>" />
                                <asp:RequiredFieldValidator ID="BiljettIDRequiredFieldValidator" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för efternamn får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="BesokarID" />--%>
                            </td>
                            <td>
                                <asp:TextBox ID="Fornamn" runat="server" 
                                    MaxLength="15" 
                                    Text="<%# BindItem.Fornamn %>" />
                                <asp:RequiredFieldValidator ID="FornamnRequiredFieldValidator1" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för Förnamn får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="Fornamn" />
                                <asp:CompareValidator ID="CompareValidator1" 
                                    runat="server" 
                                    ErrorMessage="Välj ett oredentligt Förnamn!" 
                                    ControlToValidate="Fornamn" 
                                    Text="*"
                                    Display="Dynamic" 
                                    Operator="DataTypeCheck"></asp:CompareValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="Efternamn" runat="server" 
                                    MaxLength="15" 
                                    Text="<%# BindItem.Efternamn %>" />
                                <asp:RequiredFieldValidator ID="EfternamnRequiredFieldValidator2" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för Efternamn får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="Efternamn" />
                                <asp:RegularExpressionValidator ID="EfternamnRegularExpressionValidator2" runat="server" 
                                    ControlToValidate="Efternamn" 
                                    ValidationExpression="^[a-zA-Z'.\s]{1,50}"
                                    ErrorMessage="Fältet för Efternamn får inte innehålla siffror!" 
                                    Text="*" />                                 
                            </td>
                                                            
                            <td>
                                <asp:TextBox ID="TelefonNR" runat="server" 
                                    MaxLength="10" 
                                    Text="<%# BindItem.TelefonNR %>" />
                                <asp:RequiredFieldValidator ID="TelefonNRRequiredFieldValidator3" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för TelefonNR får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="TelefonNR" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                    ControlToValidate="TelefonNR" 
                                    ValidationExpression="^[0-9]+$"
                                    ErrorMessage="Fältet för Förnamn får inte vara tomt." 
                                    Text="*" /> 
                            </td>
                                                            
                            <td>
                                <asp:TextBox ID="Kop" runat="server" 
                                    MaxLength="20" 
                                    Text="<%# BindItem.Kop %>" />
                                <asp:RequiredFieldValidator ID="KopTypRequiredFieldValidator4" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för Kop får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="Kop" />
                                <asp:RegularExpressionValidator ID="KopRegularExpressionValidator4" runat="server" 
                                    ControlToValidate="Kop" 
                                    ValidationExpression="^[a-zA-Z'.\s]{1,50}"
                                    ErrorMessage="Fältet för Köp får inte innehålla siffror!" 
                                    Text="*" />     
                            </td>       
                                                     
                            <td>
                                <asp:TextBox ID="Bokning" runat="server" 
                                    MaxLength="10" 
                                    Text="<%# BindItem.Bokning %>" />
                                <asp:RequiredFieldValidator ID="BokningRequiredFieldValidator5" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för BesokarID får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="Bokning" />
                                <asp:CompareValidator ID="CompareValidator5" 
                                    runat="server" 
                                    ErrorMessage="Fel! Ange ett giltigt datum!" 
                                    ControlToValidate="Bokning" 
                                    Text="*"
                                    Display="Dynamic" 
                                    Operator="DataTypeCheck" 
                                    Type="Date">*</asp:CompareValidator>
                            </td>
                                                        <td>
                                <asp:TextBox ID="BokningUpphor" runat="server" 
                                    MaxLength="10" 
                                    Text="<%# BindItem.BokningUpphor %>" />
                                <asp:RequiredFieldValidator ID="BokningUpphorRequiredFieldValidator6" 
                                    ValidationGroup="InsertItem" 
                                    CssClass="Error" 
                                    runat="server" 
                                    ErrorMessage="Fältet för BokningUpphor får inte vara tomt." 
                                    Text="*" 
                                    Display="Dynamic" 
                                    ControlToValidate="BokningUpphor" />
                               <asp:CompareValidator ID="CompareValidator6" 
                                    runat="server" 
                                    ErrorMessage="Fel! Ange ett giltigt datum!" 
                                    ControlToValidate="BokningUpphor" 
                                   Text="*"
                                    Display="Dynamic" 
                                    Operator="DataTypeCheck" 
                                    Type="Date">*</asp:CompareValidator>
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
                                <asp:linkbutton ID="Linkbutton1" runat="server" 
                                    commandname="Insert" 
                                    text="Lägg till Besökare" 
                                    causesvalidation="True" />
                            </td>

                        </tr>

                    </edititemtemplate>

                </asp:ListView>
    </asp:Content>