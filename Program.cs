using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            
            Console.WriteLine("Hello, User");
            var AuxDelete = 0;            

            var user = new User();
            Console.Write("User Name: ");
            user.Name = Console.ReadLine();
            user.Save();

            var sprint = new Sprint();
            Console.Write("Sprint Name: ");
            sprint.Name = Console.ReadLine();
            sprint.Save();

            var card = new Card();

            Console.Write("Card Title: ");
            card.Title = Console.ReadLine();

            Console.Write("Card Description: ");
            card.Description = Console.ReadLine();

            Console.Write("Card Estimate: ");
            card.Estimate = int.Parse(Console.ReadLine());

            card.Sprint = sprint;
            card.User = user;

            Console.Write("Card Status: ");
            string status = Console.ReadLine();        
            Status StringStatus;
            StringStatus = Status.Requested;
            if (status == "Requested")
            {
                StringStatus = Status.Requested;
            }
            if (status == "In Progress")
            {
                StringStatus = Status.In_Progress;
            }
            if (status == "Done")
            {
                StringStatus = Status.Done;
            }
            card.Status = StringStatus;

            card.Save();

            while (i == 1)
                {
                Console.Write("Do you want to delete some entity of database? (Yes - 1, No - 0): ");
                AuxDelete = int.Parse(Console.ReadLine());
                if (AuxDelete == 1)
                {
                    Delete();
                }
                else
                {
                    break;
                }                           
            }
            
        }
        static void Delete()
        {
            Console.Write("Which entity do you want to delete? (User - 0, Sprint - 1, Card - 2): ");
            int ChoiceDelete = int.Parse(Console.ReadLine());
            Console.Write("Please, put the Id of the entity you want to delete: ");
            int Id = int.Parse(Console.ReadLine());
            var db = KanbanContext.GetInstance();            
            switch (ChoiceDelete)
            {
                case 0:
                    db.Users.RemoveRange(db.Users.Where(users => users.Id == Id));
                    break;
                case 1:
                    db.Sprints.RemoveRange(db.Sprints.Where(sprints => sprints.Id == Id));
                    break;
                case 2:
                    db.Users.RemoveRange(db.Users.Where(cards => cards.Id == Id));
                    break;
            }
            db.SaveChanges();
            Console.WriteLine("Entity deleted");
        }
    }
}

