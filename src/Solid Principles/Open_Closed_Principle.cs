// Open Closed Principle (OCP) states that software entities
// (classes, modules, functions, etc.) should be open for extension but
// closed for modification. This means that the behavior of a module
// can be extended without modifying its source code.


using System; 

namespace SolidPrinciples
{
    class InvoiceDac
    {
        Invoice invoice;
        public InvoiceDac(Invoice invoice)
        {
            this.invoice = invoice;
        }

        public void saveInvoiceToDb()
        {
            Console.WriteLine("Saving Invoice to Database");
        }

        public void SaveFile()
        {
            Console.WriteLine("Saving Invoice to File");  // here we are modifyiing the invoicedac class and this violated Open Closed Principle (OCP);
        }
    }

    // To solve this Problem we can use Interface Segregation Principle (ISP) and create two separate interfaces for saving invoice to database and saving invoice to file.

    public interface InvoiveDao { 
       public void saveInvoiceToDb(Invoice invoice);
    }

    class fileInvoiceDao : InvoiveDao
    {
        public void saveInvoiceToDb(Invoice invoice)
        {
            Console.WriteLine("Saving Invoice to File");
        }
    }

    class dbInvoiceDao : InvoiveDao
    {
        public void saveInvoiceToDb(Invoice invoice)
        {
            Console.WriteLine("Saving Invoice to Database");
        }
    }
    // here we have created two separate
    // classes for saving invoice to database and saving invoice to file.
    // Now we can use these classes without modifying the existing code.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Happy Learning!");
        }
    }
}