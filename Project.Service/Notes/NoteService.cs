using System.Collections.Generic;
using Project.Model.Models;
using Project.Data;
using System.Linq;
using System;

namespace Project.Services
{
  public class NoteService : INoteService
  {
    public IRepository<Note> Repository { get; }

    public IEnumerable<Note> AllNotes => Repository.Table.OrderByDescending(n => n.Id);

    public NoteService(IRepository<Note> repository) => Repository = repository;

    public Note Add(Note e) => Repository.Insert(e);

    public Note Update(Note e) => Repository.Update(e);

    public Note GetNoteById(int id, Guid userId) => Repository.GetById(id , userId);

    public Note Delete(Note e)
    {
      Repository.Delete(e);
      return e;
    }
    public IEnumerable<Note> GetNotesByUserId(Guid userid) => Repository.Table.Where(n => n.UserId == userid);

  }
}
