using System.Collections.Generic;
using Project.Model.Models;
using Project.Data;
using System.Linq;


namespace Project.Services
{
  public class NoteService: INoteService
  {
    public IRepository<Note> NoteRepository { get; }
    public IEnumerable<Note> AllNotes => NoteRepository.Table.OrderByDescending(n => n.Id);
    public NoteService(IRepository<Note> eventRepo) => NoteRepository = eventRepo;

    public Note Add(Note e)
    {
      NoteRepository.Insert(e);
      return e;
    }

    public Note Update(Note e)
    {
      NoteRepository.Update(e);
      return e;
    }

    public Note GetNoteById(int id) => NoteRepository.GetById(id);

    public Note Delete(Note e)
    {
      NoteRepository.Delete(e);
      return e;
    }
  }
}
