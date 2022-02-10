using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanProject
{
    public class Card
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public double Estimate { get; set; }
        public int SprintId { get; set; }
        public Sprint Sprint { get; set; }
        public State State { get; set; }
    }
    public enum State
    {
        A_fazer,
        Em_andamento,
        Concluido,
    }
}
