using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C1Copy.Models;

public class Client
{
    public int ID { get; set; }
    [MaxLength(80)]
    public string Name { get; set; }
    public int? LegalEntitiesID { get; set; }
    [ForeignKey("ClientID")]
    public int? OfficesID { get; set; }
    
    public virtual LegalEntities LegalEntitie { get; set; }
    public virtual List<Office>? Offices { get; set; }
}

public class LegalEntities 
{
    public int LegalEntitiesID { get; set; }
    [MaxLength(80)]
    public string Name { get; set; }
    public List<Client> Client { get; set; }
    
}
[PrimaryKey(nameof(OfficeID))]
public class Office 
{
    public int OfficeID { get; set; }
    public int ClientID { get; set; }
    public string Adress { get; set; }
    public Client Client { get; set; }
    
}

public class ClientModel
{
    public Client Client;
    public List<LegalEntities> LegalEntitiesList;
}