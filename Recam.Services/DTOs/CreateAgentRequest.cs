namespace Recam.Services.DTOs.Agent;

public class CreateAgentRequest
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;

    public string Name { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string CompanyName { get; set; } = default!;
}