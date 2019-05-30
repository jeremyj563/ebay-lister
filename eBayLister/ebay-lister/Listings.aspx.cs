using DataRepositories;
using DataRepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Listings : System.Web.UI.Page
{
    private IDataRepository Repo { get; }

    public Listings()
    {
        var conn = ConfigurationManager.ConnectionStrings["eBayLister"].ConnectionString;
        this.Repo = new MSSQLRepository(conn);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public int NewListing(Listing listing)
    {
        var id = this.Repo.New(Listing.SQLCommands.New, listing);
        return id;
    }

    public void EditListing(Listing listing)
    {
        this.Repo.Edit(Listing.SQLCommands.Edit, listing);
    }

    public void RemoveProduct(Listing listing)
    {
        this.Repo.Remove(Listing.SQLCommands.Remove, listing);
    }

    public IQueryable<Listing> GetListings()
    {
        var listings = this.Repo.Get<Listing>(Listing.SQLCommands.GetAll);
        return listings;
    }

    public IQueryable<StoreCategory> GetStoreCategories()
    {
        var storeCategories = this.Repo.Get<StoreCategory>(StoreCategory.SQLCommands.GetAll);
        return storeCategories;
    }

    public StoreCategory GetStoreCategory(string id)
    {
        (string, object)[] idParam = { (nameof(StoreCategory.ID), id) };
        var storeCategory = this.Repo.Get<StoreCategory>(StoreCategory.SQLCommands.GetOne, idParam).SingleOrDefault();

        return storeCategory;
    }

    public void AddButton_Click(object sender, EventArgs e)
    {
        //NewProduct(new Product());

        //base.Response.Redirect(Request.RawUrl, false);
        //base.Context.ApplicationInstance.CompleteRequest();
    }

    protected void ListButton_Click(object sender, EventArgs e)
    {
        //foreach (GridViewRow row in ProductsGridView.Rows)
        //{
        //    var checkBox = row.FindControl("SelectedCheckBox") as CheckBox;
        //    if (checkBox.Checked)
        //    {
        //        var dataKey = ProductsGridView.DataKeys[row.RowIndex];
        //        Debugger.Break();
        //    }
        //}
    }
}