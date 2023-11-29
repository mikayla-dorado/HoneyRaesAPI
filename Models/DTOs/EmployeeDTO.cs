namespace HoneyRaesAPI.Models.DTOs;

public class EmployeeDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Specialty { get; set; }
    //now there is a place on the Employee class where we can store 
    //the service ticket objects that belong to any given employee
    public List<ServiceTicketDTO> ServiceTickets { get; set; }
}