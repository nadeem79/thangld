using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

/// <summary>
/// Summary description for DataLayerService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class DataLayerService : System.Web.Services.WebService
{
    public TribalWars data;
    TribalWarsTableAdapters.groupsTableAdapter adapterGroups;
    TribalWarsTableAdapters.usersTableAdapter adapterUsers;
    TribalWarsTableAdapters.villagesTableAdapter adapterVillages;
    TribalWarsTableAdapters.diplomatesTableAdapter adapterDiplomates;
    TribalWarsTableAdapters.offersTableAdapter adapterOffers;
    TribalWarsTableAdapters.movementTableAdapter adapterMovement;

    public TribalWarsTableAdapters.groupsTableAdapter AdapterGroups
    {
        get { return adapterGroups; }
        set { adapterGroups = value; }
    }

    public TribalWarsTableAdapters.usersTableAdapter AdapterUsers
    {
        get { return adapterUsers; }
        set { adapterUsers = value; }
    }
    
    public TribalWarsTableAdapters.villagesTableAdapter AdapterVillages
    {
        get { return adapterVillages; }
        set { adapterVillages = value; }
    }
    
    public TribalWarsTableAdapters.diplomatesTableAdapter AdapterDiplomates
    {
        get { return adapterDiplomates; }
        set { adapterDiplomates = value; }
    }
    
    public TribalWarsTableAdapters.offersTableAdapter AdapterOffers
    {
        get { return adapterOffers; }
        set { adapterOffers = value; }
    }
    
    public TribalWarsTableAdapters.movementTableAdapter AdapterMovement
    {
        get { return adapterMovement; }
        set { adapterMovement = value; }
    }

    public TribalWars Data
    {
        get { return this.data; }
    }

    public TribalWars.groupsDataTable Groups
    {
        get {return (TribalWars.groupsDataTable)this.data.Tables["groups"];}
    }
    public TribalWars.usersDataTable Users
    {
        get { return (TribalWars.usersDataTable)this.data.Tables["users"]; }
    }
    public TribalWars.villagesDataTable Villages
    {
        get { return (TribalWars.villagesDataTable)this.data.Tables["villages"]; }
    }
    public TribalWars.diplomatesDataTable Diplomates
    {
        get { return (TribalWars.diplomatesDataTable)this.data.Tables["diplomates"]; }
    }
    public TribalWars.offersDataTable Offers
    {
        get { return (TribalWars.offersDataTable)this.data.Tables["offers"]; }
    }
    public TribalWars.movementDataTable Movements
    {
        get { return (TribalWars.movementDataTable)this.data.Tables["movement"]; }
    }

    public DataLayerService()
    {
        
        this.data = new TribalWars();
        adapterGroups = new TribalWarsTableAdapters.groupsTableAdapter();
        adapterUsers = new TribalWarsTableAdapters.usersTableAdapter();
        adapterVillages = new TribalWarsTableAdapters.villagesTableAdapter();
        adapterDiplomates = new TribalWarsTableAdapters.diplomatesTableAdapter();
        adapterOffers = new TribalWarsTableAdapters.offersTableAdapter();
        adapterMovement = new TribalWarsTableAdapters.movementTableAdapter();

        this.adapterGroups.Fill((TribalWars.groupsDataTable)this.data.Tables["groups"]);
        this.adapterUsers.Fill((TribalWars.usersDataTable)this.data.Tables["users"]);
        this.adapterVillages.Fill((TribalWars.villagesDataTable)this.data.Tables["villages"]);
        this.adapterDiplomates.Fill((TribalWars.diplomatesDataTable)this.data.Tables["diplomates"]);
        this.adapterOffers.Fill((TribalWars.offersDataTable)this.data.Tables["offers"]);
        this.adapterMovement.Fill((TribalWars.movementDataTable)this.data.Tables["movement"]);
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

}

