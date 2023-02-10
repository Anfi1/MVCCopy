using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace C1Copy.Models;

[PrimaryKey(nameof(ID))]
public class Client
{
    public int ID { get; set; }
    [MaxLength(80)]
    public string Name { get; set; }


    public virtual ICollection<LegalEntities>? LegalEntitie { get; set; }
    public virtual ICollection<Office>? Offices { get; set; }
    public virtual ICollection<Worker>? Workers { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
[PrimaryKey("ID")]
public class LegalEntities
{
    public int ID;
    public int? ClientID { get; set; }
    [MaxLength(80)]
    public string Name { get; set; }
    public string Email { get; set; }

    public ICollection<Worker>? Workers { get; set; }
    public Client Client { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
[PrimaryKey(nameof(ID))]
public class Office 
{
    public int ID { get; set; }
    public int? ClientID { get; set; }
    public string OfficeName { get; set; }
    public string Adress { get; set; }
    public string City { get; set; }
    public int Floor { get; set; }
    public uint Cabinet { get; set; }
    
    
    public Client Client { get; set; }
    public ICollection<Worker>? Workers { get; set; }
    public ICollection<Tech>? Teches { get; set; }


}

[PrimaryKey(nameof(ID))]
public class Tech
{
    public int ID { get; set; }
    public int? OfficeID { get; set; }
    public int? WorkerID { get; set; }
    public int? WorkPlaceID { get; set; }

    public string Type { get; set; }
    
    public string InventaryID { get; set; }
    
    public string Manufacturer { get; set; }
    
    public string Model { get; set; }
    public string IPAdress { get; set; }
    
    public Office? Office { get; set; }
    public WorkPlace WorkPlace { get; set; }
    public Worker Worker { get; set; }
}

public class Human
{
    public int ID { get; set; }
    public string FIO { get; set; }
    public string? Position { get; set; }
    public string Email { get; set; }
    public string? EmailPass { get; set; }
    public string? OwnPhoneNumber { get; set; }
}

public class Worker: Human
{
    public int OfficeID { get; set; }

    public int WorkPlaceID { get; set; }

    public string? ServerIP { get; set; }
    //AnyDesk
    public int AnyDesk { get; set; }
    public string? AnyDeskPass { get; set; }
    //AD
    public string UserAD { get; set; }
    public string PassAD { get; set; }
    //Phone
    public string FIOEng { get; set; }
    public string PhoneLog { get; set; }
    public string PhonePass { get; set; }
    public string PhoneOutsideNumber { get; set; }
    
    public WorkPlace? WorkPlace { get; set; }
    public Office? Office { get; set; }
    public ICollection<Tech> teches { get; set; }
}

public class WorkPlace
{
    public int ID { get; set; }
    public int? OfficeID { get; set; }
    public int WorkplaceNumber { get; set; }

    public Office Office { get; set; }
    public ICollection<Tech> teches { get; set; }
}

public class ClientModel
{
    public Client Client;
    public List<LegalEntities> LegalEntitiesList;
}