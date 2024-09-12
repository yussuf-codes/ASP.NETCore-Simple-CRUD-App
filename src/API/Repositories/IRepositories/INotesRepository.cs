using System.Collections.Generic;
using API.Models;

namespace API.Repositories.IRepositories;

public interface INotesRepository
{
    Note Add(Note obj);
    void Delete(int id);
    bool Exists(int id);
    IEnumerable<Note> Get();
    Note Get(int id);
    void Update(int id, Note obj);
}
