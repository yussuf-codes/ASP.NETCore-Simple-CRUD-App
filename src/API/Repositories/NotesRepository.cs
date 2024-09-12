using System.Collections.Generic;
using System.Linq;
using API.Models;
using API.Repositories.IRepositories;

namespace API.Repositories;

public class NotesRepository : INotesRepository
{
    private int _nextId = 3;

    private readonly List<Note> _notes = new()
    {
        new Note() { Id = 1, Title = "SOLID Principles", Body = "" },
        new Note() { Id = 2, Title = "Design Patterns", Body = "" }
    };

    private int Index(int id)
    {
        return _notes.FindIndex(obj => obj.Id == id);
    }

    public Note Add(Note obj)
    {
        obj.Id = _nextId++;
        _notes.Add(obj);
        return obj;
    }

    public void Delete(int id)
    {
        int index = Index(id);
        _notes.RemoveAt(index);
    }

    public bool Exists(int id)
    {
        Note? obj = _notes.SingleOrDefault(obj => obj.Id == id);
        if (obj is null)
            return false;
        return true;
    }

    public IEnumerable<Note> Get()
    {
        return _notes;
    }

    public Note Get(int id)
    {
        int index = Index(id);
        return _notes[index];
    }

    public void Update(int id, Note obj)
    {
        int index = Index(id);
        _notes[index] = obj;
    }
}
