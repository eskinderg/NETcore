using System.Collections.Generic;
using Project.Model.Models;
using Project.Data;
using System.Linq;

namespace Project.Services
{
  public class NoteService : INoteService
  {
    public IRepository<Note> Repository { get; }
    public IEnumerable<Note> AllNotes => Repository.Table.OrderByDescending(n => n.Id);
    public NoteService(IRepository<Note> repository) => Repository = repository;

    public Note Add(Note e)
    {
      Repository.Insert(e);
      return e;
    }

    public Note Update(Note e)
    {
      Repository.Update(e);
      return e;
    }

    public Note GetNoteById(int id) => Repository.GetById(id);

    public Note Delete(Note e)
    {
      Repository.Delete(e);
      return e;
    }
  }
}
