namespace Project
{
     class Program
    {
        static void Main(string[] args)
        {

            IRepository<Customer> dao = new CustomerDAO();
            Customer customer = new Customer();

            Console.WriteLine("Enter your First name");
            string firstName = Console.ReadLine();
            customer.First_name = firstName;

            Console.WriteLine("Enter your Second name");
            string lastName = Console.ReadLine();
            customer.Last_name = lastName;

            Console.WriteLine("Enter your email");
            string email = Console.ReadLine();
            customer.Email = email;

            int customer_id = dao.Insert(customer);
            // Getting basic informations from user and inserting them into customer table

            Products products = new Products();
            IRepository<Products> dao2 = new ProductsDAO();

            Console.WriteLine("");
            IRepository<Orders> dao3 = new OrdersDAO();

            string answer;

            Orders orders = new Orders();

            orders.Customer_id = customer_id;
            orders.Order_date = DateTime.Now;
            int order_id = dao3.Insert(orders);

            IRepository<OrderDetails> ordersdetailDAO = new OrderDetailsDAO();
            do // Adding products to users order
            {

                Console.WriteLine("What do you want to add to your order? (First ID + space + amount)");
                dao2.GetAll().ToList().ForEach(x => Console.WriteLine(x));
                string line = Console.ReadLine();
                string[] stringArray = line.Split(" "); // Splitting string with spaces to divide ID and AMOUNT


                Console.WriteLine("Want to continue? (yes/no)");
                answer = Console.ReadLine().Trim().ToLower();

                OrderDetails details = new OrderDetails();
                details.Product_id = Convert.ToInt32(stringArray[0]); // First value is set to product_id
                details.Amount = Convert.ToInt32(stringArray[1]); // Second value is set to Amout
                details.Order_id = order_id;

                ordersdetailDAO.Insert(details);

            }
            while (answer != "no");

            Console.WriteLine("Ending order proccess");

            Console.WriteLine("Would you like to 'edit' or 'delete' a product? (edit/delete)"); // Asking user if he wants to delete or edit his order
            string action = Console.ReadLine().ToLower();

            if (action == "edit")
            {
                dao3.GetAll().ToList().ForEach(x =>
                {

                    if (x.Customer_id == customer_id) // making sure that customer_ids are matching
                    {
                        Console.WriteLine(x);
                    }

                });

                Console.WriteLine("Which order do you want to change? Write ID:");

                int orderId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("-- ORDER ID " + orderId + " --");
                List<OrderDetails> orderDetails = OrderDetailsDAO.getByOrderID(orderId).ToList(); // Storing Order details to list
                orderDetails.ForEach(x => Console.WriteLine(x));

                Console.WriteLine("");

                Console.WriteLine("Write PRODUCT ID and AMOUNT you want to change:");

                string line = Console.ReadLine();
                string[] stringArray = line.Split(" ");

                OrderDetailsDAO.updateByProductIdAndCustomerId(Convert.ToInt32(stringArray[0]), Convert.ToInt32(stringArray[1]), orderId); // getting product_id and customer_id

            }
            else if (action == "delete")
            {
                dao3.GetAll().ToList().ForEach(x =>
                { // making sure that customer_ids are matching

                    if (x.Customer_id == customer_id)
                    {
                        Console.WriteLine(x);
                    }

                });

                Console.WriteLine("Which order do you want to remove?");
                int orderId = Convert.ToInt32(Console.ReadLine());
                ordersdetailDAO.Delete(orderId);

            }


         
        }
    }
}