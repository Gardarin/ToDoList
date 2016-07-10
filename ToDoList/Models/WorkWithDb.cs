using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class WorkWithDb
    {
        public static void Registration(User user)
        {
            using (ToDoListDbContext toDoList = new ToDoListDbContext())
            {
                toDoList.Users.Add(user);
                toDoList.SaveChanges();
            }
        }

        public static User GetUserByAuthId(string authId)
        {
            using (ToDoListDbContext toDoList = new ToDoListDbContext())
            {
                return toDoList.Users.Include("Items").FirstOrDefault(x=>x.AutId==authId);
            }
        }

        public static void AddItem(string authId, Item item)
        {
            using (ToDoListDbContext toDoList = new ToDoListDbContext())
            {
                toDoList.Users.Include("Items").FirstOrDefault(x => x.AutId == authId).Items.Add(item);
                toDoList.SaveChanges();
            }
        }
    }
}