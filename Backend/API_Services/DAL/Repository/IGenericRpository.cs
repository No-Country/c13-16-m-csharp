namespace API_Services.DAL.Repository
{
    public interface IGenericRpository<TEntityModel>where TEntityModel:class
    {
        Task<bool> Insertar(TEntityModel modelo);
        Task<bool> Actualizar(TEntityModel modelo);
        Task<bool> Eliminar(int id);
        Task<TEntityModel> Obtnener(int id);
        Task<IQueryable<TEntityModel>> ObtenerTodos();
    }
}
