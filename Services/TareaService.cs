using webapi.Models;



namespace webapi.Services;
public class TareaService : ITareaService
{

    TareasContext context;

    public TareaService(TareasContext dbcontex)
    {
        this.context = dbcontex;
    }


    public async Task Delete(Guid id)
    {
        var tareaActual = context.Tareas.Find(id);
        if (tareaActual != null)
        {
            context.Remove(tareaActual);
            await context.SaveChangesAsync();

        }

    }

    public IEnumerable<Tarea> get()
    {

        return context.Tareas;
    }

    public async Task Save(Tarea tarea)
    {
        tarea.TareaId = Guid.NewGuid();
        tarea.FechaCreacion = DateTime.Now;
        await context.AddAsync(tarea);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea tarea)
    {
        var tareaActual = context.Tareas.Find(id);

        if (tareaActual != null)
        {
            tareaActual.CategoriaId = tarea.CategoriaId;
            tareaActual.Titulo = tarea.Titulo;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;
            tareaActual.Descripcion = tarea.Descripcion;
            await context.SaveChangesAsync();

        }
    }
}


public interface ITareaService
{

    IEnumerable<Tarea> get();

    Task Save(Tarea tarea);

    Task Update(Guid id, Tarea tarea);

    Task Delete(Guid id);
}