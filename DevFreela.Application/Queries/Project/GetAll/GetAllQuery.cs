using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.Project.GetAll;

public class GetAllQuery : IRequest<ResultViewModel<List<ProjectItemViewModel>>> { }
