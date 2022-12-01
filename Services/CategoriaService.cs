using webapi.Models;

namespace webapi.Services;
public class CategoriaService : ICategoriaService
{

    TareasContext context;

    public CategoriaService(TareasContext dbcontex)
    {
        this.context = dbcontex;
    }

    public IEnumerable<Categoria> get()
    {
        return context.Categorias;
    }

    //metodo guardar asincrono
    public async Task Save(Categoria categoria)
    {
        categoria.CategoriaId = Guid.NewGuid();
        await context.AddAsync(categoria);
        await context.SaveChangesAsync();
    }

    //metodo editar asincrono
    public async Task Update(Guid id, Categoria categoria)
    {
        var categoriaActual = context.Categorias.Find(id);

        if (categoriaActual != null)
        {
            categoriaActual.Nombre = categoria.Nombre;
            categoriaActual.Descripcion = categoria.Descripcion;
            categoriaActual.Peso = categoria.Peso;
            await context.SaveChangesAsync();

        }
    }

    //metodo eliminar asincrono
    public async Task Delete(Guid id)
    {
        var categoriaActual = context.Categorias.Find(id);

        if (categoriaActual != null)
        {
            context.Remove(categoriaActual);
            await context.SaveChangesAsync();

        }
    }

    //metodo guardar no asincrono
    // public void Save(Categoria categoria){
    //     context.Add(categoria);
    //     context.SaveChanges();
    // }

}

public interface ICategoriaService
{

    IEnumerable<Categoria> get();

    Task Save(Categoria categoria);

    Task Update(Guid id, Categoria categoria);

    Task Delete(Guid id);


}