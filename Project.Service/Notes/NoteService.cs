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

    IEnumerable<Note> INoteService.AllNotes => Repository.Table.OrderByDescending(n => n.Id);

    public NoteService(IRepository<Note> repository) => Repository = repository;

    Note INoteService.Add(Note e) => Repository.Insert(e);

    Note INoteService.Update(Note e) => Repository.Update(e);

    Note INoteService.GetNoteById(int id, string userId) => Repository.GetById(id , userId);

    Note INoteService.Delete(Note e)
    {
      Repository.Delete(e);
      return e;
    }
    IEnumerable<Note> INoteService.GetNotesByUserId(string userid) => Repository.Table.Where(n => n.UserId == userid);

  }
}
