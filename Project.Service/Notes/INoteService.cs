using System;
using System.Collections.Generic;
using Project.Model.Models;

namespace Project.Services
{
  public interface INoteService : IService<Note>
  {
    IEnumerable<Note> AllNotes { get; }
    Note GetNoteById(int id, string userid);
    Note Add(Note e);
    Note Update(Note e);
    Note Delete(Note e);
    IEnumerable<Note> GetNotesByUserId (string userid);
  }
}
