using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Geraldo = new User();
            Geraldo.Name = "Geraldoo";
            Geraldo.Save();

            var Sprint3 = new Sprint();
            Sprint3.Name = "Criar CRUDD";
            Sprint3.Save();

            var Card1 = new Card();
            Card1.Title = "Projeto Kanban";
            Card1.Description = "Criar um projeto Kanban";
            Card1.Estimate = 48;
            Card1.Sprint = Sprint3;
            Card1.User = Geraldo;
            Card1.State = State.In_Progress;
            Card1.Save();
        }
        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("===================");
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
        }
    }
}

