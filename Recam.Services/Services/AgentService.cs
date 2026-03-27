using Microsoft.AspNetCore.Identity;
using Recam.Models.Entities;
using Recam.Repository.Interfaces;
using Recam.Services.DTOs.Agent;
using Recam.Services.Interfaces;

namespace Recam.Services.Services;

public class AgentService : IAgentService
{
    private readonly IAgentRepository _agentRepository;
    private readonly UserManager<ApplicationUser> _userManager;

    public AgentService(
        IAgentRepository agentRepository,
        UserManager<ApplicationUser> userManager)
    {
        _agentRepository = agentRepository;
        _userManager = userManager;
    }

    public async Task<Agent?> GetByEmailAsync(string email)
    {
        return await _agentRepository.GetByEmailAsync(email);
    }

    public async Task<List<Agent>> GetAllAsync()
    {
        return await _agentRepository.GetAllAsync();
    }

    // 🔥 RECAM-82 核心
    public async Task<Guid> CreateAgentAsync(CreateAgentRequest request)
    {
        // 1️⃣ 创建 Identity User（登录用）
        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"Create user failed: {errors}");
        }

        // 2️⃣ 赋予 Agent 角色
        await _userManager.AddToRoleAsync(user, "Agent");

        // 3️⃣ 创建 Agent 表（业务数据）
        var agent = new Agent
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            Phone = request.Phone,
            CompanyName = request.CompanyName,
            CreatedAt = DateTime.UtcNow
        };

        await _agentRepository.AddAsync(agent);

        return agent.Id;
    }
}