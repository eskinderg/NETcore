using System;

public class DbUpdateConflictException : Exception
{
  public DbUpdateConflictException(string message) : base(message) { }
}
