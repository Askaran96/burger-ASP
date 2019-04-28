using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace burger_ASP
{
    public class shop

    {
        Entities1 obj = new Entities1();
        main burger = new main();

        
        public void order_complete(int id)
        {

            using (Entities1 burger = new Entities1())
            {
                
                main  obj = burger.mains .First(x => x.orderID  == id);
                burger.mains.Remove(obj);
                burger.SaveChanges();

                //this removes the data from the databse when order is complete
            }

        }
        public void OrderAdd(string Name, int Burger_id, int Fries_id)
        {
            burger.Name = Name;
            burger.Burger_id = Burger_id;
            burger.Fries_id = Fries_id;//this add the data to the main table

            obj.mains.Add(burger);
            obj.SaveChanges();



        }
        public void OrderChange(int order_id, string Name, int Burger_id, int Fries_id)
        {
            using (var bur = new Entities1())
            {
                var b = bur.mains.SingleOrDefault(x => x.orderID  == order_id);
                if (b != null)
                {
                    b.Name = Name;//it changes the order 
                    b.Burger_id  = Burger_id ;
                    b.Fries_id  = Fries_id;

                    bur.SaveChanges();

                }



            }
        }


    }


    }

