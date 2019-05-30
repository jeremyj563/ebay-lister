<%@ Page Title="Listings" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Listings.aspx.cs" Inherits="Listings" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="ListingsGridView" runat="server" CssClass="table table-hover table-striped" GridLines="None" AutoGenerateColumns="false" ItemType="Listing" DataKeyNames="ID" SelectMethod="GetListings" UpdateMethod="EditListing" DeleteMethod="RemoveListing">
        <Columns>
            <asp:CommandField ShowEditButton="true" />
            <asp:CommandField ShowDeleteButton="true" />
            <asp:TemplateField Visible="false" HeaderText="ID">
                <ItemTemplate><asp:HiddenField ID="IDLabel" runat="server" Value="<%#: Item.ID %>" /></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate><asp:CheckBox ID="SelectedCheckBox" runat="server" /></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="StoreCategory" ItemStyle-Wrap="false">
                <ItemTemplate><asp:Label ID="StoreCategoryLabel" runat="server" Text="<%# base.GetStoreCategory(Item.StoreCategoryID).Name %>" /></ItemTemplate>
                <EditItemTemplate><asp:DropDownList ID="StoreCategoryDropDown" runat="server" SelectMethod="GetStoreCategories" DataTextField="Name" DataValueField="ID"></asp:DropDownList></EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Title" HeaderText="Title" ItemStyle-Wrap="false" />
            <asp:BoundField DataField="Photo1Path" HeaderText="Photo 1" ItemStyle-Wrap="false" />
            <asp:BoundField DataField="Photo2Path" HeaderText="Photo 2" ItemStyle-Wrap="false" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:BoundField DataField="Listed" HeaderText="Listed" />
            <asp:BoundField DataField="Sold" HeaderText="Sold" />
            <asp:BoundField DataField="Condition" HeaderText="Condition" />
            <asp:BoundField DataField="WeightLBS" HeaderText="Weight LBS" />
            <asp:BoundField DataField="WeightOZ" HeaderText="Weight OZ" />
            <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Wrap="false" />
        </Columns>
    </asp:GridView>
    <div class="row">
        <asp:Button ID="AddButton" runat="server" Text="Add Listing" CssClass="btn btn-primary" OnClick="AddButton_Click" />
        <asp:Button ID="ListButton" runat="server" Text="List Selected" CssClass="btn btn-primary" OnClick="ListButton_Click" />
    </div>
</asp:Content>