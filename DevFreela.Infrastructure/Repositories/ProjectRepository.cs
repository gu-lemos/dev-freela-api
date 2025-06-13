using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly DevFreelaDbContext _context;

    public ProjectRepository(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<int> Add(Project project, CancellationToken cancellationToken)
    {
        await _context.Projects.AddAsync(project, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return project.Id;
    }

    public async Task AddComment(ProjectComment comment, CancellationToken cancellationToken)
    {
        await _context.ProjectComment.AddAsync(comment, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> Exists(int id, CancellationToken cancellationToken)
    {
        return await _context.Projects.AnyAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<List<Project>> GetAll(CancellationToken cancellationToken)
    {
        var projects = await _context.Projects
           .Include(p => p.Client)
           .Include(p => p.FreeLancer)
           .ToListAsync(cancellationToken);

        return projects;
    }

    public async Task<Project?> GetById(int id, CancellationToken cancellationToken)
    {
        var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id == id, cancellationToken);

        return project;
    }

    public async Task<Project?> GetDetailsById(int id, CancellationToken cancellationToken)
    {
        var project = await _context.Projects
           .Include(p => p.Client)
           .Include(p => p.FreeLancer)
           .Include(p => p.Comments)
           .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);

        return project;
    }

    public async Task Update(Project project, CancellationToken cancellationToken)
    {
        _context.Projects.Update(project);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
