using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C1Copy.Models;

[PrimaryKey(nameof(ID))]
public class Client
{
    
    [ForeignKey("ClientID")]
    public int ID { get; set; }
    [MaxLength(80)]
    public string Name { get; set; }
    public int? LegalEntitiesID { get; set; }

    
    public virtual LegalEntities LegalEntitie { get; set; }
    public virtual List<Office>? Offices { get; set; }
}

public class LegalEntities 
{
    public int LegalEntitiesID { get; set; }
    [MaxLength(80)]
    public string Name { get; set; }
    public List<Client> Client { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
[PrimaryKey(nameof(OfficeID))]
public class Office 
{
    public int OfficeID { get; set; }
    [ForeignKey("ID")]
    public int ClientID { get; set; }
    public string Adress { get; set; }
    public Client Client { get; set; }
    
}

public class ClientModel
{
    public Client Client;
    public List<LegalEntities> LegalEntitiesList;
}