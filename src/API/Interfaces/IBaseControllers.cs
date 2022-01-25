namespace API.Interfaces;

public interface IBaseControllers<T> where T : class
{
    Task<IResult> GetAll();
    Task<IResult> GetById(int id);
    Task<IResult> Create(T entity);
    Task<IResult> Update(T entity);
    Task<IResult> Delete(int id);
}