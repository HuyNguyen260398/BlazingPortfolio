namespace API.Controllers;

public class BaseController<T> : IBaseController<T> where T : class
{
    private readonly IBaseRepo<T> _repo;

    public BaseController(IBaseRepo<T> repo)
    {
        _repo = repo;
    }

    public async Task<IResult> GetAll()
    {
        try
        {
            return Results.Ok(await _repo.GetAllAsync());
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    public async Task<IResult> GetById(int id)
    {
        try
        {
            var service = await _repo.GetByIdAsync(id);

            if (service == null)
                return Results.NotFound();

            return Results.Ok(service);
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    public async Task<IResult> Create(T entity)
    {
        try
        {
            var isSuccess = await _repo.CreateAsync(entity);

            if (!isSuccess)
                return Results.Problem();

            return Results.Created("Create", entity);
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    public async Task<IResult> Update(T entity)
    {
        try
        {
            var isSuccess = await _repo.UpdateAsync(entity);

            if (!isSuccess)
                return Results.Problem();

            return Results.NoContent();
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    public async Task<IResult> Delete(int id)
    {
        try
        {
            var isSuccess = await _repo.DeleteAsync(id);

            if (!isSuccess)
                return Results.Problem();

            return Results.NoContent();
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }
}
