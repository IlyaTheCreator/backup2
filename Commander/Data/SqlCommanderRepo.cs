using System.Data;
using System.Collections.Generic;
using Commander.Models;
using System.Linq;
using System;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if (cmd is null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd is null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(command => command.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void UpdateCommand(Command cmd)
        {
            //Nothing
        }
    }
}