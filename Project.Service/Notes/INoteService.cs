using System.Collections.Generic;
using Project.Model.Models;

namespace Project.Services
{
  public interface INoteService
  {
    IEnumerable<Note> AllNotes { get; }
    Note GetNoteById(int id);
    Note Add(Note e);
    Note Update(Note e);
    Note Delete(Note e);
  }
}
