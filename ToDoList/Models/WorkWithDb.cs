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

        public static User GetUserBySigInInfo(string email, string password)
        {
            using (ToDoListDbContext toDoList = new ToDoListDbContext())
            {
                return toDoList.Users.FirstOrDefault(x => x.Email == email && x.Password==password);
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

        public static void CheckItem(string authId, int id)
        {
            using (ToDoListDbContext toDoList = new ToDoListDbContext())
            {
                var items = toDoList.Users.Include("Items").FirstOrDefault(x => x.AutId == authId).Items;
                items.FirstOrDefault(i => i.Id==id).IsChecked=true;
                toDoList.SaveChanges();
            }
        }

        public static void RemoveItem(string authId, int id)
        {
            using (ToDoListDbContext toDoList = new ToDoListDbContext())
            {
                var items = toDoList.Users.Include("Items").FirstOrDefault(x => x.AutId == authId).Items;
                items.Remove(items.FirstOrDefault(i => i.Id == id));
                toDoList.SaveChanges();
            }
        }

        public static void EditItem(string authId, Item item)
        {
            using (ToDoListDbContext toDoList = new ToDoListDbContext())
            {
                var items = toDoList.Users.Include("Items").FirstOrDefault(x => x.AutId == authId).Items;
                var finItem = items.FirstOrDefault(i => i.Id == item.Id);
                finItem.Description = item.Description;
                finItem.CheckedDate = item.CheckedDate;
                finItem.Name = item.Name;
                toDoList.SaveChanges();
            }
        }
    }
}